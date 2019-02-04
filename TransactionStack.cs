//-----------------------------------------------------------------------
// <copyright file="TransactionStack.cs" company="Bridgelabz">
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
    /// Transaction stack class will keep record of company buy and sell share records
    /// </summary>
    public class TransactionStack
    {
        /// <summary>
        /// keep all the transaction done by company in stack
        /// </summary>
        public void StackTransaction()
        {
            ////creating object of constant to access location of file
            Constants constants = new Constants();
            ////creating list object to read data from file
            IList<TransactionModel> transactions = new List<TransactionModel>();
            ////IList list = new ArrayList();
            ////stack object is use to keep transaction type of the company in stack
            Stack<TransactionModel> stack = new Stack<TransactionModel>();
            ////stream Reader is a class to read data from the file
            using (StreamReader stream = new StreamReader(constants.TransactionFile))
            {
                ////reading data from file and storing in the string variable
                string json = stream.ReadToEnd();
                ////storing all the data from string to list
                transactions = JsonConvert.DeserializeObject<IList<TransactionModel>>(json);
                stream.Close();
            }
            ////iteration is use to push all the transactions
            foreach (var items in transactions)
            {
                stack.Push(items);
            }
            ////iteration is used to print the data from the stack
            foreach (var item in stack)
            {
                Console.WriteLine(item.StockName + "\t" + item.TransactionType);
            }
        }
    }
}
