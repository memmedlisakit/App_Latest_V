namespace School.Pages
{
    partial class AdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.menuAdmin = new System.Windows.Forms.MenuStrip();
            this.studentsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.activationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catgoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quationsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.addQuationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticketsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCtivationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.examToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quationsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpAdminInfo = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuAdmin.SuspendLayout();
            this.grpAdminInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuAdmin
            // 
            this.menuAdmin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menuAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsToolStripMenuItem1,
            this.activationToolStripMenuItem,
            this.catgoryToolStripMenuItem,
            this.quationsToolStripMenuItem2,
            this.addQuationToolStripMenuItem,
            this.ticketsToolStripMenuItem1,
            this.profileToolStripMenuItem,
            this.resetAppToolStripMenuItem});
            this.menuAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(954, 28);
            this.menuAdmin.TabIndex = 0;
            this.menuAdmin.Text = "menuStrip1";
            // 
            // studentsToolStripMenuItem1
            // 
            this.studentsToolStripMenuItem1.Name = "studentsToolStripMenuItem1";
            this.studentsToolStripMenuItem1.Size = new System.Drawing.Size(160, 24);
            this.studentsToolStripMenuItem1.Text = "Qeydiyyatda olanlar";
            this.studentsToolStripMenuItem1.Click += new System.EventHandler(this.studentsToolStripMenuItem_Click);
            // 
            // activationToolStripMenuItem
            // 
            this.activationToolStripMenuItem.Name = "activationToolStripMenuItem";
            this.activationToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.activationToolStripMenuItem.Text = "Şifrə yarat";
            this.activationToolStripMenuItem.Click += new System.EventHandler(this.aCtivationsToolStripMenuItem_Click);
            // 
            // catgoryToolStripMenuItem
            // 
            this.catgoryToolStripMenuItem.Name = "catgoryToolStripMenuItem";
            this.catgoryToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.catgoryToolStripMenuItem.Text = "Mövzular";
            this.catgoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
            // 
            // quationsToolStripMenuItem2
            // 
            this.quationsToolStripMenuItem2.Name = "quationsToolStripMenuItem2";
            this.quationsToolStripMenuItem2.Size = new System.Drawing.Size(153, 24);
            this.quationsToolStripMenuItem2.Text = "Suallarda dəyişiklik";
            this.quationsToolStripMenuItem2.Click += new System.EventHandler(this.quationsToolStripMenuItem1_Click);
            // 
            // addQuationToolStripMenuItem
            // 
            this.addQuationToolStripMenuItem.Name = "addQuationToolStripMenuItem";
            this.addQuationToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.addQuationToolStripMenuItem.Text = "Sual əlavə et";
            this.addQuationToolStripMenuItem.Click += new System.EventHandler(this.quationsToolStripMenuItem_Click);
            // 
            // ticketsToolStripMenuItem1
            // 
            this.ticketsToolStripMenuItem1.Name = "ticketsToolStripMenuItem1";
            this.ticketsToolStripMenuItem1.Size = new System.Drawing.Size(93, 24);
            this.ticketsToolStripMenuItem1.Text = "Bilet yarat";
            this.ticketsToolStripMenuItem1.Click += new System.EventHandler(this.ticketsToolStripMenuItem_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.profileToolStripMenuItem.Text = "Hesabım";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileUpdate);
            // 
            // resetAppToolStripMenuItem
            // 
            this.resetAppToolStripMenuItem.ForeColor = System.Drawing.Color.DarkOrange;
            this.resetAppToolStripMenuItem.Name = "resetAppToolStripMenuItem";
            this.resetAppToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.resetAppToolStripMenuItem.Text = "Proqramı sıfırla";
            this.resetAppToolStripMenuItem.Click += new System.EventHandler(this.ResetApp);
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.studentsToolStripMenuItem.Text = "Students";
            this.studentsToolStripMenuItem.Click += new System.EventHandler(this.studentsToolStripMenuItem_Click);
            // 
            // aCtivationsToolStripMenuItem
            // 
            this.aCtivationsToolStripMenuItem.Name = "aCtivationsToolStripMenuItem";
            this.aCtivationsToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.aCtivationsToolStripMenuItem.Text = "Activations";
            this.aCtivationsToolStripMenuItem.Click += new System.EventHandler(this.aCtivationsToolStripMenuItem_Click);
            // 
            // examToolStripMenuItem
            // 
            this.examToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryToolStripMenuItem,
            this.quationsToolStripMenuItem1,
            this.quationsToolStripMenuItem});
            this.examToolStripMenuItem.Name = "examToolStripMenuItem";
            this.examToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.examToolStripMenuItem.Text = "Exam";
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.categoryToolStripMenuItem.Text = "Category";
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
            // 
            // quationsToolStripMenuItem1
            // 
            this.quationsToolStripMenuItem1.Name = "quationsToolStripMenuItem1";
            this.quationsToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.quationsToolStripMenuItem1.Text = "Quations";
            this.quationsToolStripMenuItem1.Click += new System.EventHandler(this.quationsToolStripMenuItem1_Click);
            // 
            // quationsToolStripMenuItem
            // 
            this.quationsToolStripMenuItem.Name = "quationsToolStripMenuItem";
            this.quationsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.quationsToolStripMenuItem.Text = "Add quation";
            this.quationsToolStripMenuItem.Click += new System.EventHandler(this.quationsToolStripMenuItem_Click);
            // 
            // ticketsToolStripMenuItem
            // 
            this.ticketsToolStripMenuItem.Name = "ticketsToolStripMenuItem";
            this.ticketsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.ticketsToolStripMenuItem.Text = "Tickets";
            this.ticketsToolStripMenuItem.Click += new System.EventHandler(this.ticketsToolStripMenuItem_Click);
            // 
            // grpAdminInfo
            // 
            this.grpAdminInfo.Controls.Add(this.txtEmail);
            this.grpAdminInfo.Controls.Add(this.label3);
            this.grpAdminInfo.Controls.Add(this.lblError);
            this.grpAdminInfo.Controls.Add(this.btnSave);
            this.grpAdminInfo.Controls.Add(this.txtPassword);
            this.grpAdminInfo.Controls.Add(this.label2);
            this.grpAdminInfo.Controls.Add(this.txtUsername);
            this.grpAdminInfo.Controls.Add(this.label1);
            this.grpAdminInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAdminInfo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.grpAdminInfo.Location = new System.Drawing.Point(12, 47);
            this.grpAdminInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpAdminInfo.Name = "grpAdminInfo";
            this.grpAdminInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpAdminInfo.Size = new System.Drawing.Size(930, 147);
            this.grpAdminInfo.TabIndex = 7;
            this.grpAdminInfo.TabStop = false;
            this.grpAdminInfo.Text = "Yeniləmə";
            this.grpAdminInfo.Visible = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(500, 76);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 30);
            this.txtEmail.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(497, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Email:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(12, 118);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 19);
            this.lblError.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.Location = new System.Drawing.Point(781, 76);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Yadda Saxla";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(253, 76);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 30);
            this.txtPassword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "İstifadəçi adı:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(16, 76);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 30);
            this.txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(250, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Şifrə:";
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 485);
            this.Controls.Add(this.grpAdminInfo);
            this.Controls.Add(this.menuAdmin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuAdmin;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.menuAdmin.ResumeLayout(false);
            this.menuAdmin.PerformLayout();
            this.grpAdminInfo.ResumeLayout(false);
            this.grpAdminInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCtivationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem examToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quationsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ticketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem activationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catgoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quationsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem addQuationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ticketsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox grpAdminInfo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem resetAppToolStripMenuItem;
    }
}