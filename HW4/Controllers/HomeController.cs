using System;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Converter()
        {
            string milesInput = Request["miles"];
            string unitsInput = Request["units"];
            decimal convertedMiles = 0;

            if (!milesInput.IsNullOrWhiteSpace())
            {
                decimal miles = 0;
                try
                {
                    miles = Decimal.Parse(milesInput);
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.ToString();
                }

                switch (unitsInput)
                {
                    case "millimeters":
                        convertedMiles = miles * 1.609m;
                        break;
                    case "centimeters":
                        convertedMiles = miles * 160934.4m;
                        break;
                    case "meters":
                        convertedMiles = miles * 1609.344m;
                        break;
                    case "kilometers":
                        convertedMiles = miles * 1.609m;
                        break;
                }
            }

            ViewBag.Converted = convertedMiles;
            ViewBag.Units = unitsInput;

            return View();
        }
    }
}