namespace Quanlychitieu
{
    partial class Formthemnoidungchi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formthemnoidungchi));
            this.txttennoidungchitieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btthemnoidungct = new System.Windows.Forms.Button();
            this.btquaylai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txttennoidungchitieu
            // 
            this.txttennoidungchitieu.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttennoidungchitieu.Location = new System.Drawing.Point(80, 78);
            this.txttennoidungchitieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txttennoidungchitieu.Name = "txttennoidungchitieu";
            this.txttennoidungchitieu.Size = new System.Drawing.Size(411, 42);
            this.txttennoidungchitieu.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(19, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 35);
            this.label2.TabIndex = 72;
            this.label2.Text = "Tên nội dung chi tiêu:";
            // 
            // btthemnoidungct
            // 
            this.btthemnoidungct.BackColor = System.Drawing.Color.Transparent;
            this.btthemnoidungct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btthemnoidungct.BackgroundImage")));
            this.btthemnoidungct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btthemnoidungct.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btthemnoidungct.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btthemnoidungct.ForeColor = System.Drawing.Color.Blue;
            this.btthemnoidungct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btthemnoidungct.ImageKey = "(none)";
            this.btthemnoidungct.Location = new System.Drawing.Point(193, 140);
            this.btthemnoidungct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btthemnoidungct.Name = "btthemnoidungct";
            this.btthemnoidungct.Size = new System.Drawing.Size(165, 44);
            this.btthemnoidungct.TabIndex = 71;
            this.btthemnoidungct.UseVisualStyleBackColor = false;
            this.btthemnoidungct.Click += new System.EventHandler(this.btthemnoidungct_Click);
            // 
            // btquaylai
            // 
            this.btquaylai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btquaylai.BackgroundImage")));
            this.btquaylai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btquaylai.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btquaylai.Location = new System.Drawing.Point(463, 4);
            this.btquaylai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btquaylai.Name = "btquaylai";
            this.btquaylai.Size = new System.Drawing.Size(63, 50);
            this.btquaylai.TabIndex = 85;
            this.btquaylai.UseVisualStyleBackColor = true;
            this.btquaylai.Click += new System.EventHandler(this.btquaylai_Click);
            // 
            // Formthemnoidungchi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 198);
            this.Controls.Add(this.btquaylai);
            this.Controls.Add(this.txttennoidungchitieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btthemnoidungct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Formthemnoidungchi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm nội dung chi tiêu";
            this.Load += new System.EventHandler(this.Formthemnoidungchi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txttennoidungchitieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btthemnoidungct;
        private System.Windows.Forms.Button btquaylai;
    }
}