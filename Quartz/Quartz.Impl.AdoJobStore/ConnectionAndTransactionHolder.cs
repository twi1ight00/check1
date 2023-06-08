using System.Data;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// Utility class to keep track of both active transaction
/// and connection.
/// </summary>
/// <author>Marko Lahma</author>
public class ConnectionAndTransactionHolder
{
	/// <summary>
	/// Gets or sets the connection.
	/// </summary>
	/// <value>The connection.</value>
	public IDbConnection Connection { get; private set; }

	/// <summary>
	/// Gets or sets the transaction.
	/// </summary>
	/// <value>The transaction.</value>
	public IDbTransaction Transaction { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder" /> class.
	/// </summary>
	/// <param name="connection">The connection.</param>
	/// <param name="transaction">The transaction.</param>
	public ConnectionAndTransactionHolder(IDbConnection connection, IDbTransaction transaction)
	{
		Connection = connection;
		Transaction = transaction;
	}
}
