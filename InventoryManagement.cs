using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OopsPrograms
{
    class InventoryManagement
    {
        List<InventoryModel> list = new List<InventoryModel>();
        public static string ReadDataFromJson()
        {

            using (StreamReader sr = new StreamReader("InventoryManagement.Json"))
            {
                string json = sr.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<InventoryModel>>(json);
                foreach (InventoryModel model in items)
                {
                    Console.WriteLine(model.name + "\t" + model.weight + "\t" + model.priceperKg + "\t" + model.weight * model.priceperKg);
                }
                //foreach (var model in items)
                //{
                //    list.Add(model);
                //}
                return json;
                
            }
            //Console.WriteLine("File contains:");
            //Console.WriteLine("Name \tWeight \tPrice \tAmount");
            //foreach (InventoryModel model in list)
            //{
            //    Console.WriteLine(model.name + "\t" + model.weight + "\t" + model.priceperKg + "\t" + model.weight * model.priceperKg);
            //}
        }
        public void ManageData()
        {
            Console.WriteLine("Enter 1 to Read Data from the file");
            Console.WriteLine("Enter 2 to Add Data to the file");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ReadDataFromJson();
                    ManageData();
                    break;
                case 2:
                    AddData();
                    break;
            }
        }
        public void UpdateJsonFile(string data)
        {
            InventoryModel inventoryModel = new InventoryModel();
            string strResultJson = JsonConvert.SerializeObject(inventoryModel);
            File.WriteAllText(@"InventoryManagement.Json", data);
           
            Console.WriteLine("Updated File Data is");
            ReadDataFromJson();
        }
        public  void AddData()
        {
            Console.WriteLine("Enter name of the product");
            string name = Console.ReadLine();
            Console.WriteLine("Enter weight");
            double weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter price per kg");
            double price = Convert.ToDouble(Console.ReadLine());
            InventoryModel inventoryModel = new InventoryModel()
            {
                name = name,
                weight = weight,
                priceperKg = price
            };
            string data = InventoryManagement.ReadDataFromJson();
            var items = JsonConvert.DeserializeObject<List<InventoryModel>>(data);
            items.Add(inventoryModel);
            string strResultJson = JsonConvert.SerializeObject(items);
            UpdateJsonFile(strResultJson);
            ManageData();
        }
    }
}
