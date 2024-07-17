using System.Windows.Forms;
using System.Drawing;

namespace Sinhvien.tlu.Login_form
{
    partial class System_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(System_Login));
            this.Logo_thuyloi = new System.Windows.Forms.PictureBox();
            this.name_school = new System.Windows.Forms.Label();
            this.login_front = new System.Windows.Forms.PictureBox();
            this.Back_login = new System.Windows.Forms.PictureBox();
            this.Exit_Button = new System.Windows.Forms.PictureBox();
            this.Login_Button = new System.Windows.Forms.PictureBox();
            this.Login_label_center = new System.Windows.Forms.Label();
            this.Login_label = new System.Windows.Forms.Label();
            this.Exit_label = new System.Windows.Forms.Label();
            this.Login_action = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Server_pick = new Guna.UI.WinForms.GunaComboBox();
            this.USR_label = new Guna.UI.WinForms.GunaLineTextBox();
            this.PASS_label = new Guna.UI.WinForms.GunaLineTextBox();
            this.Progress_Dowloader = new Guna.UI.WinForms.GunaProgressBar();
            this.Update_Status = new Guna.UI.WinForms.GunaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_thuyloi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_front)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Back_login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Login_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // Logo_thuyloi
            // 
            this.Logo_thuyloi.Image = global::Sinhvien.tlu.Properties.Resources.logo_thuyloi1;
            this.Logo_thuyloi.Location = new System.Drawing.Point(138, 12);
            this.Logo_thuyloi.Name = "Logo_thuyloi";
            this.Logo_thuyloi.Size = new System.Drawing.Size(99, 80);
            this.Logo_thuyloi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo_thuyloi.TabIndex = 1;
            this.Logo_thuyloi.TabStop = false;
            // 
            // name_school
            // 
            this.name_school.AutoSize = true;
            this.name_school.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.name_school.ForeColor = System.Drawing.Color.Transparent;
            this.name_school.Location = new System.Drawing.Point(71, 108);
            this.name_school.Name = "name_school";
            this.name_school.Size = new System.Drawing.Size(220, 25);
            this.name_school.TabIndex = 2;
            this.name_school.Text = "Trường Đại học Thủy lợi";
            // 
            // login_front
            // 
            this.login_front.BackgroundImage = global::Sinhvien.tlu.Properties.Resources.login_side_back2;
            this.login_front.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.login_front.Image = global::Sinhvien.tlu.Properties.Resources.login_side_front;
            this.login_front.Location = new System.Drawing.Point(12, 186);
            this.login_front.Name = "login_front";
            this.login_front.Size = new System.Drawing.Size(358, 252);
            this.login_front.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.login_front.TabIndex = 4;
            this.login_front.TabStop = false;
            // 
            // Back_login
            // 
            this.Back_login.BackColor = System.Drawing.Color.Transparent;
            this.Back_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Back_login.Image = global::Sinhvien.tlu.Properties.Resources.back_login;
            this.Back_login.Location = new System.Drawing.Point(399, 0);
            this.Back_login.Name = "Back_login";
            this.Back_login.Size = new System.Drawing.Size(403, 450);
            this.Back_login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Back_login.TabIndex = 5;
            this.Back_login.TabStop = false;
            // 
            // Exit_Button
            // 
            this.Exit_Button.BackColor = System.Drawing.Color.White;
            this.Exit_Button.Image = global::Sinhvien.tlu.Properties.Resources.Button_login;
            this.Exit_Button.Location = new System.Drawing.Point(477, 275);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(104, 42);
            this.Exit_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Exit_Button.TabIndex = 6;
            this.Exit_Button.TabStop = false;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // Login_Button
            // 
            this.Login_Button.BackColor = System.Drawing.Color.White;
            this.Login_Button.Image = global::Sinhvien.tlu.Properties.Resources.Button_login;
            this.Login_Button.Location = new System.Drawing.Point(631, 275);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(104, 42);
            this.Login_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Login_Button.TabIndex = 7;
            this.Login_Button.TabStop = false;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // Login_label_center
            // 
            this.Login_label_center.AutoSize = true;
            this.Login_label_center.BackColor = System.Drawing.Color.White;
            this.Login_label_center.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Login_label_center.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.Login_label_center.Location = new System.Drawing.Point(529, 80);
            this.Login_label_center.Name = "Login_label_center";
            this.Login_label_center.Size = new System.Drawing.Size(138, 29);
            this.Login_label_center.TabIndex = 8;
            this.Login_label_center.Text = "Đăng nhập";
            // 
            // Login_label
            // 
            this.Login_label.AutoSize = true;
            this.Login_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.Login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Login_label.ForeColor = System.Drawing.Color.White;
            this.Login_label.Location = new System.Drawing.Point(637, 285);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(87, 17);
            this.Login_label.TabIndex = 11;
            this.Login_label.Text = "Đăng nhập";
            this.Login_label.Click += new System.EventHandler(this.Login_label_Click);
            // 
            // Exit_label
            // 
            this.Exit_label.AutoSize = true;
            this.Exit_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.Exit_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Exit_label.ForeColor = System.Drawing.Color.White;
            this.Exit_label.Location = new System.Drawing.Point(503, 285);
            this.Exit_label.Name = "Exit_label";
            this.Exit_label.Size = new System.Drawing.Size(50, 17);
            this.Exit_label.TabIndex = 12;
            this.Exit_label.Text = "Thoát";
            this.Exit_label.Click += new System.EventHandler(this.Exit_label_Click);
            // 
            // Login_action
            // 
            this.Login_action.AutoSize = true;
            this.Login_action.BackColor = System.Drawing.Color.White;
            this.Login_action.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_action.Location = new System.Drawing.Point(477, 338);
            this.Login_action.Name = "Login_action";
            this.Login_action.Size = new System.Drawing.Size(0, 15);
            this.Login_action.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(626, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Server";
            // 
            // Server_pick
            // 
            this.Server_pick.BackColor = System.Drawing.Color.Transparent;
            this.Server_pick.BaseColor = System.Drawing.Color.White;
            this.Server_pick.BorderColor = System.Drawing.Color.Silver;
            this.Server_pick.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Server_pick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Server_pick.FocusedColor = System.Drawing.Color.Empty;
            this.Server_pick.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Server_pick.ForeColor = System.Drawing.Color.Black;
            this.Server_pick.FormattingEnabled = true;
            this.Server_pick.Items.AddRange(new object[] {
            "Sinhvien1",
            "Sinhvien2",
            "Sinhvien3",
            "Sinhvien4"});
            this.Server_pick.Location = new System.Drawing.Point(670, 9);
            this.Server_pick.Name = "Server_pick";
            this.Server_pick.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Server_pick.OnHoverItemForeColor = System.Drawing.Color.White;
            this.Server_pick.Size = new System.Drawing.Size(121, 26);
            this.Server_pick.Sorted = true;
            this.Server_pick.StartIndex = 0;
            this.Server_pick.TabIndex = 17;
            this.Server_pick.TabStop = false;
            // 
            // USR_label
            // 
            this.USR_label.Animated = true;
            this.USR_label.BackColor = System.Drawing.Color.White;
            this.USR_label.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.USR_label.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.USR_label.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.USR_label.LineColor = System.Drawing.Color.Salmon;
            this.USR_label.Location = new System.Drawing.Point(477, 142);
            this.USR_label.MaxLength = 12;
            this.USR_label.Name = "USR_label";
            this.USR_label.PasswordChar = '\0';
            this.USR_label.SelectedText = "";
            this.USR_label.Size = new System.Drawing.Size(260, 32);
            this.USR_label.TabIndex = 18;
            this.USR_label.Text = "Mã sinh viên";
            this.USR_label.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // PASS_label
            // 
            this.PASS_label.Animated = true;
            this.PASS_label.BackColor = System.Drawing.Color.White;
            this.PASS_label.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PASS_label.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PASS_label.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.PASS_label.LineColor = System.Drawing.Color.Coral;
            this.PASS_label.Location = new System.Drawing.Point(477, 195);
            this.PASS_label.MaxLength = 255;
            this.PASS_label.Name = "PASS_label";
            this.PASS_label.PasswordChar = '*';
            this.PASS_label.SelectedText = "";
            this.PASS_label.Size = new System.Drawing.Size(260, 32);
            this.PASS_label.TabIndex = 19;
            this.PASS_label.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // Progress_Dowloader
            // 
            this.Progress_Dowloader.BackColor = System.Drawing.Color.Transparent;
            this.Progress_Dowloader.BorderColor = System.Drawing.Color.Black;
            this.Progress_Dowloader.ColorStyle = Guna.UI.WinForms.ColorStyle.Default;
            this.Progress_Dowloader.IdleColor = System.Drawing.Color.Gainsboro;
            this.Progress_Dowloader.Location = new System.Drawing.Point(477, 420);
            this.Progress_Dowloader.Name = "Progress_Dowloader";
            this.Progress_Dowloader.ProgressMaxColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Progress_Dowloader.ProgressMinColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Progress_Dowloader.Size = new System.Drawing.Size(260, 18);
            this.Progress_Dowloader.TabIndex = 20;
            this.Progress_Dowloader.TabStop = false;
            // 
            // Update_Status
            // 
            this.Update_Status.AutoSize = true;
            this.Update_Status.BackColor = System.Drawing.Color.White;
            this.Update_Status.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Update_Status.Location = new System.Drawing.Point(473, 396);
            this.Update_Status.Name = "Update_Status";
            this.Update_Status.Size = new System.Drawing.Size(208, 21);
            this.Update_Status.TabIndex = 21;
            this.Update_Status.Text = "Đang tải phiên bản mới nhất";
            // 
            // System_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.Update_Status);
            this.Controls.Add(this.Progress_Dowloader);
            this.Controls.Add(this.PASS_label);
            this.Controls.Add(this.USR_label);
            this.Controls.Add(this.Server_pick);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Login_action);
            this.Controls.Add(this.Exit_label);
            this.Controls.Add(this.Login_label);
            this.Controls.Add(this.Login_label_center);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.login_front);
            this.Controls.Add(this.name_school);
            this.Controls.Add(this.Logo_thuyloi);
            this.Controls.Add(this.Back_login);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "System_Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Education | System login";
            this.Load += new System.EventHandler(this.System_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo_thuyloi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_front)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Back_login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Login_Button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox Logo_thuyloi;
        private Label name_school;
        private PictureBox login_front;
        private PictureBox Back_login;
        private PictureBox Exit_Button;
        private PictureBox Login_Button;
        private Label Login_label_center;
        private Label Login_label;
        private Label Exit_label;
        private Label Login_action;
        private Label label1;
        private Guna.UI.WinForms.GunaComboBox Server_pick;
        private Guna.UI.WinForms.GunaLineTextBox USR_label;
        private Guna.UI.WinForms.GunaLineTextBox PASS_label;
        private Guna.UI.WinForms.GunaProgressBar Progress_Dowloader;
        private Guna.UI.WinForms.GunaLabel Update_Status;
    }
}