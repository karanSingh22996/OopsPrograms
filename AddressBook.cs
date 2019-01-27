//-----------------------------------------------------------------------
// <copyright file="AddressBook.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;  
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;

    /// <summary>
    /// The address book contain all the operation of address book
    /// </summary>
    public class AddressBook
    {
        /// <summary>
        /// Adds the person.
        /// </summary>
        public void AddPerson()
        {
            IList<Person> list = new List<Person>();

            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter city");
            string city = Console.ReadLine();
            Console.WriteLine("Enter state");
            string state = Console.ReadLine();
            Console.WriteLine("Enter zip code");
            string zip = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            string phoneNum = Console.ReadLine();
            if (Regex.IsMatch(firstName, @"[a-zA-z]{1,10}") && Regex.IsMatch(lastName, @"[a-zA-z]{1,10}") && Regex.IsMatch(city, @"[a-zA-z]{1,10}")
                && Regex.IsMatch(state, @"[a-zA-z]{1,10}") && Regex.IsMatch(zip, @"[0-9]{6}") && Regex.IsMatch(phoneNum, @"[0-9]{10}"))
            {
                Address address = new Address(city, state, zip);
                Person person = new Person(firstName, lastName, address, phoneNum);
                list.Add(person);
                string strResultJson = JsonConvert.SerializeObject(list);
                Constants constants = new Constants();
                File.WriteAllText(constants.address, strResultJson);
            }
        }
    }
}
