using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SMI.Shared.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using SMI.Client.Providers;
using System.Threading.Tasks;

namespace SMI.Client.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClientNoAuth; // Para login, sin token
        private readonly HttpClient _httpClientAuth;   // Para peticiones autenticadas
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(IHttpClientFactory httpClientFactory, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _httpClientNoAuth = httpClientFactory.CreateClient("NoAuthClient");
            _httpClientAuth = httpClientFactory.CreateClient("AuthClient");
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        public async Task<bool> LoginAsync(string correo, string clave)
        {
            var loginDto = new LoginRequestDTO { Correo = correo, Clave = clave };
            var response = await _httpClientNoAuth.PostAsJsonAsync("api/auth/login", loginDto);

            if (!response.IsSuccessStatusCode)
                return false;

            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponseDTO>();

            await _localStorage.SetItemAsync("authToken", loginResponse.Token);

            ((CustomAuthStateProvider)_authStateProvider).NotifyUserAuthentication(loginResponse.Token);

            // Actualizar token en HttpClient autenticado para futuras peticiones
            _httpClientAuth.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);

            return true;
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthStateProvider)_authStateProvider).NotifyUserLogout();
            _httpClientAuth.DefaultRequestHeaders.Authorization = null;
        }
    }
}
