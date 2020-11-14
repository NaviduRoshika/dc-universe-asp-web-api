using System.Threading.Tasks;
using alone_mysql_dc_comics.Models;

namespace alone_mysql_dc_comics.Authentication
{
    public interface IAuthRepository
    {
         Task<ServiceResponse<int>> Register(User user,string password);
         Task<ServiceResponse<string>> Login(string username,string password);
         Task<bool> UserExists(string username);
    }
}