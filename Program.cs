using sims.Admin_Side;
using sims.Admin_Side.Stocks;
using sims.Splash_page_and_Loading_Screen;
using sims.Staff_Side;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DashboardOwner());
        }
    }
}
