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
    public partial class IHM_edit : Form
    {

        delegate void SetEnableCallback(bool val);
        delegate void SetTextCallback(string text);
        private List<Data_State> tmpStates = new List<Data_State>();
        private Data_Area tmpArea = new Data_Area();
        private Data_Scenario tmpScenario = new Data_Scenario();
        

        public IHM_edit()
        {
            InitializeComponent();
            updateAreaList();
            updateTrajectoryList();
            updateScenaList();
            /*
            this.COMBOBOX_create_scena_choiceAction.Items.Add("Gripper");
            this.COMBOBOX_create_scena_choiceAction.Items.Add("Move");
            this.COMBOBOX_create_scena_choiceAction.Items.Add("Stock");*/
        }

        private void BTN_create_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.ihm.Show();
        }

        private void BTN_create_save_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.ihm.Show();
        }

        public void setRobotInfo(bool actif, float speed, float rotSpeed, NLX.Robot.Kuka.Controller.CartesianPosition location)
        {
            if (actif)
            {
                setText_TEXTBOX_create_speedMotion(speed.ToString());
                setText_TEXTBOX_create_rotMotion(rotSpeed.ToString());
                setText_TEXTBOX_create_A(location.A.ToString());
                setText_TEXTBOX_create_B(location.B.ToString());
                setText_TEXTBOX_create_C(location.C.ToString());
                setText_TEXTBOX_create_x(location.X.ToString());
                setText_TEXTBOX_create_y(location.Y.ToString());
                setText_TEXTBOX_create_z(location.Z.ToString());

                openAllRobotOperation();
            }
            else
                closeAllRobotOperation();
            
        }

        private void BTN_create_robot_move_minus_Click(object sender, EventArgs e)
        {
            Program.robot.decrementSpeed();
        }

        private void BTN_create_robot_move_plus_Click(object sender, EventArgs e)
        {
            Program.robot.incrementSpeed();
        }

        private void BTN_create_robot_rot_minus_Click(object sender, EventArgs e)
        {
            Program.robot.decrementRot();
        }
        private void BTN_create_robot_rot_plus_Click(object sender, EventArgs e)
        {
            Program.robot.incrementRot();
        }
        public void closeAllRobotOperation()
        {/*
            Enable_BTN_create_addPoint(false);
            Enable_BTN_create_save(false);
            Enable_BTN_create_robot_move_plus(false);
            Enable_BTN_create_robot_move_minus(false);
            Enable_TEXTBOX_create_speedMotion(false);
            Enable_BTN_create_robot_rot_plus(false);
            Enable_BTN_create_robot_rot_minus(false);
            Enable_TEXTBOX_create_rotMotion(false);
            Enable_TEXTBOX_create_A(false);
            Enable_TEXTBOX_create_B(false);
            Enable_TEXTBOX_create_C(false);
            Enable_TEXTBOX_create_x(false);
            Enable_TEXTBOX_create_y(false);
            Enable_TEXTBOX_create_z(false);
            */
            Enable_BTN_create_addPoint(true);
            Enable_BTN_create_save(true);
            Enable_BTN_create_robot_move_plus(true);
            Enable_BTN_create_robot_move_minus(true);
            Enable_TEXTBOX_create_speedMotion(true);
            Enable_BTN_create_robot_rot_plus(true);
            Enable_BTN_create_robot_rot_minus(true);
            Enable_TEXTBOX_create_rotMotion(true);
            Enable_TEXTBOX_create_A(true);
            Enable_TEXTBOX_create_B(true);
            Enable_TEXTBOX_create_C(true);
            Enable_TEXTBOX_create_x(true);
            Enable_TEXTBOX_create_y(true);
            Enable_TEXTBOX_create_z(true);
        }

        public void openAllRobotOperation()
        {
            Enable_BTN_create_addPoint(true);
            Enable_BTN_create_save(true);
            Enable_BTN_create_robot_move_plus(true);
            Enable_BTN_create_robot_move_minus(true);
            Enable_TEXTBOX_create_speedMotion(true);
            Enable_BTN_create_robot_rot_plus(true);
            Enable_BTN_create_robot_rot_minus(true);
            Enable_TEXTBOX_create_rotMotion(true);
            Enable_TEXTBOX_create_A(true);
            Enable_TEXTBOX_create_B(true);
            Enable_TEXTBOX_create_C(true);
            Enable_TEXTBOX_create_x(true);
            Enable_TEXTBOX_create_y(true);
            Enable_TEXTBOX_create_z(true);
        }

        /**
        * CALL BACK FUNCTIONS
        */

        private void setText_TEXTBOX_create_speedMotion(string text)
        {
            if (this.TEXTBOX_create_speedMotion.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setText_TEXTBOX_create_speedMotion);
                this.Invoke(d, new object[] { text });
            }
            else
                this.TEXTBOX_create_speedMotion.Text = text;
        }
        private void setText_TEXTBOX_create_rotMotion(string text)
        {
            if (this.TEXTBOX_create_rotMotion.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setText_TEXTBOX_create_rotMotion);
                this.Invoke(d, new object[] { text });
            }
            else
                this.TEXTBOX_create_rotMotion.Text = text;
        }
        private void setText_TEXTBOX_create_A(string text)
        {
            if (this.TEXTBOX_create_A.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setText_TEXTBOX_create_A);
                this.Invoke(d, new object[] { text });
            }
            else
                this.TEXTBOX_create_A.Text = text;
        }
        private void setText_TEXTBOX_create_B(string text)
        {
            if (this.TEXTBOX_create_B.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setText_TEXTBOX_create_B);
                this.Invoke(d, new object[] { text });
            }
            else
                this.TEXTBOX_create_B.Text = text;
        }
        private void setText_TEXTBOX_create_C(string text)
        {
            if (this.TEXTBOX_create_C.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setText_TEXTBOX_create_C);
                this.Invoke(d, new object[] { text });
            }
            else
                this.TEXTBOX_create_C.Text = text;
        }
        private void setText_TEXTBOX_create_x(string text)
        {
            if (this.TEXTBOX_create_x.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setText_TEXTBOX_create_x);
                this.Invoke(d, new object[] { text });
            }
            else
                this.TEXTBOX_create_x.Text = text;
        }
        private void setText_TEXTBOX_create_y(string text)
        {
            if (this.TEXTBOX_create_y.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setText_TEXTBOX_create_y);
                this.Invoke(d, new object[] { text });
            }
            else
                this.TEXTBOX_create_y.Text = text;
        }
        private void setText_TEXTBOX_create_z(string text)
        {
            if (this.TEXTBOX_create_z.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setText_TEXTBOX_create_z);
                this.Invoke(d, new object[] { text });
            }
            else
                this.TEXTBOX_create_z.Text = text;
        }

        private void Enable_BTN_create_addPoint(bool val)
        {
            if (this.BTN_create_addPoint.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_BTN_create_addPoint);
                this.Invoke(d, new object[] { val });
            }
            else
                this.BTN_create_addPoint.Enabled = val;
        }
        private void Enable_BTN_create_save(bool val)
        {
            if (this.BTN_create_addTrajectory.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_BTN_create_save);
                this.Invoke(d, new object[] { val });
            }
            else
                this.BTN_create_addTrajectory.Enabled = val;
        }
        private void Enable_BTN_create_robot_move_plus(bool val)
        {
            if (this.BTN_create_robot_move_plus.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_BTN_create_robot_move_plus);
                this.Invoke(d, new object[] { val });
            }
            else
                this.BTN_create_robot_move_plus.Enabled = val;
        }
        private void Enable_BTN_create_robot_move_minus(bool val)
        {
            if (this.BTN_create_robot_move_minus.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_BTN_create_robot_move_minus);
                this.Invoke(d, new object[] { val });
            }
            else
                this.BTN_create_robot_rot_minus.Enabled = val;
        }
        private void Enable_TEXTBOX_create_speedMotion(bool val)
        {
            if (this.TEXTBOX_create_rotMotion.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_TEXTBOX_create_speedMotion);
                this.Invoke(d, new object[] { val });
            }
            else
                this.TEXTBOX_create_speedMotion.Enabled = val;
        }
        private void Enable_BTN_create_robot_rot_plus(bool val)
        {
            if (this.BTN_create_robot_rot_plus.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_BTN_create_robot_rot_plus);
                this.Invoke(d, new object[] { val });
            }
            else
                this.BTN_create_robot_rot_plus.Enabled = val;
        }
        private void Enable_BTN_create_robot_rot_minus(bool val)
        {
            if (this.BTN_create_robot_rot_minus.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_BTN_create_robot_rot_minus);
                this.Invoke(d, new object[] { val });
            }
            else
                this.BTN_create_robot_rot_minus.Enabled = val;
        }
        private void Enable_TEXTBOX_create_rotMotion(bool val)
        {
            if (this.TEXTBOX_create_rotMotion.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_TEXTBOX_create_rotMotion);
                this.Invoke(d, new object[] { val });
            }
            else
                this.TEXTBOX_create_rotMotion.Enabled = val;
        }
        private void Enable_TEXTBOX_create_A(bool val)
        {
            if (this.TEXTBOX_create_A.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_TEXTBOX_create_A);
                this.Invoke(d, new object[] { val });
            }
            else
                this.TEXTBOX_create_A.Enabled = val;
        }
        private void Enable_TEXTBOX_create_B(bool val)
        {
            if (this.TEXTBOX_create_B.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_TEXTBOX_create_B);
                this.Invoke(d, new object[] { val });
            }
            else
                this.TEXTBOX_create_B.Enabled = val;
        }
        private void Enable_TEXTBOX_create_C(bool val)
        {
            if (this.TEXTBOX_create_C.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_TEXTBOX_create_C);
                this.Invoke(d, new object[] { val });
            }
            else
                this.TEXTBOX_create_C.Enabled = val;
        }
        private void Enable_TEXTBOX_create_x(bool val)
        {
            if (this.TEXTBOX_create_x.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_TEXTBOX_create_x);
                this.Invoke(d, new object[] { val });
            }
            else
                this.TEXTBOX_create_x.Enabled = val;
        }
        private void Enable_TEXTBOX_create_y(bool val)
        {
            if (this.TEXTBOX_create_y.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_TEXTBOX_create_y);
                this.Invoke(d, new object[] { val });
            }
            else
                this.TEXTBOX_create_y.Enabled = val;
        }
        private void Enable_TEXTBOX_create_z(bool val)
        {
            if (this.TEXTBOX_create_z.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(Enable_TEXTBOX_create_z);
                this.Invoke(d, new object[] { val });
            }
            else
                this.TEXTBOX_create_z.Enabled = val;
        }

        private void CHECKBOX_create_gripper_Click(object sender, EventArgs e)
        {
            if (CHECKBOX_create_gripper.Checked)
                Program.robot.closeGripper();
            else
                Program.robot.openGripper();
        }

        private void BTN_create_addPoint_Click(object sender, EventArgs e)
        {
            if( this.TEXTBOX_create_x.Text != null &&
                this.TEXTBOX_create_y.Text != null &&
                this.TEXTBOX_create_z.Text != null &&
                this.TEXTBOX_create_A.Text != null &&
                this.TEXTBOX_create_B.Text != null &&
                this.TEXTBOX_create_C.Text != null)
            {

                Data_State state = new Data_State(this.list_create_points.Items.Count,
                                            Convert.ToDouble(this.TEXTBOX_create_x.Text),
                                            Convert.ToDouble(this.TEXTBOX_create_y.Text),
                                            Convert.ToDouble(this.TEXTBOX_create_z.Text),
                                            Convert.ToDouble(this.TEXTBOX_create_A.Text),
                                            Convert.ToDouble(this.TEXTBOX_create_B.Text),
                                            Convert.ToDouble(this.TEXTBOX_create_C.Text),
                                            this.CHECKBOX_create_gripper.Checked
                                            );
                tmpStates.Add(state);
                this.list_create_points.Items.Add(state.ToString());
                this.LABEL_create_nbPoints.Text = this.list_create_points.Items.Count.ToString();
            }
        }

        private void BTN_create_addTrajectory_Click(object sender, EventArgs e)
        {
            if (tmpStates.Count > 0 && !this.TEXTBOX_create_trajectoryName.Text.Equals(""))
            {
                Data_Trajectory trajectory = new Data_Trajectory(Program.data.getTrajectories().Count, tmpStates, this.TEXTBOX_create_trajectoryName.Text);
                Program.data.addTrajectory(trajectory);
                updateTrajectoryList();
                clearListPoints();
            }
        }

        public void clearListPoints()
        {
            this.tmpStates = new List<Data_State>();
            this.list_create_points.Items.Clear();
            this.TEXTBOX_create_trajectoryName.Text = "";
        }

        public void updateTrajectoryList()
        {
            this.list_trajectories.Items.Clear();
            this.COMBOBOX_create_scena_move_trajectoryList.Items.Clear();
            foreach(Data_Trajectory t in Program.data.getTrajectories())
            {
                this.list_trajectories.Items.Add(t.toString());
                this.COMBOBOX_create_scena_move_trajectoryList.Items.Add(t.getName());
            }
        }

        private void BTN_remove_trajectory_Click(object sender, EventArgs e)
        {
            for (int i= 0;i<this.list_trajectories.Items.Count; i++)
                if (this.list_trajectories.GetSelected(i))
                {
                    this.list_trajectories.Items.RemoveAt(i);
                    Program.data.removeTrajectoryID(i);
                    return;
                }
        }

        private void BTN_remove_point_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.list_create_points.Items.Count; i++)
                if (this.list_create_points.GetSelected(i))
                {
                    this.list_create_points.Items.RemoveAt(i);
                    this.tmpStates.RemoveAt(i);
                    return;
                }
        }

        private void BTN_create_area_setP0_Click(object sender, EventArgs e)
        {
            this.TEXTBOX_create_area_P0_x.Text = this.TEXTBOX_create_x.Text;
            this.TEXTBOX_create_area_P0_y.Text = this.TEXTBOX_create_y.Text;
            this.TEXTBOX_create_area_P0_z.Text = this.TEXTBOX_create_z.Text;
            this.TEXTBOX_create_area_P0_a.Text = this.TEXTBOX_create_A.Text;
            this.TEXTBOX_create_area_P0_b.Text = this.TEXTBOX_create_B.Text;
            this.TEXTBOX_create_area_P0_c.Text = this.TEXTBOX_create_C.Text;
            this.tmpArea.setP0(
                Convert.ToDouble(this.TEXTBOX_create_area_P0_x.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P0_y.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P0_z.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P0_a.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P0_b.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P0_c.Text));
        }

        private void BTN_create_area_setP1_Click(object sender, EventArgs e)
        {
            this.TEXTBOX_create_area_P1_x.Text = this.TEXTBOX_create_x.Text;
            this.TEXTBOX_create_area_P1_y.Text = this.TEXTBOX_create_y.Text;
            this.TEXTBOX_create_area_P1_z.Text = this.TEXTBOX_create_z.Text;
            this.TEXTBOX_create_area_P1_a.Text = this.TEXTBOX_create_A.Text;
            this.TEXTBOX_create_area_P1_b.Text = this.TEXTBOX_create_B.Text;
            this.TEXTBOX_create_area_P1_c.Text = this.TEXTBOX_create_C.Text;
            this.tmpArea.setP1(
                Convert.ToDouble(this.TEXTBOX_create_area_P1_x.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P1_y.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P1_z.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P1_a.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P1_b.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P1_c.Text));
        }

        private void BTN_create_area_setP2_Click(object sender, EventArgs e)
        {
            this.TEXTBOX_create_area_P2_x.Text = this.TEXTBOX_create_x.Text;
            this.TEXTBOX_create_area_P2_y.Text = this.TEXTBOX_create_y.Text;
            this.TEXTBOX_create_area_P2_z.Text = this.TEXTBOX_create_z.Text;
            this.TEXTBOX_create_area_P2_a.Text = this.TEXTBOX_create_A.Text;
            this.TEXTBOX_create_area_P2_b.Text = this.TEXTBOX_create_B.Text;
            this.TEXTBOX_create_area_P2_c.Text = this.TEXTBOX_create_C.Text;
            this.tmpArea.setP2(
                Convert.ToDouble(this.TEXTBOX_create_area_P2_x.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P2_y.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P2_z.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P2_a.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P2_b.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P2_c.Text));
        }

        private void BTN_create_area_setP3_Click(object sender, EventArgs e)
        {
            this.TEXTBOX_create_area_P3_x.Text = this.TEXTBOX_create_x.Text;
            this.TEXTBOX_create_area_P3_y.Text = this.TEXTBOX_create_y.Text;
            this.TEXTBOX_create_area_P3_z.Text = this.TEXTBOX_create_z.Text;
            this.TEXTBOX_create_area_P3_a.Text = this.TEXTBOX_create_A.Text;
            this.TEXTBOX_create_area_P3_b.Text = this.TEXTBOX_create_B.Text;
            this.TEXTBOX_create_area_P3_c.Text = this.TEXTBOX_create_C.Text;
            this.tmpArea.setP3(
                Convert.ToDouble(this.TEXTBOX_create_area_P3_x.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P3_y.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P3_z.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P3_a.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P3_b.Text),
                Convert.ToDouble(this.TEXTBOX_create_area_P3_c.Text));
        }

        private void BTN_create_area_removeArea_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.list_areas.Items.Count; i++)
                if (this.list_areas.GetSelected(i))
                {
                    this.list_areas.Items.RemoveAt(i);
                    Program.data.removeAreasID(i);
                    return;
                }
        }

        private void BTN_create_area_addArea_Click(object sender, EventArgs e)
        {
            if (!this.TEXTBOX_create_area_name.Text.Equals("")
                && Convert.ToDouble(this.TEXTBOX_create_area_nbx.Text) >= 2
                && Convert.ToDouble(this.TEXTBOX_create_area_nby.Text) >= 2)
            {
                tmpArea.setName(this.TEXTBOX_create_area_name.Text);
                tmpArea.setMonoPoint(this.CHECKBOX_create_area_monoPoint.Checked);
                tmpArea.setId(this.list_areas.Items.Count);
                tmpArea.setNB_x(Convert.ToInt16(this.TEXTBOX_create_area_nbx.Text));
                tmpArea.setNB_y(Convert.ToInt16(this.TEXTBOX_create_area_nby.Text));
                this.tmpArea.setP0(
                    Convert.ToDouble(this.TEXTBOX_create_area_P0_x.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P0_y.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P0_z.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P0_a.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P0_b.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P0_c.Text));
                this.tmpArea.setP1(
                    Convert.ToDouble(this.TEXTBOX_create_area_P1_x.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P1_y.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P1_z.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P1_a.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P1_b.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P1_c.Text));
                this.tmpArea.setP2(
                    Convert.ToDouble(this.TEXTBOX_create_area_P2_x.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P2_y.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P2_z.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P2_a.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P2_b.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P2_c.Text));
                this.tmpArea.setP3(
                    Convert.ToDouble(this.TEXTBOX_create_area_P3_x.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P3_y.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P3_z.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P3_a.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P3_b.Text),
                    Convert.ToDouble(this.TEXTBOX_create_area_P3_c.Text));
                Program.data.addAreas(new Data_Area(tmpArea));
                updateAreaList();
                this.TEXTBOX_create_area_name.Text = "";
                this.TEXTBOX_create_area_nbx.Text = "2";
                this.TEXTBOX_create_area_nby.Text = "2";
            }
        }
        public void updateAreaList()
        {
            this.list_areas.Items.Clear();
            this.COMBOBOX_create_scena_areaList.Items.Clear();
            foreach (Data_Area t in Program.data.getAreas())
            {
                this.list_areas.Items.Add(t.toString());
                this.COMBOBOX_create_scena_areaList.Items.Add(t.getName());
            }
        }

        private void BTN_create_save_Click_1(object sender, EventArgs e)
        {
            Program.data.save();
            this.Hide();
            Program.ihm.Show();
        }

        private void CHECKBOX_create_area_monoPoint_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CHECKBOX_create_area_monoPoint.Checked)
            {
                this.label24.Hide();
                this.TEXTBOX_create_area_nbx.Hide();
                this.label25.Hide();
                this.TEXTBOX_create_area_nby.Hide();

                this.label22.Hide();
                this.TEXTBOX_create_area_P2_x.Hide();
                this.TEXTBOX_create_area_P2_y.Hide();
                this.TEXTBOX_create_area_P2_z.Hide();
                this.TEXTBOX_create_area_P2_a.Hide();
                this.TEXTBOX_create_area_P2_b.Hide();
                this.TEXTBOX_create_area_P2_c.Hide();
                this.BTN_create_area_setP2.Hide();

                this.label23.Hide();
                this.TEXTBOX_create_area_P3_x.Hide();
                this.TEXTBOX_create_area_P3_y.Hide();
                this.TEXTBOX_create_area_P3_z.Hide();
                this.TEXTBOX_create_area_P3_a.Hide();
                this.TEXTBOX_create_area_P3_b.Hide();
                this.TEXTBOX_create_area_P3_c.Hide();
                this.BTN_create_area_setP3.Hide();
            }
            else
            {
                this.label24.Show();
                this.TEXTBOX_create_area_nbx.Show();
                this.label25.Show();
                this.TEXTBOX_create_area_nby.Show();

                this.label22.Show();
                this.TEXTBOX_create_area_P2_x.Show();
                this.TEXTBOX_create_area_P2_y.Show();
                this.TEXTBOX_create_area_P2_z.Show();
                this.TEXTBOX_create_area_P2_a.Show();
                this.TEXTBOX_create_area_P2_b.Show();
                this.TEXTBOX_create_area_P2_c.Show();
                this.BTN_create_area_setP2.Show();

                this.label23.Show();
                this.TEXTBOX_create_area_P3_x.Show();
                this.TEXTBOX_create_area_P3_y.Show();
                this.TEXTBOX_create_area_P3_z.Show();
                this.TEXTBOX_create_area_P3_a.Show();
                this.TEXTBOX_create_area_P3_b.Show();
                this.TEXTBOX_create_area_P3_c.Show();
                this.BTN_create_area_setP3.Show();
            }
        }
        
        private void BTN_create_scena_addMoveAction_Click(object sender, EventArgs e)
        {
            if (this.COMBOBOX_create_scena_move_trajectoryList.SelectedItem != null && !this.COMBOBOX_create_scena_move_trajectoryList.SelectedItem.Equals(""))
            {
                Dictionary<String, Object> action = new Dictionary<string, object>();
                action.Add("action", "moveTrajectory");
                action.Add("trajectoryName", this.COMBOBOX_create_scena_move_trajectoryList.SelectedItem);
                action.Add("id", this.LIST_create_scena_actionslist.Items.Count);
                this.tmpScenario.addAction(action);
                this.LIST_create_scena_actionslist.Items.Add(this.LIST_create_scena_actionslist.Items.Count +": move (" + this.COMBOBOX_create_scena_move_trajectoryList.SelectedItem + ")");
            }
        }

        private void BTN_create_scena_addGripperAction_Click(object sender, EventArgs e)
        {
            if (this.COMBOBOX_create_scena_gripperType.SelectedItem != null && !this.COMBOBOX_create_scena_gripperType.SelectedItem.Equals(""))
            {
                Console.WriteLine(this.COMBOBOX_create_scena_gripperType.SelectedItem);
                Dictionary<String, Object> action = new Dictionary<string, object>();
                action.Add("action", "gripper");
                action.Add("type", this.COMBOBOX_create_scena_gripperType.SelectedItem);
                action.Add("id", this.LIST_create_scena_actionslist.Items.Count);
                this.tmpScenario.addAction(action);
                this.LIST_create_scena_actionslist.Items.Add(this.LIST_create_scena_actionslist.Items.Count + ": gripper(" + this.COMBOBOX_create_scena_gripperType.SelectedItem + ")");
            }
        }

        private void BTN_create_scena_addStockAction_Click(object sender, EventArgs e)
        {
            if (this.COMBOBOX_create_scena_areaList.SelectedItem != null && !this.COMBOBOX_create_scena_areaList.SelectedItem.Equals("") &&
                this.COMBOBOX_create_scena_areaType.SelectedItem != null && !this.COMBOBOX_create_scena_areaType.SelectedItem.Equals(""))
            {
                Dictionary<String, Object> action = new Dictionary<string, object>();
                action.Add("action", "stock");
                action.Add("area", this.COMBOBOX_create_scena_areaList.SelectedItem);
                action.Add("stockType", this.COMBOBOX_create_scena_areaType.SelectedItem);
                action.Add("id", this.LIST_create_scena_actionslist.Items.Count);
                this.tmpScenario.addAction(action);
                this.LIST_create_scena_actionslist.Items.Add(this.LIST_create_scena_actionslist.Items.Count + ": stock " + this.COMBOBOX_create_scena_areaType.SelectedItem + "(" + this.COMBOBOX_create_scena_areaList.SelectedItem + ")");
            }
        }

        private void BTN_create_scena_addScena_Click(object sender, EventArgs e)
        {
            if (!this.TEXTBOX_create_scena_name.Equals("") && this.LIST_create_scena_actionslist.Items.Count > 0)
            {
                Data_Scenario scena = new Data_Scenario();
                scena.setName(this.TEXTBOX_create_scena_name.Text);
                scena.setID(Program.data.getSecnarios().Count);
                List<Dictionary<String, Object>> actions = new List<Dictionary<string, object>>(tmpScenario.getActions());
                scena.setActions(actions);
                Program.data.addScenario(scena);
                updateScenaList();
                this.LIST_create_scena_actionslist.Items.Clear();
                this.tmpScenario = new Data_Scenario();
                Program.ihm.createJob.updateScenaList();

            }
        }

        public void updateScenaList()
        {
            this.LIST_create_scena_scenaList.Items.Clear();
            foreach (Data_Scenario s in Program.data.getSecnarios())
            {
                this.LIST_create_scena_scenaList.Items.Add(s.getname());
            }
        }

        private void CHECKBOX_create_gripper_CheckedChanged(object sender, EventArgs e)
        {
            if(this.CHECKBOX_create_gripper.Checked)
                Program.robot.closeGripper();
            else
                Program.robot.openGripper();
        }
    }
}
