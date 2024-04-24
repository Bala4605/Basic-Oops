using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SyncCart
{
    public class CustomerDetails
    {
        public string Name{get;set;}
        public string City{get;set;}
        public string EmailID{get;set;}
        public string CustomerID{get;set;}
        public long MobileNo{get;set;}
        public int WalletBalance{get;set;}
        static int count=1001;
        public CustomerDetails(string name,string city,string emailID,long mobileNo){
        Name=name;
        City=city;
        EmailID=emailID;
        CustomerID="CID"+count++;
        MobileNo=mobileNo;
        Console.WriteLine();
        Console.WriteLine($"Registration Successful.Your Customer ID :{CustomerID}");
        
    }
        public void recharge(int a){
            WalletBalance+=a;
        }
        public void deduct(int a){
            WalletBalance-=a;
        }
        public CustomerDetails(){
            
        }
    }
    
}