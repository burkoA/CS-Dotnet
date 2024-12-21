using HomeTask7.Entities.BookEntities;

namespace HomeTask7.Entities.AbstractFactory
{
    public interface ILibraryFactory
    {
        Catalog CreateCatalog();
        List<string> CreatePressRelease();
    }
}
