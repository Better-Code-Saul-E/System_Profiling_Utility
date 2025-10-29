using System;
using Hardware.Info;
using System_Profiling_Utility.Models;
using System_Profiling_Utility.Services.Interfaces;

namespace System_Profiling_Utility.Services
{
    public class HardwareService
    {
        private readonly IHardwareInfo _hardwareInfo;

        public HardwareService(IHardwareInfo hardwareInfo)
        {
            _hardwareInfo = hardwareInfo;
            _hardwareInfo.RefreshAll();
        }
    }
}