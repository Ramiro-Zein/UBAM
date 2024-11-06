using API_UBAM.DTO;

namespace API_UBAM.Interfaces;

public interface IAuthService
{
    Task<bool> ValidarUsuario(string nombreUsuario, string clave);
    Task CerrarSesion();
}
