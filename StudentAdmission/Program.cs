using System;
using System.Collections.Generic;
namespace StudentAdmission;

class Program{
    public static void Main(string[] args)

    {   
        List<StudentDetails> studentDetails=new List<StudentDetails>();

        List<DepartmentDetails> department=new List<DepartmentDetails>();
        department.Add(new DepartmentDetails("EEE",29));
        department.Add(new DepartmentDetails("CSE",29));
        department.Add(new DepartmentDetails("MECH",30));
        department.Add(new DepartmentDetails("ECE",30));

        List<AdmissionDetails> admissionList=new List<AdmissionDetails>();
        

        
        int number=0;
        while(number!=4){
             Console.WriteLine("1.Student Registration\n2.Student Login\n3.Department wise seat availability\n4.Exit");
             number=int.Parse(Console.ReadLine());
             StudentDetails currentStudent=new StudentDetails();
             bool validStudent=currentStudent.Eligibility();
            switch(number){
            case 1:{
                Console.Write("Enter your Name :");
                string studentName=Console.ReadLine();
                Console.Write("Enter your Father Name :");
                string fatherName=Console.ReadLine();
                Console.Write("Enter your DOB :");
                DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                Console.Write("Enter your Gender :");
                GENDER gender=Enum. Parse<GENDER>(Console.ReadLine(),true);
                Console.Write("Enter your Physics Mark :");
                int physics=int.Parse(Console.ReadLine());
                Console.Write("Enter your Chemistry Mark :");
                int chemistry=int.Parse(Console.ReadLine());
                Console.Write("Enter your Maths Mark :");
                int maths=int.Parse(Console.ReadLine());
                studentDetails.Add(new StudentDetails(studentName,fatherName,dob,gender,maths,physics,chemistry));

                break;
            }
             case 2:{
                Console.Write("Enter Your StudentID :");
                string id=Console.ReadLine();
                // currentStudent=new StudentDetails();
                int flag=0;
                bool isAlready=true;

                foreach(StudentDetails i in studentDetails){
                    if(i.StudentID==id){
                        currentStudent=i;
                        flag=1;
                    }
                }
               
                char choice='z';
                if(flag==1){
                while(choice!='f'){
                Console.WriteLine();
                Console.WriteLine("a.Check Eligibility\nb.Show Details\nc.Take Admission\nd.Cancel Admission\ne.Show Admission Details\nf.Exit");
                choice=char.Parse(Console.ReadLine());
                switch(choice){
                    case 'a':{
                        Console.WriteLine();
                        if(currentStudent.Eligibility()){
                            Console.WriteLine("Student is eligible ");
                        }else{
                            Console.WriteLine("Student is not eligible "); 
                        }

                        break;
                    }
                    case 'b':{
                        Console.WriteLine();
                        Console.WriteLine($"Name :{currentStudent.StudentName}");
                        Console.WriteLine($"ID :{currentStudent.StudentID}");
                        Console.WriteLine($"Father Name :{currentStudent.FatherName}");
                        Console.WriteLine($"DOB :{currentStudent.DOB.ToShortDateString()}");
                        Console.WriteLine($"Gender :{currentStudent.Gender}");
                        Console.WriteLine($"Physics :{currentStudent.Physics}");
                        Console.WriteLine($"Chemistry :{currentStudent.Chemistry}");
                        Console.WriteLine($"Maths :{currentStudent.Maths}");
                        Console.WriteLine();
                        break;
                    }
                    case 'c':{
                          foreach(AdmissionDetails i in admissionList){
                            if(i.StudentID==id){
                                isAlready=false;
                            }
                }
                        foreach(DepartmentDetails i in department){
                        Console.WriteLine(i.DepartmentID +"     "+i.DepartmentName+"      "+i.NoOfSeats);
                        }
                        Console.Write("Enter Department ID :");
                        string depID=Console.ReadLine();
                        DepartmentDetails departmentChoosed=new DepartmentDetails();
                        validStudent=currentStudent.Eligibility();
                        bool isAvil=false;
                        
                        foreach(DepartmentDetails i in department){
                            if(i.DepartmentID==depID){
                                departmentChoosed=i;
                                isAvil=true;
                                }
                        }
                        // foreach(AdmissionDetails i in admissionList){
                        //     if(i.StudentID==)
                        // }
                        if(validStudent && isAvil && departmentChoosed.NoOfSeats!=0 && isAlready){
                           
                            admissionList.Add(new AdmissionDetails(currentStudent.StudentID,departmentChoosed.DepartmentID,DateTime.Now,Enum.Parse<ADMISSIONSTATUS>("booked",true)));
                            departmentChoosed.NoOfSeats--;
                        }else{
                            Console.WriteLine("Student not Eligible for this Process");
                        }


                        


                        break;
                    }
                    case 'd':{
                        Console.WriteLine("Enter Your Admission ID :");
                        string admitId=Console.ReadLine();
                        // string dId="";
                        foreach(AdmissionDetails i in admissionList){
                            if(i.AdmissionID==admitId){
                            Console.WriteLine($"Admission ID :{i.AdmissionID}");
                            Console.WriteLine($"Student ID :{i.StudentID}");
                            Console.WriteLine($"Department ID :{i.DepartmentID}");
                            // dId=i.DepartmentID;
                            Console.WriteLine($"Admission Date :{i.AdmissionDate}");
                            Console.WriteLine($"Application Status :{i.AdmissionStatus}");

                            Console.Write("Do You Want to Cancel Your Seart :");
                            string value=Console.ReadLine();
                            if(value=="yes"){
                                i.AdmissionStatus=ADMISSIONSTATUS.Cancelled;

                                foreach(DepartmentDetails j in department){
                                if(j.DepartmentID==i.DepartmentID){
                                j.NoOfSeats++;}}
                                Console.WriteLine("Admission cancelled successfully");
                            }


                            }
                        }
                        
                       
                        break;
                    }
                    case 'e':{
                        foreach(AdmissionDetails i in admissionList){
                            Console.WriteLine(i.AdmissionID+"   "+i.StudentID+"     "+i.DepartmentID+"     "+i.AdmissionDate.ToShortDateString()+"     "+i.AdmissionStatus);
                        }

                        break;
                    }case 'f':{
                        break;
                    }
                }
                }
                }else{
                    Console.WriteLine("Invalid UserId ");
                }
                break;
            }
             case 3:{
                
                foreach(DepartmentDetails j in department){
                    Console.WriteLine(j.DepartmentID+"    "+j.DepartmentName+"     "+j.NoOfSeats);
                }
                break;
            }
        }}
    }
}
