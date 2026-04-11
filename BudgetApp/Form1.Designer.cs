namespace BudgetApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelDesc = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.labelType = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.transactionsListBox = new System.Windows.Forms.ListBox();
            this.totalBudgetLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDesc
            // 
            this.labelDesc.AutoSize = true;
            this.labelDesc.Location = new System.Drawing.Point(10, 13);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(60, 13);
            this.labelDesc.TabIndex = 0;
            this.labelDesc.Text = "Описание:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(73, 10);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(146, 20);
            this.descriptionTextBox.TabIndex = 1;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(231, 13);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(44, 13);
            this.labelAmount.TabIndex = 2;
            this.labelAmount.Text = "Сумма:";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(274, 10);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(86, 20);
            this.amountTextBox.TabIndex = 3;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(10, 45);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(29, 13);
            this.labelType.TabIndex = 4;
            this.labelType.Text = "Тип:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.Location = new System.Drawing.Point(73, 42);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(95, 21);
            this.typeComboBox.TabIndex = 5;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(180, 45);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(36, 13);
            this.labelDate.TabIndex = 6;
            this.labelDate.Text = "Дата:";
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(233, 42);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(146, 20);
            this.datePicker.TabIndex = 7;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(238)))), ((int)(((byte)(144)))));
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Location = new System.Drawing.Point(10, 76);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(103, 26);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Location = new System.Drawing.Point(122, 76);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(103, 26);
            this.updateButton.TabIndex = 9;
            this.updateButton.Text = "Обновить";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(182)))), ((int)(((byte)(193)))));
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.Location = new System.Drawing.Point(233, 76);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(103, 26);
            this.removeButton.TabIndex = 10;
            this.removeButton.Text = "Удалить";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // transactionsListBox
            // 
            this.transactionsListBox.FormattingEnabled = true;
            this.transactionsListBox.Location = new System.Drawing.Point(10, 117);
            this.transactionsListBox.Name = "transactionsListBox";
            this.transactionsListBox.Size = new System.Drawing.Size(489, 173);
            this.transactionsListBox.TabIndex = 11;
            this.transactionsListBox.SelectedIndexChanged += new System.EventHandler(this.transactionsListBox_SelectedIndexChanged);
            // 
            // totalBudgetLabel
            // 
            this.totalBudgetLabel.AutoSize = true;
            this.totalBudgetLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.totalBudgetLabel.Location = new System.Drawing.Point(10, 303);
            this.totalBudgetLabel.Name = "totalBudgetLabel";
            this.totalBudgetLabel.Size = new System.Drawing.Size(197, 20);
            this.totalBudgetLabel.TabIndex = 12;
            this.totalBudgetLabel.Text = "Общий бюджет: 0,00 руб.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 347);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.transactionsListBox);
            this.Controls.Add(this.totalBudgetLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление бюджетом — Прокуров";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ListBox transactionsListBox;
        private System.Windows.Forms.Label totalBudgetLabel;
    }
}