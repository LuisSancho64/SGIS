using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Models;
using SMI.Shared.DTOs;  // usar DTOs compartidos
using System.Threading.Tasks;
using Application.Interfaces;


namespace SMI.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly SmiDbContext _context;

        public AuthService(SmiDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioDTO?> LoginAsync(LoginRequestDTO loginRequest)
        {
            var personaConUsuario = await _context.Personas
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Correo == loginRequest.Correo);

            if (personaConUsuario?.Usuario == null)
                return null;

            if (personaConUsuario.Usuario.Clave != loginRequest.Clave)
                return null;

            if (!(personaConUsuario.Usuario.Activo ?? false))
                return null;

            return new UsuarioDTO
            {
                IdUsuario = personaConUsuario.Usuario.Id,
                NombreUsuario = personaConUsuario.nombre,
                Correo = personaConUsuario.Correo
            };
        }
    }
}
