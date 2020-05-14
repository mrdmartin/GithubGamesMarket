using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GAMES_MARKET.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;
using GAMES_MARKET.Models.BO;

namespace GAMES_MARKET.Controllers
{
    public class ApiSearchController : Controller
    {
        // GET: ApiSearch

        [HttpPost]
        public ActionResult Index()
        {
            Dictionary<string, string> jsonRequest = GetJsonRequest();

            JuegosModel oJuegosModel = new JuegosModel();

            oJuegosModel.nombre = jsonRequest["name"];

            oJuegosModel.id_plataforma = int.Parse(jsonRequest["platform"]);

            oJuegosModel.id_genero = int.Parse(jsonRequest["gender"]);

            BOApi oBDBusqueda = new BOApi();

            List<JuegosModel> listaJuegos = oBDBusqueda.getGameslist(oJuegosModel);

            var jsonResponse = new
            {
                games = listaJuegos
            };

            return Json(jsonResponse);

        }

        private Dictionary<string, string> GetJsonRequest()
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<Dictionary<string, string>>(
                ReadRequestBody()
            );
        }

        private string ReadRequestBody()
        {
            string documentContents;
            using (Stream receiveStream = Request.InputStream)
            {
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    documentContents = readStream.ReadToEnd();
                }
            }
            return documentContents;
        }
    }
}