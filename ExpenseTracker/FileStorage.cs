using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ExpenseTracker
{
    public class FileStorage
    {
        private const string FileName = "expenses.json";

        public static List<Expense> Load()
        {
            if (!File.Exists(FileName))
            {
                return new List<Expense>();
            }

            var json = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>();
        }
        
        public static void Save(List<Expense> exp)
        {
            var json = JsonSerializer.Serialize(exp);
            File.WriteAllText(FileName, json);
        }
    }
}
