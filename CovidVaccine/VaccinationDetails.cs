using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine
{
    public class VaccinationDetails
    {
        private static int s_vaccinatioID=3001;
        public string VaccinationID {get;set;}
        public string RegistrationNumber {get;set;}
        public string  VaccineID{get;set;}
        public int DoseNumber{get;set;}
        public DateTime VaccinatedDate {get;set;}


        public VaccinationDetails(string registrationNumber,string vaccineID,int dose,DateTime vaccinatedDate){
            
            VaccinationID="VID"+s_vaccinatioID++;
            RegistrationNumber=registrationNumber;
            VaccineID=vaccineID;
            DoseNumber=dose;
            VaccinatedDate=vaccinatedDate;
        }


        
    }
}