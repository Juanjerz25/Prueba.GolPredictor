using System;
using System.Collections.Generic;

#nullable disable

namespace GolPredictor.Models.Model
{
    public partial class Pais
    {
        public Pais()
        {
            PartidoTeam1 = new HashSet<Partido>();
            PartidoTeam2 = new HashSet<Partido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Partido> PartidoTeam1 { get; set; }
        public virtual ICollection<Partido> PartidoTeam2 { get; set; }
    }
}
