using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Pineapple_AdminWeb.Models
{
    public class Noticia
       {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [Required]
        [DisplayName("Nombre")]
        [JsonProperty(PropertyName = "nombre")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Descripción")]
        [JsonProperty(PropertyName = "descripcion")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Imagen")]
        [JsonProperty(PropertyName = "urlimagen")]
        public string PictureURL { get; set; }

        [JsonProperty(PropertyName = "__createdAt")]
        public DateTime __createdAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha desaparición")]
        [JsonProperty(PropertyName = "fechadesaparicion")]
        public DateTime DateLost { get; set; }

        [JsonProperty(PropertyName = "idusuario")]
        public string IdUser { get; set; }

        [JsonProperty(PropertyName = "idestado")]
        public string IdStatus { get; set; }

        [Required]
        [DisplayName("Categoría")]
        [JsonProperty(PropertyName = "idcategoria")]
        public string IdCategory { get; set; }

        [Required]
        [DisplayName("Provincia")]
        [JsonProperty(PropertyName = "idprovincia")]
        public string IdZone { get; set; }

        [DisplayName("Reportes")]
        [JsonProperty(PropertyName = "cantidad_reportes")]
        private int ? quantityReports { get; set; }

        [JsonProperty(PropertyName = "latitud")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "longitud")]
        public string Longitude { get; set; }

        [Required]
        [DisplayName("Estado")]
        [JsonProperty(PropertyName = "solved")]
        public bool Solved { get; set; }


        [JsonProperty(PropertyName = "cantidad_comentarios")]
        public int CantidadComentarios;

        public Noticia()
        {
            DateLost = DateTime.Now;
            Solved = false;
        }

        [DisplayName("Fecha desaparición")]
        public string DateShort
        {
            get
            {
                return DateLost.ToString("dd-MM-yyyy", new CultureInfo("es-ES"));
            }
        }

        public int QuantityReports
        {
            get
            {
                if (quantityReports == null)
                {
                    return 0;
                }
                else
                {
                    return (int) quantityReports;
                }
            }
            set { quantityReports = value; }
        }


    }

}