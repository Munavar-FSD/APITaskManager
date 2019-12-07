namespace APITaskManager.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TaskDBContext : DbContext
    {
        public TaskDBContext()
            : base("name=TaskContext")
        {
        }

        public virtual DbSet<TaskRepository> ParentTasks { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskRepository>()
                .Property(e => e.Parent_Task)
                .IsUnicode(false);

            modelBuilder.Entity<TaskRepository>()
                .HasOptional(e => e.Task)
                .WithRequired(e => e.ParentTask);

            modelBuilder.Entity<Task>()
                .Property(e => e.Task1)
                .IsUnicode(false);
        }
    }
}
