using GolPredictor.WebApi.DTO.Partido;
using GolPredictor.WebApi.DTO.Response;
using GolPredictor.WebApi.DTO.UserAdmin;
using System.Collections.Generic;

namespace GolPredictor.WebApi.Application.Contracts
{
    public interface IPartidoApplication
    {
        ResponseQuery<List<PartidoDto>> GetPartidos();
        ResponseQuery<bool> ManagePartido(PartidoDto request);
    }
}
