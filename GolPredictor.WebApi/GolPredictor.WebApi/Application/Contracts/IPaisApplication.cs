using GolPredictor.WebApi.DTO.Pais;
using GolPredictor.WebApi.DTO.Partido;
using GolPredictor.WebApi.DTO.Response;
using GolPredictor.WebApi.DTO.UserAdmin;
using System.Collections.Generic;

namespace GolPredictor.WebApi.Application.Contracts
{
    public interface IPaisApplication
    {
        ResponseQuery<List<PaisDto>> GetPaises();
    }
}
