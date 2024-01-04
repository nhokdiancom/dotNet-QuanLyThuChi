namespace Quanlychitieu
{
    partial class Formlichchitieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formlichchitieu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbthongbaotien = new System.Windows.Forms.Label();
            this.btthem = new System.Windows.Forms.Button();
            this.dgvlich = new System.Windows.Forms.DataGridView();
            this.lbsotien = new System.Windows.Forms.Label();
            this.txtsotien = new System.Windows.Forms.TextBox();
            this.lbtenkhoanchi = new System.Windows.Forms.Label();
            this.cbnoidungchi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btquaylai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlich)).BeginInit();
            this.SuspendLayout();
            // 
            // lbthongbaotien
            // 
            this.lbthongbaotien.AutoSize = true;
            this.lbthongbaotien.BackColor = System.Drawing.Color.Transparent;
            this.lbthongbaotien.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbthongbaotien.ForeColor = System.Drawing.Color.Black;
            this.lbthongbaotien.Location = new System.Drawing.Point(57, 427);
            this.lbthongbaotien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbthongbaotien.Name = "lbthongbaotien";
            this.lbthongbaotien.Size = new System.Drawing.Size(188, 31);
            this.lbthongbaotien.TabIndex = 16;
            this.lbthongbaotien.Text = "Số tiền còn lại:";
            // 
            // btthem
            // 
            this.btthem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btthem.BackgroundImage")));
            this.btthem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btthem.CausesValidation = false;
            this.btthem.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btthem.ForeColor = System.Drawing.Color.Red;
            this.btthem.Location = new System.Drawing.Point(907, 64);
            this.btthem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(160, 42);
            this.btthem.TabIndex = 15;
            this.btthem.UseVisualStyleBackColor = true;
            this.btthem.Click += new System.EventHandler(this.btthem_Click);
            // 
            // dgvlich
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvlich.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvlich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvlich.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvlich.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvlich.ColumnHeadersHeight = 35;
            this.dgvlich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvlich.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvlich.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvlich.Location = new System.Drawing.Point(33, 128);
            this.dgvlich.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvlich.Name = "dgvlich";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlich.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvlich.RowHeadersWidth = 51;
            this.dgvlich.Size = new System.Drawing.Size(1133, 290);
            this.dgvlich.TabIndex = 14;
            // 
            // lbsotien
            // 
            this.lbsotien.AutoSize = true;
            this.lbsotien.BackColor = System.Drawing.Color.Transparent;
            this.lbsotien.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsotien.ForeColor = System.Drawing.Color.Black;
            this.lbsotien.Location = new System.Drawing.Point(532, 70);
            this.lbsotien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbsotien.Name = "lbsotien";
            this.lbsotien.Size = new System.Drawing.Size(103, 31);
            this.lbsotien.TabIndex = 13;
            this.lbsotien.Text = "Số tiền:";
            // 
            // txtsotien
            // 
            this.txtsotien.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsotien.Location = new System.Drawing.Point(640, 65);
            this.txtsotien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtsotien.Name = "txtsotien";
            this.txtsotien.Size = new System.Drawing.Size(241, 38);
            this.txtsotien.TabIndex = 12;
            // 
            // lbtenkhoanchi
            // 
            this.lbtenkhoanchi.AutoSize = true;
            this.lbtenkhoanchi.BackColor = System.Drawing.Color.Transparent;
            this.lbtenkhoanchi.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtenkhoanchi.ForeColor = System.Drawing.Color.Black;
            this.lbtenkhoanchi.Location = new System.Drawing.Point(20, 66);
            this.lbtenkhoanchi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtenkhoanchi.Name = "lbtenkhoanchi";
            this.lbtenkhoanchi.Size = new System.Drawing.Size(190, 31);
            this.lbtenkhoanchi.TabIndex = 11;
            this.lbtenkhoanchi.Text = "Tên khoản chi:";
            // 
            // cbnoidungchi
            // 
            this.cbnoidungchi.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbnoidungchi.FormattingEnabled = true;
            this.cbnoidungchi.Location = new System.Drawing.Point(212, 64);
            this.cbnoidungchi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbnoidungchi.Name = "cbnoidungchi";
            this.cbnoidungchi.Size = new System.Drawing.Size(297, 37);
            this.cbnoidungchi.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(309, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 42);
            this.label1.TabIndex = 9;
            this.label1.Text = "NHẬP NỘI DUNG LỊCH CHI TIÊU";
            // 
            // btquaylai
            // 
            this.btquaylai.BackColor = System.Drawing.Color.Transparent;
            this.btquaylai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btquaylai.BackgroundImage")));
            this.btquaylai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btquaylai.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btquaylai.Location = new System.Drawing.Point(1127, 1);
            this.btquaylai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btquaylai.Name = "btquaylai";
            this.btquaylai.Size = new System.Drawing.Size(65, 49);
            this.btquaylai.TabIndex = 43;
            this.btquaylai.UseVisualStyleBackColor = false;
            this.btquaylai.Click += new System.EventHandler(this.btquaylai_Click);
            // 
            // Formlichchitieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1196, 471);
            this.Controls.Add(this.btquaylai);
            this.Controls.Add(this.lbthongbaotien);
            this.Controls.Add(this.btthem);
            this.Controls.Add(this.dgvlich);
            this.Controls.Add(this.lbsotien);
            this.Controls.Add(this.txtsotien);
            this.Controls.Add(this.lbtenkhoanchi);
            this.Controls.Add(this.cbnoidungchi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Formlichchitieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch chi tiêu";
            this.Load += new System.EventHandler(this.Formlichchitieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlich)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbthongbaotien;
        private System.Windows.Forms.Button btthem;
        private System.Windows.Forms.DataGridView dgvlich;
        private System.Windows.Forms.Label lbsotien;
        private System.Windows.Forms.TextBox txtsotien;
        private System.Windows.Forms.Label lbtenkhoanchi;
        private System.Windows.Forms.ComboBox cbnoidungchi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btquaylai;
    }
}