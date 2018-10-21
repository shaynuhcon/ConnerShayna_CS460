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
            // Retrieve input values from Request object
            string milesInput = Request.QueryString["miles"];
            string unitsInput = Request.QueryString["units"];

            // Only do conversions if miles value has been provided by user
            if (!milesInput.IsNullOrWhiteSpace())
            {
                decimal convertedMiles = 0;

                // Validate miles input and return error message if non-numeric value
                if (!Decimal.TryParse(milesInput, out decimal miles))
                {
                    ViewBag.OutputMessage = "Error: Miles given must be a numerical value.";
                    return View();
                }
                
                // Calculate miles to unit conversion
                switch (unitsInput)
                {
                    case "millimeters":
                        convertedMiles = miles * 1609000m;
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
                    default:
                        ViewBag.OutputMessage = "Error: Invalid metric provided. Please select from one of the radio buttons.";
                        return View();
                }

                // Output message to display conversion
                ViewBag.OutputMessage = $"{miles} miles is equal to {convertedMiles} {unitsInput}";
            }

            return View();
        }
    }
}