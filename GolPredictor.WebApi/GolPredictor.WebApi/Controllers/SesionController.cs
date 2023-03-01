using GolPredictor.WebApi.Application.Contracts;
using GolPredictor.WebApi.DTO.Partido;
using GolPredictor.WebApi.DTO.Response;
using GolPredictor.WebApi.DTO.Sesion;
using GolPredictor.WebApi.DTO.UserAdmin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GolPredictor.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class SesionController : ControllerBase
    {
        #region Fields
        private readonly ISesionApplication _sesionApplication;

        #endregion

        #region Builder

        public SesionController(ISesionApplication sesionApplication)
        {
            _sesionApplication = sesionApplication;
        }


        #endregion

        #region Methods

        [HttpPost]
        [Route(nameof(SesionController.ManageSesion))]
        public async Task<ResponseQuery<int>> ManageSesion(SesionDto request)
        {
            return await Task.Run(() =>
            {
                return _sesionApplication.ManageSesion(request);
            });
        }

        [HttpGet]
        [Route(nameof(SesionController.GetSesiones))]
        public async Task<ResponseQuery<List<SesionDto>>> GetSesiones()
        {
            return await Task.Run(() =>
            {
                return _sesionApplication.GetSesiones();
            });
        }

        #endregion
    }
}
