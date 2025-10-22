using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    internal class TaskModel
    {
        string Name { get; set; }
        string Category { get; set; }
        string Description { get; set; }
        DateTime Date { get; set; }
        DateTime Time { get; set; }

        public TaskModel(string name, string category, string description, DateTime time, DateTime date)
        {
            Name = name;
            Category = category;
            Description = description;
            Date = date;
            Time = time;
        }


    }
}
