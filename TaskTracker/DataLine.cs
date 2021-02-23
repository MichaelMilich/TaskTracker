namespace TaskTracker
{
    /// <summary>
    /// a simple class to store relevant information to show on the viewList.
    /// To be changed and updated.
    /// </summary>
    public class DataLine
    {
        public string Name { get; set; }

        public string Work { get; set; }

        public string Base { get; set; }

        public DataLine()
        {

        }
        public DataLine(string[] args)
        {
            this.Name = args[0];
            this.Work = args[1];
            this.Base = args[2];
        }
        public DataLine(string name, string WorkingSet64, string BasePriority)
        {
            this.Name = name;
            this.Work = WorkingSet64;
            this.Base = BasePriority;
        }

    }
}
