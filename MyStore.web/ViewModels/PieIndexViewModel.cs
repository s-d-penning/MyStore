using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyStore.web.Controllers;
using MyStore.web.Models;
using PagedList;

namespace MyStore.web.ViewModels
{
    public class PieIndexViewModel
    {
        public IPagedList<Pie> Pies { get; set; }
        public string Search { get; set; }
        public IEnumerable<CategoryWithCount> CatsWithCount { get; set; }
        public string Category { get; set; }
        public string SortBy { get; set; }
        public Dictionary<string, string> Sorts { get; set; }
        public IEnumerable<SelectListItem> CatFilterItems
        {
            get
            {
                var allCats = CatsWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.CategoryName,
                    Text = cc.CatNameWithCount
                });
                return allCats;
            }
        }
    }
    public class CategoryWithCount
    {
        public int PieCatCount { get; set; }
        public string CategoryName { get; set; }
        public string CatNameWithCount => CategoryName + " (" + PieCatCount.ToString() + ")";
    }
}