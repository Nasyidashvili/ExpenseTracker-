namespace ExpenseTracker
{
    public class ExpenseService
    {
        public static void AddExpense(string description, decimal amount, Category category)
        {
            var expense = FileStorage.Load();
            int newId = expense.Count > 0 ? expense.Max(e => e.Id) + 1 : 1;
            expense.Add(new Expense
            {
                Id = newId,
                Date = DateTime.Now,
                Description = description,
                Amount = amount,
                Category = category
            });
            FileStorage.Save(expense);
            Console.WriteLine($"Expense added (ID: {newId}) ");
        }

        public static void ListExpenses()
        {
            var expense = FileStorage.Load();
            if(expense.Count == 0)
            {
                Console.WriteLine("No expenses recorded.");
                return;
            }
            foreach(var exp in expense)
            {
                Console.WriteLine($"{exp.Id} | {exp.Date:yyyy-MM-dd} | {exp.Description} | {exp.Amount:C} | {exp.Category}");
            }
        }
        
        public static void UpdateExpenses(int id, decimal amount)
        {
            var expense = FileStorage.Load();
            var exp = expense.FirstOrDefault(e => e.Id == id);
            if (exp  == null)
            {
                Console.WriteLine("Expense not found");
                return;
            }
            exp!.Amount = amount;
            FileStorage.Save(expense);
            Console.WriteLine("Expense updated Successfully");
        }

        public static void DeleteExpense(int id)
        {
            var expense = FileStorage.Load();
            var exp = expense.FirstOrDefault(e => e.Id == id);
            if (exp == null)
            {
                Console.WriteLine("Expense not found");
                return;
            }   
            expense.Remove(exp);
            FileStorage.Save(expense);
            Console.WriteLine("Expense deleted successfully");
        }

        public static void Summary()
        {
            var expense = FileStorage.Load();
            var total = expense.Sum(e => e.Amount);
            Console.WriteLine($"Total expenses: {total}");
        }

        public static void SummaryByMonth(int month)
        {
            var exp = FileStorage.Load();
            var total = exp.Where(e => e.Date.Month == month).Sum(e => e.Amount);
            Console.WriteLine($"Total expenses for month {month}: {total}");
        }
    }
}
