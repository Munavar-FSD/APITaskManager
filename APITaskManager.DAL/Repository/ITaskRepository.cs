namespace APITaskManager.DAL
{
    using APITaskManager.Model;
    using System;
    using System.Collections.Generic;

    public interface ITaskRepository<TEnity> where TEnity:class
    {
        List<TEnity> GetTaskDetails();
        bool AddTask(TaskManagerDetails taskModel);
        bool UpateTask(TaskManagerDetails taskModel);
        bool DeleteTaskById(int id);
    }
}
