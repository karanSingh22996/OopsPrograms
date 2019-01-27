using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OopsPrograms
{
   public  class Stock5
    {
        Constants constants = new Constants();
        public void AddStock()
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
            StockModel5 stock = new StockModel5();
            stock.Id = id;
            stock.Name = name;
            stock.PricePerShare = price;
            stock.NumberOfShare = num;
            Constants constants = new Constants();
            using (StreamReader sr = new StreamReader(constants.stockFile))
            {
                string json = sr.ReadToEnd();
                sr.Close();
                stockModels = JsonConvert.DeserializeObject<List<StockModel5>>(json);
                stockModels.Add(stock);
                var write = JsonConvert.SerializeObject(stockModels);
                File.WriteAllText(constants.stockFile, write);
            }
        }
        public IList<StockModel5> GetStock()
        {
            IList<StockModel5> list = new List<StockModel5>();
            using(StreamReader sr=new StreamReader(constants.stockFile))
            {
                var json = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<StockModel5>>(json);
               // Console.WriteLine("id \tname \t pricePerShare \t numberOfShare");
                //foreach(var items in list)
                //{
                //    Console.WriteLine(items.Id+"\t"+items.Name+"\t"+items.PricePerShare+"\t"+items.NumberOfShare);
                //}
            }
            return list;
        }
    }
}
