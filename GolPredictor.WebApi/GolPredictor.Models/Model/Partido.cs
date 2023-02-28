using System;
using System.Collections.Generic;

#nullable disable

namespace GolPredictor.Models.Model
{
    public partial class Partido
    {
        public Partido()
        {
            Apuesta = new HashSet<Apuesta>();
        }

        public int Id { get; set; }
        public int? Team1Id { get; set; }
        public int? Team2Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool? Status { get; set; }
        public int? ResultTeam1 { get; set; }
        public int? ResultTeam2 { get; set; }

        public virtual Pais Team1 { get; set; }
        public virtual Pais Team2 { get; set; }
        public virtual ICollection<Apuesta> Apuesta { get; set; }
    }
}
