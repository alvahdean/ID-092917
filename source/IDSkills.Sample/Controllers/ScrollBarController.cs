using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace IDSkills.Controllers
{
    public class ScrollBarController : Controller
    {
        public IActionResult ScrollBarFeatures()
        {
          return View();
        }
    }
}
