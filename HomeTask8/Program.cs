using HomeTask8.Entities.AbstractFactory;
using HomeTask8.Entities.BookEntities;
using HomeTask8.Entities;
using HomeTask8.Interfaces;
using HomeTask8.Repositories;

namespace HomeTask8
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRepository<Catalog> repositoryXML = new XMLRepository();
            IRepository<Catalog> repositoryJSON = new JSONRepository();

            Library libraryTwo = new Library();
            Library libraryOne = new Library();

            // Paper Library

            //ILibraryFactory paperBookFactory = new PaperBookLibraryFactory();
            //Library paperLibrary = new Library();

            //paperLibrary.Catalog = paperBookFactory.CreateCatalog();
            //paperLibrary.PressReleaseItems = paperBookFactory.CreatePressRelease();

            //repositoryXML.Save(paperLibrary.Catalog);
            //libraryOne.Catalog = repositoryXML.Load();

            //repositoryJSON.Save(paperLibrary.Catalog);
            //libraryTwo.Catalog = repositoryJSON.Load();

            //Electronic Library

            ILibraryFactory eBookFactory = new EBookLibraryFactory();
            Library eBookLibrary = new Library();

            eBookLibrary.Catalog = eBookFactory.CreateCatalog();
            eBookLibrary.PressReleaseItems = eBookFactory.CreatePressRelease();

            // Load and Save

            //repositoryXML.Save(eBookLibrary.Catalog);
            //libraryOne.Catalog = repositoryXML.Load();

            //repositoryJSON.Save(eBookLibrary.Catalog);
            //libraryTwo.Catalog = repositoryJSON.Load();

        }
    }
}
