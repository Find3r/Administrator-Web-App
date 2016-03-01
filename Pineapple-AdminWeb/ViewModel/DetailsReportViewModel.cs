using Pineapple_AdminWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pineapple_AdminWeb.ViewModel
{
    public class DetailsReportViewModel
    {
        public Noticia Noticia { get; set; }

        public IEnumerable<Comentario> Comentarios { get; set; }
    }
}