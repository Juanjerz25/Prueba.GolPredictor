using GolPredictor.WebApi.DTO.Pais;
using System;

namespace GolPredictor.WebApi.DTO.Partido
{
    public class PartidoDto
    {
        public int Id { get; set; }
        public int? Team1Id { get; set; }
        public int? Team2Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool? Status { get; set; }
        public int? ResultTeam1 { get; set; }
        public int? ResultTeam2 { get; set; }
        public virtual PaisDto Team1 { get; set; }
        public virtual PaisDto Team2 { get; set; }
    }
}
