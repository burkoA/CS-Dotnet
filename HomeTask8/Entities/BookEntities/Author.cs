namespace HomeTask8.Entities.BookEntities
{
    public class Author
    {
        private const int _nameMaxLength = 200;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }

        public Author(string firstName, string lastName, DateTime? birthday)
        {
            if (ValidationName(firstName) || ValidationName(lastName))
                throw new ArgumentException("Name cannot ba null or too long!");

            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        private bool ValidationName(string name)
        {
            if (name.Length > _nameMaxLength)
                return true;

            return false;
        }
    }
}
