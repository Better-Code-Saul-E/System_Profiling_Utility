using System;
using Hardware.Info;
using System_Profiling_Utility.Models;
using System_Profiling_Utility.Services.Interfaces;

namespace System_Profiling_Utility.Services
{
    public class HardwareService : IProcessorService
    {
        private readonly IHardwareInfo _hardwareInfo;

        public HardwareService(IHardwareInfo hardwareInfo)
        {
            _hardwareInfo = hardwareInfo;
            _hardwareInfo.RefreshAll();
        }

        public Processor GetProcessorInfo()
        {
            var cpu = _hardwareInfo.CpuList.FirstOrDefault();

            if (cpu == null)
            {
                return new Processor();
            }

            var info = new Processor
            {
                Name = cpu.Name.Trim(),
                Manufacturer = cpu.Manufacturer,
                CoreCount = cpu.NumberOfCores,
                ThreadCount = cpu.NumberOfLogicalProcessors,
                BaseClockSpeed = cpu.MaxClockSpeed,
                CurrentClockSpeed = cpu.CurrentClockSpeed,
                LoadPercentage = cpu.PercentProcessorTime,
                L2CacheSize = cpu.L2CacheSize,
                L3CacheSize = cpu.L3CacheSize,
                SocketType = cpu.SocketDesignation,
                Architecture = System.Runtime.InteropServices.RuntimeInformation.OSArchitecture.ToString()
            };

            return info;
        }
    }
}