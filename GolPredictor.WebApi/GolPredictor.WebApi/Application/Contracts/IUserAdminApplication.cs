using GolPredictor.WebApi.DTO.Response;
using GolPredictor.WebApi.DTO.UserAdmin;

namespace GolPredictor.WebApi.Application.Contracts
{
    public interface IUserAdminApplication
    {
        ResponseQuery<bool> LogIn(RequestLogInDto request);
    }
}
