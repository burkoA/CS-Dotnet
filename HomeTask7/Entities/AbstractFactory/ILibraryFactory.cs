namespace HomeTask7.Entities.AbstractFactory
{
    public interface ILibraryFactory
    {
        Library CreateLibrary(string csvFilePath);
    }
}
