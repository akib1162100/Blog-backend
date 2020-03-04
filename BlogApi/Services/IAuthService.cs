using BlogApi.Data;
using BlogApi.Data.Models;
namespace BlogApi.Services
{
    public interface IAuthService
    {
        DbResponse Register(UserRegistrationDTO userRegistrationDTO);
        (UserDTO userDTO, DbResponse response) Login(UserLoginDTO userLoginDTO);
    }
}