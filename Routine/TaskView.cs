using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routine
{
    public class TaskView : INotifyPropertyChanged
    {
        private Task Task;

        public event PropertyChangedEventHandler PropertyChanged;

        private bool isChecked;
        public bool IsChecked {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        public TaskView () { }

        public TaskView (String label, int period)
        {
            Task = new Task(label, period);
        }

        public TaskView (String label, int period, PropertyChangedEventHandler p) : this(label, period)
        {
            PropertyChanged += p;
        }

        public String Label
        {
            get
            {
                return Task.Label;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
