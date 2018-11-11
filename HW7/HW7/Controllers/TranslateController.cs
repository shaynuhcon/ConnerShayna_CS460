using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using HW7.DAL;
using HW7.Models;
using RestSharp;

namespace HW7.Controllers
{
    public class TranslateController : Controller
    {
        private readonly string _baseUrl = ConfigurationManager.AppSettings["GiphyUrl"];
        private readonly string _apiKey = ConfigurationManager.AppSettings["GiphyKey"];

        public ActionResult Translator()
        {
            // Get details of request
            RequestLog log = new RequestLog
            {
                DateInserted = DateTime.Now,
                RequestUrl = Request.Url?.ToString(),
                RequestType = Request.RequestType,
                Word = null,
                Browser = Request.Browser.Type,
                Ip = Request.UserHostAddress
            };

            using (var context = new LoggingContext())
            {
                // Add and save log to table
                context.RequestLogs.Add(log);
                context.SaveChanges();
            }

            return View();
        }

        public JsonResult Translate(string lastWord)
        {
            // Get details of request
            RequestLog log = new RequestLog
            {
                DateInserted = DateTime.Now,
                RequestUrl = Request.Url?.ToString(),
                RequestType = Request.RequestType,
                Word = lastWord,
                Browser = Request.Browser.Type,
                Ip = Request.UserHostAddress
            };

            using (var context = new LoggingContext())
            {
                // Add and save log to table
                context.RequestLogs.Add(log);
                context.SaveChanges();
            }

            // If input is a "boring" word, just return word
            if (_boringWords.Contains(lastWord.ToLower())) return Json(lastWord, JsonRequestBehavior.AllowGet);

            // Initialize RestClient with base Giphy URL
            RestClient client = new RestClient(_baseUrl);

            // Initialize RestRequest with parameters
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("api_key", _apiKey);
            request.AddParameter("s", lastWord);

            // Get response from Stickers API 
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
            "for",
            "you're",
            "your"
        };
    }
}