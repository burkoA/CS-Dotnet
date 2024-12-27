namespace HomeTask8.DALEntities
{
    public class DALBook
    {
        public string Title { get; set; }
        public HashSet<DALAuthor>? Authors { get; set; } = new HashSet<DALAuthor>();

        public DALBook() { }

    }
}
