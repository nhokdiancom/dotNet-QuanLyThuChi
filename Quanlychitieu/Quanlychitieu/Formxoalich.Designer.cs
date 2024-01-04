namespace Quanlychitieu
{
    partial class Formxoalich
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formxoalich));
            this.btquaylai = new System.Windows.Forms.Button();
            this.cbmalich = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbtenlich = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btxoakhoanthu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btquaylai
            // 
            this.btquaylai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btquaylai.BackgroundImage")));
            this.btquaylai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btquaylai.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btquaylai.Location = new System.Drawing.Point(306, 5);
            this.btquaylai.Name = "btquaylai";
            this.btquaylai.Size = new System.Drawing.Size(49, 42);
            this.btquaylai.TabIndex = 98;
            this.btquaylai.UseVisualStyleBackColor = true;
            this.btquaylai.Click += new System.EventHandler(this.btquaylai_Click);
            // 
            // cbmalich
            // 
            this.cbmalich.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmalich.FormattingEnabled = true;
            this.cbmalich.Location = new System.Drawing.Point(121, 129);
            this.cbmalich.Name = "cbmalich";
            this.cbmalich.Size = new System.Drawing.Size(225, 42);
            this.cbmalich.TabIndex = 96;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(16, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 35);
            this.label2.TabIndex = 93;
            this.label2.Text = "Mã lịch:";
            // 
            // cbtenlich
            // 
            this.cbtenlich.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtenlich.FormattingEnabled = true;
            this.cbtenlich.Location = new System.Drawing.Point(121, 80);
            this.cbtenlich.Name = "cbtenlich";
            this.cbtenlich.Size = new System.Drawing.Size(225, 42);
            this.cbtenlich.TabIndex = 97;
            this.cbtenlich.SelectedIndexChanged += new System.EventHandler(this.cbtenlich_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(11, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 35);
            this.label3.TabIndex = 94;
            this.label3.Text = "Tên lịch:";
            // 
            // btxoakhoanthu
            // 
            this.btxoakhoanthu.BackColor = System.Drawing.Color.Transparent;
            this.btxoakhoanthu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btxoakhoanthu.BackgroundImage")));
            this.btxoakhoanthu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btxoakhoanthu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btxoakhoanthu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btxoakhoanthu.ForeColor = System.Drawing.Color.Blue;
            this.btxoakhoanthu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btxoakhoanthu.ImageKey = "(none)";
            this.btxoakhoanthu.Location = new System.Drawing.Point(112, 187);
            this.btxoakhoanthu.Name = "btxoakhoanthu";
            this.btxoakhoanthu.Size = new System.Drawing.Size(148, 51);
            this.btxoakhoanthu.TabIndex = 95;
            this.btxoakhoanthu.UseVisualStyleBackColor = false;
            this.btxoakhoanthu.Click += new System.EventHandler(this.btxoakhoanthu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(56, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 35);
            this.label1.TabIndex = 92;
            this.label1.Text = "XÓA LỊCH CHI TIÊU";
            // 
            // Formxoalich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(359, 250);
            this.Controls.Add(this.btquaylai);
            this.Controls.Add(this.cbmalich);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbtenlich);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btxoakhoanthu);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Formxoalich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xóa lịch chi tiêu";
            this.Load += new System.EventHandler(this.Formxoalich_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btquaylai;
        private System.Windows.Forms.ComboBox cbmalich;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbtenlich;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btxoakhoanthu;
        private System.Windows.Forms.Label label1;
    }
}