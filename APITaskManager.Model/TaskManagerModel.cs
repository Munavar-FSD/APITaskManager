using System;
using System.Collections.Generic;

namespace APITaskManager.Model
{
    public class TaskManagerModel
    {
        public List<TaskManagerDetails> TaskManagerList = new List<TaskManagerDetails>();
        public TaskManagerDetails TaskManagerDetails { get; set; }
    }
    public class TaskManagerDetails
    {
        public int Parent_ID { get; set; }
        public string Parent_Task { get; set; }
        public int Task_ID { get; set; }
        public string Task { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
    }
}
