namespace HomeTask6.Entities
{
    public class Author
    {
        private const int _fullNameMaxLength = 200;

        public string FirstName { get; }
        public string LastName { get; }
        public DateTime Birthday { get; }

        public Author(string firstName, string lastName, DateTime birthday)
        {
            if (firstName.Length > _fullNameMaxLength || lastName.Length > _fullNameMaxLength)
                throw new ArgumentException("First name or last name are too long!");

            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public Author() { }
    }
}
