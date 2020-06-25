using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        List<Job> jobList = new List<Job>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.jobs = jobList;
            return View();
        }

        //[HttpGet("/search/results/")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.ColumnChoices;

            if (String.IsNullOrEmpty(searchTerm))
            {
                ViewBag.jobs = JobData.FindAll();
                return View("Index");
            }

            else 
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                return View("Index");
            }
        }
    }
}
