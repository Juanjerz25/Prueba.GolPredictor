using System;
using System.Collections.Generic;

#nullable disable

namespace GolPredictor.WebApi.DataAccess.Entities
{
    public partial class UserAdmin
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
    }
}
