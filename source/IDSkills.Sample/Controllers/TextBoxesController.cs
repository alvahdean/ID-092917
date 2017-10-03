using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace IDSkills.Controllers
{
    public partial class TextBoxesController : Controller
    {
        //
        // GET: /EditorDefault/
        public ActionResult TextBoxesFeatures()
        {
            return View();
        }
    }
}
