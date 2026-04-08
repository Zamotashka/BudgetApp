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

        public Transaction(string description, decimal amount, TransactionType type, DateTime date)
        {
            Description = description;
            Amount = amount;
            Type = type;
            Date = date;
        }

        public override string ToString()
        {
            string typeStr = Type == TransactionType.Доход ? "Доход" : "Расход";
            return $"{Description} - {typeStr} ({Amount} руб.) [{Date:dd.MM.yyyy}]";
        }
    }
}