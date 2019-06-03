using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawBencher.RandomDataGenerator
{
    class RandomGenerator
    {
        public RandomGenerator()
        {
            QueryExecutor obj = new QueryExecutor();

            obj.Admin(3);
            obj.User(15);
            obj.UserDetails();
            obj.ContactDetails();
            obj.Address();

            obj.BookCategory();
            obj.Authors();

            obj.Book(10000);
            obj.BookTransaction(20000);

            obj.ItemCategory();
            obj.Inventory(10000);
            obj.ItemTransaction(20000);
        }
    }
}
