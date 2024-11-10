namespace EdgeSearch.src.UI
{
    partial class CustomProgressBarSettings
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            progressBar = new UtilsForms.Controls.CustomProgressBar();
            lblTextColor = new System.Windows.Forms.Label();
            lblFilledTextColor = new System.Windows.Forms.Label();
            lblBackgroundColor = new System.Windows.Forms.Label();
            pbFilledColor = new System.Windows.Forms.PictureBox();
            pbTextColor = new System.Windows.Forms.PictureBox();
            pbFilledTextColor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbFilledColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbTextColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFilledTextColor).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar.ForeColor = System.Drawing.Color.Black;
            progressBar.Location = new System.Drawing.Point(3, 40);
            progressBar.Name = "progressBar";
            progressBar.PaintedColor = System.Drawing.Color.Green;
            progressBar.PaintedForeColor = System.Drawing.Color.White;
            progressBar.Size = new System.Drawing.Size(296, 23);
            progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            progressBar.TabIndex = 27;
            // 
            // lblTextColor
            // 
            lblTextColor.AutoSize = true;
            lblTextColor.Location = new System.Drawing.Point(123, 13);
            lblTextColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTextColor.Name = "lblTextColor";
            lblTextColor.Size = new System.Drawing.Size(28, 15);
            lblTextColor.TabIndex = 21;
            lblTextColor.Text = "Text";
            // 
            // lblFilledTextColor
            // 
            lblFilledTextColor.AutoSize = true;
            lblFilledTextColor.Location = new System.Drawing.Point(188, 13);
            lblFilledTextColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFilledTextColor.Name = "lblFilledTextColor";
            lblFilledTextColor.Size = new System.Drawing.Size(58, 15);
            lblFilledTextColor.TabIndex = 22;
            lblFilledTextColor.Text = "Filled text";
            // 
            // lblBackgroundColor
            // 
            lblBackgroundColor.AutoSize = true;
            lblBackgroundColor.Location = new System.Drawing.Point(13, 13);
            lblBackgroundColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblBackgroundColor.Name = "lblBackgroundColor";
            lblBackgroundColor.Size = new System.Drawing.Size(71, 15);
            lblBackgroundColor.TabIndex = 23;
            lblBackgroundColor.Text = "Background";
            // 
            // pbFilledColor
            // 
            pbFilledColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbFilledColor.Location = new System.Drawing.Point(91, 9);
            pbFilledColor.Name = "pbFilledColor";
            pbFilledColor.Size = new System.Drawing.Size(23, 23);
            pbFilledColor.TabIndex = 24;
            pbFilledColor.TabStop = false;
            // 
            // pbTextColor
            // 
            pbTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbTextColor.Location = new System.Drawing.Point(158, 9);
            pbTextColor.Name = "pbTextColor";
            pbTextColor.Size = new System.Drawing.Size(23, 23);
            pbTextColor.TabIndex = 25;
            pbTextColor.TabStop = false;
            // 
            // pbFilledTextColor
            // 
            pbFilledTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbFilledTextColor.Location = new System.Drawing.Point(253, 9);
            pbFilledTextColor.Name = "pbFilledTextColor";
            pbFilledTextColor.Size = new System.Drawing.Size(23, 23);
            pbFilledTextColor.TabIndex = 26;
            pbFilledTextColor.TabStop = false;
            // 
            // CustomProgressBarSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(progressBar);
            Controls.Add(lblTextColor);
            Controls.Add(lblFilledTextColor);
            Controls.Add(lblBackgroundColor);
            Controls.Add(pbFilledColor);
            Controls.Add(pbTextColor);
            Controls.Add(pbFilledTextColor);
            Name = "CustomProgressBarSettings";
            Size = new System.Drawing.Size(302, 66);
            ((System.ComponentModel.ISupportInitialize)pbFilledColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbTextColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFilledTextColor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblTextColor;
        private System.Windows.Forms.Label lblFilledTextColor;
        private System.Windows.Forms.Label lblBackgroundColor;
        private System.Windows.Forms.PictureBox pbFilledColor;
        private System.Windows.Forms.PictureBox pbTextColor;
        private System.Windows.Forms.PictureBox pbFilledTextColor;
        public UtilsForms.Controls.CustomProgressBar progressBar;
    }
}
