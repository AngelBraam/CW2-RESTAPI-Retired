using Microsoft.AspNetCore.Identity;

namespace CW2_RESTAPI.Entities.DataHandlers
{
    public class Admin
    {
        public Admin() { }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public readonly string PasswordCheck = "Admin123";
    }
}
