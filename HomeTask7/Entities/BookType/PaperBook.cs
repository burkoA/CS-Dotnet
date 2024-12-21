using HomeTask7.Entities.BookEntities;

namespace HomeTask7.Entities.BookType
{
    public class PaperBook : Book
    {
        public DateTime? PublicationDate { get; set; }
        public List<string> IsbnList { get; set; } = new List<string>();
        public string Publisher { get; set; }

        public PaperBook(string title, HashSet<Author> authors, DateTime? publicationDate, List<string> isbnList, string publiser) 
            : base(title, authors)
        {
            PublicationDate = publicationDate;
            IsbnList = isbnList;
            Publisher = publiser;
        }
    }
}
