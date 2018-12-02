namespace View
{
    partial class EditForm
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
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this._textBoxValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(12, 78);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(130, 23);
            this.buttonEdit.TabIndex = 0;
            this.buttonEdit.Text = "Изменить";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 120);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(130, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // _textBoxValue
            // 
            this._textBoxValue.Location = new System.Drawing.Point(12, 36);
            this._textBoxValue.Name = "_textBoxValue";
            this._textBoxValue.Size = new System.Drawing.Size(130, 22);
            this._textBoxValue.TabIndex = 2;
            this._textBoxValue.TextChanged += new System.EventHandler(this.TextBoxValue_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Значение";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 164);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._textBoxValue);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox _textBoxValue;
        private System.Windows.Forms.Label label1;
    }
}