namespace CoordPicker {
    partial class CoordPicker {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_open = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.coordBox1 = new System.Windows.Forms.TextBox();
            this.fnameBox1 = new System.Windows.Forms.TextBox();
            this.sizeBox1 = new System.Windows.Forms.TextBox();
            this.group_zoom = new System.Windows.Forms.GroupBox();
            this.scaleBox1 = new System.Windows.Forms.TextBox();
            this.button_minus = new System.Windows.Forms.Button();
            this.button_plus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.group_zoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(13, 13);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 30);
            this.button_open.TabIndex = 1;
            this.button_open.Text = "Open";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(2, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 600);
            this.panel1.TabIndex = 2;
            // 
            // coordBox1
            // 
            this.coordBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.coordBox1.Location = new System.Drawing.Point(535, 31);
            this.coordBox1.Name = "coordBox1";
            this.coordBox1.Size = new System.Drawing.Size(270, 25);
            this.coordBox1.TabIndex = 3;
            // 
            // fnameBox1
            // 
            this.fnameBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fnameBox1.BackColor = System.Drawing.SystemColors.Control;
            this.fnameBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fnameBox1.Location = new System.Drawing.Point(236, 7);
            this.fnameBox1.Name = "fnameBox1";
            this.fnameBox1.Size = new System.Drawing.Size(569, 18);
            this.fnameBox1.TabIndex = 4;
            // 
            // sizeBox1
            // 
            this.sizeBox1.BackColor = System.Drawing.SystemColors.Control;
            this.sizeBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sizeBox1.Location = new System.Drawing.Point(236, 31);
            this.sizeBox1.Name = "sizeBox1";
            this.sizeBox1.Size = new System.Drawing.Size(151, 18);
            this.sizeBox1.TabIndex = 5;
            // 
            // group_zoom
            // 
            this.group_zoom.Controls.Add(this.scaleBox1);
            this.group_zoom.Controls.Add(this.button_minus);
            this.group_zoom.Controls.Add(this.button_plus);
            this.group_zoom.Location = new System.Drawing.Point(107, 15);
            this.group_zoom.Name = "group_zoom";
            this.group_zoom.Size = new System.Drawing.Size(112, 28);
            this.group_zoom.TabIndex = 6;
            this.group_zoom.TabStop = false;
            // 
            // scaleBox1
            // 
            this.scaleBox1.Location = new System.Drawing.Point(26, 1);
            this.scaleBox1.Name = "scaleBox1";
            this.scaleBox1.Size = new System.Drawing.Size(60, 25);
            this.scaleBox1.TabIndex = 2;
            this.scaleBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button_minus
            // 
            this.button_minus.Location = new System.Drawing.Point(0, 0);
            this.button_minus.Name = "button_minus";
            this.button_minus.Size = new System.Drawing.Size(27, 27);
            this.button_minus.TabIndex = 0;
            this.button_minus.Text = "-";
            this.button_minus.UseVisualStyleBackColor = true;
            this.button_minus.Click += new System.EventHandler(this.button_minus_Click);
            // 
            // button_plus
            // 
            this.button_plus.Location = new System.Drawing.Point(85, 0);
            this.button_plus.Name = "button_plus";
            this.button_plus.Size = new System.Drawing.Size(27, 27);
            this.button_plus.TabIndex = 1;
            this.button_plus.Text = "+";
            this.button_plus.UseVisualStyleBackColor = true;
            this.button_plus.Click += new System.EventHandler(this.button_plus_Click);
            // 
            // CoordPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 664);
            this.Controls.Add(this.group_zoom);
            this.Controls.Add(this.sizeBox1);
            this.Controls.Add(this.fnameBox1);
            this.Controls.Add(this.coordBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_open);
            this.Name = "CoordPicker";
            this.Text = "CoordPicker";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.group_zoom.ResumeLayout(false);
            this.group_zoom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox coordBox1;
        private System.Windows.Forms.TextBox fnameBox1;
        private System.Windows.Forms.TextBox sizeBox1;
        private System.Windows.Forms.GroupBox group_zoom;
        private System.Windows.Forms.Button button_minus;
        private System.Windows.Forms.TextBox scaleBox1;
        private System.Windows.Forms.Button button_plus;
    }
}

