using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pineapple_AdminWeb.Models
{
    public class BaseModel
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public BaseModel(string pId, string pNombre)
        {
            Id = pId;
            Nombre = pNombre;
        }
    }
}