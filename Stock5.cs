//-----------------------------------------------------------------------
// <copyright file="Stock5.cs" company="Bridgelabz">
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
    /// stock class will have method to add and print all the stocks
    /// </summary>
    public class Stock5
    {
        /// <summary>
        /// The constants
        /// </summary>
        private Constants constants = new Constants();

        /// <summary>
        /// Adds the stock.
        /// </summary>
        public void AddStock()
        {
            try
            {
                IList<StockModel5> stockModels = new List<StockModel5>();
                Console.WriteLine("Enter customer id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter stock name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter price per share");
                int price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter number of share");
                int num = Convert.ToInt32(Console.ReadLine());
                StockModel5 stock = new StockModel5
                {
                    Id = id,
                    Name = name,
                    PricePerShare = price,
                    NumberOfShare = num
                };
                Constants constants = new Constants();
                using (StreamReader sr = new StreamReader(constants.StockFile))
                {
                    string json = sr.ReadToEnd();
                    sr.Close();
                    stockModels = JsonConvert.DeserializeObject<List<StockModel5>>(json);
                    stockModels.Add(stock);
                    var write = JsonConvert.SerializeObject(stockModels);
                    File.WriteAllText(constants.StockFile, write);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Gets the stock.
        /// </summary>
        /// <returns> IList returns </returns>
        public IList<StockModel5> GetStock()
        {
            IList<StockModel5> list = new List<StockModel5>();
            try
            {
                using (StreamReader sr = new StreamReader(this.constants.StockFile))
                {
                    var json = sr.ReadToEnd();
                    list = JsonConvert.DeserializeObject<List<StockModel5>>(json);
                    //// Console.WriteLine("id \tname \t pricePerShare \t numberOfShare");
                    ////foreach(var items in list)
                    ////{
                    ////    Console.WriteLine(items.Id+"\t"+items.Name+"\t"+items.PricePerShare+"\t"+items.NumberOfShare);
                    ////}
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return list;
        }
    }
}
