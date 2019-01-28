//-----------------------------------------------------------------------
// <copyright file="InventoryOperations.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;

    /// <summary>
    /// Inventory operations method is calling class of all the methods
    /// </summary>
    public class InventoryOperations
    {
        /// <summary>
        /// Manages this instance.
        /// </summary>
        public void Manage()
        {
            try
            {
                char ch;
                do
                {
                    InventoryManagement inventory = new InventoryManagement();
                    Console.WriteLine("Enter 1 to read the data from file");
                    Console.WriteLine("Enter 2 to Add the data to file");
                    Console.WriteLine("Enter 3 to Update the data in file");
                    Console.WriteLine("Enter 4 to Remove the data in file");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            inventory.InventoryManagementData();
                            break;
                        case 2:
                            inventory.AddToInventory();
                            break;
                        case 3:
                            inventory.UpdateInventoryData();
                            break;
                        case 4:
                            inventory.Delete();
                            break;
                    }

                    Console.WriteLine("Do you want to continue (y/n)");
                    ch = Convert.ToChar(Console.ReadLine());
                }
                while (ch != 'n');
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
