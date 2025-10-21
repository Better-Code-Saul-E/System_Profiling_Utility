using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System_Profiling_Utility.Models;
using Hardware.Info;

namespace System_Profiling_Utility.Controllers
{

    public class HomeController : Controller
    {
        private static readonly IHardwareInfo hardwareInfo = new HardwareInfo();
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            hardwareInfo.RefreshAll();

            var viewModel = new SystemInfoViewModel();

            viewModel.OSVersion = hardwareInfo.OperatingSystem.ToString();
            viewModel.OSArchitecture = System.Runtime.InteropServices.RuntimeInformation.OSArchitecture.ToString();

            var cpu = hardwareInfo.CpuList.FirstOrDefault();
            if (cpu != null)
            {
                viewModel.ProcessorName = cpu.Name.Trim();
                viewModel.ProcessorCount = (int)cpu.NumberOfLogicalProcessors;
            }

            viewModel.TotalMemoryGb = Math.Round(hardwareInfo.MemoryStatus.TotalPhysical / 1073741824.0, 2);

            return View(viewModel);
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