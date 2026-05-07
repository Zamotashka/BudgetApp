using System;

namespace BudgetApp
{
    public enum TransactionType
    {
        Доход,
        Расход
    }

    public class Transaction
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }

        public Transaction(string description, decimal amount, TransactionType type, DateTime date, string category = "Без категории")
        {
            Description = description;
            Amount = amount;
            Type = type;
            Date = date;
            Category = category;
        }

        public override string ToString()
        {
            string typeStr = Type == TransactionType.Доход ? "Доход" : "Расход";
            return $"{Description} - {typeStr} ({Amount} руб.) [{Date:dd.MM.yyyy}] [{Category}]";
        }
    }
}