using HomeTask6.Entities;
using HomeTask6.Interfaces;
using HomeTask6.Repositories;
using System.Xml.Serialization;

namespace HomeTask6
{
    public class Catalog 
    {
        public Dictionary<string, Book> _catalog { get; }

        private IRepository<Catalog> repositotyXML = new XMLRepository();
        private IRepository<Catalog> reposityoryJSON = new JSONRepository();

        public Catalog() 
        {
             _catalog = new Dictionary<string, Book>();
        }

        public Book GetBookByIsbn(string isbn)
        {
            string normaliIsbn = Isbn.NormalizeISBN(isbn);

            return _catalog.TryGetValue(normaliIsbn, out Book book) ? book : null;
        }

        public void AddBook(string isbn, Book book)
        {
            if (book == null)
                throw new Exception("Book cannot be null!");

            if (!Isbn.IsValid(isbn))
                throw new ArgumentException("Invalid isbn format!");

            string normalIsbn = Isbn.NormalizeISBN(isbn);

            if (_catalog.ContainsKey(normalIsbn))
                throw new ArgumentException("This isbn already in use!");

            _catalog[normalIsbn] = book;
        }

        public IEnumerable<string> SetOfBookBySortedAlphabetically() =>
            _catalog.OrderBy(b => b.Value.Title).Select(t => t.Value.Title);


        public IEnumerable<Book> RetriveBookByAuthorAndSorted(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author cannot be null");


            return _catalog
                .Where(b => b.Value.Authors.Any(a => $"{a.FirstName} {a.LastName}".Contains(author)))
                .Select(b => b.Value)
                .OrderBy(p => p.PublicationDate);
        }

        public List<(string, int)> RetriveAuthorAndBook() =>
            _catalog.SelectMany(book => book.Value.Authors)
                .GroupBy(author => $"{author.FirstName} {author.LastName}")
                .Select(g => (g.Key, g.Count()))
                .ToList();

        public void SaveCatalog() =>
            repositotyXML.Save(this);


        public Catalog LoadCatalog() => 
            repositotyXML.Load();

        public void SaveBookByAuthor() =>
            reposityoryJSON.Save(this);
        

        public Catalog LoadBookByAuthor() =>
            reposityoryJSON.Load();
    }
}
