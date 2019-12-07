namespace APITaskManager.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using APITaskManager.Model;

    public partial class TaskRepository: ITaskRepository<TaskManagerDetails>, IDisposable
    {
        public TaskRepository() { }
        public List<TaskManagerDetails> GetTaskDetails()
        {
            List<TaskManagerDetails> taskList;
            try
            {
                using (var context = new TaskDBContext())
                {
                    taskList = (from t in context.Tasks
                                select new TaskManagerDetails()
                                {
                                    Task_ID = t.Task_ID,
                                    Task = t.Task1,
                                    Parent_Task = t.ParentTask.Parent_Task,
                                    Priority = Convert.ToInt32(t.Priority),
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
