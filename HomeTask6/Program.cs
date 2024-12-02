using HomeTask6.Entities;
using HomeTask6.Interfaces;
using HomeTask6.Repositories;

namespace HomeTask6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<Catalog> repositotyXML = new XMLRepository();
            IRepository<Catalog> reposityoryJSON = new JSONRepository();

            //Author create

            Author author1 = new Author("John Ronald Reuel", "Tolkien", new DateTime(1892, 1, 3));
            Author author2 = new Author("Nelle Harper", "Lee", new DateTime(1926, 4, 28));
            Author author3 = new Author("Roaldl", "Dahl", new DateTime(1916, 11, 13));
            Author author4 = new Author("Joanne", "Rowling", new DateTime(1965, 7, 31));
            Author author5 = new Author("Terry", "Pratchett", new DateTime(1948, 4, 28));

            //Book create

            Book book1 = new Book("The Lord of the Rings", new DateTime(1954, 7, 29), new HashSet<Author> { author1 });
            Book book2 = new Book("To Kill a Mockingbird", new DateTime(1960, 7, 11), new HashSet<Author> { author2 });
            Book book3 = new Book("Charlie and the Chocolate Factory", new DateTime(1964, 11, 13), new HashSet<Author> { author3 });
            Book book4 = new Book("Harry Potter and the Philosopher's Stone", new DateTime(1997, 6, 26), new HashSet<Author> { author4 });
            Book book5 = new Book("Good Omens", new DateTime(1990, 5, 1), new HashSet<Author> { author4, author5 });
            Book book6 = new Book("The Hobbit", new DateTime(1937, 9, 21), new HashSet<Author> { author1 });
            Book book7 = new Book("James and the Giant Peach", new DateTime(1961, 11, 17), new HashSet<Author> { author3 });

            //Add to catalog
            Catalog catalog1 = new Catalog();

            catalog1.AddBook("978-0-26-102386-1", book1); // The Lord of the Rings
            catalog1.AddBook("978-0-06-112008-4", book2); // To Kill a Mockingbird
            catalog1.AddBook("978-0-14-241031-8", book3); // Charlie and the Chocolate Factory
            catalog1.AddBook("978-0-74-326912-9", book4); // Harry Potter and the Philosopher's Stone
            catalog1.AddBook("978-0-57-044800-6", book5); // Good Omens
            catalog1.AddBook("978-0-21-103383-3", book6); // The Hobbit
            catalog1.AddBook("978-0-14-241036-3", book7); // James and the Giant Peach

            Book testBook = catalog1.GetBookByIsbn("978-0-57-044800-6");

            var test = catalog1.RetriveAuthorAndBook();

            repositotyXML.Save(catalog1);

            var catalog2 = repositotyXML.Load();

            Book book8 = new Book("Test", DateTime.Now, new HashSet<Author> { author1, author1 });

            catalog1.AddBook("978-0-14-241036-7", book8);

            repositotyXML.Save(catalog1);

            catalog2 = repositotyXML.Load();

            reposityoryJSON.Save(catalog2);

            Catalog catalog3 = reposityoryJSON.Load();
        }
    }
}
