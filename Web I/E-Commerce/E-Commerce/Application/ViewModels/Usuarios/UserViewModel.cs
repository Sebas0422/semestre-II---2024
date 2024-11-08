namespace E_Commerce.Application.ViewModels.Usuarios
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public RoleViewModel Role { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
