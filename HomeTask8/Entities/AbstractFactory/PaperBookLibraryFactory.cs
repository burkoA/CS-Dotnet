using HomeTask8.Entities.BookEntities;
using HomeTask8.Entities.BookType;
using HomeTask8.Utilities;

namespace HomeTask8.Entities.AbstractFactory
{
    public class PaperBookLibraryFactory : ILibraryFactory
    { 
        public List<string> CreatePressRelease()
        {
            var publishers = new HashSet<string>();

            foreach (var columns in CSVParses.ReadCsvLines())
            {
                if (string.IsNullOrWhiteSpace(columns[5]))
                    continue;

                var publisher = columns[4].Trim().Trim('"');

                if (!string.IsNullOrEmpty(publisher))
                {
                    publishers.Add(publisher);
                }
            }

            return publishers.ToList();
        }

        public Catalog CreateCatalog()
        {
            Catalog catalog = new Catalog();

            foreach (var columns in CSVParses.ReadCsvLines())
            {
                if (string.IsNullOrWhiteSpace(columns[5]))
                    continue;

                var authors = AuthorUtils.ParseAuthors(columns[0]);

                var publicationDate = DateTime.TryParse(columns[3].Trim(), out var date) ? date : (DateTime?)null;
                var publisher = columns[4].Trim().Trim('"');
                List<string> isbnList = columns[5].Trim().Split(',').Select(id => id.Trim()).ToList();

                string title = columns[6].Trim().Trim('"');

                var book = new PaperBook(title, authors, publicationDate, isbnList, publisher);

                if (isbnList.Count > 0)
                {
                    string primaryIsbn = isbnList[0].Replace("urn:isbn:", "");
                    catalog.AddBook(primaryIsbn, book);
                }
            }

            return catalog;
        }
    }
}
