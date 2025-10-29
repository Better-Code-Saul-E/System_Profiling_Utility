namespace System_Profiling_Utility.Models
{
    public class Processor
    {
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }


        public uint CoreCount { get; set; }
        public uint ThreadCount { get; set; }

        public uint BaseClockSpeed { get; set; }
        public uint CurrentClockSpeed { get; set; }
        public double LoadPercentage { get; set; }

        public uint L2CacheSize { get; set; }
        public uint L3CacheSize { get; set; }

        public string? SocketType { get; set; }
        public string? Architecture { get; set; }
    }
}