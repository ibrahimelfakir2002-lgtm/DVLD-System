using DVLDPresentationLayer.Applications.Application_Types;
using DVLDPresentationLayer.Applications.Local_Driving_License;
using DVLDPresentationLayer.Login;
using DVLDPresentationLayer.People;
using DVLDPresentationLayer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLDPresentationLayer
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
            Application.Run(new frmLogin());
        }
    }
}
