using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbBill
{
    class EbBill{
    public string UserName{get;set;}
    public string MailID{get;set;}
    public long PhoneNumber{get;set;}
    
    public string id="EB";
    static int count=1001;
    public EbBill(string userName,string mailID,long phoneNumber){
        this.UserName=userName;
        this.PhoneNumber=phoneNumber;
        this.id=this.id+count;
        this.MailID=mailID;
        Console.WriteLine($"Your ID :{this.id}");
    }
    public int calculateBill(int a){
        return a*5;
    }
    public void DisplayDetails(){
        Console.WriteLine($"Name :{this.UserName}");
        Console.WriteLine($"ID :{this.id}");
        Console.WriteLine($"Email ID :{this.MailID}");
        Console.WriteLine($"Phone Number :{this.PhoneNumber}");
    }
    public EbBill(){

    }

}
}