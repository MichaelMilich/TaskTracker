using System;
using System.Collections.Generic;
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

namespace TaskTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This should be the part that handles only the GUI and not the logic. 
    /// In the future i want it to show me the windows i opened and when.
    /// I want it to put a special place for the FOREGROUND window.
    /// THIS IS CHANGE FOR THE REPOSETRY OF GIT!
    /// </summary>
    public partial class MainWindow : Window
    {
        ProcessList myProcesses;
        public MainWindow()
        {
            InitializeComponent();
            myProcesses = new ProcessList();
            DataLine temp;
            var activeWindows = myProcesses.ActiveWindows;
            int count = activeWindows.Count();
            for (int i=0; i<count;i++)
            {
                temp = new DataLine(activeWindows[i].ProcessName, activeWindows[i].WorkingSet64.ToString(), activeWindows[i].BasePriority.ToString());

                MyListView.Items.Add(temp);
            }
            this.Title = "amount of Apps open is currently :" + activeWindows.Count;
        }
        
    }
}
