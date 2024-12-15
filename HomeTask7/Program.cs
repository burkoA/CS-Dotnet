using HomeTask7.Entities;
using HomeTask7.Entities.AbstractFactory;
using HomeTask7.Interfaces;
using HomeTask7.Repositories;

namespace HomeTask7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<Catalog> repositoryXML = new XMLRepository();
            IRepository<Catalog> repositoryJSON = new JSONRepository();

            string csvFilePath = "./Resources/books_info.csv";

            ILibraryFactory paperBookFactory = new PaperBookLibraryFactory();
            Library paperBookLibrary = paperBookFactory.CreateLibrary(csvFilePath);


            ILibraryFactory eBookFactory = new EBookLibraryFactory();
            Library eBookLibrary = eBookFactory.CreateLibrary(csvFilePath);



            repositoryXML.Save(paperBookLibrary.Catalog);

            Library libraryOne = new Library();
            libraryOne.Catalog = repositoryXML.Load();

            repositoryJSON.Save(eBookLibrary.Catalog);

            Library libraryTwo = new Library();
            libraryTwo.Catalog = repositoryJSON.Load();

        }
    }
}
