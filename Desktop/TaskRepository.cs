using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Entities;

namespace Desktop
{
    public class TaskRepository
    {
        static private List<TaskModel> Tasks = new List<TaskModel>();
        public bool NewTask(string name, string category, string description, DateTime time, DateTime date, string status)
        {
            if (!Tasks.Exists(u => u.Name == name))
            {
                var newTask = new TaskModel(name, category, description, time, date, status);
                return true;
            }
            MessageBox.Show("Задача с таким именем уже существует");
            return false;
        }







    }
}
