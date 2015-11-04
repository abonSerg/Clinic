using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Medicine.Clinic.Client;
using Medicine.Clinic.Client.Presentation;

namespace Medicine.Clinic.Client.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            var presenter = new MainPresenter(new Main());
            presenter.Run();       
        }
    }
}
