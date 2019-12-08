namespace APITaskManager.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<ParentTask> ParentTasks { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentTask>()
                .Property(e => e.Parent_Task)
                .IsUnicode(false);

            modelBuilder.Entity<ParentTask>()
                .HasOptional(e => e.Task)
                .WithRequired(e => e.ParentTask);

            modelBuilder.Entity<Task>()
                .Property(e => e.Task1)
                .IsUnicode(false);
        }
    }
}
