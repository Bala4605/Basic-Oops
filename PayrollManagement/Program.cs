using System;
using System.Collections.Generic;
namespace PayrollManagement;
class Program{
    public static void Main(string[] args)


    {   
        List<EmployeeDetails> employeeList=new List<EmployeeDetails>();
        List<AttendanceDetails> attendanceList=new List<AttendanceDetails>();
        
        int choice=1;
        while(choice!=3){
            Console.WriteLine("1. Employee Registration\n2. Employee Login\n3. Exit");
            choice=int.Parse(Console.ReadLine());
            switch(choice){
                case 1:{
                    Console.Write("Enter Your Full Name :");
                    string name=Console.ReadLine();
                    Console.Write("Enter Your DOB :");
                    DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    Console.Write("Enter Your Mobile Number :");
                    long number=long.Parse(Console.ReadLine());
                    Console.Write("Enter Your Gender :");
                    GENDER gender=Enum.Parse<GENDER>(Console.ReadLine(),true);
                    Console.Write("Enter Your Branch :");
                    BRANCH branch=Enum.Parse<BRANCH>(Console.ReadLine(),true);

                    Console.Write("Enter Your Team :");
                    TEAM team=Enum.Parse<TEAM>(Console.ReadLine(),true);

                    employeeList.Add(new EmployeeDetails(name,dob,gender,number,branch,team));


                    break;
                }
                case 2:{
                    Console.Write("Enter Your Employee ID :");
                    string id=Console.ReadLine();
                    EmployeeDetails current=new EmployeeDetails();
                    bool isAvail=false;
                    foreach(EmployeeDetails i in employeeList){
                        if(id==i.EmployeeID){
                            current=i;
                            isAvail=true;

                        }
                    }
                    if(isAvail){
                    char choice1='Z';
                    while(choice1!='d'){
                        Console.WriteLine("a. Add Attendance\nb. Display Details\nc. Calculate Salary\nd. Exit");
                        choice=char.Parse(Console.ReadLine());
                        switch(choice){
                            case 'a':{
                                DateTime date=DateTime.Now;
                                DateTime checkIn=DateTime.Now;
                                DateTime checkOut;
                                Console.Write("Do you want to CheckIn-(yes/no) :");
                                
                                if(Console.ReadLine().ToLower()=="yes"){
                                    Console.Write("Enter the Date-(dd/MM/yyyy) :");
                                    date=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

                                    Console.Write("Enter the CheckIn Time-(HH:mm tt) :");
                                    checkIn=DateTime.ParseExact(Console.ReadLine(),"hh:mm tt",null);


                                }else{
                                    break;
                                }
                                Console.Write("Do you want to CheckOut-(yes/no) :");
                                if(Console.ReadLine().ToLower()=="yes"){
                                    Console.Write("Enter the CheckOut Time-(HH:mm tt) :");
                                    checkOut=DateTime.ParseExact(Console.ReadLine(),"hh:mm tt",null);
                                    attendanceList.Add(new AttendanceDetails(id,date,checkIn,checkOut));
                                }
                                

                                break;
                            }
                             case 'b':{
                                current.Display();
                                break;
                            }
                             case 'c':{
                                int total=0;
                                foreach(AttendanceDetails i in attendanceList){
                                    if(i.EmployeeID==id && i.Date.Month==DateTime.Now.Month){
                                        Console.WriteLine(i.AttendanceID+"  "+i.EmployeeID+"  "+i.Date.ToShortDateString()+"   "+i.CheckIn.ToString("hh:mm tt")+"   "+i.CheckOut.ToString("hh:mm tt")+"   "+i.Time);
                                        total+=i.Time;
                                    }
                                    
                                }
                                Console.WriteLine($"Salary :{(total/8)*500}");
                                break;
                            }
                             case 'd':{
                                choice1='d';
                                break;
                            }
                        }
                    }}else{
                        Console.WriteLine("Invalid User ID");
                    }
                    break;
                }
                case 3:{
                    choice=3;
                    break;
                }
            }
        }
    }
}