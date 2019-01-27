//-----------------------------------------------------------------------
// <copyright file="TransactionModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    public class TransactionModel
    {
        private string customerName;
        private string stockName;
        private int noOfShare;
        private int amount;
        private string time;

        public string CustomerName { get => customerName; set => customerName = value; }
        public string StockName { get => stockName; set => stockName = value; }
        public int NoOfShare { get => noOfShare; set => noOfShare = value; }
        public int Amount { get => amount; set => amount = value; }
        public string Time { get => time; set => time = value; }
        public TransactionType TransactionType { get; set; }
    }
}
