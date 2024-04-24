using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum ADMISSIONSTATUS{Booked,Cancelled};
    public class AdmissionDetails
    {
        public string AdmissionID {get;set;}
        public string StudentID {get;set;}
        public string DepartmentID {get;set;}
        public DateTime AdmissionDate {get;set;}
        public ADMISSIONSTATUS AdmissionStatus {get;set;}
        static int count=1001;
        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate,ADMISSIONSTATUS status){
            AdmissionDate=admissionDate;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionID="AID"+count++;
            AdmissionStatus=status;
            Console.WriteLine($"Admission took successfully. Your admission ID – {AdmissionID}");

        }

        
    }
}