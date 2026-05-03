namespace ShoppingClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();


            try
            {
                Application.Run(new LoginForm());
            }
            finally
            {
                // Perform cleanup on application exit
                Application.Exit();
            }
        }
    }
}
