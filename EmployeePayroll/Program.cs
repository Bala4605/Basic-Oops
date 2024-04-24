using System;
using System.Collections.Generic;


namespace EmployeePayroll;
enum WORKLOCATION{
    US,Chennai,Kenya
}    
enum GENDER{
    Male,Female
}
public class Program{
    public static void Main(string[] args)
    { 
    List<Employee> EmployeeList=new List<Employee>();
    int choice=0;
    while(choice!=3){
        Console.WriteLine("1.Registration\n2.Login\n3.Exit");
        choice=int.Parse(Console.ReadLine());
        switch(choice){
            case 1:{
                Console.Write("Enter Your Name: ");
                string employeeName=Console.ReadLine();
                Console.Write("Enter Your Gender: ");
                GENDER gender=Enum.Parse<GENDER>(Console.ReadLine(),true);
                Console.Write("Enter Your Role: ");
                string role=Console.ReadLine();
                Console.Write("Enter Your Team Name: ");
                string team=Console.ReadLine();
                Console.Write("Enter Your Work Location: ");
                WORKLOCATION work=Enum.Parse<WORKLOCATION>(Console.ReadLine(),true);
                
                Console.Write("Enter Your D.O.J: ");
                DateTime doj=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                Console.Write("Enter Your Total Working Days: ");
                int workingDays=int.Parse(Console.ReadLine());
                Console.Write("Enter Your Leaves taken: ");
                int noOfLeaves=int.Parse(Console.ReadLine());
                
                
                EmployeeList.Add(new Employee(employeeName,gender,noOfLeaves,role,doj,team,work,workingDays));
                Console.WriteLine("--------------------------------------------");

            break;
            }
            case 2:{
                Console.Write("Enter Your Customer Id: ");
                string ci=Console.ReadLine();
                Employee temp=new Employee();
                int flag=0;

                foreach(Employee i in EmployeeList){
                    if(ci==i.employeeId){
                        temp=i;
                        flag=1;

                    }}
                if(flag==1){
                    int choice1=0;
                    while(choice1!=3){
                        Console.WriteLine("1.Calculate Salary\n2.Display Details\n3.Exit");
                        choice1=int.Parse(Console.ReadLine());
                        switch(choice1){
                            case 1:{
                               
                                Console.WriteLine($"Your Salary: {temp.Salary()}");
                                break;
                            }
                            case 2:{
                               temp.EmployeeDetails(temp);
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


