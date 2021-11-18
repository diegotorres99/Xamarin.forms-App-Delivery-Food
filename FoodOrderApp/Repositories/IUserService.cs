using System;
using System.Threading.Tasks;

namespace FoodOrderApp.Repositories
{
    public interface IUserService
    {
        Task<bool> IsUserExists(string uname);
        Task<bool> RegisterUser(string uname, string passwd);
        Task<bool> LoginUser(string uname, string passwd);
    }
}
