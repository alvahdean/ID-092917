﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace IDSkills.Controllers
{
    public partial class DropdownlistController : Controller
    {
        //
        // GET: /DropdownlistDefault/
        public ActionResult DropdownlistFeatures()
        {
		return View();
        }
    }
}
