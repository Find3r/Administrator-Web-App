using Pineapple_AdminWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pineapple_AdminWeb.ViewModel
{
    public class AddReportViewModel
    {
        public Noticia Noticia { get; set; }

        public SelectList ListaProvincias { get; set; }

        public SelectList ListaCategorias { get; set; }

        public SelectList ListaEstados { get; set; }

        public HttpPostedFileBase UrlImagen { get; set; }

        private List<BaseModel> provincias = new List<BaseModel>()
        {
            new BaseModel("1","San José"),
            new BaseModel("2","Alajuela"),
            new BaseModel("3","Cartago"),
            new BaseModel("4","Heredia"),
            new BaseModel("5","Guanacaste"),
            new BaseModel("6","Puntarenas"),
            new BaseModel("7","Limón"),
        };

        private List<BaseModel> categorias = new List<BaseModel>()
        {
            new BaseModel("1","Personas"),
            new BaseModel("2","Vehículos"),
            new BaseModel("3","Mascotas"),
            new BaseModel("4","Otros")
        };

        private List<BaseModel> estados = new List<BaseModel>()
        {
            new BaseModel("0","Pendiente"),
            new BaseModel("1","Resuelto")
        };

        public AddReportViewModel()
        {
            ListaProvincias = new SelectList(provincias, "Id", "Nombre");
            ListaCategorias = new SelectList(categorias, "Id", "Nombre");
            ListaEstados = new SelectList(estados, "Id", "Nombre");
        }
    }
}