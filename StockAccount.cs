using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    class StockAccount
    {
        int id;
        string shareName;
        int PricePerShare;
        int availableShare;
        public StockAccount(int id, string shareName, int PricePerShare, int availableShare)
        {
            this.id = id;
            this.shareName = shareName;
            this.PricePerShare = PricePerShare;
            this.availableShare = availableShare;
        }
        public int ValueOf()
        {
            Console.WriteLine("What is share Price");
            PricePerShare = Convert.ToInt32(Console.ReadLine());
            return PricePerShare;
        }
        public int Sell()
        {
            Console.WriteLine("How many share you want to sell");
            int share = Convert.ToInt32(Console.ReadLine());
            availableShare = availableShare - share;
            return availableShare;
        }
        public int Buy()
        {
            Console.WriteLine("How many shares you want to buy");
            int share = Convert.ToInt32(Console.ReadLine());
            availableShare = availableShare + share;
            return availableShare;

        }
    }
}
