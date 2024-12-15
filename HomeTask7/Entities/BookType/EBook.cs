namespace HomeTask7.Entities.BookType
{
    public class EBook : Book
    {
        public string IdOfUploadSource { get; set; }
        public List<string> AvailableFormat { get; set; } = new List<string>();

        public EBook(string title, HashSet<Author> authors, 
                                        string uploadSource, List<string> availableFormat) :
            base(title, authors)
        {
            IdOfUploadSource = uploadSource;
            AvailableFormat = availableFormat ?? new List<string>();
        }
    }
}
