namespace School.Pages
{
    partial class AddActivation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddActivation));
            this.lblError = new System.Windows.Forms.Label();
            this.btnActivation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExel = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtActivation = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(6, 323);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            this.lblError.TabIndex = 15;
            // 
            // btnActivation
            // 
            this.btnActivation.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivation.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnActivation.Location = new System.Drawing.Point(438, 38);
            this.btnActivation.Name = "btnActivation";
            this.btnActivation.Size = new System.Drawing.Size(102, 30);
            this.btnActivation.TabIndex = 13;
            this.btnActivation.Text = "Emal et";
            this.btnActivation.UseVisualStyleBackColor = true;
            this.btnActivation.Click += new System.EventHandler(this.btnActivation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Şifrə sayi:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(35, 79);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 17);
            this.lblCount.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExel);
            this.groupBox1.Controls.Add(this.dgvData);
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 418);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Şifrə listi";
            // 
            // btnExel
            // 
            this.btnExel.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnExel.Location = new System.Drawing.Point(381, 379);
            this.btnExel.Name = "btnExel";
            this.btnExel.Size = new System.Drawing.Size(147, 30);
            this.btnExel.TabIndex = 23;
            this.btnExel.Text = "Yadda saxla exel";
            this.btnExel.UseVisualStyleBackColor = true;
            this.btnExel.Click += new System.EventHandler(this.btnExel_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.dgvData.Location = new System.Drawing.Point(6, 19);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(522, 292);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Aktivasiya kodu";
            this.Column2.Name = "Column2";
            // 
            // txtActivation
            // 
            this.txtActivation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActivation.Location = new System.Drawing.Point(33, 40);
            this.txtActivation.Multiline = true;
            this.txtActivation.Name = "txtActivation";
            this.txtActivation.Size = new System.Drawing.Size(200, 30);
            this.txtActivation.TabIndex = 23;
            // 
            // AddActivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 545);
            this.Controls.Add(this.txtActivation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnActivation);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddActivation";
            this.Text = "Activasiyalar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnActivation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnExel;
        private System.Windows.Forms.TextBox txtActivation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}