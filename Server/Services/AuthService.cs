using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Models;
using System.Threading.Tasks;

namespace SMI.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly SmiDbContext _context;

        public AuthService(SmiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> LoginAsync(LoginRequest loginRequest)
        {
            var personaConUsuario = await _context.Personas
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Correo == loginRequest.Correo);

            if (personaConUsuario?.Usuario == null)
                return false;

            if (personaConUsuario.Usuario.Clave != loginRequest.Clave)
                return false;

            if (!(personaConUsuario.Usuario.Activo ?? false))
                return false;

            return true;
        }
    }
}
