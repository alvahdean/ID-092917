using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IDSkills.Data;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using IDSkills.WebApp.Models.FamousFolks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IDSkills.WebApp.Controllers
{
    public class FolksController : Controller
    {
        private const int defPageSize = 3;
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;
        private FamousFolksContext _context;
        private FolkRepository _repo;

        /// <summary>
        /// Instantiates a new FolksController with specified dependencies
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="urlEncoder"></param>
        /// <param name="context"></param>
        public FolksController(
          ILogger<FolksController> logger,
          UrlEncoder urlEncoder,
          FamousFolksContext context)
        {
            _logger = logger;
            _urlEncoder = urlEncoder;
            _context = context;
            //Using handcrafted paging routines
            //_repo = new FolkRepository(context);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult Index()
        {
            return new RedirectToActionResult("SFGrid", "Folks",null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Task<IActionResult></returns>
        public async Task<IActionResult> BareBones()
        {
            //IQueryable<Folk> folks = queryFolksAll();
            FolkListViewModel vm = await getFolksModel(defPageSize);
            ViewBag.datasource = vm;
            return View(vm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Task<IActionResult></returns>
        public async Task<IActionResult> SFGrid()
        {
            //IQueryable<Folk> folks = queryFolksAll();
            FolkListViewModel vm = await getFolksModel(defPageSize);
            ViewBag.datasource = vm;
            return View(vm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PartialViewResult</returns>
        public PartialViewResult BioPanel(int id)
        {
            Folk f = queryFolksAll().FirstOrDefault(t => t.ID == id);
            return f != null 
                ? PartialView("_bioPanel", new FolkViewModel(f))
                : null;
            ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="folks"></param>
        /// <returns>Task<List<FolkViewModel>></returns>
        private async Task<List<FolkViewModel>> projectVM(IQueryable<Folk> folks)
        {
            return folks==null 
                ? new List<FolkViewModel>()
                : await folks.Select(t=>new FolkViewModel(t)).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>IQueryable<Folk></returns>
        private IQueryable<Folk> queryFolksAll()
        {
            return _context.Folks.Include("FolkField");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Task<IQueryable<Folk>></returns>
        private async Task<IQueryable<Folk>> queryFolks(FolkListViewModel model = null)
        {
            IQueryable<Folk> qry = queryFolksAll();
            if (model != null)
            {
                if (!String.IsNullOrWhiteSpace(model.FilterName))
                    qry = qry.Where(t => t.LastName.Contains(model.FilterName) || t.FirstName.Contains(model.FilterName));
                if (!String.IsNullOrWhiteSpace(model.FilterField))
                    qry = qry.Where(t => t.FolkField != null && t.FolkField.Name == model.FilterField);
                if (model.PageSize < 1)
                    model.PageSize = defPageSize;
                qry = model.SortName
                    ? qry.OrderBy(t => t.LastName).ThenBy(t => t.FirstName)
                    : qry.OrderByDescending(t => t.LastName).ThenByDescending(t => t.FirstName);

                model.TotalRecords = await qry.CountAsync();

                model.TotalPages = (int)Math.Ceiling((double)model.TotalRecords / model.PageSize);
                if (model.PageIndex > model.TotalPages)
                    model.PageIndex = model.TotalPages;
                else if (model.PageIndex < 1)
                    model.PageIndex = 1;
                int skip = model.PageSize * (model.PageIndex - 1);
                qry = qry.Skip(skip).Take(model.PageSize);
            }
            return qry;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns>Task<FolkListViewModel></returns>
        private async Task<FolkListViewModel> getFolksModel(int pageSize,int pageIndex=1)
        {
            FolkListViewModel model = new FolkListViewModel()
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
        return await getFolksModel(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Task<FolkListViewModel></returns>
        private async Task<FolkListViewModel> getFolksModel(FolkListViewModel model)
        {
            model = model ?? new FolkListViewModel()
            {
                PageIndex = 1,
                PageSize = defPageSize
            };
            try
            {
                IQueryable<Folk> qry = await queryFolks(model);
                model.Folks = await projectVM(qry);
                model.StatusMessage = $"Success: {model.Folks.Count}/{model.TotalRecords} returned";
            }
            catch(Exception ex)
            {
                model.StatusMessage = $"Exception: {ex.Message}";
            }
            return model;
        }
    }
}
