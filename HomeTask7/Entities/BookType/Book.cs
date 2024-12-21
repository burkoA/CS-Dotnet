using HomeTask7.Entities.BookEntities;

namespace HomeTask7.Entities.BookType
{
    public abstract class Book
    {
        public string Title { get; set; }
        public HashSet<Author> Authors { get; set; }

        public Book(string title, HashSet<Author> authors)
        {
            Title = title;
            Authors = authors ?? new HashSet<Author>();
        }

        public void AddAuthorToList(Author author)
        {
            if (author is null)
                throw new Exception("Author cannot be null!");

            Authors.Add(author);
        }
    }
}
