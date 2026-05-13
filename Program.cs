namespace HyRsn
{
    internal static class Program
    {
        internal static Form FormHR = new WinHR();
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(FormHR);
            
        }
    }
}