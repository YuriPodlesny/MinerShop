using System.Threading.Tasks;

namespace MinerShop.Models
{
    public interface IAccountServices
    {
        public Task<User> GetUser(LoginModel model);
    }
}