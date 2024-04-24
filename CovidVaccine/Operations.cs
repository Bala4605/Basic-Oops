using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace CovidVaccine
{
    public static class Operations
    {   
        static Beneficiary currentLogged;
        static List<Beneficiary> beneficiaryList=new List<Beneficiary>();
       
        static List<VaccineDetails> vaccineList=new List<VaccineDetails>();
         static List<VaccinationDetails> vaccinationList=new List<VaccinationDetails>();

        public static void AddingDefaultData(){
        beneficiaryList.AddRange(new List<Beneficiary>{
        new Beneficiary("Ravichandran",21,GENDER.Male,"8484484","Chennai"),
        new Beneficiary("Baskaran",21,GENDER.Male,"8484747","Chennai")});
        vaccineList.AddRange(new List<VaccineDetails>{
        new VaccineDetails(VaccineName.Covishield,50),
        new VaccineDetails(VaccineName.Covaccine,50)
        });
        vaccinationList.AddRange(new List<VaccinationDetails>{
            new VaccinationDetails("BID1001","CID2001",1,new DateTime(2021,11,11)),
            new VaccinationDetails("BID1001","CID2001",2,new DateTime(2021,03,11)),
            new VaccinationDetails("BID1002","CID2002",1,new DateTime(2021,04,04))
        });

        }
        public static void MainMenu(){
            int choice=1;
            while(choice!=4){
                Console.WriteLine("1. Beneficiary Registration\n2. Login \n3. Get Vaccine Info\n4. Exit");
                Console.Write("Enter Choice: ");
                choice=int.Parse(Console.ReadLine());
                switch(choice){
                    case 1:{
                        BeneficiaryRegistration();
                        break;
                    }
                    case 2:{
                        Login(); 

                        break;
                    }
                    case 3:{
                        GetVaccineInfo();

                        break;
                    }
                    case 4:{
                        choice=4;
                        Console.WriteLine("Exit");
                        break;
                    }default:{
                        Console.WriteLine("Enter the valid Input !!!");
                        break;
                    }
                }
            }
        }

        //BeneficiaryRegistration
        public static void BeneficiaryRegistration(){
            Console.Write("Enter Your Name: ");
            string name=Console.ReadLine();
            Console.Write("Enter Your Age: ");
            int age=int.Parse(Console.ReadLine());
            Console.Write("Enter Your Gender: ");
            GENDER gender=Enum.Parse<GENDER>(Console.ReadLine(),true);
            Console.Write("Enter Your MobileNumber: ");
            string mobileNumber=Console.ReadLine();
            Console.Write("Enter Your City: ");
            string city=Console.ReadLine();
            Beneficiary beneficiary1=new Beneficiary(name,age,gender,mobileNumber,city);
            beneficiaryList.Add(beneficiary1);
            Console.WriteLine($"Your Beneficiary ID:{beneficiary1.RegistrationNumber}");

        }
        //Login
        public static void Login(){
            Console.Write("Enter Your RegistrationNumber: ");
            string id=Console.ReadLine().ToUpper();
            bool flag=false;
            foreach(Beneficiary beneficiary in beneficiaryList){
                if(beneficiary.RegistrationNumber==id){
                    currentLogged=beneficiary;
                    flag=true;
                }
            } 
            if(flag){
            int subChoice=1;
            while(subChoice!=5){
                Console.WriteLine("1.	Show My Details\n2.	Take Vaccination\n3.	My Vaccination History\n4.	Next Due Date\n5.	Exit");
                Console.Write("Enter Choice: ");
                subChoice=int.Parse(Console.ReadLine());
                switch(subChoice){
                    case 1:{
                        ShowMyDetails();

                        break;
                    }
                    case 2:{
                        TakeVaccination();
                        break;
                    }
                    case 3:{
                        MyVaccinationHistory();
                        break;
                    }
                    case 4:{
                         NextDueDate();
                        break;
                    }
                    case 5:{
                        Console.WriteLine("Back to MainMenu");
                        subChoice=5;
                        break;
                    }
                     default:{
                        break;
                    }

                }
            }
        }
        else{
            Console.WriteLine("Invalid Register Number. ");
        }
        }

        //Show My Details
        public static void ShowMyDetails(){
            Console.WriteLine($"Name : {currentLogged.Name}");
            Console.WriteLine($"Beneficiary ID : {currentLogged.RegistrationNumber}");
            Console.WriteLine($"Age : {currentLogged.Age}");
            Console.WriteLine($"Gender : {currentLogged.Gender}");
            Console.WriteLine($"Mobile Number : {currentLogged.MobileNumber}");
            Console.WriteLine($"city : {currentLogged.City}");

        }
        //TakeVaccination
        public static void TakeVaccination(){
            GetVaccineInfo();
            Console.Write("Enter Vaccine Id :");
            string vaccineId=Console.ReadLine().ToUpper();
            bool flag=false;
            foreach(VaccineDetails vaccine in vaccineList){
                if(vaccineId==vaccine.VaccineID){
                    flag=true;
                }
            }
            int count=0;
            string previous="";
            DateTime previousDate=DateAndTime.Now;
            if(flag){
                foreach(VaccinationDetails i in vaccinationList){
                    if(i.RegistrationNumber==currentLogged.RegistrationNumber){
                        count++;
                        previous=i.VaccineID;
                        previousDate=i.VaccinatedDate;



                    }

                }
                int days=(DateAndTime.Now-previousDate).Days;
                if(count==0 && currentLogged.Age>14){
                    vaccinationList.Add(new VaccinationDetails(currentLogged.RegistrationNumber,vaccineId,1,DateTime.Now));
                    Console.WriteLine("Process Completed");
                     foreach(VaccineDetails vaccine in vaccineList){
                     if(vaccineId==vaccine.VaccineID){
                    vaccine.NoOfDoseAvailable--;}}
                }else if(count==1 || count==2){
                    if(previous==vaccineId){
                        if(days>30){
                             vaccinationList.Add(new VaccinationDetails(currentLogged.RegistrationNumber,vaccineId,++count,DateTime.Now));
                             Console.WriteLine("Process Completed");
                            foreach(VaccineDetails vaccine in vaccineList){
                           if(vaccineId==vaccine.VaccineID){
                           vaccine.NoOfDoseAvailable--;}}
                        }else{
                            Console.WriteLine("30 days Not compelted");
                        }

                    }else{
                        Console.WriteLine($"You have selected different vaccine.You can vaccine with {previous}");
                    }
                }else{
                    Console.WriteLine("All the three Vaccination are completed, you cannot be vaccinated now");
                }
                
                

            }else{
                Console.WriteLine("Not valid!!!");
            }
        }
        //MyVaccinationHistory
        public static void MyVaccinationHistory(){
            Console.WriteLine($"{"VaccinationID",-15}|{"RegisterNumber",-15}|{"VaccineID",-15}|{"DoseNumber",-15}|{"VaccinatedDate",-15}"); 
            foreach(VaccinationDetails vaccination in vaccinationList){
                if(vaccination.RegistrationNumber==currentLogged.RegistrationNumber){
                    Console.WriteLine($"{vaccination.VaccinationID,-15}|{vaccination.RegistrationNumber,-15}|{vaccination.VaccineID,-15}|{vaccination.DoseNumber,-15}|{vaccination.VaccinatedDate.ToShortDateString(),-15}");
                    
                }
            }
        }
        //NextDueDate
        public static void NextDueDate(){
            int count=0;
            DateTime nextDue=DateTime.Now;
             foreach(VaccinationDetails vaccination in vaccinationList){
                if(vaccination.RegistrationNumber==currentLogged.RegistrationNumber){
                    count++;
                    nextDue=vaccination.VaccinatedDate;
                }
                
                }
                if(count==3){
                    Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive");
                }else if(count==0){
                    Console.WriteLine("you can take vaccine now");
                }else{
                    Console.WriteLine($"Next due Date :{nextDue.AddDays(30).ToShortDateString()}");
                }

        }
        //GetvaccineInfo
        public static void GetVaccineInfo(){
            Console.WriteLine($"|{"vaccine Id",-15}|{"Vaccine Name",-15}|{"NoOfDoseAvailable",-20}|");
            foreach(VaccineDetails vaccine in vaccineList){
            Console.WriteLine($"|{vaccine.VaccineID,-15}|{vaccine.VaccineName,-15}|{vaccine.NoOfDoseAvailable,-20}|");
            
            }
        }
        
    }
}