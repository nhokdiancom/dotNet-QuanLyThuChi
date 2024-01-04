namespace Quanlychitieu
{
    partial class Formxoathunhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formxoathunhap));
            this.cbmatn = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbkhoanthunhap = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btxoakhoanthu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btquaylai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbmatn
            // 
            this.cbmatn.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmatn.FormattingEnabled = true;
            this.cbmatn.Location = new System.Drawing.Point(233, 146);
            this.cbmatn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbmatn.Name = "cbmatn";
            this.cbmatn.Size = new System.Drawing.Size(304, 42);
            this.cbmatn.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(33, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 35);
            this.label2.TabIndex = 81;
            this.label2.Text = "Mã thu nhập:";
            // 
            // cbkhoanthunhap
            // 
            this.cbkhoanthunhap.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbkhoanthunhap.FormattingEnabled = true;
            this.cbkhoanthunhap.Location = new System.Drawing.Point(233, 85);
            this.cbkhoanthunhap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbkhoanthunhap.Name = "cbkhoanthunhap";
            this.cbkhoanthunhap.Size = new System.Drawing.Size(304, 42);
            this.cbkhoanthunhap.TabIndex = 85;
            this.cbkhoanthunhap.SelectedIndexChanged += new System.EventHandler(this.cbkhoanthunhap_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(11, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 35);
            this.label3.TabIndex = 82;
            this.label3.Text = "Tên khoản thu:";
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
            this.btxoakhoanthu.Location = new System.Drawing.Point(217, 208);
            this.btxoakhoanthu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btxoakhoanthu.Name = "btxoakhoanthu";
            this.btxoakhoanthu.Size = new System.Drawing.Size(207, 59);
            this.btxoakhoanthu.TabIndex = 83;
            this.btxoakhoanthu.UseVisualStyleBackColor = false;
            this.btxoakhoanthu.Click += new System.EventHandler(this.btxoakhoanthu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 35);
            this.label1.TabIndex = 80;
            this.label1.Text = "XÓA THÔNG TIN KHOẢN THU";
            // 
            // btquaylai
            // 
            this.btquaylai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btquaylai.BackgroundImage")));
            this.btquaylai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btquaylai.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btquaylai.Location = new System.Drawing.Point(505, 4);
            this.btquaylai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btquaylai.Name = "btquaylai";
            this.btquaylai.Size = new System.Drawing.Size(65, 48);
            this.btquaylai.TabIndex = 92;
            this.btquaylai.UseVisualStyleBackColor = true;
            this.btquaylai.Click += new System.EventHandler(this.btquaylai_Click);
            // 
            // Formxoathunhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(573, 288);
            this.Controls.Add(this.btquaylai);
            this.Controls.Add(this.cbmatn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbkhoanthunhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btxoakhoanthu);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Formxoathunhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xóa thu nhập";
            this.Load += new System.EventHandler(this.Formxoathunhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbmatn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbkhoanthunhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btxoakhoanthu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btquaylai;
    }
}