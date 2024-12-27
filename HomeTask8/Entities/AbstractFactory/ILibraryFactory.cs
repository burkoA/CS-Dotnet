using HomeTask8.Entities.BookEntities;

namespace HomeTask8.Entities.AbstractFactory
{
    public interface ILibraryFactory
    {
        Catalog CreateCatalog();
        List<string> CreatePressRelease();
    }
}
