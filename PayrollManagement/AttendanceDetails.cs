using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagement
{
    public class AttendanceDetails
    {
        public string AttendanceID{get;set;}
        public string EmployeeID{get;set;}
        public DateTime Date{get;set;}
        public DateTime CheckIn{get;set;}
        public DateTime CheckOut{get;set;}
        public int Time{get;set;}
        static int count=1001;
        /// <summary>
        /// This Class Performs an important Function
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <param name="checkIn"></param>
        /// <param name="checkOut"></param> <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="date"></param>
        /// <param name="checkIn"></param>
        /// <param name="checkOut"></param>
        public AttendanceDetails(string employeeID,DateTime date,DateTime checkIn,DateTime checkOut){
            EmployeeID=employeeID;
            Date=date;
            CheckIn=checkIn;
            CheckOut=checkOut;
            Time=Math.Abs((checkIn-CheckOut).Hours)>8?8:(checkIn-CheckOut).Hours;
            AttendanceID="AID"+count++;
            if(Time>=8){
                Console.WriteLine($"Check-in and Checkout Successful and today you have worked 8 Hours");
            }
            
        }
        public AttendanceDetails(){}    

    }
}