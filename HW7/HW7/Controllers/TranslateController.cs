using System.Web.Mvc;
using RestSharp;

namespace HW7.Controllers
{
    public class TranslateController : Controller
    {
        public ActionResult Translator()
        {
            return View();
        }

        public JsonResult Translate(string word)
        {
            RestClient client = new RestClient("https://api.giphy.com/v1/stickers/translate?api_key=KjJ8Sheq7lqXoB3zvB0pW0Qd8ZcFQYkq&s=lobster");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            string data = response.Content;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}