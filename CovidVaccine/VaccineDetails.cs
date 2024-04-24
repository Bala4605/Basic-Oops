using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine
{
    public enum VaccineName{Covishield, Covaccine}
    public class VaccineDetails
    {
        private static int s_vaccineID=2001;
        public string VaccineID {get;}
        public VaccineName VaccineName {get;set;}
        public int NoOfDoseAvailable{get;set;}
        public VaccineDetails(VaccineName vaccineName,int noOfDoseAvailable){
            VaccineID="CID"+s_vaccineID++;
            VaccineName=vaccineName;
            NoOfDoseAvailable=noOfDoseAvailable;

        }

        
    }
}