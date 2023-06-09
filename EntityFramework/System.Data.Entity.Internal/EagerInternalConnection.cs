using System.Data.Common;
using System.Data.Entity.Infrastructure;

namespace System.Data.Entity.Internal;

/// <summary>
///     A EagerInternalConnection object wraps an already existing DbConnection object.
/// </summary>
internal class EagerInternalConnection : InternalConnection
{
	private readonly bool _connectionOwned;

	/// <summary>
	///     Returns the origin of the underlying connection string.
	/// </summary>
	public override DbConnectionStringOrigin ConnectionStringOrigin => DbConnectionStringOrigin.UserCode;

	/// <summary>
	///     Creates a new EagerInternalConnection that wraps an existing DbConnection.
	/// </summary>
	/// <param name="existingConnection">An existing connection.</param>
	/// <param name="connectionOwned">If set to <c>true</c> then the underlying connection should be disposed when this object is disposed.</param>
	public EagerInternalConnection(DbConnection existingConnection, bool connectionOwned)
	{
		base.UnderlyingConnection = existingConnection;
		_connectionOwned = connectionOwned;
		OnConnectionInitialized(base.UnderlyingConnection);
	}

	/// <summary>
	///     Dispose the existing connection is the original caller has specified that it should be disposed
	///     by the framework.
	/// </summary>
	public override void Dispose()
	{
		if (_connectionOwned)
		{
			base.UnderlyingConnection.Dispose();
		}
	}
}
