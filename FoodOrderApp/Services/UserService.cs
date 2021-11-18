using System;
using System.Threading.Tasks;
using Firebase.Database;
using FoodOrderApp.Model;
using System.Linq;
using Firebase.Database.Query;
using FoodOrderApp.Repositories;
using Xamarin.Forms;
using FoodOrderApp.Services;

[assembly:Dependency(typeof(UserService))]
namespace FoodOrderApp.Services
{
    public class UserService : IUserService
    {
        FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient("https://foodorderingapp-f8cdb.firebaseio.com/");
        }

        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname).FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> RegisterUser(string uname, string passwd)
        {
            if( await IsUserExists(uname) == false)
            {
                await client.Child("Users")
                    .PostAsync(new User()
                    {
                        Username = uname,
                        Password = passwd
                    });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUser(string uname, string passwd)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname)
                .Where(u => u.Object.Password == passwd).FirstOrDefault();

            return (user != null);
        }
    }
}
