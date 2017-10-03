using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDSkills.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IDSkills.WebApp.Models.FamousFolks
{
    public class FolkListViewModel
    {
        public FolkListViewModel()
        {
            PageIndex = 1;
            PageSize = 3;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public string FilterName { get; set; }
        public string FilterField { get; set; }
        public bool SortName { get; set; }
        public string StatusMessage { get; set; }
        public List<SelectListItem> FieldList { get; set; }
        public List<FolkViewModel> Folks { get; set; }
    }
}
