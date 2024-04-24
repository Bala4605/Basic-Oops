using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountOpening
{
public class Bank
{
public string CustomerName{get;set;}
public string MailId{get;set;}

GENDER Gen;
public string customerId="HDFC";
static int count=1001;
public int Balance{get;set;}
public long PhoneNumber{get;set;}
public DateTime Dob{get;set;}   
public Bank(string customerName,GENDER gender,long phoneNumber,string mailId,DateTime dob){
CustomerName=customerName;
Dob=dob;
this.Gen=gender;
MailId=mailId;
PhoneNumber=phoneNumber;
this.customerId="HDFC"+count;
Console.WriteLine("HDFC Welcomes You");
Console.WriteLine($"Your Customer ID: {this.customerId}");

count++;
}
public int Deposit(int amt){
    this.Balance+=amt;
    return this.Balance;
}
public int WithDraw(int amt){
    this.Balance-=amt;
    return this.Balance;
}
public int Display(){
    return this.Balance;
}
public Bank(){}
}

    
}