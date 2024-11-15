using HomeTask5_2.Entities;

namespace HomeTask5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> authors = new HashSet<string> { "Alpha", "Romeo" };
            HashSet<string> authors2 = new HashSet<string> { "Hfhff", "huidfuhsdfg" };

            Book book1 = new Book("gihujdsuh", DateTime.Now, authors);
            Book book2 = new Book("ASHIDUIAHSd", DateTime.Today, authors2);

            Catalog catalog1 = new Catalog();
            Catalog catalog2 = new Catalog();

            catalog1.AddBook("123-4-56-783902-3", book1);
            catalog1.AddBook("123-4-56-789012-4", book2);

            var catalog22 = catalog1.SetOfBookBySortedAlphabetically();

            var getBook = catalog1.GetBookByISBN("123-4-56-783902-3");
        }
    }
}