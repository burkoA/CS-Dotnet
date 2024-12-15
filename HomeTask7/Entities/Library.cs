using HomeTask7.Entities.BookType;

namespace HomeTask7.Entities
{
    public class Library
    {
        public Catalog Catalog { get; set; }
        public List<string> PressReleaseItems { get; set; }

        public Library()
        {
            Catalog = new Catalog();
            PressReleaseItems = new List<string>();
        }

        public void AddBook(string key, Book book)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null or empty.");

            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");

            // Add book using the Catalog
            Catalog.AddBook(key, book);
        }

        public void AddPressReleaseItem(string item)
        {
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentException("Item cannot be null or empty.");

            PressReleaseItems.Add(item);
        }
    }
}
