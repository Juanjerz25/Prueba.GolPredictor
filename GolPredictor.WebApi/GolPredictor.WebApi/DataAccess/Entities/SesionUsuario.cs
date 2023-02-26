using System;
using System.Collections.Generic;

#nullable disable

namespace GolPredictor.WebApi.DataAccess.Entities
{
    public partial class SesionUsuario
    {
        public SesionUsuario()
        {
            Apuesta = new HashSet<Apuesta>();
        }

        public int Id { get; set; }
        public int? IdSesion { get; set; }
        public string NombreUsuario { get; set; }

        public virtual Sesion IdSesionNavigation { get; set; }
        public virtual ICollection<Apuesta> Apuesta { get; set; }
    }
}
