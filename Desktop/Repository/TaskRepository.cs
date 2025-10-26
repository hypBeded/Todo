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
        public bool NewTask(UserModel user, string name, string category, string description, DateTime time, DateTime date, bool status)
        {

            if (user.UTasks.Exists(t => t.Name == name))
            {
                MessageBox.Show("Задача с таким именем уже существует");
                return false;
            }

            var newTask = new TaskModel(name, category, description, time, date, status);
            user.UTasks.Add(newTask); // Привязываем к пользователю
            return true;
        }







    }
}
