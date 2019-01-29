//-----------------------------------------------------------------------
// <copyright file="AddressBook.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;

    /// <summary>
    /// this class is used for storing the data of a person
    /// </summary>
    public class AddressBook
    {
        /// <summary>
        /// Addresses the book details.
        /// </summary>
        /// <exception cref="Exception">casting exception</exception>
        public void AddressBookDetails()
        {
            try
            {
                int caseCondition;
                string doCondition = null;
                do
                {
                    Console.WriteLine("enter 1 for add person");
                    Console.WriteLine("enter 2 for edit information");
                    Console.WriteLine("enter 3 for delete person");
                    Console.WriteLine("enter 4 for sort by last name");
                    Console.WriteLine("enter 5 for sort by zip");
                    Console.WriteLine("enter 6 for print address book ");
                    caseCondition = Convert.ToInt32(Console.ReadLine());
                    AddressUtility addressUtility = new AddressUtility();
                    switch (caseCondition)
                    {
                        case 1:
                            addressUtility.AddPerson();
                            break;
                        case 2:
                            addressUtility.Update();
                            break;                       
                        case 3:
                            addressUtility.DeleteData();
                            break;
                        case 4:
                            addressUtility.SortByLastName();
                            break;
                        case 5:
                            addressUtility.SortByZip();
                            break;
                        case 6:
                            addressUtility.PrintAddressBook();
                            break;
                    }

                    Console.WriteLine("enter y to continue");
                    doCondition = Console.ReadLine();
                }
                while (doCondition.Equals("y"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}