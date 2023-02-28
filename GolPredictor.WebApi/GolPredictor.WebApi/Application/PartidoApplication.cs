using AutoMapper;
using GolPredictor.WebApi.Application.Contracts;
using GolPredictor.WebApi.DataAccess.Entities;
using GolPredictor.WebApi.DataAccess.Repositories.Contracts;
using GolPredictor.WebApi.DTO.Partido;
using GolPredictor.WebApi.DTO.Response;
using GolPredictor.WebApi.DTO.UserAdmin;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GolPredictor.WebApi.Application
{
    class PartidoApplication : IPartidoApplication
    {
        #region Fields
        private readonly IPartidoRepository _partidoRepository;
        private readonly IMapper mapper;
        #endregion

        #region Builders


        public PartidoApplication(IPartidoRepository PartidoRepository, IMapper mapper)
        {
            _partidoRepository = PartidoRepository;
            this.mapper = mapper;
        }
        #endregion

        #region Methods

        public ResponseQuery<bool> ManagePartido(PartidoDto request)
        {
            ResponseQuery<bool> response = new ResponseQuery<bool>();
            try
            {
                

                var partido = mapper.Map<PartidoDto>(request);
                var validationMessage = ValidateData(partido);
                if (!string.IsNullOrEmpty(validationMessage))
                {
                    response.ResponseMessage(validationMessage, false);
                    return response;
                }

                if(partido.Id ==0)
                    _partidoRepository.Insert(partido);
                else
                    _partidoRepository.Update(partido);

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);
                
            }
            return response;
        }

        public ResponseQuery<List<PartidoDto>> GetPartidos()
        {
            ResponseQuery<List<PartidoDto>> response = new ResponseQuery<List<PartidoDto>>();
            try
            {
                var partidoList = _partidoRepository.List(x=> x.FechaInicio.Value.Date == DateTime.Today.Date);


                var partidoDtoList = mapper.Map<List<PartidoDto>>(partidoList);
                
                response.Result = partidoDtoList;

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);

            }
            return response;
        }

        #endregion

        #region PrivateMethods
        /// <summary>
        /// Validación de data ingresada
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        private string ValidateData(PartidoDto partido)
        {
            //fecha actual
            if (partido.FechaInicio.Value.Date != DateTime.Today.Date)            
                return "El partido ingresado no es de la fecha actual";

            // Equipos iguales
            if (partido.Team1Id == partido.Team2Id)
                return "El Equipo 1 no puede ser igual al Equipo 2";


            //cruce de fechas y juego de equipo
            List<PaisDto> partidoList = _partidoRepository.List(x=> x.FechaInicio.Value.Date == DateTime.Today.Date).ToList();
            foreach(var item in partidoList)
            {
                if (item.Id == partido.Id && partido.Id != 0)
                    continue;
                //validación
                if(item.FechaInicio <= partido.FechaInicio && item.FechaFin >= partido.FechaInicio || item.FechaInicio <= partido.FechaFin && item.FechaFin >= partido.FechaFin)
                    return "El partido ingresado se cruza con otro ya registrado";

                if (item.Team1Id == partido.Team1Id)
                    return $"{item.Team1.Nombre} ({item.Team1.Abreviatura}) ya jugó en la fecha seleccionada";

                if (item.Team2Id == partido.Team2Id)
                    return $"{item.Team2.Nombre} ({item.Team2.Abreviatura}) ya jugó en la fecha seleccionada";

            }
            return string.Empty;
        }
        #endregion
    }


}
