using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace RawBencher
{
    [Config(typeof(ORMRunner))]
    public class ORMRunner : ManualConfig
    {
        EntityFramework EFObj;
        EntityFrameworkCore EFCoreObj;
        DapperORM DapperObj;
        NHibernateORM NHibenateObj;

        public ORMRunner()
        {
            Add(new Job()
            {
                Run = { LaunchCount = 1, WarmupCount = 5, TargetCount = 5 },
            });

            EFObj = new EntityFramework();
            EFCoreObj = new EntityFrameworkCore();
            DapperObj = new DapperORM();
            NHibenateObj = new NHibernateORM();
        }

        //[Benchmark]
        //public void EntityFrameworkCore() => EFCoreObj.GetAllRecords();

        //[Benchmark]
        //public void EntityFramework() => EFObj.GetAllRecords();

        //[Benchmark]
        //public void DapperORM() => DapperObj.GetAllRecords();

        [Benchmark]
        public void NHibernateORM() => NHibenateObj.GetAllRecords();

    }
}
