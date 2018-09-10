namespace School.Pages
{
    partial class Student
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Student));
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.rdEmail = new System.Windows.Forms.RadioButton();
            this.rdUsername = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grpStudents = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.grpInfo.SuspendLayout();
            this.grpStudents.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column5});
            this.dgvData.Location = new System.Drawing.Point(10, 19);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(1236, 524);
            this.dgvData.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Aktivasiya kodu";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "İstifadəçi adi";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Email";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "İstifadəçi Computer Məlumatı";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Aktivasiya Vəziyyəti";
            this.Column5.Name = "Column5";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblCount.Location = new System.Drawing.Point(139, 43);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 22);
            this.lblCount.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CadetBlue;
            this.label3.Location = new System.Drawing.Point(9, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Aktivasiya sayı:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(9, 77);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 20);
            this.lblError.TabIndex = 11;
            // 
            // btnAll
            // 
            this.btnAll.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnAll.Location = new System.Drawing.Point(673, 102);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(215, 30);
            this.btnAll.TabIndex = 14;
            this.btnAll.Text = "Aktivasiyalı Tələbələr";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.rdEmail);
            this.grpInfo.Controls.Add(this.rdUsername);
            this.grpInfo.Controls.Add(this.txtSearch);
            this.grpInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInfo.Location = new System.Drawing.Point(673, 12);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(315, 84);
            this.grpInfo.TabIndex = 15;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Axtar";
            // 
            // rdEmail
            // 
            this.rdEmail.AutoSize = true;
            this.rdEmail.Location = new System.Drawing.Point(110, 25);
            this.rdEmail.Name = "rdEmail";
            this.rdEmail.Size = new System.Drawing.Size(54, 17);
            this.rdEmail.TabIndex = 4;
            this.rdEmail.Text = "email";
            this.rdEmail.UseVisualStyleBackColor = true;
            // 
            // rdUsername
            // 
            this.rdUsername.AutoSize = true;
            this.rdUsername.Checked = true;
            this.rdUsername.Location = new System.Drawing.Point(8, 25);
            this.rdUsername.Name = "rdUsername";
            this.rdUsername.Size = new System.Drawing.Size(97, 17);
            this.rdUsername.TabIndex = 3;
            this.rdUsername.TabStop = true;
            this.rdUsername.Text = "istifadəçi adi";
            this.rdUsername.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(7, 48);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 30);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchUser);
            // 
            // grpStudents
            // 
            this.grpStudents.Controls.Add(this.dgvData);
            this.grpStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStudents.Location = new System.Drawing.Point(12, 137);
            this.grpStudents.Name = "grpStudents";
            this.grpStudents.Size = new System.Drawing.Size(1253, 553);
            this.grpStudents.TabIndex = 16;
            this.grpStudents.TabStop = false;
            this.grpStudents.Text = "Aktivasiyalar";
            // 
            // Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 657);
            this.Controls.Add(this.grpStudents);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Student";
            this.Text = "Activasiyalar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.Load += new System.EventHandler(this.Student_Load);
            this.Resize += new System.EventHandler(this.FormResize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpStudents.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdEmail;
        private System.Windows.Forms.RadioButton rdUsername;
        private System.Windows.Forms.GroupBox grpStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}