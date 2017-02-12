using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Routine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<TaskView> TasksList = new List<TaskView>();
        public int Completion
        { 
            get
            {
                int max = TasksList.Count;
                return (max == 0) ? max : (TasksList.Count(n => n.IsChecked == true)*100) / max;
            }
        }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            listBoxTasks.ItemsSource = TasksList;
            progressBarDone.IsIndeterminate = false;
        }

        private void setAddView()
        {
            stackPanelAdd.Visibility = Visibility.Visible;
            dockPanelMain.Visibility = Visibility.Collapsed;
        }
        private void setTasksView()
        {
            textBoxLabel.Text = String.Empty;
            textBoxPeriod.Text = String.Empty;
            stackPanelAdd.Visibility = Visibility.Collapsed;
            dockPanelMain.Visibility = Visibility.Visible;
        }

        private void addToTaskList(TaskView v)
        {
            // Black Magic
            listBoxTasks.ItemsSource = null;
            TasksList.Add(v);
            listBoxTasks.ItemsSource = TasksList;
            // end Black Magic

            OnPropertyChanged("TaskList");
        }

        #region INotifyPropertyChanged
        private void taskViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChecked")
                OnPropertyChanged("Completion");
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Events
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            setAddView();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            UInt16 period;
            if (UInt16.TryParse(textBoxPeriod.Text, out period))
            {
                addToTaskList(new TaskView(textBoxLabel.Text, period, taskViewPropertyChanged));
                labelPeriod.Foreground = Brushes.Black;
                setTasksView();
            }
            else
            { 
                labelPeriod.Foreground = Brushes.Red;
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            setTasksView();
        }
        #endregion
    }
}
