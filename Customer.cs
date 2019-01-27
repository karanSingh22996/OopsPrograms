//-----------------------------------------------------------------------
// <copyright file="ICustomer.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public interface ICustomer
    {
        void AddCustomer();

        IList<CustomerModel> GetAllCustomers();

        void CustomerById();      
    }

    public class CustomerData : ICustomer
    {
        public CustomerModel customerModel = new CustomerModel();
        public void AddCustomer()
        {
            try
            {
                Console.WriteLine("Enter customer Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter customer name");
                string name = Console.ReadLine();
                Console.WriteLine("What is the valuation of customer");
                int value = Convert.ToInt32(Console.ReadLine());
                CustomerModel customerModel = new CustomerModel
                {
                    Id = id,
                    Name = name,
                    Valuation = value
                };
                IList<CustomerModel> customers = new List<CustomerModel>();
                Constants constants = new Constants();
                using (StreamReader sr = new StreamReader(constants.customerData))
                {
                    string json = sr.ReadToEnd();
                    sr.Close();
                    customers = JsonConvert.DeserializeObject<List<CustomerModel>>(json);
                    customers.Add(customerModel);
                    var write = JsonConvert.SerializeObject(constants.customerData);
                    File.WriteAllText(constants.customerData, write);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CustomerById()
        {
            throw new NotImplementedException();
        }

        public IList<CustomerModel> GetAllCustomers()
        {
            IList<CustomerModel> customers = new List<CustomerModel>();
             try
             {
                Constants constants = new Constants();
                using (StreamReader sr = new StreamReader(constants.customerData))
                {
                    string json = sr.ReadToEnd();
                    customers = JsonConvert.DeserializeObject<List<CustomerModel>>(json);

                    Console.WriteLine("id \t name \t valuation");
                    ////foreach (var item in customers)
                    ////{
                    ////    Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Valuation);
                    ////}
                }
             }
            catch (Exception e)
             {
                Console.WriteLine(e.Message);
             } 

            return customers;
        }
    }
}
