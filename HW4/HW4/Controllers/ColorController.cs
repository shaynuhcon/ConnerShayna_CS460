using System.Drawing;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class ColorController : Controller
    {
        public ActionResult Index()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(string firstColor, string secondColor)
        {
            // Convert user-provided colors to Color object
            Color firstRgb = ColorTranslator.FromHtml(firstColor);
            Color secondRgb = ColorTranslator.FromHtml(secondColor);

            // Math calculations on user-provided colors
            int reds = LimitValue(firstRgb.R, secondRgb.R);
            int greens = LimitValue(firstRgb.G, secondRgb.G);
            int blues = LimitValue(firstRgb.B, secondRgb.B);

            // Use calculated values to get new/third color
            Color newColor = Color.FromArgb(reds, greens, blues);

            // Assign colors to ViewBag objects
            ViewBag.ColorOne = ColorTranslator.ToHtml(firstRgb);
            ViewBag.ColorTwo = ColorTranslator.ToHtml(secondRgb);
            ViewBag.NewColor = ColorTranslator.ToHtml(newColor);

            return View();
        }

        // Ensures value of red, green, or blue value does not exceed 255
        private int LimitValue(int first, int second)
        {
            // Max value is 25
            const int max = 255;

            // Add both parameters and return that value if it's not greater than 255
            int value = first + second;
            if (value < max) return first + second;
            return max;
        }
    }
}