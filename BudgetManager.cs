using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BudgetApp
{
    public class BudgetManager
    {
        private const string FilePath = "transactions.txt";

        public List<Transaction> Transactions { get; private set; }

        public decimal TotalBudget
        {
            get
            {
                return Transactions.Sum(t =>
                    t.Type == TransactionType.Доход ? t.Amount : -t.Amount);
            }
        }

        public BudgetManager()
        {
            Transactions = new List<Transaction>();
            LoadTransactions();
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            Transactions.Add(transaction);
            SaveTransactions();
        }

        public void RemoveTransaction(Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            Transactions.Remove(transaction);
            SaveTransactions();
        }

        public void UpdateTransaction(Transaction transaction, string newDescription,
            decimal newAmount, TransactionType newType)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            transaction.Description = newDescription;
            transaction.Amount = newAmount;
            transaction.Type = newType;
            SaveTransactions();
        }

        private void SaveTransactions()
        {
            File.WriteAllLines(FilePath, Transactions.Select(t =>
                $"{t.Description}|{t.Amount.ToString(CultureInfo.InvariantCulture)}|{(int)t.Type}|{t.Date:yyyy-MM-dd HH:mm:ss}"));
        }

        private void LoadTransactions()
        {
            if (!File.Exists(FilePath))
                return;

            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length != 4)
                    continue;

                if (decimal.TryParse(parts[1], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out decimal amount)
                    && int.TryParse(parts[2], out int typeInt)
                    && Enum.IsDefined(typeof(TransactionType), typeInt)
                    && DateTime.TryParse(parts[3], out DateTime date))
                {
                    Transactions.Add(new Transaction(
                        parts[0], amount, (TransactionType)typeInt, date));
                }
            }
        }
    }
}