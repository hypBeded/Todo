using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TaskModel
    {
        public string Name { get; set; }
        string Category { get; set; }
        string Description { get; set; }
        DateTime Date { get; set; }
        DateTime Time { get; set; }
        bool Status {  get; set; }
       
    

        public TaskModel(string name, string category, string description, DateTime time, DateTime date, bool status)
        {
            Name = name;
            Category = category;
            Description = description;
            Date = date;
            Time = time;
            Status = status;
            
        }


    }
}
