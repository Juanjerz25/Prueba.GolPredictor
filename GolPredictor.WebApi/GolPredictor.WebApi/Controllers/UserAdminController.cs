using GolPredictor.WebApi.Application.Contracts;
using GolPredictor.WebApi.DTO.Response;
using GolPredictor.WebApi.DTO.UserAdmin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GolPredictor.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class UserAdminController : ControllerBase
    {
        #region Fields
        private readonly IUserAdminApplication _userAdminApplication;

        #endregion

        #region Builder


        #endregion

        #region Methods

        public UserAdminController(IUserAdminApplication userAdminApplication)
        {
            _userAdminApplication = userAdminApplication;
        }

        #endregion


        #region Methods

        [HttpPost]
        [Route(nameof(UserAdminController.LogIn))]
        public async Task<ResponseQuery<bool>> LogIn(RequestLogInDto request)
        {
            return await Task.Run(() =>
            {
                return _userAdminApplication.LogIn(request);
            });
        }

        #endregion
    }
}
