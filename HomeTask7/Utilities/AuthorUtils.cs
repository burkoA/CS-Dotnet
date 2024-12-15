using HomeTask7.Entities;

namespace HomeTask7.Utilities
{
    public static class AuthorUtils
    {
        public static HashSet<Author> ParseAuthors(string creatorField)
        {
            HashSet<Author> authors = new HashSet<Author>();

            if (string.IsNullOrWhiteSpace(creatorField))
                return authors;

            string[] authorChunks = creatorField.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            int index = 0;
            while (index < authorChunks.Length)
            {
                string lastName = authorChunks[index].Trim();
                index++;

                if (index >= authorChunks.Length)
                    break;

                string firstName = authorChunks[index].Trim();
                index++;

                DateTime? birthYear = null;
                if (index < authorChunks.Length && int.TryParse(authorChunks[index].TrimEnd('-').Trim(), out int year))
                {
                    birthYear = new DateTime(year, 1, 1);
                    index++;
                }

                while (index < authorChunks.Length && !char.IsLetter(authorChunks[index][0]))
                {
                    index++;
                }

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                    throw new ArgumentException($"Invalid author entry for '{lastName}'");

                authors.Add(new Author(firstName, lastName, birthYear));
            }

            return authors;
        }
    }
}
