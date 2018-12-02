namespace View
{
    partial class ImpedanceForm
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
            this.StartLabel = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.StepLabel = new System.Windows.Forms.Label();
            this.StartTextBox = new System.Windows.Forms.TextBox();
            this.FinishTextBox = new System.Windows.Forms.TextBox();
            this.StepTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Частота = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Импеданс = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalculateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(16, 11);
            this.StartLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(58, 17);
            this.StartLabel.TabIndex = 0;
            this.StartLabel.Text = "Начало";
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(16, 43);
            this.EndLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(64, 17);
            this.EndLabel.TabIndex = 1;
            this.EndLabel.Text = "Граница";
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Location = new System.Drawing.Point(16, 75);
            this.StepLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(32, 17);
            this.StepLabel.TabIndex = 2;
            this.StepLabel.Text = "Шаг";
            // 
            // StartTextBox
            // 
            this.StartTextBox.Location = new System.Drawing.Point(119, 7);
            this.StartTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.StartTextBox.Name = "StartTextBox";
            this.StartTextBox.Size = new System.Drawing.Size(132, 22);
            this.StartTextBox.TabIndex = 3;
            this.StartTextBox.TextChanged += new System.EventHandler(this.StartTextBox_TextChanged);
            // 
            // FinishTextBox
            // 
            this.FinishTextBox.Location = new System.Drawing.Point(119, 39);
            this.FinishTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.FinishTextBox.Name = "FinishTextBox";
            this.FinishTextBox.Size = new System.Drawing.Size(132, 22);
            this.FinishTextBox.TabIndex = 4;
            this.FinishTextBox.TextChanged += new System.EventHandler(this.FinishTextBox_TextChanged);
            // 
            // StepTextBox
            // 
            this.StepTextBox.Location = new System.Drawing.Point(119, 71);
            this.StepTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.StepTextBox.Name = "StepTextBox";
            this.StepTextBox.Size = new System.Drawing.Size(132, 22);
            this.StepTextBox.TabIndex = 5;
            this.StepTextBox.TextChanged += new System.EventHandler(this.StepTextBox_TextChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Частота,
            this.Импеданс});
            this.dataGridView.Location = new System.Drawing.Point(19, 139);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(232, 173);
            this.dataGridView.TabIndex = 6;
            // 
            // Частота
            // 
            this.Частота.Frozen = true;
            this.Частота.HeaderText = "Частота";
            this.Частота.Name = "Частота";
            this.Частота.ReadOnly = true;
            this.Частота.Width = 60;
            // 
            // Импеданс
            // 
            this.Импеданс.Frozen = true;
            this.Импеданс.HeaderText = "Импеданс";
            this.Импеданс.Name = "Импеданс";
            this.Импеданс.ReadOnly = true;
            this.Импеданс.Width = 150;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(20, 107);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(231, 23);
            this.CalculateButton.TabIndex = 7;
            this.CalculateButton.Text = "Расчитать";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // ImpedanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 325);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.StepTextBox);
            this.Controls.Add(this.FinishTextBox);
            this.Controls.Add(this.StartTextBox);
            this.Controls.Add(this.StepLabel);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(287, 298);
            this.Name = "ImpedanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчет импеданса";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImpedanceForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.TextBox StartTextBox;
        private System.Windows.Forms.TextBox FinishTextBox;
        private System.Windows.Forms.TextBox StepTextBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource _calculationBindingSource;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Частота;
        private System.Windows.Forms.DataGridViewTextBoxColumn Импеданс;
    }
}