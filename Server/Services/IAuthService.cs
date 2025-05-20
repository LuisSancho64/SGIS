using Infrastructure.Models;
using System.Threading.Tasks;

namespace SMI.Server.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginRequest loginRequest);
    }
}
