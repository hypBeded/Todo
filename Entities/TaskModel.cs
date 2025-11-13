using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TaskModel : INotifyPropertyChanged
    {
        private string _name;
        private string _category;
        private string _description;
        private DateTime _date;
        private DateTime _time;
        private bool _status;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        public bool Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        // Для привязки в ListView
        public string TimeDisplay => Time.ToString("HH:mm");
        public string DateDisplay => Date.ToString("dd MMMM yyyy");

        public TaskModel(string name, string category, string description, DateTime time, DateTime date, bool status)
        {
            Name = name;
            Category = category;
            Description = description;
            Time = time;
            Date = date;
            Status = status;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
