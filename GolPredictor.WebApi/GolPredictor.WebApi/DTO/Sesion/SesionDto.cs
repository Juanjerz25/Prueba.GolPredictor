using GolPredictor.WebApi.DataAccess.Entities;
using GolPredictor.WebApi.DTO.Partido;
using System.Collections.Generic;

namespace GolPredictor.WebApi.DTO.Sesion
{
    public class SesionDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string EntryCode { get; set; }
        public int? PartidoId { get; set; }
        public bool? Status { get; set; }
        public virtual PartidoDto Partido { get; set; }
        public virtual ICollection<SesionUsuarioDto> SesionUsuario { get; set; }
    }
}
