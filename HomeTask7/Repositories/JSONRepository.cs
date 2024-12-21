using HomeTask7.Entities.BookType;
using HomeTask7.Interfaces;
using System.Text.Json;
using HomeTask7.Entities.BookEntities;
using HomeTask7.Utilities;

namespace HomeTask7.Repositories
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

            var booksByAuthors = catalog.BooksCatalog
                .SelectMany(entry => entry.Value.Authors.Select(author => new { Author = author, ISBN = entry.Key, Book = entry.Value }))
                .GroupBy(x => $"{x.Author.FirstName}_{x.Author.LastName}");

            foreach (var authorGroup in booksByAuthors)
            {
                string fileName = Path.Combine(directoryPath, $"{authorGroup.Key}.json");

                var data = authorGroup.Select(x => new
                {
                    x.ISBN,
                    x.Book.Title,
                    Authors = x.Book.Authors.Select(author => new
                    {
                        author.FirstName,
                        author.LastName,
                        author.Birthday
                    }).ToList()
                }).ToList();

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
                    var isbnRaw = entry.ContainsKey("ISBN") ? entry["ISBN"].GetString() : null;
                    var title = entry.ContainsKey("Title") ? entry["Title"].GetString() : null;

                    if (isbnRaw == null || title == null) continue;

                    var authorsArray = entry.ContainsKey("Authors") && entry["Authors"].ValueKind == JsonValueKind.Array
                        ? entry["Authors"].EnumerateArray()
                        : Enumerable.Empty<JsonElement>();

                    var authors = authorsArray.Select(authorNode =>
                    {
                        string firstName = authorNode.GetProperty("FirstName").GetString();
                        string lastName = authorNode.GetProperty("LastName").GetString();
                        DateTime? birthday = null;

                        if (authorNode.TryGetProperty("Birthday", out var birthdayElement))
                        {
                            if (birthdayElement.ValueKind == JsonValueKind.Null)
                            {
                                birthday = null;
                            }
                            else if (birthdayElement.ValueKind == JsonValueKind.String && DateTime.TryParse(birthdayElement.GetString(), out var parsedDate))
                            {
                                birthday = parsedDate;
                            }
                        }

                        return new Author(firstName, lastName, birthday);
                    }).ToHashSet();

                    Book book;

                    if (!KeyValidator.CheckForIsbn(isbnRaw))
                    {
                        book = new EBook(title, authors, "UploadSourcePlaceholder", new List<string>());
                    }
                    else
                    {
                        var publicationDate = entry.ContainsKey("PublicationDate") && entry["PublicationDate"].ValueKind == JsonValueKind.String
                            ? DateTime.TryParse(entry["PublicationDate"].GetString(), out var pubDate) ? pubDate : (DateTime?)null
                            : (DateTime?)null;

                        var publisher = entry.ContainsKey("Publisher") ? entry["Publisher"].GetString() : "PublisherUnknown";
                        var isbnList = entry.ContainsKey("IsbnList") ? entry["IsbnList"].EnumerateArray().Select(isbnNode => isbnNode.GetString()).ToList() : new List<string>();

                        book = new PaperBook(title, authors, publicationDate, isbnList, publisher);
                    }

                    if (!catalog.BooksCatalog.ContainsKey(isbnRaw))
                    {
                        catalog.BooksCatalog[isbnRaw] = book;
                    }
                }
            }

            return catalog;
        }

    }
}
