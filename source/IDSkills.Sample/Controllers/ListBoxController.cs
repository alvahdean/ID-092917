using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace IDSkills.Controllers
{
    public class ListBoxController : Controller
    {
        public IActionResult ListBoxFeatures()
        {
          return View();
        }
    }
}
