namespace HomeTask5_2.Entities
{
    public class Book
    {
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public HashSet<string>? Authors { get; set; }

        public Book(string title, DateTime? publicationDate, HashSet<string>? authors)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title cannot be null or empty!");
            }

            Title = title;
            PublicationDate = publicationDate;
            Authors = authors ?? new HashSet<string>();
        }
    }
}