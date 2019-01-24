using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    class InventoryOperations
    {
        public void Manage()
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
            } while (ch != 'n');
        }
    }
}
