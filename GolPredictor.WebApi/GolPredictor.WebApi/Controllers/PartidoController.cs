using GolPredictor.WebApi.Application.Contracts;
using GolPredictor.WebApi.DTO.Partido;
using GolPredictor.WebApi.DTO.Response;
using GolPredictor.WebApi.DTO.UserAdmin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GolPredictor.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class PartidoController : ControllerBase
    {
        #region Fields
        private readonly IPartidoApplication _partidoApplication;

        #endregion

        #region Builder

        public PartidoController(IPartidoApplication partidoApplication)
        {
            _partidoApplication = partidoApplication;
        }


        #endregion

        #region Methods

        [HttpPost]
        [Route(nameof(PartidoController.ManagePartido))]
        public async Task<ResponseQuery<bool>> ManagePartido(PartidoDto request)
        {
            return await Task.Run(() =>
            {
                return _partidoApplication.ManagePartido(request);
            });
        }

        [HttpGet]
        [Route(nameof(PartidoController.GetPartidos))]
        public async Task<ResponseQuery<List<PartidoDto>>> GetPartidos()
        {
            return await Task.Run(() =>
            {
                return _partidoApplication.GetPartidos();
            });
        }

        #endregion
    }
}
