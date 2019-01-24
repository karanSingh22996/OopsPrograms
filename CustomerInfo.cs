using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    class CustomerInfo
    {
        string name;
        int id;
        int numberOfShare;
        public CustomerInfo(int id,string name,int numberOfShare)
        {
            this.id = id;
            this.name = name;
            this.numberOfShare = numberOfShare;
        }
    }
}
