//-----------------------------------------------------------------------
// <copyright file="DataProcessingMain.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// DataProcessingMain class is calling class which will execute all the methods
    /// </summary>
    public class DataProcessingMain
    {
        /// <summary>
        /// Data the process.
        /// </summary>
        public void DataProcess()
        {
            try
            {
                char ch;
                do
                {
                    Console.WriteLine("Enter 1 for adding customer");
                    Console.WriteLine("Enter 2 to view customer");
                    Console.WriteLine("enter 3 for adding stocks");
                    Console.WriteLine("Enter 4 to view stock");
                    Console.WriteLine("Enter 5 to view Transaction");
                    Console.WriteLine("Enter 6  to buy stock");
                    Console.WriteLine("Enter 7  to sell stock");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            DataProcessingMain.AddingCustomer();
                            break;
                        case 2:
                            DataProcessingMain.ViewCustomer();
                            break;
                        case 3:
                            DataProcessingMain.AddStock();
                            break;
                        case 4:
                            DataProcessingMain.ViewStack();
                            break;
                        case 5:
                            DataProcessingMain.ViewTransactions();
                            break;
                        case 6:
                            Transaction transaction = new Transaction();
                            transaction.BuyStock();
                            break;
                        case 7:
                            Transaction transaction1 = new Transaction();
                            transaction1.SellStock();
                            break;
                    }

                    Console.WriteLine("Do you want to continue data processing");
                    ch = Convert.ToChar(Console.ReadLine());
                }
                while (ch != 'n');
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Addings the customer.
        /// </summary>
        public static void AddingCustomer()
        {
            CustomerData customer1 = new CustomerData();
            customer1.AddCustomer();
        }

        /// <summary>
        /// Views the customer.
        /// </summary>
        public static void ViewCustomer()
        {
            CustomerData customer2 = new CustomerData();
            IList<CustomerModel> list = customer2.GetAllCustomers();
            foreach (var items in list)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Valuation);
            }
        }

        /// <summary>
        /// Adds the stock.
        /// </summary>
        public static void AddStock()
        {
            Stock5 stock = new Stock5();
            stock.AddStock();
        }

        /// <summary>
        /// Views the stack.
        /// </summary>
        public static void ViewStack()
        {
            Stock5 stock1 = new Stock5();
            IList<StockModel5> stocks = stock1.GetStock();
            foreach (var items in stocks)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShare + "\t" + items.PricePerShare);
            }
        }

        /// <summary>
        /// Views the transactions.
        /// </summary>
        public static void ViewTransactions()
        {
            IList<TransactionModel> item = Transaction.GetAllTransactions();
            foreach (var items in item)
            {
                Console.WriteLine(items.CustomerName + "\t" + items.StockName + "\t" + items.NoOfShare + "\t" + items.Time + "\t" + items.TransactionType + "\t" + items.Amount);
            }
        }
    }
}
