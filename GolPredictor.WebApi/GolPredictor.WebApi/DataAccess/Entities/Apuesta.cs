using System;
using System.Collections.Generic;

#nullable disable

namespace GolPredictor.WebApi.DataAccess.Entities
{
    public partial class Apuesta
    {
        public int Id { get; set; }
        public int? IdPartido { get; set; }
        public int? IdSesionUsuario { get; set; }
        public int? MarcadorTeam1 { get; set; }
        public int? MarcadorTeam2 { get; set; }

        public virtual PaisDto IdPartidoNavigation { get; set; }
        public virtual SesionUsuario IdSesionUsuarioNavigation { get; set; }
    }
}
