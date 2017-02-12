using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routine
{
    public class MyMockClass
    {
        public MyMockClass()
        {
            MyListBoxItems = new ObservableCollection<TaskView>();
            MyListBoxItems.Add(new TaskView("test text 1", 1));
            MyListBoxItems.Add(new TaskView("test text 2", 2));
        }
        public ObservableCollection<TaskView> MyListBoxItems { get; set; }
    }
}
