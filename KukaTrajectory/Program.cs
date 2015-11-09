using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KukaTrajectory
{
    static class Program
    {
        public static Robot robot;
        public static Menu ihm;
        public static Mouse3D mouse3D;
        public static Data data;
        public static Engine_Scenario engineScenario = new Engine_Scenario();

        [STAThread]
        static void Main()
        {
            Console.WriteLine("Program start ...");
            data = new Data();
            robot = new Robot();
            mouse3D = new Mouse3D();
            Console.WriteLine("Program is running!");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ihm = new Menu();
            Application.Run(ihm);
            
        }
    }
}
