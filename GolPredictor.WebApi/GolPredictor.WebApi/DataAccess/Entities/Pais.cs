using System;
using System.Collections.Generic;

#nullable disable

 namespace GolPredictor.WebApi.DataAccess.Entities
{
    public partial class Pais
    {
        public Pais()
        {
            PartidoTeam1 = new HashSet<PaisDto>();
            PartidoTeam2 = new HashSet<PaisDto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        
        public virtual ICollection<PaisDto> PartidoTeam1 { get; set; }
        public virtual ICollection<PaisDto> PartidoTeam2 { get; set; }
    }
}
