using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace IDSkills.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult MenuFeatures()
        {
          return View();
        }
    }
}
