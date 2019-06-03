using BenchmarkDotNet.Running;
using EFCoreBencher;
using NHibernateBencher;
using RawBencher.RandomDataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawBencher
{
    class Program
    {
        static void Main(string[] args)
        {


            // RandomGenerator obj = new RandomGenerator();

            //NHibernateORM obj = new NHibernateORM();
            //obj.GetAllRecords();

            //EntityFramework EFObj = new EntityFramework();
            //EFObj.GetAllRecords();

            //EntityFrameworkCore EFCoreObj = new EntityFrameworkCore();
            //EFCoreObj.GetAllRecords();

            var summury = BenchmarkRunner.Run(typeof(ORMRunner));

            Console.ReadLine();
        }
    }
}

