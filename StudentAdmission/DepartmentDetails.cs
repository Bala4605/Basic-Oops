using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{   
    /// <summary>
/// Class DepartmentDetails used to create instance for student <see cref="DepartmentDe tails"/>
/// Refer documention on <see href="www.syncfusion.com" />
/// </summary>
        public class DepartmentDetails
    {   
        public string DepartmentID{get;set;}
        public string DepartmentName{get;set;}
        public int NoOfSeats{get;set;}
        static int count=101;
        public DepartmentDetails(string departmentName,int noOfSeats){
            DepartmentName=departmentName;
            NoOfSeats=noOfSeats;
            DepartmentID="DID"+count++;
        }
        public DepartmentDetails(){

        }
        
}
}