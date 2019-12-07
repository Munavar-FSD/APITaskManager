namespace APITaskManager.DAL
{
    using System;
    using System.Collections.Generic;

    public interface ITaskRepository<TEnity> where TEnity:class
    {
        List<TEnity> GetTaskDetails();
    }
}
