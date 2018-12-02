namespace View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PaintGroupBox = new System.Windows.Forms.GroupBox();
            this.circuitPictureBox = new System.Windows.Forms.PictureBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CalculateImpedanceButton = new System.Windows.Forms.Button();
            this.CircuitsComboBox = new System.Windows.Forms.ComboBox();
            this.SelectingCircuitLabel = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.NadeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NominalTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PaintGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circuitPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PaintGroupBox
            // 
            this.PaintGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PaintGroupBox.Controls.Add(this.panel1);
            this.PaintGroupBox.Location = new System.Drawing.Point(255, 15);
            this.PaintGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.PaintGroupBox.Name = "PaintGroupBox";
            this.PaintGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.PaintGroupBox.Size = new System.Drawing.Size(645, 362);
            this.PaintGroupBox.TabIndex = 0;
            this.PaintGroupBox.TabStop = false;
            // 
            // circuitPictureBox
            // 
            this.circuitPictureBox.Location = new System.Drawing.Point(3, 9);
            this.circuitPictureBox.Name = "circuitPictureBox";
            this.circuitPictureBox.Size = new System.Drawing.Size(629, 334);
            this.circuitPictureBox.TabIndex = 0;
            this.circuitPictureBox.TabStop = false;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(146, 275);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(99, 60);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(20, 275);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(105, 30);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CalculateImpedanceButton
            // 
            this.CalculateImpedanceButton.Location = new System.Drawing.Point(20, 343);
            this.CalculateImpedanceButton.Margin = new System.Windows.Forms.Padding(4);
            this.CalculateImpedanceButton.Name = "CalculateImpedanceButton";
            this.CalculateImpedanceButton.Size = new System.Drawing.Size(225, 28);
            this.CalculateImpedanceButton.TabIndex = 2;
            this.CalculateImpedanceButton.Text = "Рассчитать импеданс";
            this.CalculateImpedanceButton.UseVisualStyleBackColor = true;
            this.CalculateImpedanceButton.Click += new System.EventHandler(this.CalculateImpedanceButton_Click);
            // 
            // CircuitsComboBox
            // 
            this.CircuitsComboBox.FormattingEnabled = true;
            this.CircuitsComboBox.Location = new System.Drawing.Point(113, 11);
            this.CircuitsComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.CircuitsComboBox.Name = "CircuitsComboBox";
            this.CircuitsComboBox.Size = new System.Drawing.Size(132, 24);
            this.CircuitsComboBox.TabIndex = 4;
            this.CircuitsComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectingCircuitsComboBox_SelectedIndexChanged);
            // 
            // SelectingCircuitLabel
            // 
            this.SelectingCircuitLabel.AutoSize = true;
            this.SelectingCircuitLabel.Location = new System.Drawing.Point(16, 15);
            this.SelectingCircuitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectingCircuitLabel.Name = "SelectingCircuitLabel";
            this.SelectingCircuitLabel.Size = new System.Drawing.Size(87, 17);
            this.SelectingCircuitLabel.TabIndex = 5;
            this.SelectingCircuitLabel.Text = "Выбор цепи";
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(20, 44);
            this.treeView.Margin = new System.Windows.Forms.Padding(4);
            this.treeView.MinimumSize = new System.Drawing.Size(225, 136);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(225, 136);
            this.treeView.TabIndex = 6;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewCircuit_AfterSelect);
            // 
            // NadeComboBox
            // 
            this.NadeComboBox.FormattingEnabled = true;
            this.NadeComboBox.Location = new System.Drawing.Point(20, 213);
            this.NadeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.NadeComboBox.Name = "NadeComboBox";
            this.NadeComboBox.Size = new System.Drawing.Size(225, 24);
            this.NadeComboBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 192);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Добавить элемент";
            // 
            // NominalTextBox
            // 
            this.NominalTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.NominalTextBox.Location = new System.Drawing.Point(20, 245);
            this.NominalTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NominalTextBox.Name = "NominalTextBox";
            this.NominalTextBox.Size = new System.Drawing.Size(225, 22);
            this.NominalTextBox.TabIndex = 9;
            this.NominalTextBox.Text = "Значение";
            this.NominalTextBox.Enter += new System.EventHandler(this.NominalTextBox_Enter);
            this.NominalTextBox.Leave += new System.EventHandler(this.NominalTextBox_Leave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 30);
            this.button1.TabIndex = 10;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.circuitPictureBox);
            this.panel1.Location = new System.Drawing.Point(7, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 343);
            this.panel1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 394);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NominalTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NadeComboBox);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.SelectingCircuitLabel);
            this.Controls.Add(this.CircuitsComboBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CalculateImpedanceButton);
            this.Controls.Add(this.PaintGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(733, 409);
            this.Name = "MainForm";
            this.Text = "Расчет комплексного сопротивления";
            this.PaintGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.circuitPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PaintGroupBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CalculateImpedanceButton;
        private System.Windows.Forms.ComboBox CircuitsComboBox;
        private System.Windows.Forms.Label SelectingCircuitLabel;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ComboBox NadeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NominalTextBox;
        private System.Windows.Forms.PictureBox circuitPictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}

