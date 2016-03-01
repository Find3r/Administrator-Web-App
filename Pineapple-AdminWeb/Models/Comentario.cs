
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pineapple_AdminWeb.Models
{
    public class Comentario
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "idusuario")]
        public string IdUser { get; set; }

        [JsonProperty(PropertyName = "idnoticia")]
        public string IdNew { get; set; }

        [JsonProperty(PropertyName = "fecha")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "hora")]
        public string Hour { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "urlimagen")]
        public string UserPictureURL { get; set; }
    }
}