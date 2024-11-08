namespace E_Commerce.Domain.Usuarios
{
    public class User
    {
        public Guid Id { get; set; }
        public Role Role { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(Guid id, Role role, string fullName, string email, string password)
        {
            Id = id;
            Role = role;
            FullName = fullName;
            Email = email;
            Password = password;
        }

        public User(Role role, string fullName, string email, string password)
        : this(Guid.Empty, role, fullName, email, password)
        { }

        public User()
        {
            Id = Guid.Empty;
            Role = new Role();
            FullName = "";
            Email = "";
            Password = "";
        }
    }
}
