namespace WinFormsStarter
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AnyCAD.Foundation.GlobalInstance.Initialize();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            AnyCAD.Foundation.GlobalInstance.Destroy();
        }
    }
}