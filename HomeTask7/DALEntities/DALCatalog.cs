using HomeTask7.Entities.BookType;
using System.Xml.Serialization;
using HomeTask7.Entities.BookEntities;
using HomeTask7.Utilities;

namespace HomeTask7.DALEntities
{
    [XmlRoot("DALCatalog")]
    public class DALCatalog
    {
        [XmlElement("Book")]
        public List<(string Key, DALBook value)> Books { get; set; } = new List<(string Key, DALBook value)>();

        public DALCatalog(Catalog catalog)
        {
            if (catalog == null)
                throw new ArgumentNullException("Catalog cannot be null!");

            Books = catalog.BooksCatalog.Select(c => (
                c.Key,
                new DALBook
                {
                    Title = c.Value.Title,
                    Authors = c.Value.Authors?.Select(a => new DALAuthor
                    {
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Birthday = a.Birthday
                    }).ToHashSet()
                }
            )).ToList();
        }

        public DALCatalog() { }

        public Catalog ToCatalog()
        {
            Catalog catalog = new Catalog();

            foreach (var (key, dalBook) in Books)
            {
                Book book = null;

                if (KeyValidator.CheckForIsbn(key))
                {
                    book = new PaperBook(
                        dalBook.Title,
                        dalBook.Authors?.Select(a => new Author(
                            a.FirstName,
                            a.LastName,
                            a.Birthday
                        )).ToHashSet() ?? new HashSet<Author>(),
                        DateTime.Now,
                        new List<string>(),
                        "PublisherName"
                    );
                }
                else if (KeyValidator.CheckForLink(key))
                {
                    book = new EBook(
                        dalBook.Title,
                        dalBook.Authors?.Select(a => new Author(
                            a.FirstName,
                            a.LastName,
                            a.Birthday
                        )).ToHashSet() ?? new HashSet<Author>(),
                        "uploadSource",
                        new List<string>()
                    );
                }

                catalog.BooksCatalog[key] = book;
            }

            return catalog;
        }
    }
}
