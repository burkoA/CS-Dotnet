namespace HomeTask6.Entities
{
    public class Author
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime Birthday { get; }

        public Author(string firstName, string lastName, DateTime birthday)
        {
            if (firstName.Length > 200 || lastName.Length > 200)
                throw new ArgumentException("First name or last name are too long!");

            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public Author() { }
    }
}
