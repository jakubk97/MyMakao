using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Makao
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Model model = new Model();
            IView view = new Form1();
            Presenter presenter = new Presenter(view, model);
            Application.Run((Form1)view);
        }
    }
}
