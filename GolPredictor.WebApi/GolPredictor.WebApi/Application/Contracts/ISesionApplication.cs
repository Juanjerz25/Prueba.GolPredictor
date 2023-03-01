using GolPredictor.WebApi.DTO.Partido;
using GolPredictor.WebApi.DTO.Response;
using GolPredictor.WebApi.DTO.Sesion;
using GolPredictor.WebApi.DTO.UserAdmin;
using System.Collections.Generic;

namespace GolPredictor.WebApi.Application.Contracts
{
    public interface ISesionApplication
    {
        ResponseQuery<List<SesionDto>> GetSesiones();
        ResponseQuery<int> ManageSesion(SesionDto request);
    }
}
