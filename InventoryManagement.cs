using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OopsPrograms
{
    class InventoryManagement
    {
        IList<InventoryManagement> inventory = new List<InventoryManagement>();
        Constants constants = new Constants();

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public double weight { get; set; }

        /// <summary>
        /// Gets or sets the price per kg.
        /// </summary>
        /// <value>
        /// The price per kg.
        /// </value>
        public double pricePerKg { get; set; }


        public void InventoryManagementData()
        {
            Console.WriteLine("File Contains");
            Constants constants = new Constants();
            //string items = InventoryManagementModel.ReadFile(Constants.inventoryManageMentDetails);

            using (StreamReader streamReader = new StreamReader(constants.inventoryProducts))
            {
                string json = streamReader.ReadToEnd();
                inventory = JsonConvert.DeserializeObject<List<InventoryManagement>>(json);
            }
            foreach (var items in inventory)
            {
                Console.WriteLine(items.id+"\t"+items.name + "\t" + items.weight + "\t" + items.pricePerKg);
            }
        }
        public void AddToInventory()
        {
            try
            {
                Console.WriteLine("Enter name of the item to add");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the weight of the item");
                double weight = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the price of item");
                double price = Convert.ToDouble(Console.ReadLine());
                InventoryManagement managementModel = new InventoryManagement()
                {
                    name = name,
                    weight = weight,
                    pricePerKg = price
                };

                string data = InventoryManagement.ReadFile(constants.inventoryProducts);
                inventory = JsonConvert.DeserializeObject<List<InventoryManagement>>(data);
                inventory.Add(managementModel);
                var convertedJson = JsonConvert.SerializeObject(inventory);
                File.WriteAllText(constants.inventoryProducts, convertedJson);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static string ReadFile(string fileName)
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string json = streamReader.ReadToEnd();
                streamReader.Close();
                return json;
            }

        }

        public void UpdateInventoryData()
        {
            Constants constants = new Constants();
            string data = InventoryManagement.ReadFile(constants.inventoryProducts);
            IList<InventoryManagement> inventoryDetails = JsonConvert.DeserializeObject<List<InventoryManagement>>(data);

            foreach (var items in inventoryDetails)
            {
                Console.WriteLine(items.id + "\t" + items.name + "\t" + items.weight + "\t" + items.pricePerKg);
            }
            Console.WriteLine("Enter the Id to update");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var item in inventoryDetails)
            {
                while (id == item.id)
                {
                    Console.WriteLine(item.id + "\t" + item.name + "\t" + item.weight + "\t" + item.pricePerKg);
                    break;
                }
            }
            Console.WriteLine("Enter 1 to change the price \n Enter 2 to change weight");
            int property = Convert.ToInt32(Console.ReadLine());
            int newPrice = 0;
            int newWeight = 0;
            switch (property)
            {
                case 1:
                    Console.WriteLine("Enter new Price");
                    newPrice = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in inventoryDetails)
                    {
                        while (id == item.id)
                        {
                            item.pricePerKg = newPrice;
                            break;
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter new Price");
                    newWeight = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in inventoryDetails)
                    {
                        while (id == item.id)
                        {
                            item.weight = weight;
                            break;
                        }
                    }
                    break;
            }
            var convertedJson = JsonConvert.SerializeObject(inventoryDetails);
            File.WriteAllText(this.constants.inventoryProducts, convertedJson);

        }
    }
}