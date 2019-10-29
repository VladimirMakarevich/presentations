namespace Forms.ReactiveX
{
    partial class Form1
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
            this.txt_simpleBox = new System.Windows.Forms.TextBox();
            this.lbl_text = new System.Windows.Forms.Label();
            this.btn_OpenReactiveForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_simpleBox
            // 
            this.txt_simpleBox.Location = new System.Drawing.Point(56, 41);
            this.txt_simpleBox.Name = "txt_simpleBox";
            this.txt_simpleBox.Size = new System.Drawing.Size(100, 20);
            this.txt_simpleBox.TabIndex = 0;
            this.txt_simpleBox.TextChanged += new System.EventHandler(this.Txt_simpleBox_TextChanged);
            // 
            // lbl_text
            // 
            this.lbl_text.AutoSize = true;
            this.lbl_text.Location = new System.Drawing.Point(323, 41);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(129, 13);
            this.lbl_text.TabIndex = 1;
            this.lbl_text.Text = "here will be text from input";
            this.lbl_text.Click += new System.EventHandler(this.Lbl_text_Click);
            // 
            // btn_OpenReactiveForm
            // 
            this.btn_OpenReactiveForm.Location = new System.Drawing.Point(56, 89);
            this.btn_OpenReactiveForm.Name = "btn_OpenReactiveForm";
            this.btn_OpenReactiveForm.Size = new System.Drawing.Size(100, 23);
            this.btn_OpenReactiveForm.TabIndex = 2;
            this.btn_OpenReactiveForm.Text = "open reactive form";
            this.btn_OpenReactiveForm.UseVisualStyleBackColor = true;
            this.btn_OpenReactiveForm.Click += new System.EventHandler(this.Btn_OpenReactiveForm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_OpenReactiveForm);
            this.Controls.Add(this.lbl_text);
            this.Controls.Add(this.txt_simpleBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_simpleBox;
        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Button btn_OpenReactiveForm;
    }
}

