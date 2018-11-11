using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using RestSharp;

namespace HW7.Controllers
{
    public class TranslateController : Controller
    {
        private readonly string _apiKey = ConfigurationManager.AppSettings["GiphyKey"];

        public ActionResult Translator()
        {
            return View();
        }

        public JsonResult Translate(string lastWord)
        {
            // If input is a "boring" word, just return word
            if (_boringWords.Contains(lastWord.ToLower())) return Json(lastWord, JsonRequestBehavior.AllowGet);
            
            // Get sticker response from Giphy 
            RestClient client = new RestClient($"https://api.giphy.com/v1/stickers/translate?api_key={_apiKey}={lastWord}");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            // Deserialize and return json response
            var data = new JavaScriptSerializer().Deserialize<object>(response.Content);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        private readonly List<string> _boringWords = new List<string>
        {
            "the",
            "a",
            "of",
            "i",
            "is",
            "am",
            "me",
            "they",
            "you",
            "he",
            "she",
            "it",
            "i'm",
            "to",
            "my",
            "this",
            "that",
            "him",
            "her",
            "going",
        };
    }
}