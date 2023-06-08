using System.Data.Common;
using System.Data.Entity.Resources;

namespace System.Data.Entity.ModelConfiguration.Utilities;

internal static class DbProviderServicesExtensions
{
	public static string GetProviderManifestTokenChecked(this DbProviderServices providerServices, DbConnection connection)
	{
		try
		{
			return providerServices.GetProviderManifestToken(connection);
		}
		catch (ProviderIncompatibleException innerException)
		{
			if ("(localdb)\v11.0".Equals(connection.DataSource, StringComparison.OrdinalIgnoreCase))
			{
				throw new ProviderIncompatibleException(Strings.BadLocalDBDatabaseName, innerException);
			}
			throw new ProviderIncompatibleException(Strings.FailedToGetProviderInformation, innerException);
		}
	}
}
