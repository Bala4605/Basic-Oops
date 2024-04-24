using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public class ProductDetails
    {
        public string ProductName{get;set;}
        public string ProductID{get;set;}
        public int Stock{get;set;}
        public int Price{get;set;}
        public int ShippingDuration{get;set;}
        static int count=1001;
        public ProductDetails(string productName,int stock,int price,int shippingDuration){
            ProductName=productName;
            Stock=stock;
            Price=price;
            ShippingDuration=shippingDuration;
            ProductID="PID"+count++;
        }
    }
}