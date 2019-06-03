using EF6.Bencher.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace RawBencher
{
    public class EntityFramework
    {
        public void GetAllRecords()
        {
            using (LibraryDBEntities context = new LibraryDBEntities())
            {
                var result = (from users in context.Users
                              join UserDetail in context.UserDetails on users.UserID equals UserDetail.UserID
                              join ContactDetail in context.ContactDetails on users.UserID equals ContactDetail.UserID
                              join Address in context.Addresses on users.UserID equals Address.UserID
                              join BookTransaction in context.BookTransactions on users.UserID equals BookTransaction.UserID

                              select new
                              {
                                  users.UserID,
                                  users.JoiningDate,

                                  UserDetail.FirstName,
                                  UserDetail.LastName,
                                  ContactDetail.MobileNo,
                                  ContactDetail.EmailAddress,

                                  Address.AddressLine,
                                  Address.CityName,
                                  Address.StateName,

                                  BookTransaction.IssueDate,
                                  BookTransaction.ReturnDate

                              }).ToList();
            }
        }
    }
}
