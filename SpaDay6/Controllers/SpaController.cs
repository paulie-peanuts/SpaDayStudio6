using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaDay6.Controllers
{
    public class SpaController : Controller
    {
        public bool CheckSkinType(string skinType, string facialType)
        {

            if (facialType != "Microdermabrasion")
            {
                if (skinType == "oily" && facialType != "Rejuvenating")
                {
                    return false;
                }
                else if (skinType == "combination" && (facialType != "Rejuvenating" || facialType != "Enzyme Peel"))
                {
                    return false;
                }
                else if (skinType == "dry" && facialType != "Hydrofacial")
                {
                    return false;
                }
            }

            return true;

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/SpaDisplay")]
        public IActionResult Menu(string name, string skintype, string manipedi)
        {
            List<string> facials = new List<string>()
            {
                "Microdermabrasion", "Hydrofacial", "Rejuvenating", "Enzyme Peel"
            };

            List<string> appropriateFacials = new List<string>();
            for (int i = 0; i < facials.Count; i++)
            {
                if (CheckSkinType(skintype, facials[i]))
                {
                    appropriateFacials.Add(facials[i]);
                }
            }

            ViewBag.Name = name;
            ViewBag.AppropriateFacials = appropriateFacials;
            ViewBag.SkinType = skintype;
            ViewBag.ManiPedi = manipedi;

            List<string> polishColors = new();
            polishColors.Add("#ffbe0b");
            polishColors.Add("#fb5607");
            polishColors.Add("#ff006e");
            polishColors.Add("#8338ec");
            polishColors.Add("#3a86ff");
            ViewBag.PolishColors = polishColors;

            return View();
        }
    }
}

