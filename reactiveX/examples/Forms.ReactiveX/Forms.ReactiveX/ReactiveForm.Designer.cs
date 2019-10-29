namespace Forms.ReactiveX
{
    partial class ReactiveForm
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
            this.lbl_ReactiveForm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_ReactiveForm
            // 
            this.lbl_ReactiveForm.AutoSize = true;
            this.lbl_ReactiveForm.Location = new System.Drawing.Point(193, 40);
            this.lbl_ReactiveForm.Name = "lbl_ReactiveForm";
            this.lbl_ReactiveForm.Size = new System.Drawing.Size(44, 13);
            this.lbl_ReactiveForm.TabIndex = 0;
            this.lbl_ReactiveForm.Text = "ooh my!";
            this.lbl_ReactiveForm.Click += new System.EventHandler(this.Lbl_ReactiveForm_Click);
            // 
            // ReactiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 98);
            this.Controls.Add(this.lbl_ReactiveForm);
            this.Name = "ReactiveForm";
            this.Text = "ReactiveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ReactiveForm;
    }
}