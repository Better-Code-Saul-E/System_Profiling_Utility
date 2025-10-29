namespace  System_Profiling_Utility.Models
{
    public class SystemInfoViewModel
    {
        // OS Info
        public string? OSVersion { get; set; }
        public string? OSArchitecture { get; set; }

        // CPU Info 
        public string? ProcessorName { get; set; }
        public int ProcessorCount { get; set; }

        // Memory Info
        public double TotalMemoryGb { get; set; }

    }
}