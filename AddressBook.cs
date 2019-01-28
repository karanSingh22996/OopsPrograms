//-----------------------------------------------------------------------
// <copyright file="AddressBook.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The address book contain all the operation of address book
    /// </summary>
    public class AddressBook
    {
        /// <summary>
        /// The list
        /// </summary>
         private ArrayList list = new ArrayList();

        /// <summary>
        /// The constants
        /// </summary>
         private Constants constants = new Constants();

        /// <summary>
        /// The address
        /// </summary>
        private Address address = new Address();

        /// <summary>
        /// The person
        /// </summary>
        private Person person = new Person();

        /// <summary>
        /// Adds the person.
        /// </summary>
        public void AddPerson()
        {
           //// List<Person> list = new List<Person>();

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
                this.list.Add(person);
                string strResultJson = JsonConvert.SerializeObject(this.list);
                Constants constants = new Constants();
                File.WriteAllText(constants.Address, strResultJson);
            }
        }

        /// <summary>
        /// Edits the information.
        /// </summary>
        public void EditInfo()
        {
            Console.WriteLine("Enter Person FirstName Of Edited Person");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter MobileNumber Of Edited Person");
            string phone = Console.ReadLine();
            foreach (Person items in this.list)
            {
                if (this.person.FirstName.Equals(firstname) && this.person.PhoneNum.Equals(phone))
                {
                    int answer2 = 0;
                    char ch;
                    do
                    {
                        Console.WriteLine("What You Want To Edit");
                        Console.WriteLine("1.LastName");
                        Console.WriteLine("2.City");
                        Console.WriteLine("3.Zip");
                        Console.WriteLine("4.State");
                        Console.WriteLine("5.Phone");
                        Console.WriteLine("6.Exit");
                        answer2 = Convert.ToInt32(Console.ReadLine());
                        switch (answer2)
                        {
                            case 1:
                                Console.WriteLine("Enter New LastName");
                                string lastname = Console.ReadLine();
                                if (this.person.LastName.StartsWith(lastname))
                                {
                                    this.person.LastName = lastname;
                                }

                                break;
                            case 2:
                                Console.WriteLine("Enter city to edit");
                                string city = Console.ReadLine();
                                if (this.address.City.StartsWith(city))
                                {
                                    this.address.City = city;
                                }

                                break;
                            case 3:
                                Console.WriteLine("Enter zip code to edit");
                                string zip = Console.ReadLine();
                                if (this.address.Zip1.StartsWith(zip))
                                {
                                    this.address.Zip1 = zip;
                                }

                                break;
                            case 4:
                                Console.WriteLine("Enter phone number to edit");
                                string phonenum = Console.ReadLine();
                                if (this.person.PhoneNum.StartsWith(phonenum))
                                {
                                    this.person.PhoneNum = phonenum;
                                }

                                break;
                            case 5:
                                Console.WriteLine("Existing");
                                break;
                            default:
                                Console.WriteLine("Enter valid Data");
                                break;
                        }

                        Console.WriteLine("Do you want to continue");
                        ch = Convert.ToChar(Console.ReadLine());
                    }
                    while (ch != 'n');
                }
            }
        }

        /// <summary>
        /// Deletes the person.
        /// </summary>
        public void DeletePerson()
        {
            Console.WriteLine("Enter First name to remove");
            string name = Console.ReadLine();
            Console.WriteLine("Enter mobile number");
            string mobileNum = Console.ReadLine();
            for (int i = 0; i < this.list.Count; i++)
            {
                if (this.person.FirstName.Equals(name) && this.person.PhoneNum.Equals(mobileNum))
                {
                    ////i = int.Parse(string.Format("{0}", person));
                    this.list.Remove(i);
                    break;
                }
                else
                {
                    Console.WriteLine("No data found for given name and phone num");
                }
            }
        }

        /// <summary>
        /// Sorts the name of the by.
        /// </summary>
       public void SortByName()
        {
            object[] str = this.list.ToArray();
            /////string[] str1=str.ToString().ToArray();
            try
            {
                ////Stopwatch stopwatch = new Stopwatch();
                ////stopwatch.Start();
                for (int i = 0; i < str.GetLength(0) - 1; i++)
                {
                    for (int j = 1; j < str.GetLength(0) - i; j++)
                    {
                        if (!str[j - 1].Equals(str[j]))
                        {
                            object temp = str[j - 1];
                            str[j - 1] = str[j];
                            str[j] = temp;
                        }
                    }
                }

                Console.WriteLine("Sorted list are:");
                for (int i = 0; i < str.GetLength(0); i++)
                {
                    Console.Write(str[i] + " ");
                }

                Console.WriteLine();
                ////stopwatch.Stop();
                ////Console.WriteLine("ElapsedTime = " + stopwatch.Elapsed);
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
        }

        /// <summary>
        /// Prints this instance.
        /// </summary>
       public void Print()
        {
            foreach (Person items in this.list)
            {
                Console.Write(items.FirstName + "\t" + items.LastName + "\t" + items.PhoneNum);
            } 

            Console.WriteLine();
            foreach (Address items in this.list)
            {
                Console.Write(items.City + "\t" + items.State + "\t" + items.Zip1);
            }
        }
    }
}