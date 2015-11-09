namespace KukaTrajectory
{
    partial class IHM_CreateJob
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTN_move_area_1 = new System.Windows.Forms.Button();
            this.BTN_move_area_0 = new System.Windows.Forms.Button();
            this.BTN_move_area_2 = new System.Windows.Forms.Button();
            this.BTN_Play_trajectory_test_out = new System.Windows.Forms.Button();
            this.BTN_Play_trajectory_test = new System.Windows.Forms.Button();
            this.LIST_scenarios = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_load_scena_start = new System.Windows.Forms.Button();
            this.BTN_load_scena_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_move_area_1
            // 
            this.BTN_move_area_1.Location = new System.Drawing.Point(377, 296);
            this.BTN_move_area_1.Name = "BTN_move_area_1";
            this.BTN_move_area_1.Size = new System.Drawing.Size(159, 23);
            this.BTN_move_area_1.TabIndex = 14;
            this.BTN_move_area_1.Text = "Move to area 1";
            this.BTN_move_area_1.UseVisualStyleBackColor = true;
            this.BTN_move_area_1.Click += new System.EventHandler(this.BTN_move_area_1_Click);
            // 
            // BTN_move_area_0
            // 
            this.BTN_move_area_0.Location = new System.Drawing.Point(377, 267);
            this.BTN_move_area_0.Name = "BTN_move_area_0";
            this.BTN_move_area_0.Size = new System.Drawing.Size(159, 23);
            this.BTN_move_area_0.TabIndex = 13;
            this.BTN_move_area_0.Text = "Move to area 0";
            this.BTN_move_area_0.UseVisualStyleBackColor = true;
            this.BTN_move_area_0.Click += new System.EventHandler(this.BTN_move_area_0_Click);
            // 
            // BTN_move_area_2
            // 
            this.BTN_move_area_2.Location = new System.Drawing.Point(377, 325);
            this.BTN_move_area_2.Name = "BTN_move_area_2";
            this.BTN_move_area_2.Size = new System.Drawing.Size(159, 23);
            this.BTN_move_area_2.TabIndex = 12;
            this.BTN_move_area_2.Text = "Move to area 2";
            this.BTN_move_area_2.UseVisualStyleBackColor = true;
            this.BTN_move_area_2.Click += new System.EventHandler(this.BTN_move_area_2_Click);
            // 
            // BTN_Play_trajectory_test_out
            // 
            this.BTN_Play_trajectory_test_out.Location = new System.Drawing.Point(377, 354);
            this.BTN_Play_trajectory_test_out.Name = "BTN_Play_trajectory_test_out";
            this.BTN_Play_trajectory_test_out.Size = new System.Drawing.Size(159, 23);
            this.BTN_Play_trajectory_test_out.TabIndex = 11;
            this.BTN_Play_trajectory_test_out.Text = "Play Trajectory Test out";
            this.BTN_Play_trajectory_test_out.UseVisualStyleBackColor = true;
            this.BTN_Play_trajectory_test_out.Click += new System.EventHandler(this.BTN_Play_trajectory_test_out_Click);
            // 
            // BTN_Play_trajectory_test
            // 
            this.BTN_Play_trajectory_test.Location = new System.Drawing.Point(377, 383);
            this.BTN_Play_trajectory_test.Name = "BTN_Play_trajectory_test";
            this.BTN_Play_trajectory_test.Size = new System.Drawing.Size(159, 23);
            this.BTN_Play_trajectory_test.TabIndex = 10;
            this.BTN_Play_trajectory_test.Text = "Play Trajectory Test in";
            this.BTN_Play_trajectory_test.UseVisualStyleBackColor = true;
            this.BTN_Play_trajectory_test.Click += new System.EventHandler(this.BTN_Play_trajectory_test_Click);
            // 
            // LIST_scenarios
            // 
            this.LIST_scenarios.FormattingEnabled = true;
            this.LIST_scenarios.Location = new System.Drawing.Point(25, 40);
            this.LIST_scenarios.Name = "LIST_scenarios";
            this.LIST_scenarios.Size = new System.Drawing.Size(163, 95);
            this.LIST_scenarios.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Scenarios:";
            // 
            // BTN_load_scena_start
            // 
            this.BTN_load_scena_start.Location = new System.Drawing.Point(127, 160);
            this.BTN_load_scena_start.Name = "BTN_load_scena_start";
            this.BTN_load_scena_start.Size = new System.Drawing.Size(75, 23);
            this.BTN_load_scena_start.TabIndex = 17;
            this.BTN_load_scena_start.Text = "Start";
            this.BTN_load_scena_start.UseVisualStyleBackColor = true;
            this.BTN_load_scena_start.Click += new System.EventHandler(this.BTN_load_scena_start_Click);
            // 
            // BTN_load_scena_back
            // 
            this.BTN_load_scena_back.Location = new System.Drawing.Point(12, 160);
            this.BTN_load_scena_back.Name = "BTN_load_scena_back";
            this.BTN_load_scena_back.Size = new System.Drawing.Size(75, 23);
            this.BTN_load_scena_back.TabIndex = 19;
            this.BTN_load_scena_back.Text = "Back";
            this.BTN_load_scena_back.UseVisualStyleBackColor = true;
            this.BTN_load_scena_back.Click += new System.EventHandler(this.BTN_load_scena_back_Click);
            // 
            // IHM_CreateJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 423);
            this.Controls.Add(this.BTN_load_scena_back);
            this.Controls.Add(this.BTN_load_scena_start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LIST_scenarios);
            this.Controls.Add(this.BTN_move_area_1);
            this.Controls.Add(this.BTN_move_area_0);
            this.Controls.Add(this.BTN_move_area_2);
            this.Controls.Add(this.BTN_Play_trajectory_test_out);
            this.Controls.Add(this.BTN_Play_trajectory_test);
            this.Name = "IHM_CreateJob";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_move_area_1;
        private System.Windows.Forms.Button BTN_move_area_0;
        private System.Windows.Forms.Button BTN_move_area_2;
        private System.Windows.Forms.Button BTN_Play_trajectory_test_out;
        private System.Windows.Forms.Button BTN_Play_trajectory_test;
        private System.Windows.Forms.ListBox LIST_scenarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_load_scena_start;
        private System.Windows.Forms.Button BTN_load_scena_back;
    }
}