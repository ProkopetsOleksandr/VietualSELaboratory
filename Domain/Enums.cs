using System.ComponentModel;

namespace Domain
{
    public class Enums
    {
        public enum TaskName
        {
            [Description("Divide by categories")]
            DivideByCategories,
            [Description("Divide by priority")]
            DivideByPriority,
            [Description("Divide by reqs performance")]
            DivideByReqsPerformance
        }
    }
}
