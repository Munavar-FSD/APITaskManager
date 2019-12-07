using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APITaskManager.Model;
using System.Data.Entity;
using System.Web.Http.Results;
using APITaskManager.BAL;
using System.Web.Http.Cors;

namespace APITaskManager.Controllers
{
    [RoutePrefix("api/Task")]
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class TaskManagerController : ApiController
    {
        //static TaskManagerModel TaskDbContext;
        //static DbContext dbContext;
        
        public TaskManagerController()
        {
            //TaskDbContext = new TaskManagerModel();
        }

        [HttpGet]
        [Route("AllTask")]
        //public IList<TaskManagerModel> GetAllTaskManager()
        public List<TaskManagerDetails> GetAllTask()
        {
            //IList<TaskManagerDetails> lsttaskManagers = new List<TaskManagerDetails>();
            //TaskManagerDetails taskModel = new TaskManagerDetails();
            //taskModel.Parent_ID = 1;
            //taskModel.Task_ID = 1001;
            //taskModel.Parent_Task = "Task 1";
            //taskModel.Start_Date = Convert.ToDateTime("01/01/2019");
            //taskModel.End_Date = Convert.ToDateTime("12/01/2019");
            //taskModel.Priority = 15;
            //lsttaskManagers.Add(taskModel);
            //taskModel.Parent_ID = TaskDbContext.Parent_ID;
            //taskModel.Parent_Task = TaskDbContext.Parent_Task;
            //taskModel.Task = TaskDbContext.Task;
            //taskModel.Start_Date = TaskDbContext.Start_Date;
            //taskModel.End_Date = TaskDbContext.End_Date;
            //taskModel.Priority = TaskDbContext.Priority;
            //return lsttaskManagers;

            // return TaskDbContext.TaskManagerList.ToList();
            using (var taskList = new TaskManagerBal()) {
                return taskList.GetTask();
            }

        }

        [HttpGet]
        [Route("Test")]
        public string GetTest()
        {
            
            return "Test";
        }

        [HttpGet]
        [Route("TaskById")]
        public TaskManagerDetails GetTaskManagerById(int TaskID)
        {
            TaskManagerDetails taskManager = new TaskManagerDetails();
            taskManager = null;//TaskDbContext.TaskManagerList.Find(t => t.Task_ID == TaskID);
            return taskManager;
        }

        [HttpPost]
        [Route("AddTaskById")]
        public bool AddTaskManagerById(TaskManagerDetails TaskManager)
        {
            bool status = false;
            if (TaskManager != null)
            {
                //TaskDbContext.TaskManagerList.Add(TaskManager);
                status = true;
            }
            return status;
        }

        [HttpPut]
        [Route("EditTaskById")]
        public bool EditTaskManagerById(TaskManagerModel TaskManager)
        {
            //TaskManagerDetails taskDetails = TaskDbContext.TaskManagerList.Find(t => t.Task_ID == TaskManager.Task_ID);

            //if (taskDetails != null)
            //{

            //}
            //else
            //{

            //}
            return false;
        }

        [HttpDelete]
        [Route("DeleteTaskById")]
        public bool DeleteTaskManagerById(TaskManagerModel TaskManager)
        {
            return false;
        }
    }
}
