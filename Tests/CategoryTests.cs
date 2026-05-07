using Microsoft.VisualStudio.TestTools.UnitTesting;
using BudgetApp;
using System;
using System.Collections.Generic;

namespace BudgetApp.Tests
{
    [TestClass]
    public class CategoryTests
    {
        // Тест 1: Назначение категории транзакции 
        [TestMethod]
        public void Transaction_WithCategory_ShouldSaveCategory()
        {
            // Arrange
            var transaction = new Transaction(
                "Автобус", 50, TransactionType.Расход, DateTime.Today, "Транспорт");

            // Act + Assert
            Assert.AreEqual("Транспорт", transaction.Category);
        }

        // Тест 2: Категория по умолчанию 
        [TestMethod]
        public void Transaction_WithoutCategory_ShouldUseDefault()
        {
            // Arrange
            var transaction = new Transaction(
                "Зарплата", 50000, TransactionType.Доход, DateTime.Today);

            // Act + Assert
            Assert.AreEqual("Без категории", transaction.Category);
        }

        // Тест 3: Статистика по одной категории
        [TestMethod]
        public void GetCategoryStats_SingleCategory_ShouldReturnCorrectSum()
        {
            // Arrange
            var manager = new BudgetManager();
            manager.Transactions.Add(new Transaction(
                "Автобус", 50, TransactionType.Расход, DateTime.Today, "Транспорт"));
            manager.Transactions.Add(new Transaction(
                "Метро", 50, TransactionType.Расход, DateTime.Today, "Транспорт"));

            // Act
            Dictionary<string, decimal> stats = manager.GetCategoryStats();

            // Assert
            Assert.AreEqual(-100m, stats["Транспорт"]);
        }

        // Тест 4: Статистика по нескольким категориям 
        [TestMethod]
        public void GetCategoryStats_MultipleCategories_ShouldReturnAll()
        {
            // Arrange
            var manager = new BudgetManager();
            manager.Transactions.Add(new Transaction(
                "Зарплата", 50000, TransactionType.Доход, DateTime.Today, "Работа"));
            manager.Transactions.Add(new Transaction(
                "Кафе", 500, TransactionType.Расход, DateTime.Today, "Еда"));

            // Act
            Dictionary<string, decimal> stats = manager.GetCategoryStats();

            // Assert
            Assert.AreEqual(2, stats.Count);
            Assert.IsTrue(stats.ContainsKey("Работа"));
            Assert.IsTrue(stats.ContainsKey("Еда"));
        }

        // Тест 5: Статистика при пустом списке
        [TestMethod]
        public void GetCategoryStats_NoTransactions_ShouldReturnEmpty()
        {
            // Arrange
            var manager = new BudgetManager();

            // Act
            Dictionary<string, decimal> stats = manager.GetCategoryStats();

            // Assert
            Assert.AreEqual(0, stats.Count);
        }

        // Тест 6: Обновление категории
        [TestMethod]
        public void Transaction_UpdateCategory_ShouldChangeCategory()
        {
            // Arrange
            var transaction = new Transaction(
                "Автобус", 50, TransactionType.Расход, DateTime.Today, "Транспорт");

            // Act
            transaction.Category = "Работа";

            // Assert
            Assert.AreEqual("Работа", transaction.Category);
        }

        // Тест 7: Фильтрация транзакций по категории
        [TestMethod]
        public void Transactions_FilterByCategory_ShouldReturnOnlyMatching()
        {
            // Arrange
            var manager = new BudgetManager();
            manager.Transactions.Add(new Transaction(
                "Автобус", 50, TransactionType.Расход, DateTime.Today, "Транспорт"));
            manager.Transactions.Add(new Transaction(
                        "Кафе", 300, TransactionType.Расход, DateTime.Today, "Еда"));
            manager.Transactions.Add(new Transaction(
                "Метро", 50, TransactionType.Расход, DateTime.Today, "Транспорт"));

            // Act
            var filtered = manager.Transactions
                .FindAll(t => t.Category == "Транспорт");

            // Assert
            Assert.AreEqual(2, filtered.Count);
            Assert.AreEqual("Автобус", filtered[0].Description);
            Assert.AreEqual("Метро", filtered[1].Description);
        }
    }
}