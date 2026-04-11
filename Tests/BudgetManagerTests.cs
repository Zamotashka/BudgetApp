using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetApp.Tests
{
    [TestClass]
    public class BudgetManagerTests
    {
        private BudgetManager _manager;

        [TestInitialize]
        public void Setup()
        {
            if (File.Exists("transactions.txt"))
                File.Delete("transactions.txt");

            _manager = new BudgetManager();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists("transactions.txt"))
                File.Delete("transactions.txt");
        }

        [TestMethod]
        public void AddTransaction_IncreasesCount()
        {
            // Arrange
            var transaction = new Transaction("Зарплата", 50000, TransactionType.Доход, DateTime.Now);
            // Act
            _manager.AddTransaction(transaction);
            // Assert
            Assert.AreEqual(1, _manager.Transactions.Count);
        }

        [TestMethod]
        public void RemoveTransaction_DecreasesCount()
        {
            // Arrange
            var transaction = new Transaction("Зарплата", 50000, TransactionType.Доход, DateTime.Now);
            _manager.AddTransaction(transaction);
            // Act
            _manager.RemoveTransaction(transaction);
            // Assert
            Assert.AreEqual(0, _manager.Transactions.Count);
        }

        [TestMethod]
        public void TotalBudget_IncomeOnly()
        {
            // Arrange
            _manager.AddTransaction(new Transaction("Зарплата", 50000, TransactionType.Доход, DateTime.Now));
            _manager.AddTransaction(new Transaction("Фриланс", 10000, TransactionType.Доход, DateTime.Now));
            // Act
            var result = _manager.TotalBudget;
            // Assert
            Assert.AreEqual(60000, result);
        }

        [TestMethod]
        public void TotalBudget_ExpenseOnly()
        {
            // Arrange
            _manager.AddTransaction(new Transaction("Продукты", 3000, TransactionType.Расход, DateTime.Now));
            _manager.AddTransaction(new Transaction("Кафе", 1000, TransactionType.Расход, DateTime.Now));
            // Act
            var result = _manager.TotalBudget;
            // Assert
            Assert.AreEqual(-4000, result);
        }

        [TestMethod]
        public void TotalBudget_MixedTransactions()
        {
            // Arrange
            _manager.AddTransaction(new Transaction("Зарплата", 50000, TransactionType.Доход, DateTime.Now));
            _manager.AddTransaction(new Transaction("Аренда", 20000, TransactionType.Расход, DateTime.Now));
            // Act
            var result = _manager.TotalBudget;
            // Assert
            Assert.AreEqual(30000, result);
        }

        [TestMethod]
        public void TotalBudget_EmptyList()
        {
            // Act
            var result = _manager.TotalBudget;
            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void UpdateTransaction_ChangesDescription()
        {
            // Arrange
            var transaction = new Transaction("Старое", 1000, TransactionType.Доход, DateTime.Now);
            _manager.AddTransaction(transaction);
            // Act
            _manager.UpdateTransaction(transaction, "Новое", 1000, TransactionType.Доход);
            // Assert
            Assert.AreEqual("Новое", transaction.Description);
        }

        [TestMethod]
        public void UpdateTransaction_ChangesAmount()
        {
            // Arrange
            var transaction = new Transaction("Зарплата", 1000, TransactionType.Доход, DateTime.Now);
            _manager.AddTransaction(transaction);
            // Act
            _manager.UpdateTransaction(transaction, "Зарплата", 5000, TransactionType.Доход);
            // Assert
            Assert.AreEqual(5000, transaction.Amount);
        }

        [TestMethod]
        public void UpdateTransaction_ChangesType()
        {
            // Arrange
            var transaction = new Transaction("Перевод", 1000, TransactionType.Доход, DateTime.Now);
            _manager.AddTransaction(transaction);
            // Act
            _manager.UpdateTransaction(transaction, "Перевод", 1000, TransactionType.Расход);
            // Assert
            Assert.AreEqual(TransactionType.Расход, transaction.Type);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTransaction_NullThrows()
        {
            // Act
            _manager.AddTransaction(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveTransaction_NullThrows()
        {
            // Act
            _manager.RemoveTransaction(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateTransaction_NullThrows()
        {
            // Act
            _manager.UpdateTransaction(null, "Тест", 1000, TransactionType.Доход);
        }
    }
}