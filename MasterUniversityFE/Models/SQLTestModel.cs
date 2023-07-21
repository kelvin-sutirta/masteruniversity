namespace MasterUniversityFE.Models
{
    public class SQLTestModel
    {
        public int TestCases { get; set; }
    }
    public class TestResult
    {
        public int ID { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int MiliSeconds { get; set; }
        public int DataProcessed { get; set; }
        public string AverageTime { get; set; }

    }
    public class TestResultListModel
    {
        public IEnumerable<TestResult> Items { get; set; }

        public int length { get; set; }

    }
    public class GraphData
    {
        public int DataAmount { get; set; }
        public float AveragePerformanceSpeed { get; set; }

    }

    public class LineChartData
    {
        public double oneK { get; set; } = 0;
        public double fiveK { get; set; } = 0;
        public double tenK { get; set; } = 0;
        public double fiftyK { get; set; } = 0;
        public double hundredK { get; set; } = 0;

    }
}
