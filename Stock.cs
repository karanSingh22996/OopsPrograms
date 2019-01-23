//-----------------------------------------------------------------------
// <copyright file=" Stock.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    /// <summary>
    /// stock class will display all the date inside the stock json file
    /// </summary>
    class Stock
    {
        /// <summary>
        /// Reads the data.
        /// </summary>
        public void ReadData()
        {
            ////using streamreader class to read data from stock json file
            using (StreamReader r = new StreamReader("stock.json"))
            {
                ////json variable store all the details of the files read by readToEnd method
                string json = r.ReadToEnd();
                ////printing all name on console
                Console.WriteLine("Id \t name \t\t availableShares \t price");
                ////creating object of list to desrialize the data inside the json file
                IList<StockModel> items = JsonConvert.DeserializeObject<List<StockModel>>(json);
                ////iterating using enhanced foreach loop to print all the data inside the json file
                foreach (var share in items)
                {
                    ////Console.WriteLine(share.availableShares);
                    Console.WriteLine("{0} \t {1}  \t {2} \t\t\t {3}",share.id,share.name,share.availableShares, share.price);
                }
            }
        }
    }
}
