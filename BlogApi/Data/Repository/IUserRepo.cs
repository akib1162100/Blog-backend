using BlogApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Data.Repository
{
    public interface IUserRepo
    {
        User Get(string uid);
        DbResponse Add(User user);
        DbResponse Update(string uid);
    }
}
