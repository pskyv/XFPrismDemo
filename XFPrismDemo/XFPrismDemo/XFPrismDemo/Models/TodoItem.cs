using SQLite;
using System;

namespace XFPrismDemo.Models
{
    public class TodoItem
    {
        [PrimaryKey]
        public int Id { get; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsDone { get; set; }
    }
}
