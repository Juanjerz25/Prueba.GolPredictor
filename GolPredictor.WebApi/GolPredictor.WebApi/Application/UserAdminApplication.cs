using GolPredictor.WebApi.Application.Contracts;
using GolPredictor.WebApi.DataAccess.Repositories.Contracts;
using GolPredictor.WebApi.DTO.Response;
using GolPredictor.WebApi.DTO.UserAdmin;
using System;

namespace GolPredictor.WebApi.Application
{
    class UserAdminApplication: IUserAdminApplication
    {
        #region Fields
        private readonly IUserAdminRepository _userAdminRepository;
        #endregion

        #region Builders


        public UserAdminApplication(IUserAdminRepository userAdminRepository)
        {
            _userAdminRepository = userAdminRepository;
        }
        #endregion

        #region Methods

        public ResponseQuery<bool> LogIn(RequestLogInDto request)
        {
            ResponseQuery<bool> response = new ResponseQuery<bool>();
            try
            {
                var userAdmin = _userAdminRepository.Find(x => x.Nombre == request.Nombre && x.Contrasena == request.Contrasena);
                response.Successful = true;
                if (userAdmin == null)
                {
                    response.Message = "Usuario y/o contraseña invalido";
                    response.Successful = false;
                }
                
                return response;

            }
            catch (Exception ex)
            {
                response.Successful = false;
                response.Message = "Hubo un error al ejecutar la instancia";
                response.ErrorMessage = ex.Message;

                return response;
            }
        }
        #endregion
    }
}
