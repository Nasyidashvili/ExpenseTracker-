
namespace ExpenseTracker
{
    public enum Category
    {
        Food,
        Transport,
        Entertainment,
        Health,
        Other
    }
    public class Expense
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public Category Category { get; set; }
    }
}
