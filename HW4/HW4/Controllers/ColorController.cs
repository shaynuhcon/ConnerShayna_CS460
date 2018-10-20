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
            Color firstRgb = ColorTranslator.FromHtml(firstColor);
            Color secondRgb = ColorTranslator.FromHtml(secondColor);

            int reds = LimitValue(firstRgb.R, secondRgb.R);
            int greens = LimitValue(firstRgb.G, secondRgb.G);
            int blues = LimitValue(firstRgb.B, secondRgb.B);

            Color newColor = Color.FromArgb(reds, greens, blues);

            ViewBag.ColorOne = firstRgb;
            ViewBag.ColorTwo = secondRgb;
            ViewBag.NewColor = newColor;

            return View();
        }

        // Ensures value of red, green, or blue value does not exceed 255
        private int LimitValue(int first, int second)
        {
            const int max = 255;
            int value = first + second;
            if (value < max) return first + second;

            return max;
        }
    }
}