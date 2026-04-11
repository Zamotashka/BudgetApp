using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace BudgetApp.Tests
{
    [TestClass]
    public class TransactionTests
    {
        [TestMethod]
        public void ToString_IncomeFormat()
        {
            // Arrange
            var transaction = new Transaction("Зарплата", 50000, TransactionType.Доход, new DateTime(2024, 1, 15));
            // Act
            var result = transaction.ToString();
            // Assert
            StringAssert.Contains(result, "Зарплата");
            StringAssert.Contains(result, "Доход");
            StringAssert.Contains(result, "50000");
        }
        [TestMethod]
        public void ToString_ExpenseFormat()
        {
            // Arrange
            var transaction = new Transaction("Продукты", 1500, TransactionType.Расход, new DateTime(2024, 1, 15));
            // Act
            var result = transaction.ToString();
            // Assert
            StringAssert.Contains(result, "Продукты");
            StringAssert.Contains(result, "Расход");
            StringAssert.Contains(result, "1500");
        }
        [TestMethod]
        public void ToString_DateFormat()
        {
            // Arrange
            var transaction = new Transaction("Тест", 100, TransactionType.Доход, new DateTime(2024, 3, 5));
            // Act
            var result = transaction.ToString();
            // Assert
            StringAssert.Contains(result, "05.03.2024");
        }
        [TestMethod]
        public void Constructor_SavesDescription()
        {
            // Arrange
            var transaction = new Transaction("Аренда", 20000, TransactionType.Расход, DateTime.Now);
            // Act
            var result = transaction.Description;
            // Assert
            Assert.AreEqual("Аренда", result);
        }
        [TestMethod]
        public void Constructor_SavesAmount()
        {
            // Arrange
            var transaction = new Transaction("Фриланс", 15000, TransactionType.Доход, DateTime.Now);
            // Act
            var result = transaction.Amount;
            // Assert
            Assert.AreEqual(15000, result);
        }
        [TestMethod]
        public void Constructor_SavesType()
        {
            // Arrange
            var transaction = new Transaction("Кафе", 500, TransactionType.Расход, DateTime.Now);
            // Act
            var result = transaction.Type;
            // Assert
            Assert.AreEqual(TransactionType.Расход, result);
        }
        [TestMethod]
        public void Constructor_SavesDate()
        {
            // Arrange
            var date = new DateTime(2024, 6, 20);
            var transaction = new Transaction("Бонус", 3000, TransactionType.Доход, date);
            // Act
            var result = transaction.Date;
            // Assert
            Assert.AreEqual(date, result);
        }
    }
}