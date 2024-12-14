using HomeTask6.Entities;
using HomeTask6.Interfaces;
using System.Text.Json;

namespace HomeTask6.Repositories
{
    public class JSONRepository : IRepository<Catalog>
    {
        private string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "BooksByAuthor");

        public void Save(Catalog catalog)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var booksByAuthors = catalog._catalog
                .SelectMany(entry => entry.Value.Authors.Select(author => new { Author = author, ISBN = entry.Key, Book = entry.Value }))
                .GroupBy(x => $"{x.Author.FirstName}_{x.Author.LastName}");

            foreach (var authorGroup in booksByAuthors)
            {
                string fileName = Path.Combine(directoryPath, $"{authorGroup.Key}.json");

                var data = authorGroup.Select(x => new { x.ISBN, x.Book }).ToList();

                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(fileName, JsonSerializer.Serialize(data, options));
            }
        }

        public Catalog Load()
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException("The directory for JSON files does not exist.");
            }

            Catalog catalog = new Catalog();
            var jsonFiles = Directory.GetFiles(directoryPath, "*.json");

            foreach (var file in jsonFiles)
            {
                var entries = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(File.ReadAllText(file))
                              ?? new List<Dictionary<string, JsonElement>>();

                foreach (var entry in entries)
                {
                    var isbnRaw = entry["ISBN"].GetString();
                    var bookNode = entry["Book"];

                    if (isbnRaw != null && bookNode.ValueKind == JsonValueKind.Object)
                    {
                        var book = new Book(
                            title: bookNode.GetProperty("Title").GetString(),
                            publicationDate: bookNode.TryGetProperty("PublicationDate", out var pubDate) && pubDate.GetDateTime() is DateTime validDate ? validDate : (DateTime?)null,
                            authors: bookNode.TryGetProperty("Authors", out var authorsArray) && authorsArray.ValueKind == JsonValueKind.Array
                                ? authorsArray.EnumerateArray().Select(authorNode => new Author(
                                    authorNode.GetProperty("FirstName").GetString(),
                                    authorNode.GetProperty("LastName").GetString(),
                                    authorNode.GetProperty("Birthday").GetDateTime()
                                )).ToHashSet()
                                : new HashSet<Author>()
                        );

                        string normalizedIsbn = Isbn.NormalizeISBN(isbnRaw);
                        if (!catalog._catalog.ContainsKey(normalizedIsbn))
                        {
                            catalog._catalog[normalizedIsbn] = book;
                        }
                    }
                }
            }

            return catalog;
        }
    }
}
