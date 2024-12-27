using HomeTask8.Entities.BookEntities;

namespace HomeTask8.Entities.BookType
{
    public class EBook : Book
    {
        public string IdOfUploadSource { get; set; }
        public List<string> AvailableFormat { get; set; } = new List<string>();
        public int Pages { get; set; }

        public EBook(string title, HashSet<Author> authors, 
                                        string uploadSource, List<string> availableFormat, int pages) :
            base(title, authors)
        {
            IdOfUploadSource = uploadSource;
            AvailableFormat = availableFormat ?? new List<string>();
            Pages = pages;
        }
    }
}
