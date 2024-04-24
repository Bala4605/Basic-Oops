using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace BankAccountOpening;
public enum GENDER{MALE,FEMALE};
public class Program{
  
    public static void Main(string[] args)
    { 
    
    List<Bank> bankList=new List<Bank>();

    int choice=0;
    while(choice!=3){
        Console.WriteLine("1.Registration\n2.Login\n3.Exit");
        choice=int.Parse(Console.ReadLine());
        switch(choice){
            case 1:{
                
                Console.Write("Enter Your Name: ");
                string customerName=Console.ReadLine();
                Console.Write("Enter Your Gender: ");
                GENDER gender=Enum.Parse<GENDER>(Console.ReadLine(),true);
                Console.Write("Enter Your Phone Number: ");
                long phoneNumber=long.Parse(Console.ReadLine());
                Console.Write("Enter Your Mail ID: ");
                string mailId=Console.ReadLine();
                Console.Write("Enter Your D.O.B: ");
                DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                bankList.Add(new Bank(customerName,gender,phoneNumber,mailId,dob));
                Console.WriteLine("--------------------------------------------");

            break;
            }
            case 2:{
                Console.Write("Enter Your Customer Id: ");
                string ci=Console.ReadLine();
                Bank temp=new Bank();
                int flag=0;

                foreach(Bank i in bankList){
                    if(ci==i.customerId){
                        temp=i;
                        flag=1;

                    }
                }
                if(flag==1){
                    int choice1=0;
                    while(choice1!=4){
                        Console.WriteLine("1.Deposit\n2.Withdraw\n3.Balance Check\n4.Exit");
                        choice1=int.Parse(Console.ReadLine());
                        switch(choice1){
                            case 1:{
                                Console.Write("Enter The Amount To Deposit :");
                                int amt=int.Parse(Console.ReadLine());
                                Console.WriteLine($"Balance: {temp.Deposit(amt)}");
                                break;
                            }
                            case 2:{
                                Console.Write("Enter The Amount To Withdrawal :");
                                int amt=int.Parse(Console.ReadLine());
                                Console.WriteLine($"Balance: {temp.WithDraw(amt)}");
                                break;
                            }
                            case 3:{
                                Console.WriteLine($"Balance: {temp.Display()}");
                                break;
                            }
                        }
                    Console.WriteLine("--------------------------------------------");

                    }
                }
                else{
                    Console.WriteLine("Invalid user ID");
                    Console.WriteLine("--------------------------------------------");

                }
            break;
            }
        }

    }
        
    }
}
