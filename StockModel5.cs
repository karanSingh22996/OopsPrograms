using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    public class StockModel5
    {
        private int id;
       
        private string name;
        
        private int numberOfShare;
     
        private int pricePerShare;
   

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int PricePerShare { get => pricePerShare; set => pricePerShare = value; }
        public int NumberOfShare { get => numberOfShare; set => numberOfShare = value; }
    }
}
