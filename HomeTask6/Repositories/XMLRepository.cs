using HomeTask6.DALEntities;
using HomeTask6.Interfaces;
using System.Xml.Serialization;

namespace HomeTask6.Repositories
{
    public class XMLRepository : IRepository<Catalog>
    {
        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "catalogBooks.xml");

        public void Save(Catalog catalog)
        {
            var dalCatalog = new DALCatalog(catalog);

            using FileStream catalogStream = new FileStream(filePath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(DALCatalog));
            serializer.Serialize(catalogStream, dalCatalog);
            catalogStream.Close();
        }

        public Catalog Load()
        {
            if(!File.Exists(filePath))
                throw new FileNotFoundException("The file was not found!");

            using FileStream catalogStream = new FileStream(filePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(DALCatalog));

            var dalCatalogs = (DALCatalog)serializer.Deserialize(catalogStream);

            return dalCatalogs.ToCatalog();
        }
    }
}
