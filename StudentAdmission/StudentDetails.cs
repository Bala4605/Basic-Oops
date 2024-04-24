using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
/// <summary>
/// DataType Gender used to select a instance of <see cref="StudentSetails" /> Gender Information
/// </summary>
public enum GENDER{Male,Female,TransGender}
/// <summary>
/// Class StudentDetails used to create instance for student <see cref="StudentDeatails"/>
/// Refer documention on <see href="www.syncfusion.com" />
/// </summary>
    public class StudentDetails
    {    /// <summary>
        /// StudentName property used to hold StudentName of a instance of <see cref="StudentDetails"/> 
        /// </summary>
        public string StudentName{get;set;}
        /// <summary>
        /// FatherName property used to hold FatherName of a instance of <see cref="StudentDetails"/> 
        /// </summary>
        
        public string FatherName{get;set;}
         /// <summary>
        /// DOB property used to hold DOB of a instance of <see cref="StudentDetails"/> 
        /// </summary>
        public DateTime DOB {get;set;}
         /// <summary>
        /// Gender property used to hold Gender of a instance of <see cref="StudentDetails"/> 
        /// </summary>
        public GENDER Gender{get;set;}
         /// <summary>
        /// Maths property used to hold Maths of a instance of <see cref="StudentDetails"/> 
        /// </summary>
        /// <value>Range 0 t0 100</value>
        public int Maths {get;set;}
        /// <summary>
        /// Physics property used to hold physics of a instance of <see cref="StudentDetails"/>
        /// </summary>
        /// <value></value>
        public int Physics {get;set;}
        /// <summary>
        /// Chemistry property used to hold chemisrty of a instance of <see cref="StudentDetails"/> 
        /// </summary>
        /// <value></value>
        public int Chemistry {get;set;}
        /// <summary>
        /// StudentId Property used to hold a Student's ID of instance of <see cref="StudentDetails"/>
        /// </summary>
  
        public string StudentID{get;set;}
        /// <summary>
        /// Static Field s_number used to auto increment StudentID of the instance of <see cref="StudentDetails"/> 
        /// </summary>
        static int s_number=1001;
        /// <summary>
        /// Constructor StudentDetails used to initialize parameter values to the properties
        /// </summary>
        /// <param name="studentName">studentName parameter used to assign its value to associated property</param>
        /// <param name="fatherName">fathername parameter used to assign its value to associated property</param>
        /// <param name="dob">dob parameter used to assign its value to associated property</param>
        /// <param name="gender">gender parameter used to assign its value to associated property</param>
        /// <param name="maths">maths parameter used to assign its value to associated property</param>
        /// <param name="physics">physics parameter used to assign its value to associated property</param>
        /// <param name="chemistry">chemistry parameter used to assign its value to associated property</param>
        public StudentDetails(string studentName,string fatherName,DateTime dob,GENDER gender,int maths,int physics,int chemistry){
                StudentName=studentName;
                FatherName=fatherName;
                DOB=dob;
                Gender=gender;
                Maths=maths;
                Physics=physics;
                Chemistry=chemistry;
                StudentID="SF"+s_number++;
                Console.WriteLine();
                Console.WriteLine($"Student Registered Successfully and StudentID is {StudentID}");
                Console.WriteLine();

        }/// <summary>
        /// Constructor StudentDetails used to initailize default value to its Properties.
        /// </summary>
        public StudentDetails(){

        }
        /// <summary>
        /// method eligibility used to check whether the instance of <see cref="StudentDetails"/>
        /// </summary>
        
        /// <returns>return true if eligibile,else false</returns>
        public bool Eligibility(){
            
            return ((Maths+Physics+Chemistry)/3)>75;
        }
        
    }
}