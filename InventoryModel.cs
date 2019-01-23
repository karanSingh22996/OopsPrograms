﻿//-----------------------------------------------------------------------
// <copyright file=" InventoryModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    class InventoryModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required(ErrorMessage = "Name is Required")]
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        [Range(1, 1000, ErrorMessage = "availableShare must be in range 1 to 1000")]
        public double weight { get; set; }
        /// <summary>
        /// Gets or sets the priceper kg.
        /// </summary>
        /// <value>
        /// The priceper kg.
        /// </value>
        [Range(1, 10000, ErrorMessage = "availableShare must be in range 1 to 10000")]
        public double priceperKg { get; set; }
        /// <summary>
        /// Reads the json data.
        /// </summary>
        public static void ReadJsonData()
        {
            using (StreamReader r = new StreamReader("Inventory.json"))
            {
                string json = r.ReadToEnd();
                Console.WriteLine("Name\t weight\t PriceperKg\t Amount");
                List<InventoryModel> items = JsonConvert.DeserializeObject<List<InventoryModel>>(json);
                foreach(var model in items)
                {
                    Console.WriteLine(" {0}\t  {1}\t  {2}\t\t {3}",model.name, model.weight, model.priceperKg, (model.weight * model.priceperKg));
                    //Console.WriteLine("Weight {0}", model.weight);
                    //Console.WriteLine("Price {0}",model.priceperKg);
                    //Console.WriteLine("The price of "+model.name+" is "+(model.weight*model.priceperKg));
                }
            }
        }
    }
}