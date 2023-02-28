using GolPredictor.WebApi.DTO.Partido;
using GolPredictor.WebApi.DTO.Response;
using GolPredictor.WebApi.DTO.UserAdmin;

namespace GolPredictor.WebApi.Application.Contracts
{
    public interface IPartidoApplication
    {
        ResponseQuery<bool> ManagePartido(PartidoDto request);
    }
}
