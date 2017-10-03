using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace IDSkills.Controllers
{
    public class RibbonController : Controller
    {
        public IActionResult RibbonFeatures()
        {
          return View();
        }
    }
}
