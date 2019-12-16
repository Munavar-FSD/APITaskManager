using System;
using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using APITaskManager.Controllers;
using APITaskManager.Model;
using APITaskManager.BAL;
using APITaskManager.DAL;
using System.Collections.Generic;
using NUnit.Mocks;

namespace APITaskManager.Test
{
    [TestFixture]
    public class TaskManagerTest
    {
       // private DynamicMock taskRepositoryMock;
       // private List<TaskManagerDetails> taskList;
       //[SetUp]
       //public void TestInit()
       // {
       //     TaskManagerDetails taskdetails = new TaskManagerDetails()
       //     {
       //         Task = "New Task One",
       //         Parent_Task = "New Parent Task One",
       //         Priority = 5,
       //         Start_Date = DateTime.Now,
       //         End_Date = DateTime.Now
       //     };
       //     taskList.Add(taskdetails);
       //     taskRepositoryMock.ExpectAndReturn("GetTasks", taskList);
       //     TaskManagerBal bal = new TaskManagerBal((ITaskRepository<object)taskRepositoryMock.MockInstance);
       // }
        [Test]
        public void GetTask()
        {
            TaskManagerDetails taskdetails = new TaskManagerDetails()
            {
                Task = "New Task",
                Parent_Task = "New Parent Task",
                Priority = 5,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now
            };

            //TaskManagerBal taskBal = new TaskManagerBal();
            TaskManagerController taskController = new TaskManagerController();
            taskController.AddTaskManager(taskdetails);
            //taskBal.AddTask(taskdetails);

            List<TaskManagerDetails> result = taskController.GetAllTask();

            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.Count, 1);

        }

        [Test]
        public void AddTask()
        {
            TaskManagerDetails taskdetails = new TaskManagerDetails()
            {
                Task = "Add Task",
                Parent_Task = "Add Parent Task",
                Priority = 5,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now
            };

            TaskManagerController taskController = new TaskManagerController();
            bool result = taskController.AddTaskManager(taskdetails);
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void EditTask()
        {
            TaskManagerDetails taskdetails = new TaskManagerDetails()
            {
                Task_ID = 1003,
                Task = "Edit Task",
                Parent_Task = "Edit Parent Task",
                Priority = 5,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now
            };

            TaskManagerController taskController = new TaskManagerController();
            bool result = taskController.EditTaskManagerById(taskdetails);
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void DeleteTask()
        {
            TaskManagerDetails taskdetails = new TaskManagerDetails()
            {
                Task = "Delete Task",
                Parent_Task = "Delete Parent Task",
                Priority = 5,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now
            };

            TaskManagerController taskController = new TaskManagerController();
            taskController.AddTaskManager(taskdetails);

            List<TaskManagerDetails> resultGetTasks = taskController.GetAllTask();
            TaskManagerDetails selectedTask = resultGetTasks.Find(x => x.Task == "Delete Task");
            bool result = taskController.DeleteTaskManagerById(selectedTask.Task_ID);
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result);
        }
    }
}
