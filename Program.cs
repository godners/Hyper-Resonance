namespace HyRsn
{
    internal static class Program
    {
        internal static Form FormHR = new WinHR();
        [STAThread]
        internal static void Main()
        {            
            ApplicationConfiguration.Initialize();            
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            Application.Run(FormHR);
        }
    }
}