using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MinerShop.Models;
using MinerShop.Models.Data;

namespace MinerShop.Services
{
    public class AccountServices : IAccountServices
    {
        private ShopDbContext db;

        public AccountServices(ShopDbContext db)
        {
            this.db = db;
        }

        //[ValidateAntiForgeryToken]
        public async Task<User> GetUser(LoginModel model)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
            return user;
        }
    }
}