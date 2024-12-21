using System.Text;

namespace HomeTask7.Utilities
{
    public static class CSVParses
    {
        private const string csvFilePath = "./Resources/books_info.csv";

        public static List<string> ParseCsvLine(string line)
        {
            List<string> columns = new List<string>();
            StringBuilder currentColumn = new StringBuilder();
            bool insideQuotes = false;

            foreach (var ch in line)
            {
                if (ch == '"' && !insideQuotes)
                {
                    insideQuotes = true;
                }
                else if (ch == '"' && insideQuotes)
                {
                    insideQuotes = false;
                }
                else if (ch == ',' && !insideQuotes)
                {
                    columns.Add(currentColumn.ToString());
                    currentColumn.Clear();
                }
                else
                {
                    currentColumn.Append(ch);
                }
            }

            if (currentColumn.Length > 0)
            {
                columns.Add(currentColumn.ToString());
            }

            columns.RemoveRange(7, columns.Count - 7);

            return columns;
        }

        public static IEnumerable<string[]> ReadCsvLines()
        {
            if (!File.Exists(csvFilePath))
                throw new FileNotFoundException($"File not found at path: {csvFilePath}");

            var lines = File.ReadLines(csvFilePath).Skip(1);

            foreach (var line in lines)
            {
                yield return ParseCsvLine(line).ToArray();
            }
        }
    }
}
