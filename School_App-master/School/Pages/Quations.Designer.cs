namespace School.Pages
{
    partial class Quations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quations));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNumberOfQuation = new System.Windows.Forms.Label();
            this.pnlAllQuations = new System.Windows.Forms.Panel();
            this.txtNumOfQuation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.linkUpload = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.pctInfoQuation = new System.Windows.Forms.PictureBox();
            this.txtInfoAnswer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbInfoCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctInfoQuation)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNumberOfQuation);
            this.groupBox2.Controls.Add(this.pnlAllQuations);
            this.groupBox2.Controls.Add(this.txtNumOfQuation);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbCategory);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(24, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(742, 653);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Suallar Listi";
            // 
            // lblNumberOfQuation
            // 
            this.lblNumberOfQuation.AutoSize = true;
            this.lblNumberOfQuation.Font = new System.Drawing.Font("Microsoft Yi Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfQuation.ForeColor = System.Drawing.Color.Red;
            this.lblNumberOfQuation.Location = new System.Drawing.Point(349, 88);
            this.lblNumberOfQuation.Name = "lblNumberOfQuation";
            this.lblNumberOfQuation.Size = new System.Drawing.Size(0, 14);
            this.lblNumberOfQuation.TabIndex = 47;
            // 
            // pnlAllQuations
            // 
            this.pnlAllQuations.Location = new System.Drawing.Point(8, 130);
            this.pnlAllQuations.Name = "pnlAllQuations";
            this.pnlAllQuations.Size = new System.Drawing.Size(726, 517);
            this.pnlAllQuations.TabIndex = 46;
            // 
            // txtNumOfQuation
            // 
            this.txtNumOfQuation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumOfQuation.Location = new System.Drawing.Point(352, 55);
            this.txtNumOfQuation.Multiline = true;
            this.txtNumOfQuation.Name = "txtNumOfQuation";
            this.txtNumOfQuation.Size = new System.Drawing.Size(208, 30);
            this.txtNumOfQuation.TabIndex = 45;
            this.txtNumOfQuation.TextChanged += new System.EventHandler(this.selectQuation);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(349, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "Sual nömrəsi:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(39, 53);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(208, 32);
            this.cmbCategory.TabIndex = 30;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(36, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Mövzu:";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.btnCancel);
            this.grpInfo.Controls.Add(this.linkUpload);
            this.grpInfo.Controls.Add(this.btnSave);
            this.grpInfo.Controls.Add(this.pctInfoQuation);
            this.grpInfo.Controls.Add(this.txtInfoAnswer);
            this.grpInfo.Controls.Add(this.label4);
            this.grpInfo.Controls.Add(this.cmbInfoCategory);
            this.grpInfo.Controls.Add(this.label3);
            this.grpInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInfo.Location = new System.Drawing.Point(793, 29);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(504, 515);
            this.grpInfo.TabIndex = 36;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Sual məlumatları";
            this.grpInfo.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnCancel.Location = new System.Drawing.Point(9, 478);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 30);
            this.btnCancel.TabIndex = 53;
            this.btnCancel.Text = "Ləğv edin";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // linkUpload
            // 
            this.linkUpload.AutoSize = true;
            this.linkUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkUpload.Location = new System.Drawing.Point(6, 114);
            this.linkUpload.Name = "linkUpload";
            this.linkUpload.Size = new System.Drawing.Size(45, 13);
            this.linkUpload.TabIndex = 52;
            this.linkUpload.TabStop = true;
            this.linkUpload.Text = "seçin..";
            this.linkUpload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpload_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.Location = new System.Drawing.Point(379, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 30);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "Yadda saxla";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pctInfoQuation
            // 
            this.pctInfoQuation.Location = new System.Drawing.Point(6, 130);
            this.pctInfoQuation.Name = "pctInfoQuation";
            this.pctInfoQuation.Size = new System.Drawing.Size(492, 342);
            this.pctInfoQuation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctInfoQuation.TabIndex = 50;
            this.pctInfoQuation.TabStop = false;
            // 
            // txtInfoAnswer
            // 
            this.txtInfoAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoAnswer.Location = new System.Drawing.Point(290, 52);
            this.txtInfoAnswer.Multiline = true;
            this.txtInfoAnswer.Name = "txtInfoAnswer";
            this.txtInfoAnswer.Size = new System.Drawing.Size(208, 30);
            this.txtInfoAnswer.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(287, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 48;
            this.label4.Text = "Cavab:";
            // 
            // cmbInfoCategory
            // 
            this.cmbInfoCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInfoCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInfoCategory.FormattingEnabled = true;
            this.cmbInfoCategory.Location = new System.Drawing.Point(6, 52);
            this.cmbInfoCategory.Name = "cmbInfoCategory";
            this.cmbInfoCategory.Size = new System.Drawing.Size(208, 32);
            this.cmbInfoCategory.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Mövzu:";
            // 
            // Quations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Quations";
            this.Text = "Suallar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.Load += new System.EventHandler(this.Quations_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctInfoQuation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlAllQuations;
        private System.Windows.Forms.TextBox txtNumOfQuation;
        private System.Windows.Forms.Label lblNumberOfQuation;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.PictureBox pctInfoQuation;
        private System.Windows.Forms.TextBox txtInfoAnswer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbInfoCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel linkUpload;
    }
}