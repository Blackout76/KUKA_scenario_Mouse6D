using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KukaTrajectory
{
    public partial class Menu : Form
    {
        private IHM_edit createIHM = new IHM_edit();
        public IHM_CreateJob createJob = new IHM_CreateJob();

        public Menu()
        {
            InitializeComponent();
            Thread ihmEngineThread = new Thread(new ThreadStart(updateRobotInfo));
            ihmEngineThread.Start();
        }


        private void BTN_menu_create_Click(object sender, EventArgs e)
        {
            if (this.createIHM.Visible)
                this.createIHM.Hide();
            else
                this.createIHM.Show();
            this.Hide();
        }

        public void setRobotInfo(bool actif, float speed, float rotSpeed, NLX.Robot.Kuka.Controller.CartesianPosition location)
        {
            this.createIHM.setRobotInfo(actif, speed, rotSpeed, location);
        }

        public void updateRobotInfo()
        {
            while (true)
            {
                if (Program.robot.isConnected())
                {
                    //this.createIHM.openAllRobotOperation();
                    setRobotInfo(Program.robot.isConnected(), Program.robot.getSpeed(), Program.robot.getRotSpeed(), Program.robot.getLocation());
                   
                }
                else
                {
                    //this.createIHM.closeAllRobotOperation();
                    setRobotInfo(Program.robot.isConnected(), Program.robot.getSpeed(), Program.robot.getRotSpeed(), null);
                }
                System.Threading.Thread.Sleep(50);
            }
        }
        public bool canRobotMoveFromMouse()
        {
            if (this.createIHM.Visible)
                return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            System.Environment.Exit(1);
        }

        private void BTN_menu_load_Click(object sender, EventArgs e)
        {
            if (this.createJob.Visible)
                this.createJob.Hide();
            else
                this.createJob.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Program.robot.isConnected())
                Program.robot.connect();
        }
    }
}
