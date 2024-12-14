namespace HomeTask6.DALEntities
{
    public class DALBook
    {
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public HashSet<DALAuthor>? Authors { get; set; } = new HashSet<DALAuthor>();

        public DALBook() { }

    }
}
