using System.Collections.Generic;
using System.Web.Mvc;
using GAMES_MARKET.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;
using GAMES_MARKET.Models.BO;

namespace GAMES_MARKET.Controllers
{
    // Api del buscador AJAX
    public class ApiSearchController : Controller
    {
        //Genera y envia la lista de juegos
        [HttpPost]
        public ActionResult Index()
        {
            //Aqui recoge los datos con formato dccionario
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
        //Da formato diccionario los datos en un diccionario.
        private Dictionary<string, string> GetJsonRequest()
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<Dictionary<string, string>>(
                ReadRequestBody()
            );
        }
        //Recoge los datos del formulario
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