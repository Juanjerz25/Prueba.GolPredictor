using AutoMapper;
using GolPredictor.WebApi.DataAccess.Entities;
using GolPredictor.WebApi.DTO.Pais;
using GolPredictor.WebApi.DTO.Partido;

namespace GolPredictor.WebApi.Helpers
{
    public class AutomapperConfig : Profile
    {

        public AutomapperConfig()
        {
            CreateMap<PartidoDto, Partido>()
                            .AfterMap((input, output) =>
                            {
                                output.FechaFin = input.FechaInicio.Value.AddMinutes(90);
                            })
                            .ReverseMap();

            CreateMap<PaisDto, Pais>().ReverseMap();
        }

    }
}
