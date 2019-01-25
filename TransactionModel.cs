using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    class TransactionModel
    {
        private string customerName;
        private string stockName;
        private int noOfShare;
        private int amount;
        private string Time;

        public string CustomerName { get => customerName; set => customerName = value; }
        public string StockName { get => stockName; set => stockName = value; }
        public int NoOfShare { get => noOfShare; set => noOfShare = value; }
        public int Amount { get => amount; set => amount = value; }
        public string Time1 { get => Time; set => Time = value; }
        public TransactionType transactionType { get; set; }
    }
}
