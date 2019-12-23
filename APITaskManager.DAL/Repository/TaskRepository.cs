namespace APITaskManager.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using APITaskManager.Model;

    public partial class TaskRepository: ITaskRepository<TaskManagerDetails>, IDisposable
    {
        //public TaskRepository() { }
        public List<TaskManagerDetails> GetTaskDetails()
        {
            List<TaskManagerDetails> taskList;
            try
            {
                using (var context = new DBContext())
                {
                    taskList = (from t in context.Tasks
                                select new TaskManagerDetails()
                                {
                                    Task_ID = t.Task_ID,
                                    Parent_ID = t.Parent_ID,
                                    Task = t.Task1,
                                    Parent_Task = t.ParentTask.Parent_Task,
                                    Priority = t.Priority,
                                    Start_Date = t.Start_Date,
                                    End_Date = t.End_Date
                                }).ToList();

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return taskList;
        }

        public bool AddTask(TaskManagerDetails taskModel)
        {
           // ParentTask addParentTask;
            try
            {
                using (var context = new DBContext())
                {
                    Task addTask = new Task()
                    {
                        Task_ID = taskModel.Task_ID,
                        Parent_ID = taskModel.Parent_ID,
                        Task1 = taskModel.Task,
                        Start_Date = taskModel.Start_Date,
                        End_Date = taskModel.End_Date,
                        Priority = taskModel.Priority,
                        ParentTask = new ParentTask()
                        {
                            Parent_ID = taskModel.Parent_ID,
                            Parent_Task = taskModel.Parent_Task

                        }
                    };
                    context.Tasks.Add(addTask);
                    context.SaveChanges();
                    return true;
                    //ParentTask addParentTask = new ParentTask()
                    //{
                    //    Parent_ID = taskModel.TaskManagerDetails.Parent_ID,
                    //    Parent_Task = taskModel.TaskManagerDetails.Parent_Task

                    //};

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return taskList;
        }

        public bool UpateTask(TaskManagerDetails taskModel)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var model = (from task in context.Tasks
                                 where task.Task_ID == taskModel.Task_ID
                                 select task).FirstOrDefault();
                    if (taskModel == null)
                    {
                        return false;
                    }
                    model.Task1 = taskModel.Task;
                    model.Priority = taskModel.Priority;
                    model.Start_Date = taskModel.Start_Date;
                    model.End_Date = taskModel.End_Date;

                    context.Tasks.Add(model);
                    context.Entry(model).State = EntityState.Modified;
                    context.SaveChanges();
                }

                using (var contextdb = new DBContext())
                {
                    if (taskModel.Parent_Task != null)
                    {
                        var parentModel = (from task in contextdb.ParentTasks
                                           where task.Parent_ID == taskModel.Parent_ID
                                           select task).FirstOrDefault();
                        if (parentModel == null)
                        {
                            return false;
                        }
                        parentModel.Parent_Task = taskModel.Parent_Task;

                        contextdb.ParentTasks.Add(parentModel);

                        contextdb.Entry(parentModel).State = EntityState.Modified;
                        contextdb.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool DeleteTaskById(int id)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var taskDetails = (from task in context.Tasks
                                       where task.Task_ID == id
                                       select task).FirstOrDefault();

                    if (taskDetails == null)
                    {
                        return false;
                    }
                    context.Tasks.Remove(taskDetails);
                    context.Entry(taskDetails).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
