namespace MiniSharePointComponent.UI
{
    partial class TextController
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInsider = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInsider
            // 
            this.txtInsider.AcceptsReturn = true;
            this.txtInsider.AcceptsTab = true;
            this.txtInsider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInsider.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInsider.Location = new System.Drawing.Point(0, 0);
            this.txtInsider.Multiline = true;
            this.txtInsider.Name = "txtInsider";
            this.txtInsider.Size = new System.Drawing.Size(150, 150);
            this.txtInsider.TabIndex = 1;
            // 
            // TextController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtInsider);
            this.Name = "TextController";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInsider;

    }
}
