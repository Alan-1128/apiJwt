using BackendApi.Models;
using System.Threading.Tasks;

namespace BackendApi.Repositories
{
    public interface IUserRepositorie
    {
        public Task<string> Register(User user, string password);
        public Task<string> Login(string userName, string password);
        public Task<bool> UserExiste(string username);
    }
}
