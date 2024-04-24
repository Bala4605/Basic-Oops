using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace PayrollManagement
{
    public enum BRANCH{Eymard,Karuna,Madura}
    public enum TEAM{Network, Hardware, Developer, Facility}
    public enum GENDER{Male,Female}
    public class EmployeeDetails 
    {
        public string FullName{get;set;}
        public string EmployeeID{get;set;}
        public DateTime DOB{get;set;}
        public long MobileNumber{get;set;}
        public GENDER Gender{get;set;}
        public BRANCH Branch{get;set;}
        public TEAM Team{get;set;}
        static int count=1001;

        public EmployeeDetails(string fullName,DateTime dob,GENDER gender,long mobileNumber,BRANCH branch,TEAM team){
            FullName=fullName;
            DOB=dob;
            MobileNumber=mobileNumber;
            Gender=gender;
            Branch=branch;
            Team=team;
            EmployeeID="SF"+count++;
            Console.WriteLine($"Employee added successfully your id is:{EmployeeID}");

        }
        public EmployeeDetails(){}
        public void Display(){
            Console.WriteLine($"Full Name :{FullName}");
            Console.WriteLine($"Employee ID :{EmployeeID}");
            Console.WriteLine($"DOB :{DOB.ToShortDateString()}");
            Console.WriteLine($"Mobile Number :{MobileNumber}");
            Console.WriteLine($"Gender :{Gender}");
            Console.WriteLine($"Branch :{Branch}");
            Console.WriteLine($"Team :{Team}");
        }
    }
}