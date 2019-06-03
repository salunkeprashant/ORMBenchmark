using EFCoreBencher;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace RawBencher
{
    public class EntityFrameworkCore
    {
        public void GetAllRecords()
        {
            using (LibraryCoreModelDataContext context = new LibraryCoreModelDataContext())
            {

                var result = (from users in context.Users
                              join UserDetail in context.UserDetails on users.UserId equals UserDetail.UserId
                              join ContactDetail in context.ContactDetails on users.UserId equals ContactDetail.UserId
                              join Address in context.Addresses on users.UserId equals Address.UserId
                              join BookTransaction in context.BookTransactions on users.UserId equals BookTransaction.UserId

                              select new
                              {
                                  users.UserId,
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
