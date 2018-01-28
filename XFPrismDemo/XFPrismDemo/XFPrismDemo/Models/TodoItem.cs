using SQLite;
using System;

namespace XFPrismDemo.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]                
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsDone { get; set; }
    }
}
