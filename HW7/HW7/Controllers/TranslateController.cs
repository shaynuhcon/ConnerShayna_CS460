using System.Web.Mvc;
using RestSharp;

namespace HW7.Controllers
{
    public class TranslateController : Controller
    {

        public ActionResult Sticker(string word)
        {
            RestClient client = new RestClient("https://api.giphy.com/v1/stickers/translate?api_key=KjJ8Sheq7lqXoB3zvB0pW0Qd8ZcFQYkq&s=lobster");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return View("Translator");
        }
    }
}