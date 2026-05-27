A CLI application for tracking expenses built with c# and System.CommandLine.

Project URL 
https://roadmap.sh/projects/expense-tracker

Features

add an expense with a description and amount.
update an expense.
delete an expense.
view all expenses.
view a summary of all expenses.
Users can view a summary of expenses for a specific month (of current year)

Installation

1. Clone the repository:
   git clone https://github.com/Nasyidashvili/ExpenseTracker-
2. Navigate to the project folder:
   cd ExpenseTracker
3. Build the project:
   dotnet build


Usage 

dotnet run add --description "Lunch" --amount 15 --category Food
dotnet run list
dotnet run update --id 1 --amount 20
dotnet run delete --id 1
dotnet run summary
dotnet run summary --month 5


Project URL: https://github.com/Nasyidashvili/ExpenseTracker-
