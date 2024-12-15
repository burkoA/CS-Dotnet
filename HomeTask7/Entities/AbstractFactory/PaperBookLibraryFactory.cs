using HomeTask7.Entities.BookType;
using HomeTask7.Utilities;

namespace HomeTask7.Entities.AbstractFactory
{
    public class PaperBookLibraryFactory : ILibraryFactory
    {
        public Library CreateLibrary(string csvFilePath)
        {
            Library library = new Library();

            foreach (var line in File.ReadLines(csvFilePath).Skip(1)) // Skip the header row
            {
                var columns = CSVParses.ParseCsvLine(line);

                if (string.IsNullOrWhiteSpace(columns[5]))
                    continue;

                var authors = AuthorUtils.ParseAuthors(columns[0]);

                // Extract other fields
                var publicationDate = DateTime.TryParse(columns[3].Trim(), out var date) ? date : (DateTime?)null;
                var publisher = columns[4].Trim().Trim('"'); // Remove quotes
                List<string> isbnList = new List<string>();

                foreach (var id in columns[5].Trim().Split(','))
                {
                    isbnList.Add(id.Trim());
                }

                string title = columns[6].Trim().Trim('"'); // Remove quotes

                var book = new PaperBook(title, authors, publicationDate, isbnList, publisher);

                if (isbnList.Count > 0)
                {
                    library.AddBook(isbnList[0].Replace("urn:isbn:", ""), book);
                }

                if (!library.PressReleaseItems.Contains(publisher))
                {
                    library.AddPressReleaseItem(publisher);
                }
            }

            return library;
        }
    }
}
