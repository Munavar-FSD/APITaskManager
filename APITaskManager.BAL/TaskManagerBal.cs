using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APITaskManager.Model;
using APITaskManager.DAL;

namespace APITaskManager.BAL
{
    public class TaskManagerBal:IDisposable, ITaskManagerBal
    {
        //private ITaskRepository<object> taskRepo;

        //public TaskManagerBal(ITaskRepository<object> repos)
        //{
        //    this.taskRepo = repos;
        //}

        public bool AddTask(TaskManagerDetails taskDetails)
        {
            try
            {
                using (var repository = new TaskRepository())
                {
                    return repository.AddTask(taskDetails);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateTask(TaskManagerDetails taskDetails)
        {
            try
            {
                using (var repository = new TaskRepository())
                {
                    return repository.UpateTask(taskDetails);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           // return true;
        }

        public bool DeleteTask(int taskId)
        {
            try
            {
                using (var repository = new TaskRepository())
                {
                    return repository.DeleteTaskById(taskId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // return true;
        }


        public List<TaskManagerDetails> GetTask()
        {
            //List<TaskManagerDetails> details = new List<TaskManagerDetails>();
            try
            {
                using (var rep = new TaskRepository())
                {
                    var taskDetails = rep.GetTaskDetails();
                    return taskDetails;
                }
                //details.Add(new TaskManagerDetails
                //{
                //    Task_ID = 001,
                //    Task = "Task1",
                //    Parent_ID = 1001,
                //    Parent_Task = "ParentTask01",
                //    Priority = 05,
                //    Start_Date = DateTime.Now,
                //    End_Date = DateTime.Now
                //});
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return details;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
