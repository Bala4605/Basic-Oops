using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine
{
    public enum GENDER{Male,Female,Others}
    public class Beneficiary

    {   
        private static int s_registrationNumber=1001;
        public string RegistrationNumber{get;}
        public string Name {get;set;}
        public int Age{get;set;}
        public GENDER Gender {get;set;}
        public string MobileNumber{get;set;}
        public string City{get;set;}

        public Beneficiary(string name,int age,GENDER gender,string mobileNumber,string city){
        RegistrationNumber="BID"+s_registrationNumber++;
        Name=name;
        Age=age;
        Gender=gender;
        MobileNumber=mobileNumber;
        City=city;
        // Console.WriteLine($"Your Beneficiary ID: {RegistrationNumber}");
        }

    }
}