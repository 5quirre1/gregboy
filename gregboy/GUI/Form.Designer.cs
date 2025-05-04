namespace Gregboy
{
    partial class Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region what

        private void InitializeComponent()
        {
            pictureBox = new System.Windows.Forms.PictureBox();
            dragDropLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new System.Drawing.Point(0, 0);
            pictureBox.Margin = new System.Windows.Forms.Padding(0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(320, 288);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.DragDrop += Drag_Drop;
            pictureBox.DragEnter += Drag_Enter;
            // 
            // dragDropLabel
            // 
            dragDropLabel.AutoSize = true;
            dragDropLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            dragDropLabel.Location = new System.Drawing.Point(44, 109);
            dragDropLabel.Name = "dragDropLabel";
            dragDropLabel.Size = new System.Drawing.Size(228, 28);
            dragDropLabel.TabIndex = 1;
            dragDropLabel.Text = "drag and drop a game :3";
            // 
            // Form
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(318, 249);
            Controls.Add(dragDropLabel);
            Controls.Add(pictureBox);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "Form";
            Text = "gregboy";
            Load += Form_Load;
            DragDrop += Drag_Drop;
            DragEnter += Drag_Enter;
            KeyDown += Key_Down;
            KeyUp += Key_Up;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox;
        public System.Windows.Forms.Label dragDropLabel;
    }
}