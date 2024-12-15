using HomeTask7.Entities.BookType;
using HomeTask7.Utilities;

namespace HomeTask7.Entities.AbstractFactory
{
    public class EBookLibraryFactory : ILibraryFactory
    {
        public Library CreateLibrary(string csvFilePath)
        {
            var library = new Library();

            foreach (var line in File.ReadLines(csvFilePath).Skip(1))
            {
                // Use CSVParses to split the line into columns
                var columns = CSVParses.ParseCsvLine(line);

                // Extract title from the 6th column
                var title = columns[6].Trim();

                // Use AuthorUtils to parse author information
                var authors = AuthorUtils.ParseAuthors(columns[0].Trim());

                // Extract identifier from the 2nd column
                var identifier = columns[2].Trim();

                // Extract formats from the 1st column (comma-separated formats)
                var formats = new List<string>(columns[1].Trim().Split(','));

                // Create an eBook instance
                var book = new EBook(title, authors, identifier, formats);

                // Add the book to the library using the identifier as the key
                if (!library.Catalog.BooksCatalog.ContainsKey(identifier))
                {
                    library.AddBook(identifier, book);

                    // Add new formats to press release items if not already present
                    foreach (var format in formats)
                    {
                        if (!library.PressReleaseItems.Contains(format))
                        {
                            library.AddPressReleaseItem(format);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Skipping book with identifier '{identifier}' because it already exists.");
                }
            }

            return library;
        }
    }
}
