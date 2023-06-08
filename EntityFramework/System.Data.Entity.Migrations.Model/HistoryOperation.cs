using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Common base class for operations that affect the migrations history table.
/// The migrations history table is used to store a log of the migrations that have been applied to the database.
/// </summary>
public abstract class HistoryOperation : MigrationOperation
{
	private readonly string _table;

	private readonly string _migrationId;

	/// <summary>
	/// Gets the name of the migrations history table.
	/// </summary>
	public string Table => _table;

	/// <summary>
	/// Gets the name of the migration being affected.
	/// </summary>
	public string MigrationId => _migrationId;

	/// <inheritdoc />
	public override bool IsDestructiveChange => false;

	/// <summary>
	/// Initializes a new instance of the HistoryOperation class.
	/// </summary>
	/// <param name="table">Name of the migrations history table.</param>
	/// <param name="migrationId">Name of the migration being affected.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	protected HistoryOperation(string table, string migrationId, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(table), null, "!string.IsNullOrWhiteSpace(table)");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(migrationId), null, "!string.IsNullOrWhiteSpace(migrationId)");
		base._002Ector(anonymousArguments);
		_table = table;
		_migrationId = migrationId;
	}
}
