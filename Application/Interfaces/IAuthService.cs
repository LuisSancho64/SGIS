using SMI.Shared.DTOs;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<UsuarioDTO?> LoginAsync(LoginRequestDTO loginRequest);
    }
}
