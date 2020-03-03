using BlogApi.Data.Models;

namespace BlogApi.Data.Repository
{
    public interface IAuthRepository
    {
        DbResponse Register(User user);
        User Login(string userId);
        bool UserExists(UserRegistrationDTO userRegistrationDTO);
    }
}