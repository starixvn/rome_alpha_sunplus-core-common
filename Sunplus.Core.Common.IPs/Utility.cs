using System.Configuration;
using System.Data.EntityClient;
using Fanex.Common;

namespace Sunplus.Core.Common.IPs
{
    public static class Utility
    {
        private static string EFConnectionString = string.Empty;

        public static string GetEFConnectionString()
        {
            if (!string.IsNullOrEmpty(EFConnectionString))
            {
                return EFConnectionString;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["IPEntities"].ConnectionString;
            EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder(connectionString);
            entityConnectionStringBuilder.ProviderConnectionString = Cryptography.DeCryptConnectionString(entityConnectionStringBuilder.ProviderConnectionString);
            EFConnectionString = entityConnectionStringBuilder.ToString();

            return EFConnectionString;
        }
    }
}