using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents altering an existing column.
/// </summary>
public class AlterColumnOperation : MigrationOperation
{
	private readonly string _table;

	private readonly ColumnModel _column;

	private readonly AlterColumnOperation _inverse;

	private readonly bool _destructiveChange;

	/// <summary>
	/// Gets the name of the table that the column belongs to.
	/// </summary>
	public string Table => _table;

	/// <summary>
	/// Gets the new definition for the column.
	/// </summary>
	public ColumnModel Column => _column;

	/// <summary>
	/// Gets an operation that represents reverting the alteration.
	/// The inverse cannot be automatically calculated, 
	/// if it was not supplied to the constructor this property will return null.
	/// </summary>
	public override MigrationOperation Inverse => _inverse;

	/// <inheritdoc />
	public override bool IsDestructiveChange => _destructiveChange;

	/// <summary>
	/// Initializes a new instance of the AlterColumnOperation class.
	/// </summary>
	/// <param name="table">The name of the table that the column belongs to.</param>
	/// <param name="column">Details of what the column should be altered to.</param>
	/// <param name="isDestructiveChange">Value indicating if this change will result in data loss.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public AlterColumnOperation(string table, ColumnModel column, bool isDestructiveChange, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(table), null, "!string.IsNullOrWhiteSpace(table)");
		RuntimeFailureMethods.Requires(column != null, null, "column != null");
		base._002Ector(anonymousArguments);
		_table = table;
		_column = column;
		_destructiveChange = isDestructiveChange;
	}

	/// <summary>
	/// Initializes a new instance of the AlterColumnOperation class.
	/// </summary>
	/// <param name="table">The name of the table that the column belongs to.</param>
	/// <param name="column">Details of what the column should be altered to.</param>
	/// <param name="isDestructiveChange">Value indicating if this change will result in data loss.</param>
	/// <param name="inverse">An operation to revert this alteration of the column.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public AlterColumnOperation(string table, ColumnModel column, bool isDestructiveChange, AlterColumnOperation inverse, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(inverse != null, null, "inverse != null");
		this._002Ector(table, column, isDestructiveChange);
		_inverse = inverse;
	}
}
