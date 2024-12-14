using HomeTask6.Entities;
using System.Xml.Serialization;

namespace HomeTask6.DALEntities
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

            Books = catalog._catalog.Select(c => (
                c.Key,
                new DALBook
                {
                    Title = c.Value.Title,
                    PublicationDate = c.Value.PublicationDate,
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
                var book = new Book(
                    dalBook.Title,
                    dalBook.PublicationDate,
                    dalBook.Authors?.Select(a => new Author(
                        a.FirstName,
                        a.LastName,
                        a.Birthday
                    )).ToHashSet() ?? new HashSet<Author>()
                );

                catalog._catalog[key] = book;
            }

            return catalog;
        }
    }
}
