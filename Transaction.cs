//-----------------------------------------------------------------------
// <copyright file="Transaction.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    /// <summary>
    /// Transaction class holds all the operations which are done during transactions
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Writes the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="data">The data.</param>
        public static void WriteFile(string fileName, object data)
        {
            var convertedJson = JsonConvert.SerializeObject(data);
            File.WriteAllText(fileName, convertedJson);
        }

        /// <summary>
        /// Gets all transactions.
        /// </summary>
        /// <returns> IList return type </returns>
        public static IList<TransactionModel> GetAllTransactions()
        {
            Constants constants = new Constants();
            IList<TransactionModel> transactions = new List<TransactionModel>();
            using (StreamReader stream = new StreamReader(constants.TransactionFile))
            {
                string json = stream.ReadToEnd();
                stream.Close();
                transactions = JsonConvert.DeserializeObject<IList<TransactionModel>>(json);
                stream.Close();
            }

            return transactions;
        }

        /// <summary>
        /// Buys the stock.
        /// </summary>
        /// <exception cref="Exception">
        /// Invalid stock id
        /// or
        /// Invalid stock id
        /// or
        /// Invalid customer id
        /// or
        /// No. of shares you mentioned are not available in stock or invalid input
        /// </exception>
        public void BuyStock()
        {
            CustomerData customer = new CustomerData();
            IList<CustomerModel> customerModels = customer.GetAllCustomers();
            Console.WriteLine("id \t name \t valuation");
            foreach (var items in customerModels)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Valuation);
            }

            Console.WriteLine("Please enter the customer id");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Stock5 stockData = new Stock5();
            IList<StockModel5> stockModels = stockData.GetStock();
            Console.WriteLine("id \tname \tnumberofshares \tpricepershare");
            foreach (var items in stockModels)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShare + "\t" + items.PricePerShare);
            }

            Console.WriteLine("Please enter the  Stock Id to select stock for the customer");
            int stockId = Convert.ToInt32(Console.ReadLine());
            StockModel5 stockDataModel = null;
            bool stockFl = true;
            foreach (var items in stockModels)
            {
                if (items.Id == stockId)
                {
                    stockDataModel = items;
                    Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShare + "\t" + items.PricePerShare);
                    stockFl = false;
                }
            }

            if (stockFl == true)
            {
                throw new Exception("Invalid stock id");
            }

            Console.WriteLine("Enter the number of shares need to purchase");
            int numberOfShares = Convert.ToInt32(Console.ReadLine());
            string customerName = string.Empty;
            string stockName = string.Empty;
            int amountValuation = 0;
            if (numberOfShares < stockDataModel.NumberOfShare || numberOfShares <= 0)
            {
                int priceOfShare = 0;
                bool stockFlag = true;
                foreach (var items in stockModels)
                {
                    if (items.Id == stockId)
                    {
                        items.NumberOfShare = items.NumberOfShare - numberOfShares;
                        priceOfShare = items.PricePerShare;
                        stockName = items.Name;
                        stockFlag = false;
                    }
                }

                if (stockFlag == true)
                {
                    throw new Exception("Invalid stock id");
                }

                bool customerFlag = true;
                foreach (var item in customerModels)
                {
                    if (item.Id == customerId)
                    {
                        item.Valuation = item.Valuation - (priceOfShare * numberOfShares);
                        customerName = item.Name;
                        amountValuation = item.Valuation;
                        customerFlag = false;
                    }
                }

                if (customerFlag == true)
                {
                    throw new Exception("Invalid customer id");
                }
            }
            else
            {
                throw new Exception("No. of shares you mentioned are not available in stock or invalid input");
            }

            TransactionModel transactionModel = new TransactionModel()
            {
                CustomerName = customerName,
                StockName = stockName,
                NoOfShare = numberOfShares,
                Amount = amountValuation,
                Time = DateTime.Now.ToString(),
                TransactionType = TransactionType.Buy
            };
            IList<TransactionModel> transactionModels = Transaction.GetAllTransactions();
            transactionModels.Add(transactionModel);
            Constants constants = new Constants();
            Transaction.WriteFile(constants.StockFile, stockModels);
            Transaction.WriteFile(constants.CustomerData, customerModels);
            Transaction.WriteFile(constants.TransactionFile, transactionModels);
            Console.WriteLine("purchase sucessfull");
        }

        /// <summary>
        /// Sells the stock.
        /// </summary>
        /// <exception cref="Exception">
        /// Invalid stock id
        /// or
        /// Invalid stock id
        /// or
        /// Invalid customer id
        /// or
        /// No. of shares you mentioned are not available in stock or invalid input
        /// </exception>
        public void SellStock()
        {
            CustomerData customer = new CustomerData();
            IList<CustomerModel> customerModels = customer.GetAllCustomers();
            Console.WriteLine("id \t name \t valuation");
            foreach (var items in customerModels)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Valuation);
            }

            Console.WriteLine("Please enter the selling customer id");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Stock5 stockData = new Stock5();
            IList<StockModel5> stockModels = stockData.GetStock();
            Console.WriteLine("id \tname \tnumberofshares \tpricepershare");
            foreach (var items in stockModels)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShare + "\t" + items.PricePerShare);
            }

            Console.WriteLine("Please enter the Stock Id to which stock you want to sell");
            int stockId = Convert.ToInt32(Console.ReadLine());
            StockModel5 stockDataModel = null;
            bool stockFl = true;
            foreach (var items in stockModels)
            {
                if (items.Id == stockId)
                {
                    stockDataModel = items;
                    Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShare + "\t" + items.PricePerShare);
                    stockFl = false;
                }
            }

            if (stockFl == true)
            {
                throw new Exception("Invalid stock id");
            }

            Console.WriteLine("Enter the number of shares need to sell");
            int numberOfShares = Convert.ToInt32(Console.ReadLine());
            string customerName = string.Empty;
            string stockName = string.Empty;
            int amountValuation = 0;
            if (numberOfShares > 0)
            {
                int priceOfShare = 0;
                bool stockFlag = true;
                foreach (var items in stockModels)
                {
                    if (items.Id == stockId)
                    {
                        items.NumberOfShare = items.NumberOfShare + numberOfShares;
                        priceOfShare = items.PricePerShare * numberOfShares;
                        stockName = items.Name;
                        stockFlag = false;
                    }
                }

                if (stockFlag == true)
                {
                    throw new Exception("Invalid stock id");
                }

                bool customerFlag = true;
                foreach (var item in customerModels)
                {
                    if (item.Id == customerId)
                    {
                        item.Valuation = item.Valuation + priceOfShare;
                        customerName = item.Name;
                        amountValuation = item.Valuation;
                        customerFlag = false;
                    }
                }

                if (customerFlag == true)
                {
                    throw new Exception("Invalid customer id");
                }
            }
            else
            {
                throw new Exception("No. of shares you mentioned are not available in stock or invalid input");
            }

            TransactionModel transactionModel = new TransactionModel()
            {
                CustomerName = customerName,
                StockName = stockName,
                NoOfShare = numberOfShares,
                Amount = amountValuation,
                Time = DateTime.Now.ToString(),
                TransactionType = TransactionType.Sell
            };
            IList<TransactionModel> transactionModels = Transaction.GetAllTransactions();
            transactionModels.Add(transactionModel);
            Constants constants = new Constants();
            Transaction.WriteFile(constants.StockFile, stockModels);
            Transaction.WriteFile(constants.CustomerData, customerModels);
            Transaction.WriteFile(constants.TransactionFile, transactionModels);
            Console.WriteLine("selling is successfull");
        }
    }
}