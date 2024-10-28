namespace EdgeSearch.UI
{
    partial class AcceptCancelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAccept = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            lblMessage = new System.Windows.Forms.Label();
            flpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAccept.Location = new System.Drawing.Point(539, 3);
            btnAccept.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new System.Drawing.Size(88, 27);
            btnAccept.TabIndex = 0;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.Location = new System.Drawing.Point(635, 3);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(88, 27);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // flpButtons
            // 
            flpButtons.Controls.Add(btnCancel);
            flpButtons.Controls.Add(btnAccept);
            flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flpButtons.Location = new System.Drawing.Point(0, 172);
            flpButtons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flpButtons.Name = "flpButtons";
            flpButtons.Size = new System.Drawing.Size(727, 33);
            flpButtons.TabIndex = 1;
            // 
            // lblMessage
            // 
            lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            lblMessage.Location = new System.Drawing.Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new System.Drawing.Size(727, 172);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "Initial message";
            lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblMessage.Visible = false;
            // 
            // AcceptCancelForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(727, 205);
            Controls.Add(lblMessage);
            Controls.Add(flpButtons);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AcceptCancelForm";
            flpButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Label lblMessage;
    }
}