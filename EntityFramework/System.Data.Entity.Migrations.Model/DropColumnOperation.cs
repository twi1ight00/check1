using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents a column being dropped from a table.
/// </summary>
public class DropColumnOperation : MigrationOperation
{
	private readonly string _table;

	private readonly string _name;

	private readonly AddColumnOperation _inverse;

	/// <summary>
	/// Gets the name of the table the column should be dropped from.
	/// </summary>
	public string Table => _table;

	/// <summary>
	/// Gets the name of the column to be dropped.
	/// </summary>
	public string Name => _name;

	/// <summary>
	/// Gets an operation that represents reverting dropping the column.
	/// The inverse cannot be automatically calculated, 
	/// if it was not supplied to the constructor this property will return null.
	/// </summary>
	public override MigrationOperation Inverse => _inverse;

	/// <inheritdoc />
	public override bool IsDestructiveChange => true;

	/// <summary>
	/// Initializes a new instance of the DropColumnOperation class.
	/// </summary>
	/// <param name="table">The name of the table the column should be dropped from.</param>
	/// <param name="name">The name of the column to be dropped.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public DropColumnOperation(string table, string name, object anonymousArguments = null)
		: this(table, name, null, anonymousArguments)
	{
	}

	/// <summary>
	/// Initializes a new instance of the DropColumnOperation class.
	/// </summary>
	/// <param name="table">The name of the table the column should be dropped from.</param>
	/// <param name="name">The name of the column to be dropped.</param>
	/// <param name="inverse">The operation that represents reverting the drop operation.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public DropColumnOperation(string table, string name, AddColumnOperation inverse, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(table), null, "!string.IsNullOrWhiteSpace(table)");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(name), null, "!string.IsNullOrWhiteSpace(name)");
		base._002Ector(anonymousArguments);
		_table = table;
		_name = name;
		_inverse = inverse;
	}
}
