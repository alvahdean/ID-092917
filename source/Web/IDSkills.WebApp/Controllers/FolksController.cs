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
        private const int defPageSize = 2;
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
            return new RedirectToActionResult("BareBones", "Folks",null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Task<IActionResult></returns>
        public async Task<IActionResult> BareBones(FolkListViewModel model)
        {
            model = model ?? new FolkListViewModel() {PageIndex = 1, PageSize = defPageSize};
            model = await updateModel(model);
            ViewBag.datasource = model;
            return View(model);
        }
        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> First(FolkListViewModel model)
        {
            model.Folks = null;
            model.PageIndex=1;
            model= await updateModel(model);
            return new RedirectToActionResult("BareBones","Folks",model);
        }

        public async Task<IActionResult> Previous(FolkListViewModel model)
        {
            model.Folks = null;
            model.PageIndex--;
            model = await updateModel(model);
            return new RedirectToActionResult("BareBones", "Folks", model);
        }

        public async Task<IActionResult> Next(FolkListViewModel model)
        {
            model.Folks = null;
            model.PageIndex++;
            model = await updateModel(model);
            return new RedirectToActionResult("BareBones", "Folks", model);
        }

        public async Task<IActionResult> Last(FolkListViewModel model)
        {
            model.Folks = null;
            model.PageIndex = model.TotalPages;
            model = await updateModel(model);
            return new RedirectToActionResult("BareBones", "Folks", model);
        }
        public async Task<IActionResult> All(FolkListViewModel model)
        {
            model.Folks = null;
            model.PageIndex = 1;
            model.PageSize = 0;
            model = await updateModel(model);
            return new RedirectToActionResult("BareBones", "Folks", model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Task<IActionResult></returns>
        public async Task<IActionResult> SFGrid()
        {
            //IQueryable<Folk> folks = queryFolksAll();
            FolkListViewModel vm = await getFolksModel(int.MaxValue);
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
            List<FolkViewModel> result = new List<FolkViewModel>();
            if (folks != null)
            {
                List<Folk> list = await folks.ToListAsync();
                foreach (var f in list)
                {
                    FolkViewModel m = new FolkViewModel(f);
                    if (m != null)
                        result.Add(m);
                }
            }
            //if (folks!=null)
            //    await folks.ForEachAsync(t=> result.Add(new FolkViewModel(t)));
            return result;
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
        private async Task<FolkListViewModel> updateModel(FolkListViewModel model = null)
        {
            model = model ?? new FolkListViewModel()
            {
                PageIndex = 1,
                PageSize = defPageSize
            };

            IQueryable<Folk> qry = queryFolksAll();
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

            model.TotalPages = (int) Math.Ceiling((double) model.TotalRecords / model.PageSize);
            if (model.PageIndex > model.TotalPages)
                model.PageIndex = model.TotalPages;
            else if (model.PageIndex < 1)
                model.PageIndex = 1;
            model.HasPreviousPage = model.PageIndex > 1 && model.TotalPages > 1;
            model.HasNextPage = model.PageIndex < model.TotalPages && model.TotalPages > 1;
            int skip = model.PageSize * (model.PageIndex - 1);
            qry = qry.Skip(skip).Take(model.PageSize);
            try
            {

                model.FieldList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>()
                {
                    new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                    {
                        Text = "None",
                        Value = ""
                    }
                };
                (await _context.FolkFields.Select(t => t.Name).ToListAsync())
                    .ForEach(t => model.FieldList.Add(
                        new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() {Text = t, Value = t})
                    );
                model.Folks = await projectVM(qry);
                model.StatusMessage = $"Success: {model.Folks.Count}/{model.TotalRecords} returned";
            }
            catch (Exception ex)
            {
                model.Folks = new List<FolkViewModel>();
                model.StatusMessage = $"Exception: {ex.Message}";
            }
            return model;
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
        return await updateModel(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Task<FolkListViewModel></returns>
        //private async Task<FolkListViewModel> getFolksModelDeprecated(FolkListViewModel model)
        //{
        //    model = model ?? new FolkListViewModel()
        //    {
        //        PageIndex = 1,
        //        PageSize = defPageSize
        //    };
        //    try
        //    {
        //        IQueryable<Folk> qry = await queryFolks(model);
        //        model.Folks = await projectVM(qry);
        //        model.StatusMessage = $"Success: {model.Folks.Count}/{model.TotalRecords} returned";
        //    }
        //    catch(Exception ex)
        //    {
        //        model.StatusMessage = $"Exception: {ex.Message}";
        //    }
        //    return model;
        //}
    }
}
