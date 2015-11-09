namespace KukaTrajectory
{
    partial class Menu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTN_menu_load = new System.Windows.Forms.Button();
            this.BTN_menu_create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_menu_load
            // 
            this.BTN_menu_load.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTN_menu_load.FlatAppearance.BorderSize = 10;
            this.BTN_menu_load.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BTN_menu_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BTN_menu_load.Location = new System.Drawing.Point(12, 132);
            this.BTN_menu_load.Name = "BTN_menu_load";
            this.BTN_menu_load.Size = new System.Drawing.Size(82, 34);
            this.BTN_menu_load.TabIndex = 0;
            this.BTN_menu_load.Text = "Load";
            this.BTN_menu_load.UseVisualStyleBackColor = false;
            this.BTN_menu_load.Click += new System.EventHandler(this.BTN_menu_load_Click);
            // 
            // BTN_menu_create
            // 
            this.BTN_menu_create.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTN_menu_create.FlatAppearance.BorderSize = 10;
            this.BTN_menu_create.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BTN_menu_create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BTN_menu_create.Location = new System.Drawing.Point(12, 172);
            this.BTN_menu_create.Name = "BTN_menu_create";
            this.BTN_menu_create.Size = new System.Drawing.Size(82, 34);
            this.BTN_menu_create.TabIndex = 1;
            this.BTN_menu_create.Text = "Create";
            this.BTN_menu_create.UseVisualStyleBackColor = false;
            this.BTN_menu_create.Click += new System.EventHandler(this.BTN_menu_create_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.label1.Location = new System.Drawing.Point(110, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Menu";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatAppearance.BorderSize = 10;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button1.Location = new System.Drawing.Point(12, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Quit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.FlatAppearance.BorderSize = 10;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.button2.Location = new System.Drawing.Point(234, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 17);
            this.button2.TabIndex = 5;
            this.button2.Text = "Robot connect";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(319, 262);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_menu_create);
            this.Controls.Add(this.BTN_menu_load);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kuka Trajectory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_menu_load;
        private System.Windows.Forms.Button BTN_menu_create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

