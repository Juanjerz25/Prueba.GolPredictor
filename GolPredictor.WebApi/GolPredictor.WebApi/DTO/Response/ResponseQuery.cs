using System;
using System.Runtime.Serialization;

namespace GolPredictor.WebApi.DTO.Response
{
    [Serializable]
    [DataContract]
    public class ResponseQuery<T>
    {
        /// <summary>
        /// True: indica que la operación se ejecutó exitósamene.
        /// </summary>
        [DataMember]
        public bool Successful { get; set; }

        /// <summary>
        /// Código de fallo en caso de presentarse un error.
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Detalle del error que pueda presentarse.
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Entidad compuesta con información 
        /// </summary>
        [DataMember]
        public T Result { get; set; }
    }
}
