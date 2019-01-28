//-----------------------------------------------------------------------
// <copyright file="ICustomer.cs" company="Bridgelabz">
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
    /// ICustomer is an interface which have all the unimplemented methods
    /// </summary>
    public interface ICustomer
    {
        /// <summary>
        /// Adds the customer.
        /// </summary>
        void AddCustomer();

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>IList return type</returns>
        IList<CustomerModel> GetAllCustomers();

        /// <summary>
        /// Customers the by identifier.
        /// </summary>
        void CustomerById();      
    }

    /// <summary>
    /// Customer data is an implementation class of ICustomer
    /// </summary>
    /// <seealso cref="OopsPrograms.ICustomer" />
    public class CustomerData : ICustomer
    {
        /// <summary>
        /// The customer model
        /// </summary>       
        private CustomerModel customerModel = new CustomerModel();

        /// <summary>
        /// Adds the customer.
        /// </summary>
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
                using (StreamReader sr = new StreamReader(constants.CustomerData))
                {
                    string json = sr.ReadToEnd();
                    sr.Close();
                    customers = JsonConvert.DeserializeObject<List<CustomerModel>>(json);
                    customers.Add(customerModel);
                    var write = JsonConvert.SerializeObject(constants.CustomerData);
                    File.WriteAllText(constants.CustomerData, write);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Customers the by identifier.
        /// </summary>
        /// <exception cref="NotImplementedException"> Not implemented exception </exception>
        public void CustomerById()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>IList return type</returns>
        public IList<CustomerModel> GetAllCustomers()
        {
            IList<CustomerModel> customers = new List<CustomerModel>();
             try
             {
                Constants constants = new Constants();
                using (StreamReader sr = new StreamReader(constants.CustomerData))
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
