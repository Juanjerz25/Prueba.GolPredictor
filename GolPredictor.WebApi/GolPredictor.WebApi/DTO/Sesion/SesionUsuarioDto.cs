using System.Text.Json.Serialization;

namespace GolPredictor.WebApi.DTO.Sesion
{
    public class SesionUsuarioDto
    {
        public int Id { get; set; }
        public int? IdSesion { get; set; }
        public string NombreUsuario { get; set; }
        public int? Team1Marcador { get; set; }
        public int? Team2Marcador { get; set; }

        [JsonIgnore]
        public virtual SesionDto IdSesionNavigation { get; set; }
    }
}
