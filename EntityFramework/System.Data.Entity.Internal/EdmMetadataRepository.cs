using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace System.Data.Entity.Internal;

internal class EdmMetadataRepository : RepositoryBase
{
	public EdmMetadataRepository(string connectionString, DbProviderFactory providerFactory)
		: base(connectionString, providerFactory)
	{
	}

	public virtual string QueryForModelHash(Func<DbConnection, EdmMetadataContext> createContext)
	{
		using EdmMetadataContext edmMetadataContext = createContext(CreateConnection());
		try
		{
			return (from m in edmMetadataContext.Metadata.AsNoTracking()
				orderby m.Id descending
				select m).FirstOrDefault()?.ModelHash;
		}
		catch (EntityCommandExecutionException)
		{
			return null;
		}
	}
}
