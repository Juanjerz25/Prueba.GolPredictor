using AutoMapper;
using GolPredictor.WebApi.Application.Contracts;
using GolPredictor.WebApi.DataAccess.Entities;
using GolPredictor.WebApi.DataAccess.Repositories.Contracts;
using GolPredictor.WebApi.DTO.Partido;
using GolPredictor.WebApi.DTO.Response;
using GolPredictor.WebApi.DTO.Sesion;
using GolPredictor.WebApi.DTO.UserAdmin;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GolPredictor.WebApi.Application
{
    class SesionApplication : ISesionApplication
    {
        #region Fields
        private readonly ISesionRepository _sesionRepository;
        private readonly IMapper mapper;
        #endregion

        #region Builders


        public SesionApplication(IMapper mapper, ISesionRepository sesionRepository)
        {
            this.mapper = mapper;
            _sesionRepository = sesionRepository;
        }
        #endregion

        #region Methods

        public ResponseQuery<bool> ManageSesion(SesionDto request)
        {
            ResponseQuery<bool> response = new ResponseQuery<bool>();
            try
            {               
                var sesion = mapper.Map<Sesion>(request);

                if(sesion.Id == 0)
                {
                    sesion.EntryCode = Guid.NewGuid().ToString().Substring(0,5);
                    _sesionRepository.Insert(sesion);
                }                    
                else
                    _sesionRepository.Update(sesion);

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);
                
            }
            return response;
        }
        public ResponseQuery<List<SesionDto>> GetSesiones()
        {
            ResponseQuery<List<SesionDto>> response = new ResponseQuery<List<SesionDto>>();
            try
            {
                var sesionList = _sesionRepository.List(x=> x.Status.HasValue && x.Status == true);


                var sesionDtoList = mapper.Map<List<SesionDto>>(sesionList);
                
                response.Result = sesionDtoList.OrderBy(x=> x.Nombre).ToList();

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }

        #endregion

        #region PrivateMethods

        #endregion
    }


}
