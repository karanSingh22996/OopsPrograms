//-----------------------------------------------------------------------
// <copyright file="AddressUtility.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;

    /// <summary>
    /// this class is used for storing the address
    /// </summary>
    public class AddressUtility
    {
        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>returns the list</returns>
        public static string ReadFile(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string json = streamReader.ReadToEnd();
                streamReader.Close();
                return json;
            }
        }

        /// <summary>
        /// Adds the person.
        /// </summary>
        public void AddPerson()
        {
            try
            {
                Constants constants = new Constants();
                IList<AddressBookModel> addressBook = new List<AddressBookModel>();
                Console.WriteLine("enter first name");
                string firstname = Console.ReadLine();
                Console.WriteLine("enter last name");
                string lastname = Console.ReadLine();
                Console.WriteLine("enter address");
                string address = Console.ReadLine();
                Console.WriteLine("enter city");
                string city = Console.ReadLine();
                Console.WriteLine("enter state");
                string state = Console.ReadLine();
                Console.WriteLine("enter zip");
                string zip = Console.ReadLine();
                Console.WriteLine("enter phone number");
                string phoneNumber = Console.ReadLine();
                if (Regex.IsMatch(phoneNumber, @"[0-9]{10}") && Regex.IsMatch(zip, @"[0-9]{6}") && Regex.IsMatch(firstname, @"[a-zA-Z]") && Regex.IsMatch(lastname, @"[a-zA-Z]") && Regex.IsMatch(city, @"[a-zA-Z]") && Regex.IsMatch(state, @"[a-zA-Z]"))
                {
                    AddressBookModel addressBookModel = new AddressBookModel()
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Address = address,
                        City = city,
                        State = state,
                        ZipCode = zip,
                        PhoneNumber = phoneNumber
                    };
                    string file = AddressUtility.ReadFile(constants.Address);
                    addressBook = JsonConvert.DeserializeObject<List<AddressBookModel>>(file);
                    addressBook.Add(addressBookModel);
                    var convertedJson = JsonConvert.SerializeObject(addressBook);
                    File.WriteAllText(constants.Address, convertedJson);
                    Console.WriteLine("new person added");
                }
                else
                {
                    Console.WriteLine("enter proper details");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void Update()
        {
            try
            {
                Console.WriteLine("enter your phone number to update");
                string phoneNumber = Console.ReadLine();
                Constants constants = new Constants();
                IList<AddressBookModel> addressBookModel = new List<AddressBookModel>();
                string json = AddressUtility.ReadFile(constants.Address);
                addressBookModel = JsonConvert.DeserializeObject<List<AddressBookModel>>(json);
                bool number = true;
                foreach (var items in addressBookModel)
                {
                    if (items.PhoneNumber == phoneNumber)
                    {
                        Console.WriteLine(items.FirstName + "\n" + items.LastName + "\n" + items.Address + "\n" + items.City + "\n" + items.State + "\n" + items.ZipCode + "\n" + items.PhoneNumber);
                        number = false;
                        string doCondition = null;
                        do
                        {
                            Console.WriteLine("enter 1 for changing phone number");
                            Console.WriteLine("enter 2 for changing address");
                            Console.WriteLine("enter 3 for changing state");
                            Console.WriteLine("enter 4 for changing city");
                            int switchCase = Convert.ToInt32(Console.ReadLine());
                            switch (switchCase)
                            {
                                case 1:
                                    Console.WriteLine("enter new number");
                                    string newPhoneNumber = Console.ReadLine();
                                    if (Regex.IsMatch(phoneNumber, @"[0-9]{10}"))
                                    {
                                        items.PhoneNumber = newPhoneNumber;
                                    }
                                    else
                                    {
                                        Console.WriteLine("enter phone number correctly");
                                    }

                                    break;
                                case 2:
                                    Console.WriteLine("enter new address");
                                    string newAddress = Console.ReadLine();
                                    items.Address = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("enter new state");
                                    string newState = Console.ReadLine();
                                    if (Regex.IsMatch(newState, @"[a-zA-Z]"))
                                    {
                                        items.PhoneNumber = newState;
                                    }
                                    else
                                    {
                                        Console.WriteLine("invalid data");
                                    }

                                    break;
                                case 4:
                                    Console.WriteLine("enter new city");
                                    string newCity = Console.ReadLine();
                                    if (Regex.IsMatch(newCity, @"[a-zA-Z]"))
                                    {
                                        items.PhoneNumber = newCity;
                                    }
                                    else
                                    {
                                        Console.WriteLine("invalid data");
                                    }

                                    break;
                            }

                            Console.WriteLine("enter y to continue");
                            doCondition = Console.ReadLine();
                        }
                        while (doCondition.Equals("y"));
                        var convertedJson = JsonConvert.SerializeObject(addressBookModel);
                        File.WriteAllText(constants.Address, convertedJson);
                        Console.WriteLine("update successful");
                    }
                }

                if (number == true)
                {
                    Console.WriteLine("enter proper phone number");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Prints the address book.
        /// </summary>
        public void PrintAddressBook()
        {
            try
            {
                Constants constants = new Constants();
                IList<AddressBookModel> addressBook = new List<AddressBookModel>();
                using (StreamReader stream = new StreamReader(constants.Address))
                {
                    string data = stream.ReadToEnd();
                    stream.Close();
                    addressBook = JsonConvert.DeserializeObject<List<AddressBookModel>>(data);
                    foreach (var items in addressBook)
                    {
                        Console.Write(items.FirstName + "\t" + items.LastName + "\t" + items.Address + "\t" + items.City + "\t" + items.State + "\t" + items.ZipCode + "\t" + items.PhoneNumber);
                        Console.WriteLine();
                    }                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Deletes the data.
        /// </summary>
        public void DeleteData()
        {
            try
            {
                Console.WriteLine("enter your phone number to update");
                string phoneNumber = Console.ReadLine();
                Constants constants = new Constants();
                IList<AddressBookModel> addressBookModel = new List<AddressBookModel>();
                string json = AddressUtility.ReadFile(constants.Address);
                addressBookModel = JsonConvert.DeserializeObject<List<AddressBookModel>>(json);
                bool number = true;
                foreach (var items in addressBookModel)
                {
                    if (items.PhoneNumber == phoneNumber)
                    {
                        Console.WriteLine(items.FirstName + "\n" + items.LastName + "\n" + items.Address + "\n" + items.City + "\n" + items.State + "\n" + items.ZipCode + "\n" + items.PhoneNumber);
                        number = false;
                    }
                }

                if (number == true)
                {
                    Console.WriteLine("your details does not fount enter proper name");
                }

                var itemToRemove = addressBookModel.Single(r => r.PhoneNumber == phoneNumber);
                addressBookModel.Remove(itemToRemove);
                ////searilizeing the object
                var convertedJson = JsonConvert.SerializeObject(addressBookModel);
                ////writing in to the file
                File.WriteAllText(constants.Address, convertedJson);
                Console.WriteLine("your record deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Sorts the last name of the by.
        /// </summary>
        public void SortByLastName()
        {
            try
            {
                Constants constants = new Constants();
                string json = AddressUtility.ReadFile(constants.Address);
                IList<AddressBookModel> addressBookModels = new List<AddressBookModel>();
                addressBookModels = JsonConvert.DeserializeObject<List<AddressBookModel>>(json);
                var ascending = addressBookModels.OrderBy(x => x.LastName);
                var orderedByLastName = JsonConvert.SerializeObject(ascending);
                File.WriteAllText(constants.Address, orderedByLastName);
                Console.WriteLine("Sorted by last name");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Sorts the by zip.
        /// </summary>
        public void SortByZip()
        {
            try
            {
                Constants constants = new Constants();
                string json = AddressUtility.ReadFile(constants.Address);
                IList<AddressBookModel> addressBookModels = new List<AddressBookModel>();
                addressBookModels = JsonConvert.DeserializeObject<List<AddressBookModel>>(json);
                var ascending = addressBookModels.OrderBy(x => x.ZipCode);
                var orderedByLastName = JsonConvert.SerializeObject(ascending);
                File.WriteAllText(constants.Address, orderedByLastName);
                Console.WriteLine("Sorted by Zip code");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
