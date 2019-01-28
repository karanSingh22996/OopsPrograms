//-----------------------------------------------------------------------
// <copyright file="AddresManager.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    /// <summary>
    /// Address manager is calling calling class
    /// </summary>
    public class AddresManager
    {
        /// <summary>
        /// Drivers the manager.
        /// </summary>
        public void DriverManager()
        {
            ////Creating object of address class
            AddressBook addressBook = new AddressBook();
            char ch;
            do
            {
                Console.WriteLine("Enter 1 for Add Person \n2 For edit info \n3 For Delete Person \n4 For Sort by name \n5 For sort by zip");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ////calling add person method
                        addressBook.AddPerson();
                        break;
                    case 2:
                        ////calling editinfo method
                        addressBook.EditInfo();
                        break;
                    case 3:
                        ////calling delete person
                        addressBook.DeletePerson();
                        break;
                    case 4:
                        ////calling sort by name
                        addressBook.SortByName();
                        break;
                    case 5:
                        ////calling sort by zip method
                        addressBook.SortByZip();
                        break;
                }
                System.Console.WriteLine("Do you want to continue(y/n)");
                ch = Convert.ToChar(Console.ReadLine());
            } while (ch != 'n');
        }
    }
}
