using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System_Profiling_Utility.Models;
using System_Profiling_Utility.ViewModels;
using System_Profiling_Utility.Services.Interfaces;

namespace System_Profiling_Utility.Controllers
{

    public class HomeController : Controller
    {
        public HomeController(IProcessorService processorService)
        {
            _processorService = processorService;
        }
        private readonly IProcessorService _processorService;
        public IActionResult Index()
        {
            var cpu = _processorService.GetProcessorInfo();

            var vm = new DashboardOverviewViewModel
            {
                OSVersion = "N/A",
                OSArchitecture = cpu.Architecture,
                ProcessorName = cpu.Name,
                ProcessorCount = (int)cpu.ThreadCount,
                TotalMemoryGb = 0
            };
            return View(vm);
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