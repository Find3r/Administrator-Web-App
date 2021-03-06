﻿using Microsoft.WindowsAzure.MobileServices;
using Pineapple_AdminWeb.Helpers;
using Pineapple_AdminWeb.Models;
using Pineapple_AdminWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pineapple_AdminWeb.Controllers
{
    public class HomeController : Controller
    {

        public static MobileServiceClient MobileService = new MobileServiceClient(
            "https://wantedapp.azure-mobile.net/",
            "MIqlLCMyhKNIonsgsNuFlpBXzqqNWj11"
        );

        // se obtiene la referencia a la tabla
        IMobileServiceTable<Noticia> tableNoticia = MobileService.GetTable<Noticia>();

        // colecciön estática para tener en memoria las noticias
        static IEnumerable <Noticia> noticias;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddReport()
        {
            return View(new AddReportViewModel());
        }

        public ActionResult EditReport(string id)
        {
            // se busca la noticia en la colección
            Noticia noticia = noticias.Where(e => e.Id.Equals(id)).FirstOrDefault();

            // se pasa la noticia
            AddReportViewModel viewModel = new AddReportViewModel();
            viewModel.Noticia = noticia;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditReport(AddReportViewModel viewModel)
        {
            try
            {
                // se verifica si la url de la imagen del viewmodel es diferente de null, si es así se cambiará la imagen
                if (viewModel.UrlImagen != null)
                {
                    // se cargan las imágenes
                    AzureBlob blob = new AzureBlob();
                    // guardamos y establecemos las url
                    viewModel.Noticia.PictureURL = await blob.GuardarImagen(viewModel.UrlImagen);
                }

                await tableNoticia.UpdateAsync(viewModel.Noticia);

                ViewBag.Status = "Actualizado con éxito";

                return View(new AddReportViewModel() { Noticia = viewModel.Noticia });
            }
            catch (Exception)
            {

                //throw;
            }
            return View(new AddReportViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> AddReport(AddReportViewModel viewModel)
        {
            try
            {
                // se cargan las imágenes
                AzureBlob blob = new AzureBlob();

                ViewBag.Status = "Agregado con éxito";

                // guardamos y establecemos las url
                viewModel.Noticia.PictureURL = await blob.GuardarImagen(viewModel.UrlImagen);

                await tableNoticia.InsertAsync(viewModel.Noticia);

                ModelState.Clear();

                return View(new AddReportViewModel() { Noticia = viewModel.Noticia });
            }
            catch (Exception)
            {

                //throw;
            }
            return View(new AddReportViewModel());
        }

        public async Task<ActionResult> DetailsReport(string id)
        {
            DetailsReportViewModel viewModel = new DetailsReportViewModel();

            // se busca la noticia en la colección
            viewModel.Noticia = noticias.Where(e => e.Id.Equals(id)).FirstOrDefault();

            // se buscan los comentarios
            viewModel.Comentarios = await MobileService.InvokeApiAsync<IEnumerable<Comentario>>("postcomments", HttpMethod.Get, new Dictionary<string, string> { { "id", viewModel.Noticia.Id } });

            // se pasa el viewModel
            return View(viewModel);
        }

        [Authorize]
        public async Task<ActionResult> Reporte()
        {
            ViewBag.Message = "Your application description page.";

            await CargarNoticias();

            // se pasan las noticias a la vista
            return View(noticias);
        }

        private async Task CargarNoticias()
        {
            // se obtienen las noticias
            noticias = await MobileService.InvokeApiAsync<IEnumerable<Noticia>>("last_newsaux", System.Net.Http.HttpMethod.Get, new Dictionary<string, string> { { "id", "1" } });
        }

    }
}