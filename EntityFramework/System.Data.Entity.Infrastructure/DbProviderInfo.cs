using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Infrastructure;

[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
public sealed class DbProviderInfo
{
	private readonly string _providerInvariantName;

	private readonly string _providerManifestToken;

	public string ProviderInvariantName => _providerInvariantName;

	public string ProviderManifestToken => _providerManifestToken;

	public DbProviderInfo(string providerInvariantName, string providerManifestToken)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(providerInvariantName), null, "!string.IsNullOrWhiteSpace(providerInvariantName)");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(providerManifestToken), null, "!string.IsNullOrWhiteSpace(providerManifestToken)");
		base._002Ector();
		_providerInvariantName = providerInvariantName;
		_providerManifestToken = providerManifestToken;
	}
}
