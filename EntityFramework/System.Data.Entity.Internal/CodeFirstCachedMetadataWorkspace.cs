using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.Internal;

/// <summary>
///     Implements ICachedMetadataWorkspace for a Code First model.
/// </summary>
internal class CodeFirstCachedMetadataWorkspace : ICachedMetadataWorkspace
{
	private readonly MetadataWorkspace _metadataWorkspace;

	private readonly IEnumerable<Assembly> _assemblies;

	private readonly DbProviderInfo _providerInfo;

	private readonly string _defaultContainerName;

	/// <summary>
	///     The default container name for code first is the container name that is set from the DbModelBuilder
	/// </summary>
	public string DefaultContainerName => _defaultContainerName;

	/// <summary>
	///     The list of assemblies that contain entity types for this workspace, which may be empty, but
	///     will never be null.
	/// </summary>
	public IEnumerable<Assembly> Assemblies => _assemblies;

	/// <summary>
	/// The provider info used to construct the workspace.
	/// </summary>
	public DbProviderInfo ProviderInfo => _providerInfo;

	/// <summary>
	///     Builds and stores the workspace based on the given code first configuration.
	/// </summary>
	/// <param name="databaseMapping">The code first EDM model.</param>
	public CodeFirstCachedMetadataWorkspace(DbDatabaseMapping databaseMapping)
	{
		_providerInfo = databaseMapping.Database.GetProviderInfo();
		_metadataWorkspace = databaseMapping.ToMetadataWorkspace();
		_assemblies = (from t in databaseMapping.Model.GetClrTypes()
			select t.Assembly).Distinct().ToList();
		_defaultContainerName = databaseMapping.Model.Containers.First().Name;
	}

	/// <summary>
	///     Gets the <see cref="T:System.Data.Metadata.Edm.MetadataWorkspace" />.
	///     If the workspace is not compatible with the provider manifest obtained from the given
	///     connection then an exception is thrown.
	/// </summary>
	/// <param name="storeConnection">The connection to use to create or check SSDL provider info.</param>
	/// <returns>The workspace.</returns>
	public MetadataWorkspace GetMetadataWorkspace(DbConnection storeConnection)
	{
		string providerInvariantName = storeConnection.GetProviderInvariantName();
		if (!string.Equals(_providerInfo.ProviderInvariantName, providerInvariantName, StringComparison.Ordinal))
		{
			throw Error.CodeFirstCachedMetadataWorkspace_SameModelDifferentProvidersNotSupported();
		}
		return _metadataWorkspace;
	}
}
