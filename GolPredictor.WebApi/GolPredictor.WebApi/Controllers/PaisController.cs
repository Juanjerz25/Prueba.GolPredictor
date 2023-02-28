using GolPredictor.WebApi.Application.Contracts;
using GolPredictor.WebApi.DTO.Pais;
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
    public class PaisController : ControllerBase
    {
        #region Fields
        private readonly IPaisApplication _paisApplication;

        #endregion

        #region Builder

        public PaisController(IPaisApplication paisApplication)
        {
            _paisApplication = paisApplication;
        }


        #endregion

        #region Methods

        [HttpGet]
        [Route(nameof(PaisController.GetPaises))]
        public async Task<ResponseQuery<List<PaisDto>>> GetPaises()
        {
            return await Task.Run(() =>
            {
                return _paisApplication.GetPaises();
            });
        }

        #endregion
    }
}
