namespace HomeTask5_2
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
                throw new ArgumentException("Title cannot be null!");
            }

            Title = title;
            PublicationDate = publicationDate;
            Authors = authors ?? new HashSet<string>();
        }
    }
}
