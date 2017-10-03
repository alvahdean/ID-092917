using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace IDSkills.Controllers
{
    public class ToolBarController : Controller
    {
        List<ToolbarOrientation> tool = new List<ToolbarOrientation>();
        public IActionResult ToolBarFeatures()
        {
          tool.Add(new ToolbarOrientation { edid = "1", spriteCss = "cursor" });
            tool.Add(new ToolbarOrientation { edid = "2", spriteCss = "select" });
            tool.Add(new ToolbarOrientation { edid = "3", spriteCss = "move" });
            tool.Add(new ToolbarOrientation { edid = "4", spriteCss = "rectselect" });
            tool.Add(new ToolbarOrientation { edid = "5", spriteCss = "roundselect" });
            tool.Add(new ToolbarOrientation { edid = "6", spriteCss = "brush" });
            tool.Add(new ToolbarOrientation { edid = "7", spriteCss = "pen" });
            tool.Add(new ToolbarOrientation { edid = "8", spriteCss = "gradient" });
            tool.Add(new ToolbarOrientation { edid = "9", spriteCss = "crop" });
            tool.Add(new ToolbarOrientation { edid = "10", spriteCss = "symbols" });
            ViewBag.datasource = tool;
            return View();
        }
    }
    public class ToolbarOrientation
    {
        public string edid { get; set; }
        public string spriteCss { get; set; }
    }
}
