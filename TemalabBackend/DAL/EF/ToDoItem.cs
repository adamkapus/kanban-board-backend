using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TemalabBackend.DAL.EF
{
    public class ToDoItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
        public string Category { get; set; }
        public int CategoryPos { get; set; }
    }
}
