using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public enum ORDERSTATUS{Default,Ordered,Cancelled}
    public class OrderDetails
    {
        public string CustomerID{get;set;}
        public string ProductID{get;set;}
        public string OrderID{get;set;}
        public int TotalPrice{get;set;}
        public int Quantity{get;set;}
        public DateTime PurchaseDate{get;set;}
        public ORDERSTATUS OrderStatus{get;set;}
        static int count=1001;
        public OrderDetails(string customerID,string productID,int totalPrice,int quantity,int days){
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalPrice;
            Quantity=quantity;
            PurchaseDate=DateTime.Now;
            OrderStatus=ORDERSTATUS.Ordered;
            OrderID="PID"+count++;
            Console.WriteLine();
            Console.WriteLine($"Order Placed Successfully. Order ID:{OrderID}.");
            Console.WriteLine($"Order placed successfully. Your order will be delivered on {PurchaseDate.AddDays(days).ToShortDateString()}");

        }


    }
}