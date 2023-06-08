using System.Data;

namespace Quartz.Impl.AdoJobStore.Common;

/// <summary>
/// Data access provider interface.
/// </summary>
/// <author>Marko Lahma</author>
public interface IDbProvider
{
	/// <summary>
	/// Connection string used to create connections.
	/// </summary>
	string ConnectionString { get; set; }

	DbMetadata Metadata { get; }

	/// <summary>
	/// Initializes the db provider implementation.
	/// </summary>
	void Initialize();

	/// <summary>
	/// Returns a new command object for executing SQL statments/Stored Procedures
	/// against the database.
	/// </summary>
	/// <returns>An new <see cref="T:System.Data.IDbCommand" /></returns>
	IDbCommand CreateCommand();

	/// <summary>
	/// Returns a new instance of the providers CommandBuilder class.
	/// </summary>
	/// <remarks>In .NET 1.1 there was no common base class or interface
	/// for command builders, hence the return signature is object to
	/// be portable (but more loosely typed) across .NET 1.1/2.0</remarks>
	/// <returns>A new Command Builder</returns>
	object CreateCommandBuilder();

	/// <summary>
	/// Returns a new connection object to communicate with the database.
	/// </summary>
	/// <returns>A new <see cref="T:System.Data.IDbConnection" /></returns>
	IDbConnection CreateConnection();

	/// <summary>
	/// Returns a new parameter object for binding values to parameter
	/// placeholders in SQL statements or Stored Procedure variables.
	/// </summary> 
	/// <returns>A new <see cref="T:System.Data.IDbDataParameter" /></returns>
	IDbDataParameter CreateParameter();

	/// <summary>
	/// Shutdowns this instance.
	/// </summary>
	void Shutdown();
}
