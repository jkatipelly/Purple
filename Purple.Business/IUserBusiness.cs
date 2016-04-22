using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purple.Entities;
namespace Purple.Business
{
    public interface IUserBusiness
    {
        User GetById(int userID);
        int Login(string username, string password);
        int RegisterUser(User user);
        bool UpdateUser(int userId,User user);
    }
}
