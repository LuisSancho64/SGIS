using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using SMI.Shared.DTOs;

namespace SMI.Client.Pages
{
    public partial class Login
    {
        // Inyección de dependencias
        [Inject] private HttpClient Http { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private ILocalStorageService LocalStorage { get; set; }

        // Estado del formulario
        private LoginRequestDTO loginRequest = new();
        private string errorMessage;
        private string passwordInputType = "password";
        private bool showCorreoError = false;
        private bool showClaveError = false;

        // Método de login
        private async Task IniciarSesion()
        {
            showCorreoError = string.IsNullOrWhiteSpace(loginRequest.Correo);
            showClaveError = string.IsNullOrWhiteSpace(loginRequest.Clave);

            if (showCorreoError || showClaveError)
            {
                errorMessage = string.Empty;
                return;
            }

            try
            {
                var response = await Http.PostAsJsonAsync("api/auth/login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    var usuario = await response.Content
                                              .ReadFromJsonAsync<LoginResponseDTO>();

                    if (usuario != null)
                    {
                        await LocalStorage.SetItemAsync("usuarioNombre", usuario.NombreCompleto);
                    }

                    Navigation.NavigateTo("/home");
                }
                else
                {
                    errorMessage = "Correo o clave inválidos, o usuario inactivo.";
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Error al intentar iniciar sesión: " + ex.Message;
            }
        }

        // Toggle visibilidad de la contraseña
        private void TogglePasswordVisibility()
        {
            passwordInputType = passwordInputType == "password" ? "text" : "password";
        }
    }
}
