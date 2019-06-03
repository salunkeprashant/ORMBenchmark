using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using EFCoreBencher;
using EF6.Bencher.Model;
using System;

namespace RawBencher
{
    public class DapperORM
    {
        public void GetAllRecords()
        {
            using (IDbConnection db = new SqlConnection(Constants.EFCoreconnectionString))
            {
                var results = db.Query<BookTransaction>
                    ($"select UserID,IssueDate from BookTransaction where AdminID=1").ToList();


                //Console.WriteLine(results.Count);
            }
        }
    }
}
