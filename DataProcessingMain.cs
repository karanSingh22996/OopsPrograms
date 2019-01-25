using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    class DataProcessingMain
    {
        public void DataProcess()
        {
            Console.WriteLine("Enter 1 for adding customer");
            Console.WriteLine("Enter 2 to view customer");
            Console.WriteLine("enter 3 for adding stocks");
            Console.WriteLine("Enter 4 to view stock");
            Console.WriteLine("Enter 5 to view Transaction");
            Console.WriteLine("Enter 6  for Transactions");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    CustomerData customer1 = new CustomerData();
                    customer1.AddCustomer();
                    break;
                case 2:
                    CustomerData customer2 = new CustomerData();
                    customer2.GetAllCustomers();
                    break;
                case 3:
                    Stock5 stock = new Stock5();
                    stock.AddStock();
                    break;
                case 4:
                    Stock5 stock1 = new Stock5();
                    stock1.GetStock();
                    break;
                case 5:
                    Transaction.GetAllTransactions();
                    break;
                case 6:
                    Transaction.BuyStock();
                    Transaction.SellStock();
                    break;
            }

        }
    }
}
