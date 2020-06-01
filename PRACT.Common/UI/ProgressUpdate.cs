using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Common.UI
{
    public class ProgressUpdate
    {
        public int TotalTasks { get; set; }
        public int CurrentTaskOrder { get; set; }
        public string TaskElementName { get; set; }
        public string LongProgress { get; set; }
        public string GetShortProgress()
        {
            return $"{ CurrentTaskOrder } / { TotalTasks } {TaskElementName } processed";
        }
        public ProgressUpdate(int totalTasks)
        {
            TotalTasks = totalTasks;
        }
    }
}
