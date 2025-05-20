using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMI.Shared.DTOs;

namespace Application.Interfaces
{
    public interface IPersonaService
    {
        Task<List<PersonaDTO>> GetAllPersonasAsync();          
        Task<PersonaDTO?> GetPersonaByIdAsync(int id);         
        Task<PersonaDTO> AddPersonaAsync(PersonaDTO persona);
        Task<PersonaDTO?> UpdatePersonaAsync(PersonaDTO persona);
        Task<bool> DeletePersonaAsync(int id);
    }
}
