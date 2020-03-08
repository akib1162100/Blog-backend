using BlogApi.Data;
using BlogApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Services
{
    public interface IUserService
    {
        DbResponse Registration(UserRegisterDTO registerDTO);
        DbResponse Login(UserLoginDTO loginDTO);
    }
}
