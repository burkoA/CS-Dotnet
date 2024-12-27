using HomeTask8.Entities.BookEntities;
using HomeTask8.Entities.BookType;
using HomeTask8.Utilities;

namespace HomeTask8.Entities.AbstractFactory
{
    public class EBookLibraryFactory : ILibraryFactory
    {
        public Catalog CreateCatalog()
        {
            var catalog = new Catalog();

            foreach (var columns in CSVParses.ReadCsvLines())
            {
                var title = columns[6].Trim();
                var authors = AuthorUtils.ParseAuthors(columns[0].Trim());
                var identifier = columns[2].Trim();
                var formats = new List<string>(columns[1].Trim().Split(','));
                int pages = 0;

                var book = new EBook(title, authors, identifier, formats, pages);

                if (!catalog.BooksCatalog.ContainsKey(identifier))
                {
                    catalog.AddBook(identifier, book);
                }
            }

            HttpLoadPages.InitializePagesAsync(catalog).Wait();

            return catalog;
        }

        public List<string> CreatePressRelease()
        {
            var pressReleaseItems = new HashSet<string>();

            foreach (var columns in CSVParses.ReadCsvLines())
            {
                var formats = columns[1].Trim().Split(',');

                foreach (var format in formats)
                {
                    pressReleaseItems.Add(format.Trim());
                }
            }

            return pressReleaseItems.ToList();
        }
    }
}
