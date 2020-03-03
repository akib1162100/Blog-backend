using BlogApi.Data;
using BlogApi.Data.Models;
namespace BlogApi.Services
{
    public interface IAuthService
    {
        DbResponse Register(UserRegistrationDTO userRegistrationDTO);
        DbResponse Login(UserLoginDTO userLoginDTO);
    }
}