using API_UBAM.DTO;

namespace API_UBAM.Interfaces;

public interface IAuthService
{
    Task<UserDTO> ValidateUser(LoginSolicitarDto loginSolicitar);
    Task SignOut();
}