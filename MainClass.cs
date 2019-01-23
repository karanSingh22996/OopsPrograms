//-----------------------------------------------------------------------
// <copyright file="MainClass.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    /// <summary>
    /// Main class is created to give choice to user which program you want to execute
    /// </summary>
    public class MainClass
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            ////try block is use to execute the normal flow of the program execution
            try
            {
                char ch;
                do
                {
                    Console.WriteLine("Enter 1.To read data from json file");
                    Console.WriteLine("Enter 2.For Regular Expression Program");
                    Console.WriteLine("Enter 3.For stock Program");
                    Console.WriteLine("Enter 4.For InventoryManagement Program");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            InventoryModel.ReadJsonData();
                            break;
                        case 2:
                            RegularExpression regularExpression = new RegularExpression();
                            regularExpression.RetrieveInfo();
                            break;
                        case 3:
                            Stock stock = new Stock();
                            stock.ReadData();
                            break;
                        case 4:
                            InventoryManagement inventoryManagement = new InventoryManagement();
                            inventoryManagement.ManageData();
                            break;
                        default:
                            Console.WriteLine("Enter valid data");
                            break;
                    }
                    Console.WriteLine("Do you want to continue(y/n)");
                    ch = Convert.ToChar(Console.ReadLine());
                } while (ch != 'n');
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
