using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{/// <summary>
/// Contains Details about BorrowedBooks in Library<see cref="BorrowedDetails"/>
/// </summary>
    public enum Status{Default, Borrowed, Returned }
    public class  BorrowDetails 
    {
        public static int s_borrowID=2001;
        public string BorrowID {get;set;}
        public string BookID {get;set;}
        public string	UserID{get;set;}
        public DateTime	BorrowedDate{get;set;}
        public int BorrowBookCount {get;set;}
        public Status Status  {get;set;}
        public int PaidFineAmount{get;set;}

        public BorrowDetails(string bookID,string userID,DateTime borrowedDate,int borrowBookCount,Status status,int paidFineAmount){
            BorrowID="LB"+s_borrowID++;
            BookID=bookID;
            UserID=userID;
            BorrowedDate=borrowedDate;
            BorrowBookCount=borrowBookCount;
            Status=status;
            PaidFineAmount=paidFineAmount;
        }

    }
}