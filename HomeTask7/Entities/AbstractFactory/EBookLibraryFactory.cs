using HomeTask7.Entities.BookEntities;
using HomeTask7.Entities.BookType;
using HomeTask7.Utilities;

namespace HomeTask7.Entities.AbstractFactory
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

                var book = new EBook(title, authors, identifier, formats);

                if (!catalog.BooksCatalog.ContainsKey(identifier))
                {
                    catalog.AddBook(identifier, book);
                }
                else
                {
                    Console.WriteLine($"Skipping book with identifier '{identifier}' because it already exists.");
                }
            }

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
