namespace APITaskManager.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ParentTask")]
    public partial class TaskRepository
    {
        [Key]
        public int Parent_ID { get; set; }

        [StringLength(50)]
        public string Parent_Task { get; set; }

        public virtual Task Task { get; set; }
    }
}
