using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace IDSkills.Controllers
{
    public partial class TileViewController : Controller
    {
        //
        // GET: /DefaultFunctionalities/
        public ActionResult TileViewFeatures()
        {
            return View();
        }
    }
}
