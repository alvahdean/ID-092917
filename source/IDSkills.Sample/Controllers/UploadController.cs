using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace IDSkills.Controllers
{
    public partial class UploadController : Controller
    {
        //
        // GET: /UploadDefault/
        public ActionResult UploadFeatures()
        {
            return View();
        } 
    }
}
