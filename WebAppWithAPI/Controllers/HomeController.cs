using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppWithAPI.Infrastructures.Interfaces;
using WebAppWithAPI.Models;
using WebAppWithAPI.Models.ViewModels;

namespace WebAppWithAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPoskodService poskodService;

        public HomeController(ILogger<HomeController> logger, IPoskodService poskodService)
        {
            _logger = logger;
            this.poskodService = poskodService;
        }

        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> GetPoskod()
        {

            try
            {
                //get input from datatable
                var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault()); //max length or required only 10 
                var page = Convert.ToInt32(Request.Form["start"].FirstOrDefault()) /length + 1;
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                var draw = Request.Form["draw"].FirstOrDefault();

                //call service to get data from api
                var data = await poskodService.GetPoskod(searchValue , page, length);

                //map data result to new object with checking null or not
                var jsonData = new
                {
                    draw = draw,
                    recordsFiltered = (data != null) ? data.totalRecords : 0,
                    recordsTotal = (data != null) ? data.totalRecords : 0,
                    data = (data != null) ? data.data : new List<PoskodBandarViewModel>()
                };

                //return json with important data for dt
                return Json(jsonData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in dt setting ", ex);
                throw;
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
