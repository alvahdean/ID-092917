using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace IDSkills.Controllers
{
    public partial class ListViewController : Controller
    {
        //
        // GET: /DefaultFunctionalities/
        public ActionResult ListViewFeatures()
        {
              return View();
        }
    }
}
