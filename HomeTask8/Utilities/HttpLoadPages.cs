using HomeTask8.Entities.BookEntities;
using HomeTask8.Entities.BookType;
using System.Text.RegularExpressions;

namespace HomeTask8.Utilities
{
    public static class HttpLoadPages
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static readonly Regex PagesRegex = new Regex(@"<span\s+itemprop=""numberOfPages"">(\d+)<\/span>", RegexOptions.IgnoreCase);

        public static async Task InitializePagesAsync(Catalog catalog)
        {
            var tasks = catalog.BooksCatalog.Values.OfType<EBook>().Select(book =>
            {
                return Task.Run(async () =>
                {
                    var url = $"https://archive.org/details/{book.IdOfUploadSource}";
                    book.Pages = await GetNumberOfPagesAsync(url);
                });
            }).ToArray();

            await Task.WhenAll(tasks);
        }

        public static async Task<int> GetNumberOfPagesAsync(string url)
        {
            try
            {
                var html = await HttpClient.GetStringAsync(url);

                var match = PagesRegex.Match(html);

                if (match.Success)
                {
                    return int.Parse(match.Groups[1].Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching the number of pages for URL {url}: {ex.Message}");
            }

            return 0;
        }
    }
}
