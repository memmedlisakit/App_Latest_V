namespace School.Pages
{
    partial class Tickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tickets));
            this.btnAddTicket = new System.Windows.Forms.Button();
            this.grpTickets = new System.Windows.Forms.GroupBox();
            this.dgwTickets = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddTicket
            // 
            this.btnAddTicket.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTicket.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddTicket.Location = new System.Drawing.Point(1099, 22);
            this.btnAddTicket.Name = "btnAddTicket";
            this.btnAddTicket.Size = new System.Drawing.Size(139, 30);
            this.btnAddTicket.TabIndex = 4;
            this.btnAddTicket.Text = "Bilet Əlavə et";
            this.btnAddTicket.UseVisualStyleBackColor = true;
            this.btnAddTicket.Click += new System.EventHandler(this.btnAddTicket_Click);
            // 
            // grpTickets
            // 
            this.grpTickets.Controls.Add(this.dgwTickets);
            this.grpTickets.Font = new System.Drawing.Font("MilitaryID", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTickets.Location = new System.Drawing.Point(14, 58);
            this.grpTickets.Name = "grpTickets";
            this.grpTickets.Size = new System.Drawing.Size(1251, 414);
            this.grpTickets.TabIndex = 5;
            this.grpTickets.TabStop = false;
            this.grpTickets.Text = "Bütün Biletlər";
            // 
            // dgwTickets
            // 
            this.dgwTickets.AllowUserToAddRows = false;
            this.dgwTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgwTickets.Location = new System.Drawing.Point(6, 19);
            this.dgwTickets.Name = "dgwTickets";
            this.dgwTickets.Size = new System.Drawing.Size(1226, 389);
            this.dgwTickets.TabIndex = 0;
            this.dgwTickets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.updateAndDelete);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Id";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 70F;
            this.Column1.HeaderText = "Bilet Adı";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 15F;
            this.Column2.HeaderText = "Yenilə";
            this.Column2.MinimumWidth = 3;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 15F;
            this.Column3.HeaderText = "Sil";
            this.Column3.Name = "Column3";
            // 
            // Tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 485);
            this.Controls.Add(this.grpTickets);
            this.Controls.Add(this.btnAddTicket);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tickets";
            this.Text = "Biletlər";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.Load += new System.EventHandler(this.Tickets_Load);
            this.Resize += new System.EventHandler(this.FormResize);
            this.grpTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTickets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddTicket;
        private System.Windows.Forms.GroupBox grpTickets;
        private System.Windows.Forms.DataGridView dgwTickets;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}