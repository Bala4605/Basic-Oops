using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public enum Gender{Male,Female}
    public enum Department{ECE, EEE, CSE}
    /// <summary>
/// Contains Details about users in Library<see cref="UserDetails"/>
/// </summary>
    public class  UserDetails 
    {
        //static
        private static int s_userID=3001;
        //property
        public string UserID {get;}
        public string UserName {get;set;}
        public string MobileNumber {get;set;}
        public string MailID {get;set;}
        public Department Department{get;set;}
        public Gender Gender{get;set;}
        public int WalletBalance{get;set;}

        //constructor
        public UserDetails(string username,Gender gender,Department department,string mobileNumber,string mailID,int walletBalance){
            UserID="SF"+s_userID++;
            UserName=username;
            MobileNumber=mobileNumber;
            MailID=mailID;
            Department=department;
            Gender=gender;
            WalletBalance=walletBalance;
        }
        //methods
        public void WalletRecharge(int amount){
            WalletBalance+=amount;
            Console.WriteLine($"Wallet Balance :{WalletBalance}");
        }
        public void DeductBalance(int amount){
            WalletBalance-=amount;
            Console.WriteLine($"Wallet Balance :{WalletBalance}");
        }

    }
}