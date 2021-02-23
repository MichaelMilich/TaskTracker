using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TaskTracker
{
    /// <summary>
    /// This class should be the class that handles the logic behind the project.
    /// it should be able to say what is the FOREGROUND window and all the currently open windows.
    /// it should be able to log all the metadata about the windows - date opened (to the second), date closed (to the second) , time as foreground and time as background.
    /// In the fututre this will be my daily log. 
    /// 
    /// current work is to make this class follow and update itself everytime a new window is the foreground window.
    /// </summary>
    class ProcessList
    {
        private Process[] myProcesses;          // all the processes that are oen in the computer
        private string[,] processesData;        // the data i wanted for the processes. i dont know if this is the correct method to store the data.
        public List<Process> ActiveWindows;     // a list of all open windows .
        /// <summary>
        /// Starts the processList and collects all the data necessery. 
        /// </summary>
        public ProcessList()
        {
            ActiveWindows = new List<Process>();
            myProcesses= Process.GetProcesses();
            processesData = new string[myProcesses.Count(), 3];
            for(int i=0;i< myProcesses.Count(); i++)
            {
                processesData[i, 0] = myProcesses[i].ProcessName;               // the name of the process. should stay
                processesData[i, 1] = myProcesses[i].WorkingSet64.ToString();   // the working set of the process. should be changed to starting date.
                processesData[i, 2] = myProcesses[i].BasePriority.ToString();   // the base priority of the process. should be changed to date.
                /*                                      RANDOM DATA I TRIED TO COLLECT , THE PROGRAM THRW AN EXCEPTION - NO ENOUGH PREMMISION

                //   processesData[i, 3] = myProcesses[i].ProcessName;
                //   processesData[i, 4] = myProcesses[i].UserProcessorTime.ToString();
                //   processesData[i, 5] = myProcesses[i].PrivilegedProcessorTime.ToString();
                //   processesData[i, 6] = myProcesses[i].TotalProcessorTime.ToString();
                //   processesData[i, 7] = myProcesses[i].PagedSystemMemorySize64.ToString();
                */

                if (!String.IsNullOrEmpty(myProcesses[i].MainWindowTitle))      // Check if the process has a window title, if so add it to the list. 
                {
                    ActiveWindows.Add(myProcesses[i]);
                }
            }
        }
        public DataLine getProcessDataAtIndex(int i)
        {
            return new DataLine(processesData[i, 0], processesData[i, 1], processesData[i, 2]);
        }
        public int GetProcessesAmount()
        {
            return myProcesses.Count();
        }
    }
}
