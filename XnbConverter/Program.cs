using System;
using System.Windows.Forms;

namespace XnbConverter
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());

            /*
            using (var game = new Game1())
                game.Run();
                */
        }
    }
}
