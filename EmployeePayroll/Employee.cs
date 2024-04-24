using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll
{
class Employee{

public string EmployeeName{get;set;}
public string Role{get;set;}
public string Team{get;set;}
public GENDER Gen {get;set;}
public WORKLOCATION Work {get;set;}
public string employeeId="SF";
private static int count=1001;
// int balance=0;
public int NoOfLeaves {get;set;}
public int WorkingDays {get;set;}
public DateTime Doj {get;set;}    
public Employee(string employeeName,GENDER gender,int noOfLeaves,string role,DateTime doj,string team,WORKLOCATION work,int workingDays){
this.EmployeeName=employeeName;
this.Doj=doj;
this.Gen=gender;
this.Team=team;
this.Work=work;
this.Role=role;
this.NoOfLeaves=noOfLeaves;
this.WorkingDays=workingDays;
this.employeeId="SF"+count;
Console.WriteLine("SyncFusion Welcomes You");
Console.WriteLine($"Your employee ID: {this.employeeId}");
Console.WriteLine("--------------------------------------------");


count++;
}
public int Salary(){
    return (WorkingDays-NoOfLeaves)*500;
}
public void EmployeeDetails(Employee emp){
        Console.WriteLine($"Name :{emp.EmployeeName}");
        Console.WriteLine($"Gender :{emp.Gen}");
        Console.WriteLine($"Employee ID :{emp.employeeId}");
        Console.WriteLine($"Role :{emp.Role}");
        Console.WriteLine($"Team:{emp.Team}");
        Console.WriteLine($"Work Location :{emp.Work}");
        Console.WriteLine($"Date Of Joining :{emp.Doj.ToString("D")}");

        Console.WriteLine("--------------------------------------------");

        }
public Employee(){}
}}