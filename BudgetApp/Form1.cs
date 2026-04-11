using System;
using System.Windows.Forms;

namespace BudgetApp
{
    public partial class Form1 : Form
    {
        private BudgetManager _budgetManager;

        public Form1()
        {
            InitializeComponent();
            _budgetManager = new BudgetManager();
            typeComboBox.Items.AddRange(new object[] { "Доход", "Расход" });
            typeComboBox.SelectedIndex = 0;
            RefreshList();
            UpdateBudgetLabel();
        }

        // ───── вспомогательные методы ─────────────────────────────────────

        private void RefreshList()
        {
            transactionsListBox.Items.Clear();
            foreach (var t in _budgetManager.Transactions)
                transactionsListBox.Items.Add(t.ToString());
        }

        private void UpdateBudgetLabel()
        {
            decimal total = _budgetManager.TotalBudget;
            totalBudgetLabel.Text = $"Общий бюджет: {total:F2} руб.";
            totalBudgetLabel.ForeColor = total >= 0
                ? System.Drawing.Color.Green
                : System.Drawing.Color.Red;
        }

        // ───── валидация ввода ────────────────────────────────────────────

        private bool TryGetInput(out string description, out decimal amount)
        {
            description = string.Empty;
            amount = 0;

            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text) ||
                string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(amountTextBox.Text, out amount) || amount < 0)
            {
                MessageBox.Show("Введите корректную сумму (не отрицательную)!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            description = descriptionTextBox.Text.Trim();
            return true;
        }

        private TransactionType GetSelectedType()
        {
            return (TransactionType)Enum.Parse(typeof(TransactionType),
                typeComboBox.SelectedItem.ToString());
        }

        private void ClearInputs()
        {
            descriptionTextBox.Clear();
            amountTextBox.Clear();
        }

        // ───── обработчики кнопок ─────────────────────────────────────────

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out string description, out decimal amount))
                return;

            var transaction = new Transaction(
                description, amount, GetSelectedType(), datePicker.Value);

            try
            {
                _budgetManager.AddTransaction(transaction);
                ClearInputs();
                RefreshList();
                UpdateBudgetLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (transactionsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите транзакцию для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var transaction = _budgetManager.Transactions[transactionsListBox.SelectedIndex];

            try
            {
                _budgetManager.RemoveTransaction(transaction);
                ClearInputs();
                RefreshList();
                UpdateBudgetLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (transactionsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите транзакцию для обновления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryGetInput(out string description, out decimal amount))
                return;

            var transaction = _budgetManager.Transactions[transactionsListBox.SelectedIndex];

            try
            {
                _budgetManager.UpdateTransaction(
                    transaction, description, amount, GetSelectedType());
                ClearInputs();
                RefreshList();
                UpdateBudgetLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ───── автозаполнение полей при выборе транзакции ─────────────────

        private void transactionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (transactionsListBox.SelectedIndex == -1)
                return;

            var t = _budgetManager.Transactions[transactionsListBox.SelectedIndex];
            descriptionTextBox.Text = t.Description;
            amountTextBox.Text = t.Amount.ToString();
            typeComboBox.SelectedIndex = (int)t.Type;
            datePicker.Value = t.Date;
        }
    }
}