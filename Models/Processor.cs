namespace System_Profiling_Utility.Models
{
    public class Processor
    {
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }


        public int CoreCount { get; set; }
        public int NumberOfLogicalProcessors { get; set; }

        public float MaxClockSpeed { get; set; }
        public float CurrentClockSpeed { get; set; }
        public double LoadPercentage { get; set; }

        public uint L1CacheSpeed { get; set; }
        public uint L2CacheSpeed { get; set; }
        public uint L3CacheSpeed { get; set; }

        public string? SocketType { get; set; }
        public string? Architecture { get; set; }
    }
}