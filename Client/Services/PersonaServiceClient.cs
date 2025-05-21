using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using SMI.Client.Models;

public class PersonaServiceClient
{
    private readonly HttpClient _httpClient;

    public PersonaServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Obtener todas las personas
    public async Task<List<PersonaDto>> GetAllPersonas()
    {
        return await _httpClient.GetFromJsonAsync<List<PersonaDto>>("api/persona");
    }

    // Obtener una persona por ID
    public async Task<PersonaDto> GetPersonaById(int id)
    {
        return await _httpClient.GetFromJsonAsync<PersonaDto>($"api/persona/{id}");
    }

    // Agregar nueva persona
    public async Task<bool> AddPersona(PersonaDto persona)
    {
        var response = await _httpClient.PostAsJsonAsync("api/persona", persona);
        return response.IsSuccessStatusCode;
    }

    // Editar persona existente
    public async Task<bool> UpdatePersona(int id, PersonaDto persona)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/persona/{id}", persona);
        return response.IsSuccessStatusCode;
    }

    // Eliminar persona
    public async Task<bool> DeletePersona(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/persona/{id}");
        return response.IsSuccessStatusCode;
    }

    // Buscar personas por campo y valor (asumiendo un endpoint de búsqueda)
    public async Task<List<PersonaDto>> BuscarPersonas(string campo, string valor)
    {
        return await _httpClient.GetFromJsonAsync<List<PersonaDto>>($"api/persona/buscar?campo={campo}&valor={valor}");
    }
}
