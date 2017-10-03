using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace IDSkills.Controllers
{
    public partial class TreeGridController : Controller
    {
        public ActionResult TreeGridFeatures()
        {
            ViewBag.datasource = this.GetFilteringDataSource();
            ViewBag.toolbarItems = new List<String>() { "add", "edit", "delete", "update", "cancel", "expandAll", "collapseAll" };
            return View();
        }
        private List<BusinessObject> GetFilteringDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObject Record1 = null;
            Record1 = new BusinessObject()
            {
                TaskId = 1,
                TaskName = "Planning",
                FilterStartDate = new DateTime(2014, 02, 03, 0, 0, 0),
                FilterEndDate = new DateTime(2014, 02, 07),
                Progress = 100,
                Priority = "Normal",
                InProgress = false,
                Children = new List<BusinessObject>(),
            };
            BusinessObject Child1 = new BusinessObject()
            {
                TaskId = 2,
                TaskName = "Plan timeline",
                FilterStartDate = new DateTime(2014, 02, 03),
                FilterEndDate = new DateTime(2014, 02, 07),
                Priority = "Low",
                Progress = 100,
                InProgress = true
            };
            BusinessObject Child2 = new BusinessObject()
            {
                TaskId = 3,
                TaskName = "Plan budget",
                FilterStartDate = new DateTime(2014, 02, 03),
                FilterEndDate = new DateTime(2014, 02, 07),
                Progress = 100,
                InProgress = false
            };
            BusinessObject Child3 = new BusinessObject()
            {
                TaskId = 4,
                TaskName = "Allocate resources",
                FilterStartDate = new DateTime(2014, 02, 03),
                FilterEndDate = new DateTime(2014, 02, 07),
                Priority = "High",
                Progress = 100,
                InProgress = false
            };
            BusinessObject Child4 = new BusinessObject()
            {
                TaskId = 5,
                TaskName = "Planning complete",
                FilterStartDate = new DateTime(2014, 02, 07),
                FilterEndDate = new DateTime(2014, 02, 07),
                Priority = "Low",
                Progress = 0,
                InProgress = true
            };
            Record1.Children.Add(Child1);
            Record1.Children.Add(Child2);
            Record1.Children.Add(Child3);
            Record1.Children.Add(Child4);
            BusinessObject Record2 = new BusinessObject()
            {
                TaskId = 6,
                TaskName = "Design",
                FilterStartDate = new DateTime(2014, 02, 10),
                FilterEndDate = new DateTime(2014, 02, 14),
                Progress = 86,
                Priority = "High",
                InProgress = false,
                Children = new List<BusinessObject>(),
            };
            BusinessObject Child5 = new BusinessObject()
            {
                TaskId = 7,
                TaskName = "Software Specification",
                FilterStartDate = new DateTime(2014, 02, 10),
                FilterEndDate = new DateTime(2014, 02, 12),
                Priority = "Critical",
                Progress = 60,
                InProgress = true,
            };
            BusinessObject Child6 = new BusinessObject()
            {
                TaskId = 8,
                TaskName = "Develop prototype",
                FilterStartDate = new DateTime(2014, 02, 10),
                FilterEndDate = new DateTime(2014, 02, 12),
                Priority = "Normal",
                Progress = 100,
                InProgress = false
            };
            BusinessObject Child7 = new BusinessObject()
            {
                TaskId = 9,
                TaskName = "Get approval from customer",
                FilterStartDate = new DateTime(2014, 02, 13),
                FilterEndDate = new DateTime(2014, 02, 14),
                Progress = 100,
                InProgress = true
            };
            BusinessObject Child8 = new BusinessObject()
            {
                TaskId = 10,
                TaskName = "Design complete",
                FilterStartDate = new DateTime(2014, 02, 14),
                FilterEndDate = new DateTime(2014, 02, 14),
                Priority = "High",
                Progress = 0,
                InProgress = false
            };
            Record2.Children.Add(Child5);
            Record2.Children.Add(Child6);
            Record2.Children.Add(Child7);
            Record2.Children.Add(Child8);
            BusinessObjectCollection.Add(Record1);
            BusinessObjectCollection.Add(Record2);
            return BusinessObjectCollection;
        }
    }
    public class BusinessObject
    {
        public int TaskId
        {
            get;
            set;
        }
        public string TaskName
        {
            get;
            set;
        }
        public string StartDate
        {
            get;
            set;
        }
        public string EndDate
        {
            get;
            set;
        }
        public int Duration
        {
            get;
            set;
        }
        public int Progress
        {
            get;
            set;
        }
        public string Priority
        {
            get;
            set;
        }
        public bool InProgress
        {
            get;
            set;
        }
        public DateTime FilterStartDate
        {
            get;
            set;
        }
        public DateTime FilterEndDate
        {
            get;
            set;
        }
        public List<BusinessObject> Children
        {
            get;
            set;
        }
    }
}
