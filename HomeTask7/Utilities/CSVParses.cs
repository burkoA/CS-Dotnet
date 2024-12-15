using System.Text;

namespace HomeTask7.Utilities
{
    public static class CSVParses
    {
        public static List<string> ParseCsvLine(string line)
        {
            List<string> columns = new List<string>();
            StringBuilder currentColumn = new System.Text.StringBuilder();
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
    }
}
