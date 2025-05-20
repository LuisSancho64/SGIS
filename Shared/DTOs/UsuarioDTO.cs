namespace SMI.Shared.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public int IdUsuario { get; set; }
    public string? NombreUsuario { get; set; }
}
