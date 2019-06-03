using System.Configuration;

namespace NHibernateBencher
{
    public static class Constants
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["NHDBConnection"].ConnectionString;

    }
}