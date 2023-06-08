using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Resources;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Utilities;

internal static class DbConnectionExtensions
{
	public static string GetProviderInvariantName(this DbConnection connection)
	{
		Type type = DbProviderServices.GetProviderFactory(connection).GetType();
		AssemblyName assemblyName = new AssemblyName(type.Assembly.FullName);
		foreach (DataRow row in DbProviderFactories.GetFactoryClasses().Rows)
		{
			string typeName = (string)row[3];
			AssemblyName rowProviderFactoryAssemblyName = null;
			Type.GetType(typeName, delegate(AssemblyName a)
			{
				rowProviderFactoryAssemblyName = a;
				return null;
			}, (Assembly _, string __, bool ___) => null);
			if (rowProviderFactoryAssemblyName == null || !string.Equals(assemblyName.Name, rowProviderFactoryAssemblyName.Name, StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			try
			{
				DbProviderFactory factory = DbProviderFactories.GetFactory(row);
				if (factory.GetType().Equals(type))
				{
					return (string)row[2];
				}
			}
			catch
			{
			}
		}
		throw Error.ModelBuilder_ProviderNameNotFound(connection);
	}

	public static DbProviderInfo GetProviderInfo(this DbConnection connection, out DbProviderManifest providerManifest)
	{
		DbProviderServices providerServices = DbProviderServices.GetProviderServices(connection);
		string providerManifestTokenChecked = providerServices.GetProviderManifestTokenChecked(connection);
		DbProviderInfo result = new DbProviderInfo(connection.GetProviderInvariantName(), providerManifestTokenChecked);
		providerManifest = providerServices.GetProviderManifest(providerManifestTokenChecked);
		return result;
	}
}
