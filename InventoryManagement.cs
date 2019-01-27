//-----------------------------------------------------------------------
// <copyright file="InventoryManagement.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class InventoryManagement
    {
        public IList<InventoryManagement> inventory = new List<InventoryManagement>();
        public Constants constants = new Constants();

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public double Weight { get; set; }

        /// <summary>
        /// Gets or sets the price per kg.
        /// </summary>
        /// <value>
        /// The price per kg.
        /// </value>
        public double PricePerKg { get; set; }
        public void InventoryManagementData()
        {
            try
            {
                Console.WriteLine("File Contains");
                ////Constants constants = new Constants();
                ////string items = InventoryManagementModel.ReadFile(Constants.inventoryManageMentDetails);

                using (StreamReader streamReader = new StreamReader(constants.inventoryProducts))
                {
                    string json = streamReader.ReadToEnd();
                    inventory = JsonConvert.DeserializeObject<List<InventoryManagement>>(json);
                }

                foreach (var items in inventory)
                {
                    Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Weight + "\t" + items.PricePerKg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                    Name = name,
                    Weight = weight,
                    PricePerKg = price
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
            try
            {
                ////Constants constants = new Constants();
                string data = InventoryManagement.ReadFile(constants.inventoryProducts);
                IList<InventoryManagement> inventoryDetails = JsonConvert.DeserializeObject<List<InventoryManagement>>(data);
                foreach (var items in inventoryDetails)
                {
                    Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Weight + "\t" + items.PricePerKg);
                }

                Console.WriteLine("Enter the Id to update");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (var item in inventoryDetails)
                {
                    while (id == item.Id)
                    {
                        Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Weight + "\t" + item.PricePerKg);
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
                            while (id == item.Id)
                            {
                                item.PricePerKg = newPrice;
                                break;
                            }
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter new Price");
                        newWeight = Convert.ToInt32(Console.ReadLine());
                        foreach (var item in inventoryDetails)
                        {
                            while (id == item.Id)
                            {
                                item.Weight = Weight;
                                break;
                            }
                        }

                        break;
                }

                var convertedJson = JsonConvert.SerializeObject(inventoryDetails);
                File.WriteAllText(this.constants.inventoryProducts, convertedJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete()
        {
            try
            {
                string data = InventoryManagement.ReadFile(constants.inventoryProducts);
                IList<InventoryManagement> inventoryDetails = JsonConvert.DeserializeObject<List<InventoryManagement>>(data);

                foreach (var items in inventoryDetails)
                {
                    Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Weight + "\t" + items.PricePerKg);
                }

                Console.WriteLine("Enter the Id to Delete");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (var item in inventoryDetails)
                {
                    while (id == item.Id)
                    {
                        Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Weight + "\t" + item.PricePerKg);
                        break;
                    }
                }

                foreach (var item in inventoryDetails)
                {
                    while (id == item.Id)
                    {
                        inventoryDetails.Remove(item);
                        break;
                    }
                }

                var convertedJson = JsonConvert.SerializeObject(inventoryDetails);
                File.WriteAllText(this.constants.inventoryProducts, convertedJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}