using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KukaTrajectory
{
    public partial class IHM_CreateJob : Form
    {
        public IHM_CreateJob()
        {
            InitializeComponent();
            updateScenaList();
        }

        private void BTN_move_area_0_Click(object sender, EventArgs e)
        {
            Program.robot.clearTrajectory();
            Program.robot.addCartesianPointToTrajectory(Program.data.getAreas().ElementAt(0).getP0());
            Program.robot.sendTrajectory();
        }

        private void BTN_move_area_1_Click(object sender, EventArgs e)
        {
            Program.robot.clearTrajectory();
            Program.robot.addCartesianPointToTrajectory(Program.data.getAreas().ElementAt(1).getP0());
            Program.robot.sendTrajectory();
        }

        private void BTN_move_area_2_Click(object sender, EventArgs e)
        {
            Program.robot.clearTrajectory();
            Program.robot.addCartesianPointToTrajectory(Program.data.getAreas().ElementAt(2).getP0());
            Program.robot.sendTrajectory();
        }

        private void BTN_Play_trajectory_test_out_Click(object sender, EventArgs e)
        {
            Program.robot.clearTrajectory();
            foreach (Data_State s in Program.data.getTrajectories().ElementAt(3).getPath())
                Program.robot.addCartesianPointToTrajectory(s.getLocation());
            Program.robot.sendTrajectory();
        }

        private void BTN_Play_trajectory_test_Click(object sender, EventArgs e)
        {
            Program.robot.clearTrajectory();
            foreach (Data_State s in Program.data.getTrajectories().ElementAt(2).getPath())
                Program.robot.addCartesianPointToTrajectory(s.getLocation());
            Program.robot.sendTrajectory();
        }

        private void BTN_load_scena_start_Click(object sender, EventArgs e)
        {
            if(this.LIST_scenarios.SelectedItem != null)
                Program.engineScenario.startScenario(this.LIST_scenarios.SelectedItem.ToString());
        }

        private void BTN_load_scena_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.ihm.Show();
        }

        public void updateScenaList()
        {
            this.LIST_scenarios.Items.Clear();
            foreach (Data_Scenario s in Program.data.getSecnarios())
            {
                this.LIST_scenarios.Items.Add(s.getname());
            }
        }
    }
}
