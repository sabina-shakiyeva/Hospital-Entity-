namespace ConsoleApp6.Entities
{
    public class User
    {
        public User(string name, string surname, string email, string number)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Number = number;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
    }
}
