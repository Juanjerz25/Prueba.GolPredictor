using System;
using System.Collections.Generic;

#nullable disable

namespace GolPredictor.WebApi.DataAccess.Entities
{
    public partial class Sesion
    {
        public Sesion()
        {
            SesionUsuario = new HashSet<SesionUsuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<SesionUsuario> SesionUsuario { get; set; }
    }
}
