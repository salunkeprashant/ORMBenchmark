using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace RawBencher.RandomDataGenerator
{
    public class QueryExecutor
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);
        Random rand = new Random();

        public void Admin(int num)
        {
            List<string> allFirstName = Names.GetFirstNames();

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            string uname = "admin";
            string pwd = "admin";

            for (var i = 0; i < num; i++)
            {
                cmd.CommandText = "insert into Admins (AdminName,Username,Password)" + "VALUES('" + allFirstName[i] + "','" +uname+ "','"+pwd+"')";
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            Console.WriteLine("Users Inserted.");
            conn.Close();
        }

        public void User(int num)
        {
            var dates = Names.GenerateRandomDates(num);
            List<DateTime> JoiningDates = new List<DateTime>();
            foreach (var item in dates)
            {
                JoiningDates.Add(item);
            }

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            for (var i = 0; i < num; i++)
            {
                cmd.CommandText = "insert into Users (JoiningDate)" + "VALUES('" + JoiningDates[rand.Next(JoiningDates.Count)] + "')";
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            Console.WriteLine("Admin Inserted.");
            conn.Close();
        }

        public void UserDetails()
        {
            int allUserID = GetCountfromDB("UserID", "Users");
            List<string> allFirstName = Names.GetFirstNames();
            List<string> allLastName = Names.GetLastNames();

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            for (var i = 0; i < allUserID; i++)
            {
                cmd.CommandText = "insert into UserDetails (UserID,FirstName,LastName)" + "VALUES(" +(i+1)+ ",'" + allFirstName[i] + "','" + allLastName[i] + "')";
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            Console.WriteLine("User Details Inserted.");
            conn.Close();
        }

        public void ContactDetails()
        {
            int allUserID = GetCountfromDB("UserID", "Users");
            var allMobileNo = Names.GetContacts();
            var allEmailAddress = Names.GetEmails();

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            for (var i = 0; i < allUserID; i++)
            {
                cmd.CommandText = "insert into ContactDetails (UserID,MobileNo,EmailAddress)" + "VALUES(" + (i+1) + "," + allMobileNo[rand.Next(allMobileNo.Count)] + ",'" + allEmailAddress[i] + "')";
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            Console.WriteLine("Contact Details Inserted.");
            conn.Close();
        }
        public void Address()
        {
            int allUserID = GetCountfromDB("UserID", "Users");
            var allAddressLine = Names.GetAddress();
            var allCityName = Names.GetCities();
            var AllStateName = Names.GetStates();

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            for (var i = 0; i < allUserID; i++)
            {
                cmd.CommandText = "insert into Address (UserID,AddressLine,CityName,StateName)" + "VALUES(" + (i+1) + ",'" + allAddressLine[rand.Next(allAddressLine.Count)] + "','" + allCityName[rand.Next(allCityName.Count)] + "','" + AllStateName[rand.Next(AllStateName.Count)] + "')";
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            Console.WriteLine("Address Inserted.");
            conn.Close();
        }

        public void BookCategory()
        {
            List<string> allCategory = Names.GetBookCategory();

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            for (var i = 0; i < allCategory.Count; i++)
            {
                cmd.CommandText = "insert into BookCategory (CategoryName)" + "VALUES('" + allCategory[i] + "')";
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            Console.WriteLine("Book Category Names Inserted.");
            conn.Close();
        }

        public void Authors()
        {
            List<string> allAuthorName = Names.GetAuthorNames();
            var allBookPublished = Names.GetBookPublished();

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            for (var i = 0; i < allAuthorName.Count; i++)
            {
                cmd.CommandText = "insert into Authors(AuthorName,BookPublished)" + "VALUES('" + allAuthorName[i] + "'," + allBookPublished[rand.Next(allBookPublished.Count)] + ")";
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            Console.WriteLine("Authors Names Inserted.");
            conn.Close();
        }

        public void Book(int num)
        {
            var allBookNames = Names.GetBookNames();
            var allAuthorID = GetCountfromDB("AuthorID", "Authors");
            var allCategoryID = GetCountfromDB("CategoryID", "BookCategory");
            var pages = Names.GetPages();
            var yop = Names.GetYear();
            var qty = Names.GetQuantity();
            var rating = Names.GetRatings();

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            for (var i = 0; i < num; i++)
            {
                cmd.CommandText = "insert into Books (BookName, CategoryID,AuthorID,Pages,YearOfPublish,Ratings,Quantity)" + "VALUES('" + allBookNames[rand.Next(allBookNames.Count)] + "' ," + rand.Next(1, allCategoryID) + "," + rand.Next(1, allAuthorID) + "," + pages[rand.Next(pages.Count)] + "," + yop[rand.Next(yop.Count)] + "," + rating[rand.Next(rating.Count)] + "," + qty[rand.Next(qty.Count)] + ")";
                cmd.ExecuteNonQuery();
            }

            transaction.Commit();
            Console.WriteLine("Books Inserted.");
            conn.Close();
        }

        public void ItemCategory()
        {
            List<string> allCategory = Names.getItemCategory();

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            for (var i = 0; i < allCategory.Count; i++)
            {
                cmd.CommandText = "insert into ItemCategory (CategoryName)" + "VALUES('" + allCategory[i] + "')";
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            Console.WriteLine("Item Category Names Inserted.");
            conn.Close();
        }
        public void Inventory(int num)
        {
            int allCategoryID = GetCountfromDB("CategoryID", "ItemCategory");
            var allCategoryName = Names.getItemCategory();
            var allItemDescription = Names.GetItemDescription();

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            for (var i = 0; i < num; i++)
            {
                cmd.CommandText = "insert into Inventory (CategoryID,ItemName, ItemDescription)" + "VALUES(" + rand.Next(1, allCategoryID) + ",'" + allCategoryName[rand.Next(allCategoryName.Count)] + "' ,'" + allItemDescription[rand.Next(allItemDescription.Count)] + "')";
                cmd.ExecuteNonQuery();
            }

            transaction.Commit();
            Console.WriteLine("Inventory Item Inserted.");
            conn.Close();
        }


        public void BookTransaction(int num)
        {
            int allAdminID = GetCountfromDB("AdminID", "Admins");
            int allUserID = GetCountfromDB("UserID", "Users");
            int allBookID = GetCountfromDB("BookID", "Books");


            var isuedate = Names.GetDates();
            List<DateTime> allIssueDate = new List<DateTime>();
            List<DateTime> allReturnDate = new List<DateTime>();
            foreach (var item in isuedate)
            {
                allIssueDate.Add(item.Item1);
                allReturnDate.Add(item.Item2);
            }

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            for (var i = 0; i < num; i++)
            {
                cmd.CommandText = "insert into BookTransaction (AdminID,UserID,BookID,IssueDate,ReturnDate)" + "VALUES(" + rand.Next(1, allAdminID) + "," + rand.Next(1, allUserID) + "," + rand.Next(1, allBookID) + ",'" + allIssueDate[rand.Next(allIssueDate.Count)] + "','" + allReturnDate[rand.Next(allReturnDate.Count)] + "')";
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            Console.WriteLine("Book Transaction Inserted.");
            conn.Close();
        }

        public void ItemTransaction(int num)
        {
            int allAdminID = GetCountfromDB("AdminID", "Admins");
            int allUserID = GetCountfromDB("UserID", "Users");
            int allItemID = GetCountfromDB("ItemID", "Inventory");


            var isuedate = Names.GetDates();
            List<DateTime> allIssueDate = new List<DateTime>();
            List<DateTime> allReturnDate = new List<DateTime>();
            foreach (var item in isuedate)
            {
                allIssueDate.Add(item.Item1);
                allReturnDate.Add(item.Item2);
            }

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            for (var i = 0; i < num; i++)
            {
                cmd.CommandText = "insert into ItemTransaction (AdminID,UserID,ItemID,IssueDate,ReturnDate)" + "VALUES(" + rand.Next(1, allAdminID) + "," + rand.Next(1, allUserID) + "," + rand.Next(1, allItemID) + ",'" + allIssueDate[rand.Next(allIssueDate.Count)] + "','" + allReturnDate[rand.Next(allReturnDate.Count)] + "')";
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            Console.WriteLine("Item Transaction Inserted.");
            conn.Close();
        }

        public int GetCountfromDB(string IdName, string table)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            var transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = transaction;

            cmd.CommandText = "select count(" + IdName + ") from " + table + "";
            cmd.CommandType = CommandType.Text;
            int idcount = Convert.ToInt32(cmd.ExecuteScalar());
            transaction.Commit();
            conn.Close();
            return idcount;
        }
    }
}
