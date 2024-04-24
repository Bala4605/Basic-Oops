using System;
using System.Collections.Generic;
namespace SyncCart;

class Program{
    public static void Main(string[] args)
    {
        List<CustomerDetails> customerList=new List<CustomerDetails>();
        
        List<ProductDetails> productList=new List<ProductDetails>();

        productList.Add(new ProductDetails("Mobile(Samsung)",10,10000,3));
        productList.Add(new ProductDetails("Tablet (Lenovo)",5,15000,2));
        productList.Add(new ProductDetails("Camara (Sony)",3,20000,4));
        productList.Add(new ProductDetails("iPhone",5,50000,6));
        productList.Add(new ProductDetails("Laptop (Lenovo I3)",3,40000,3));
        productList.Add(new ProductDetails("HeadPhone (Boat)",5,1000,2));
        productList.Add(new ProductDetails("Speakers (Boat)",4,500,2));


        List<OrderDetails> orderList=new List<OrderDetails>();

        // foreach(ProductDetails i in productList){
        //     Console.WriteLine(i.ProductID+"   "+i.ProductName+"     "+i.Stock+"    "+i.Price+"   "+i.ShippingDuration);
        // }
        int choice=0;
        while(choice!=3){
            Console.WriteLine("1. Customer Registration\n2. Login\n3. Exit");
            choice=int.Parse(Console.ReadLine());
            switch(choice){
                case 1:{
                    Console.Write("Enter your Name :");
                    string name=Console.ReadLine();
                    Console.Write("Enter your City :");
                    string city=Console.ReadLine();
                    Console.Write("Enter your Phone Number :");
                    long number=long.Parse(Console.ReadLine());
                    Console.Write("Enter your Email ID :");
                    string mailId=Console.ReadLine();
                    customerList.Add(new CustomerDetails(name,city,mailId,number));
                    

                break;}
                
                case 2:{

                    Console.Write("Enter Your customer ID :");
                    string cid=Console.ReadLine();
                    bool isCustomer=false;
                    CustomerDetails currentCustomer=new CustomerDetails();

                    foreach(CustomerDetails i in customerList){
                        if(i.CustomerID==cid){
                            isCustomer=true;
                            currentCustomer=i;
                        }
                    }

                    if(isCustomer){
                    char choice2='z';

                    while(choice2!='f'){
                        Console.WriteLine("a. Purchase\nb. Order History\nc. Cancel Order\nd. Wallet Balance\ne. WalletRecharge\nf. Exit");
                        choice2=char.Parse(Console.ReadLine().ToLower());
                        switch(choice2){
                                case 'a':{
                                    foreach(ProductDetails i in productList){
                                        Console.WriteLine(String.Format("{0,-10}",i.ProductID)+"   "+String.Format("{0,-20}",i.ProductName)+"     "+String.Format("{0,-2}",i.Stock)+"    "+String.Format("{0,-10}",i.Price)+"   "+i.ShippingDuration);
                                    }  
                                    Console.Write("Enter Your product ID :");
                                    string pid=Console.ReadLine();
                                    int count=0;
                                    foreach(ProductDetails i in productList){
                                       if(pid==i.ProductID){
                                        Console.Write("Enter the quantity :");
                                        count=int.Parse(Console.ReadLine());
                                        if(count<=i.Stock){
                                            int totalPrice=(count*i.Price)+50;
                                            if(currentCustomer.WalletBalance>totalPrice){
                                                currentCustomer.deduct(totalPrice);
                                                i.Stock-=count;
                                                orderList.Add(new OrderDetails(currentCustomer.CustomerID,i.ProductID,totalPrice,count,i.ShippingDuration));
                                            }else{
                                                Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again.");
                                            }
                                        }else{
                                            Console.WriteLine($"Required count not available. Current availability is {i.Stock}.");
                                        }
                                        
                                       }
                                    } 


                                break;}
                                case 'b':{
                                    
                                    Console.WriteLine(String.Format("{0,-10}","Order ID")+String.Format("{0,-14}","Customer ID")+String.Format("{0,-14}","Product ID")+String.Format("{0,-16}","Purchase Date")+String.Format("{0,-10}","Quantity")+String.Format("{0,-12}","Order Status"));
                                    Console.WriteLine();
                                    foreach(OrderDetails i in orderList){
                                        if(i.CustomerID==cid){
                                            Console.WriteLine(String.Format("{0,-10}",i.OrderID)+String.Format("{0,-14}",i.CustomerID)+String.Format("{0,-14}",i.ProductID)+String.Format("{0,-16}",i.PurchaseDate.ToShortDateString())+String.Format("{0,-10}",i.Quantity)+String.Format("{0,-12}",i.OrderStatus));

                                        }
                                    }

                                break;}
                                case 'c':{
                                    Console.WriteLine(String.Format("{0,-10}","Order ID")+String.Format("{0,-14}","Customer ID")+String.Format("{0,-14}","Product ID")+String.Format("{0,-16}","Purchase Date")+String.Format("{0,-10}","Quantity")+String.Format("{0,-12}","Order Status"));
                                    Console.WriteLine();
                                    foreach(OrderDetails i in orderList){
                                        if(i.CustomerID==cid && i.OrderStatus==ORDERSTATUS.Ordered){
                                            Console.WriteLine(String.Format("{0,-10}",i.OrderID)+String.Format("{0,-14}",i.CustomerID)+String.Format("{0,-14}",i.ProductID)+String.Format("{0,-16}",i.PurchaseDate.ToShortDateString())+String.Format("{0,-10}",i.Quantity)+String.Format("{0,-12}",i.OrderStatus));

                                        }
                                    }
                                    Console.Write("Enter Product ID :");
                                    string pid=Console.ReadLine();
                                    bool valid=false;
                                    foreach(OrderDetails i in orderList){
                                        if(i.ProductID==pid){
                                            valid=true;
                                            i.OrderStatus=ORDERSTATUS.Cancelled;
                                            currentCustomer.WalletBalance+=i.TotalPrice;
                                            foreach(ProductDetails j in productList){
                                                if(j.ProductID==pid){
                                                    j.Stock+=i.Quantity;
                                                }
                                            }
                                        }
                                    }
                                    if(valid){
                                    Console.WriteLine($"Order :{pid} cancelled successfully");}
                                    else{
                                    Console.WriteLine("Invalid Order Id");
                                    }
                                break;}
                                case 'd':{
                                    Console.WriteLine($"Wallet Balance :{currentCustomer.WalletBalance}");

                                break;}
                                case 'e':{
                                    Console.Write("Do you want to Recharge? (yes/no):");
                                    string value=Console.ReadLine();
                                    if(value=="yes"){
                                        Console.Write("Enter amount :");
                                        int amt=int.Parse(Console.ReadLine());
                                        currentCustomer.recharge(amt);
                                        Console.WriteLine($"Wallet Balance :{currentCustomer.WalletBalance}");
                                    }
                                    

                                break;}
                                case 'f':{
                                choice2='f';

                                break;}
                                default:{
                                    Console.WriteLine("InValid !");
                                    choice2='a';
                                    break;
                                }
                        }
                        }}else{
                            Console.WriteLine("Invalid CustomerID ");
                        }
                break;}

                case 3:{
                    choice=3;
                break;}

                default:{
                Console.WriteLine("InValid !");
                choice=0;
                break;
                }
            }
        }
    }
}