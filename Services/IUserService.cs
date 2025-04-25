using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public interface IUserService
    {
        string Authenticate(string username, string password);
    }
}
