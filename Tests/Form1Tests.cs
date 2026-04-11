using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetApp.Tests
{
    [TestClass]
    public class UITests
    {
        private Form1 _form;

        [TestInitialize]
        public void SetUp()
        {
            _form = new Form1();
            _form.Show();
        }

        [TestCleanup]
        public void TearDown()
        {
            _form.Close();
        }

        [TestMethod]
        public void DescriptionTextBox_IsVisibleAndEnabled()
        {
            // Assert
            Assert.IsTrue(_form.descriptionTextBox.Visible);
            Assert.IsTrue(_form.descriptionTextBox.Enabled);
        }

        [TestMethod]
        public void AmountTextBox_IsVisibleAndEnabled()
        {
            // Assert
            Assert.IsTrue(_form.amountTextBox.Visible);
            Assert.IsTrue(_form.amountTextBox.Enabled);
        }

        [TestMethod]
        public void TypeComboBox_IsVisibleAndEnabled()
        {
            // Assert
            Assert.IsTrue(_form.typeComboBox.Visible);
            Assert.IsTrue(_form.typeComboBox.Enabled);
        }

        [TestMethod]
        public void TypeComboBox_HasTwoItems()
        {
            // Assert
            Assert.AreEqual(2, _form.typeComboBox.Items.Count);
        }

        [TestMethod]
        public void TypeComboBox_DefaultIsIncome()
        {
            // Assert
            Assert.AreEqual(0, _form.typeComboBox.SelectedIndex);
        }

        [TestMethod]
        public void AddButton_IsVisibleAndEnabled()
        {
            // Assert
            Assert.IsTrue(_form.addButton.Visible);
            Assert.IsTrue(_form.addButton.Enabled);
        }

        [TestMethod]
        public void RemoveButton_IsVisibleAndEnabled()
        {
            // Assert
            Assert.IsTrue(_form.removeButton.Visible);
            Assert.IsTrue(_form.removeButton.Enabled);
        }

        [TestMethod]
        public void UpdateButton_IsVisibleAndEnabled()
        {
            // Assert
            Assert.IsTrue(_form.updateButton.Visible);
            Assert.IsTrue(_form.updateButton.Enabled);
        }

        [TestMethod]
        public void TransactionsListBox_IsVisibleAndEnabled()
        {
            // Assert
            Assert.IsTrue(_form.transactionsListBox.Visible);
            Assert.IsTrue(_form.transactionsListBox.Enabled);
        }

        [TestMethod]
        public void DatePicker_IsVisibleAndEnabled()
        {
            // Assert
            Assert.IsTrue(_form.datePicker.Visible);
            Assert.IsTrue(_form.datePicker.Enabled);
        }
    }
}