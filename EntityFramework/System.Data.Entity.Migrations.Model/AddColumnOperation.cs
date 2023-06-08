using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents a column being added to a table.
/// </summary>
public class AddColumnOperation : MigrationOperation
{
	private readonly string _table;

	private readonly ColumnModel _column;

	/// <summary>
	/// Gets the name of the table the column should be added to.
	/// </summary>
	public string Table => _table;

	/// <summary>
	/// Gets the details of the column being added.
	/// </summary>
	public ColumnModel Column => _column;

	/// <summary>
	/// Gets an operation that represents dropping the added column.
	/// </summary>
	public override MigrationOperation Inverse => new DropColumnOperation(Table, Column.Name);

	/// <inheritdoc />
	public override bool IsDestructiveChange => false;

	/// <summary>
	/// Initializes a new instance of the AddColumnOperation class.
	/// </summary>
	/// <param name="table">The name of the table the column should be added to.</param>
	/// <param name="column">Details of the column being added.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public AddColumnOperation(string table, ColumnModel column, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(table), null, "!string.IsNullOrWhiteSpace(table)");
		RuntimeFailureMethods.Requires(column != null, null, "column != null");
		base._002Ector(anonymousArguments);
		_table = table;
		_column = column;
	}
}
