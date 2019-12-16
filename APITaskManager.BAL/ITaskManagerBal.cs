using APITaskManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITaskManager.BAL
{
    public interface ITaskManagerBal
    {
        bool AddTask(TaskManagerDetails taskDetails);
        bool UpdateTask(TaskManagerDetails taskDetails);
        bool DeleteTask(int taskId);
        List<TaskManagerDetails> GetTask();
    }
}
