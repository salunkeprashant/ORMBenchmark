using System.Configuration;

namespace EFCoreBencher
{
    public static class Constants
    {
        public static string EFCoreconnectionString = ConfigurationManager.ConnectionStrings["EFCoreConnection"].ConnectionString;
    }
}