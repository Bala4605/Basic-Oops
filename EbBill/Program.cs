using System;
using System.Collections.Generic;

namespace EbBill;
public class Program{
    public static void Main(string[] args)
    { 
    List<EbBill> ebBillList=new List<EbBill>();    
    int choice=0;
    while(choice!=3){
        Console.WriteLine("1.Registration\n2.Login\n3.Exit");
        choice=int.Parse(Console.ReadLine());
        switch(choice){

            case 1:{
                Console.Write("Enter Your Name: ");
                string userName=Console.ReadLine();
                Console.Write("Enter Your Phone Number: ");
                long phoneNumber=long.Parse(Console.ReadLine());
                Console.Write("Enter Your Email Id :");
                string mailID=Console.ReadLine();
                ebBillList.Add(new EbBill(userName,mailID,phoneNumber));

            break;
            }
            case 2:{
                Console.Write("Enter Your Customer Id: ");
                string ci=Console.ReadLine();
                EbBill temp=new EbBill();
                int flag=0;

                foreach(EbBill i in ebBillList){
                    if(ci==i.id){
                        temp=i;
                        flag=1;

                    }}
                if(flag==1){
                    int choice1=0;
                    while(choice1!=3){
                        Console.WriteLine("1.Calculate Amount\n2.Display User Details\n3.Exit");
                        choice1=int.Parse(Console.ReadLine());
                         switch(choice1){
                            case 1:{
                                Console.Write("Enter Units :");
                                int unit =int.Parse(Console.ReadLine());
                                Console.WriteLine($"Amount: {temp.calculateBill(unit)}");
                                break;
                            }
                            case 2:{
                               temp.DisplayDetails();
                                break;
                            }
                            
                        }
                    Console.WriteLine("--------------------------------------------");
                    }
                }
                else{
                    Console.WriteLine("Invalid user ID");
                }
            break;
            }
        }

    }
        
}
}



