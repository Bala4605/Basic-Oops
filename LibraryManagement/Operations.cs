using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public static class Operations
    {
        static List<UserDetails> userList=new List<UserDetails>();
        static List<BookDetails> bookList=new List<BookDetails>();
        static List<BorrowDetails> borrowList=new List<BorrowDetails>();
        static UserDetails currentUser;
        public static void defaultData(){
        UserDetails user1=new UserDetails("Ravichandran",Gender.Male,Department.EEE,"9938388333","ravi@gmail.com",100);
        UserDetails user2=new UserDetails("Priyadharshini",Gender.Female,Department.CSE,"9944444455","priya@gmail.com",150);
        userList.AddRange(new List<UserDetails>{user1,user2});

        BookDetails book1=new BookDetails("C#","Author1",3);
        BookDetails book2=new BookDetails("HTML","Author2",5);
        BookDetails book3=new BookDetails("CSS","Author1",3);
        BookDetails book4=new BookDetails("JS","Author1",3);
        BookDetails book5=new BookDetails("TS","Author2",2);
        bookList.AddRange(new List<BookDetails>{book1,book2,book3,book4,book5});

        BorrowDetails borrow1=new BorrowDetails(book1.BookID,user1.UserID,new DateTime(2023,09,10),2,Status.Borrowed,0);
        BorrowDetails borrow2=new BorrowDetails(book3.BookID,user1.UserID,new DateTime(2023,09,12),1,Status.Borrowed,0);
        BorrowDetails borrow3=new BorrowDetails(book4.BookID,user1.UserID,new DateTime(2023,09,14),1,Status.Returned,16);
        BorrowDetails borrow4=new BorrowDetails(book2.BookID,user2.UserID,new DateTime(2023,09,11),2,Status.Borrowed,0);
        BorrowDetails borrow5=new BorrowDetails(book5.BookID,user2.UserID,new DateTime(2023,09,09),1,Status.Returned,20);
        borrowList.AddRange(new List<BorrowDetails>{borrow1,borrow2,borrow3,borrow4,borrow5});
        
        // foreach(UserDetails user in userList){
        //     Console.WriteLine(user.UserID);
        // }
        // foreach(BookDetails book in bookList){
        //     Console.WriteLine(book.BookID);
        // }
        // foreach(BorrowDetails borrow in borrowList){
        //     Console.WriteLine(borrow.BorrowID);
        // }
        }
        public static void MainMenu(){
            Console.WriteLine("------------------- SYNCFUSION LIBRARY -------------------");
            Console.WriteLine();
            int choice=1;
            while(choice!=3){
                Console.WriteLine("1. UserRegistration\n2. UserLogin\n3. Exit");
                Console.WriteLine();
                Console.Write("Enter Your Choice: ");
                choice=int.Parse(Console.ReadLine());
                switch(choice){
                    case 1:{
                        UserRegistration();
                        break;
                    }
                    case 2:{

                        Login();

                        break;
                    }
                    case 3:{
                        choice=3;
                        Console.WriteLine("------- Exited Application SuccessFully --------");
                        break;
                    }
                    default:{
                        Console.WriteLine("Invalid Option !!!");
                        Console.WriteLine("Please Enter Valid option :");

                        break;
                    }
                }
            }

        }
        // /UserRegistration
        public static void UserRegistration(){
        Console.Write("Enter Your Name :"); 
        string username=Console.ReadLine();
        Console.Write("Enter Your Gender(Male,Female) :");
        bool valid=Enum.TryParse<Gender>(Console.ReadLine(),true,out Gender gender);
        while(!valid){
           Console.Write("Please Enter the Valid data!!(Male,Female) :");
           valid=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender); 
        }
        Console.Write("Enter Your Department(EEE,CSE,ECE) :");
        valid=Enum.TryParse<Department>(Console.ReadLine(),true,out Department department);
        while(!valid){
           Console.Write("Please Enter the Valid data!!(ECE,EEE,CSE) :");
           valid=Enum.TryParse<Department>(Console.ReadLine(),true,out department); 
        }
        Console.Write("Enter Your Mobile Number :"); 
        string	mobileNumber=Console.ReadLine();
        Console.Write("Enter Your Mail ID :");
        string	mailID=Console.ReadLine();
        Console.Write("Enter Your Amount for Wallent Balance :");

        int	walletBalance=int.Parse(Console.ReadLine());
        while(walletBalance<=0){
          Console.Write("Account Can't be Empty.Please Enter amount :");  
          walletBalance=int.Parse(Console.ReadLine());
        }
        UserDetails user=new UserDetails(username,gender,department,mobileNumber,mailID,walletBalance);
        Console.WriteLine();
        Console.WriteLine($"Registration Successful.Your ID :{user.UserID}");
        Console.WriteLine();
        userList.Add(user);
        }
        //Login
        public static void  Login(){
            bool flag=false;
            
            Console.Write("Enter user ID :");
            string usersID=Console.ReadLine().ToUpper();
            foreach(UserDetails user in userList){
            if(usersID==user.UserID){
                flag=true;
                currentUser=user;

            }
            }
            
            if(flag){
            int subChoice=1;
            while(subChoice!=5){
                Console.WriteLine();
                Console.WriteLine("1. Borrowbook.\n2. ShowBorrowedhistory.\n3. ReturnBooks\n4. WalletRecharge \n5. Exit");
                Console.WriteLine();
                Console.Write("Enter Your Choice: ");

                subChoice=int.Parse(Console.ReadLine());
                switch(subChoice){
                    case 1:{
                        Console.WriteLine();
                        Borrowbook();
                        break;
                    }
                    case 2:{
                        Console.WriteLine();

                        ShowBorrowedhistory();
                        break;
                    }
                    case 3:{
                        Console.WriteLine();
                        ReturnBooks();
                        break;
                    }
                    case 4:{
                        Console.WriteLine();
                        WalletRecharge ();

                        break;
                    }
                    case 5:{
                        Console.WriteLine("---------- Log Out Successfully-----------");
                        subChoice=5;
                        break;
                    }
                    default:{
                        Console.WriteLine("Invalid Choice!!!!! Please Enter a Valid One .");
                       
                        break;
                    }
                }

            }
            }else{
                Console.WriteLine("Invalid ID!!!!");
            }

        }
        //Borrowbook()
        public static void Borrowbook(){
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"{"BookID",-15}|{"BookName",-15}|{"AuthorName",-15}| {"BookCount",-15}|");
            Console.WriteLine("-----------------------------------------------------------------");
            foreach(BookDetails book in bookList){
            Console.WriteLine($"{book.BookID,-15}|{book.BookName,-15}|{book.AuthorName,-15}| {book.BookCount,-15}|");
            Console.WriteLine("-----------------------------------------------------------------");
            }
            Console.Write("Enter Book ID :");
            string bID=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(BookDetails book in bookList){
                if(book.BookID==bID){
                Console.Write("Enter the count of the book :");
                int count=int.Parse(Console.ReadLine());
                if(book.BookCount>=count){
                    int total=0;
                    foreach(BorrowDetails borrow in borrowList){
                        if(borrow.UserID==currentUser.UserID && borrow.Status==Status.Borrowed){
                          total+=borrow.BorrowBookCount;  
                        }
                        }
                    if(total<3){
                        borrowList.Add(new BorrowDetails(book.BookID,currentUser.UserID,DateTime.Now,count,Status.Borrowed,0));
                        book.BookCount-=count;
                        Console.WriteLine($"Thank You.Book Borrowed successfully");
                    }else{
                        Console.WriteLine("You have borrowed 3 books already");
                        Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {total} and requested count is {count}, which exceeds 3 ");
                    } 
                }else{
                    Console.WriteLine("Books are not available for the selected count");
                    foreach(BorrowDetails borrow in borrowList){
                        if(borrow.BookID==book.BookID){
                            Console.WriteLine($"The book will be available on {borrow.BorrowedDate.AddDays(15).ToShortDateString()}");
                        }
                    }
                }



                flag=false;
                }
            }
            if(flag){
                Console.WriteLine("“ Invalid Book ID, Please enter valid ID");
            }
        }
        //ShowBorrowedhistory()
        public static void ShowBorrowedhistory(){
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"BorrowID",-16}|{"BookID",-16}|{"UserID",-16}|{"BorrowedDate",-16}|{"BorrowBookCount",-16}|{"Status",-16}|{"PaidFineAmount",-16}|");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            foreach(BorrowDetails borrow in borrowList){
                if(borrow.UserID==currentUser.UserID){
                 Console.WriteLine($"{borrow.BorrowID,-16}|{borrow.BookID,-16}|{borrow.UserID,-16}|{borrow.BorrowedDate.ToShortDateString(),-16}|{borrow.BorrowBookCount,-16}|{borrow.Status,-16}|{borrow.PaidFineAmount,-16}|");
                 Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                 
                }
            }
        }
        //ReturnBooks()
        public static void ReturnBooks(){
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

           
            Console.WriteLine($"{"BorrowID",-10}|{"BookID",-10}|{"UserID",-10}|{"BorrowedDate",-16}|{"BorrowBookCount",-16}|{"Status",-16}|{"PaidFineAmount",-16}|{"ReturnDate",-16}|");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            bool isPresent=false;
            foreach(BorrowDetails borrow in borrowList){
                if(borrow.UserID==currentUser.UserID && borrow.Status==Status.Borrowed){
                 Console.WriteLine($"{borrow.BorrowID,-10}|{borrow.BookID,-10}|{borrow.UserID,-10}|{borrow.BorrowedDate.ToShortDateString(),-16}|{borrow.BorrowBookCount,-16}|{borrow.Status,-16}|{borrow.PaidFineAmount,-16}|{borrow.BorrowedDate.AddDays(15).ToShortDateString(),-16}|");
                 Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                 isPresent=true;
                }
            }  
            if(isPresent){
            Console.Write("Enter The BorrowID :");
            string borrowId=Console.ReadLine().ToUpper();
            foreach(BorrowDetails borrow in borrowList){
              if(borrow.BorrowID==borrowId && borrow.Status==Status.Borrowed){
                 int days=(DateTime.Now-borrow.BorrowedDate.AddDays(15)).Days;
                 if(days>0){
                    int fineAmount=days*borrow.BorrowBookCount;
                    if(fineAmount<currentUser.WalletBalance){
                        borrow.Status=Status.Returned;
                        borrow.PaidFineAmount+=fineAmount;
                        currentUser.DeductBalance(fineAmount);
                        Console.WriteLine("Book returned successfully");
                        foreach(BookDetails book in bookList){
                            if(borrow.BookID==book.BookID){
                                book.BookCount+=borrow.BorrowBookCount;
                            }
                        }
                    }else{
                        Console.WriteLine("Insufficient balance. Please rechange and proceed");
                    }
                 }else{
                    borrow.Status=Status.Returned;
                    Console.WriteLine("Book returned successfully");
                    foreach(BookDetails book in bookList){
                            if(borrow.BookID==book.BookID){
                                book.BookCount+=borrow.BorrowBookCount;
                            }
                    }
                 }
              }  
            }}else{
                Console.WriteLine("----------------No data to show----------------");
            }
        }
        //WalletRecharge ()
        public static void WalletRecharge (){
            Console.Write("Enter the Amount :");
            int amount=int.Parse(Console.ReadLine());
            currentUser.WalletRecharge(amount);
        }
        
    }
    
}