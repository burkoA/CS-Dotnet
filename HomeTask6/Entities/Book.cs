namespace HomeTask6.Entities
{
    public class Book
    {
        public string Title { get; }
        public DateTime? PublicationDate { get; }
        public HashSet<Author>? Authors { get; }

        public Book(string title, DateTime? publicationDate, HashSet<Author> authors)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("Title cannot be null or empty");

            Title = title;
            PublicationDate = publicationDate;
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
