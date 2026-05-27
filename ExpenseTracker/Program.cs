using System.CommandLine;
using ExpenseTracker;

class Program
{
    static async Task<int> Main(string[] args)
    {
        Option<string> descOption = new Option<string>("--description") { Description = "Expense description" };
        Option<decimal> amountOption = new Option<decimal>("--amount") { Description = "Expense amount" };
        Option<Category> catOption = new Option<Category>("--category") { Description = "Expense category" };
        Option<int> idOption = new Option<int>("--id") { Description = "Expense ID" };
        Option<int?> monthOption = new Option<int?>("--month") { Description = "Month number (1-12)" };

        var addComm = new Command("add", "Add a new expense");
        var listComm = new Command("list", "list all expenses");
        var UpdateComm = new Command("update", "update an expense");
        var deleteComm = new Command("delete", "delete an expense");
        var summaryComm = new Command("summary", "show summary of expenses");

        var rootCommand = new RootCommand("Expense Tracker CLI");

        rootCommand.Subcommands.Add(addComm);
        rootCommand.Subcommands.Add(listComm);
        rootCommand.Subcommands.Add(UpdateComm);
        rootCommand.Subcommands.Add(deleteComm);
        rootCommand.Subcommands.Add(summaryComm);

        addComm.Options.Add(descOption);
        addComm.Options.Add(amountOption);
        addComm.Options.Add(catOption);
        UpdateComm.Options.Add(idOption);
        UpdateComm.Options.Add(amountOption);
        deleteComm.Options.Add(idOption);
        summaryComm.Options.Add(monthOption);

        addComm.SetAction(res =>
        {
            var desc = res.GetValue(descOption);
            var amount = res.GetValue(amountOption);
            var cat = res.GetValue(catOption);
            ExpenseService.AddExpense(desc!, amount!, cat!);
        });

        listComm.SetAction(res =>
        {
            ExpenseService.ListExpenses();
        });

        UpdateComm.SetAction(res =>
        {
            var id = res.GetValue(idOption);
            var amount = res.GetValue(amountOption);
            ExpenseService.UpdateExpenses(id!, amount!);
        });

        deleteComm.SetAction(res =>
        {
            var id = res.GetValue(idOption);
            ExpenseService.DeleteExpense(id!);
        });

        summaryComm.SetAction(res =>
        {
            var month = res.GetValue(monthOption);
            if (month.HasValue)
            {
                ExpenseService.SummaryByMonth(month.Value);
            }
            else
            {
                ExpenseService.Summary();
            }
        });



        return await rootCommand.Parse(args).InvokeAsync();


    }
}
