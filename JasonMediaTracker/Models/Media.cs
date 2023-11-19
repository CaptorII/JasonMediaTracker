using SQLite;
using System;

namespace JasonMediaTracker.Models
{
    public class Media
    {
        [PrimaryKey] public string title { get; set; }
        public bool isCompleted { get; set; }
        public DateTime releaseDate { get; set; }
    }
}
