using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchTerm, string searchType)
        {
            ViewBag.columns = ListController.columnChoices;
            if (searchType == "all")
            {
                List<Dictionary<String, String>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
            }
            else
            {
                List<Dictionary<String, String>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
            }
            
            ViewBag.title = "Jobs with " + searchType + ": " + searchTerm;
            
            return View("Views/Search/Index.cshtml");
        }

    }
}
