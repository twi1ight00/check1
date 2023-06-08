using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents renaming an existing column.
/// </summary>
public class RenameColumnOperation : MigrationOperation
{
	private readonly string _table;

	private readonly string _name;

	private readonly string _newName;

	/// <summary>
	/// Gets the name of the table the column belongs to.
	/// </summary>
	public virtual string Table => _table;

	/// <summary>
	/// Gets the name of the column to be renamed.
	/// </summary>
	public virtual string Name => _name;

	/// <summary>
	/// Gets the new name for the column.
	/// </summary>
	public virtual string NewName => _newName;

	/// <summary>
	/// Gets an operation that reverts the rename.
	/// </summary>
	public override MigrationOperation Inverse => new RenameColumnOperation(Table, NewName, Name);

	/// <inheritdoc />
	public override bool IsDestructiveChange => false;

	/// <summary>
	/// Initializes a new instance of the RenameColumnOperation class.
	/// </summary>
	/// <param name="table">Name of the table the column belongs to.</param>
	/// <param name="name">Name of the column to be renamed.</param>
	/// <param name="newName">New name for the column.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public RenameColumnOperation(string table, string name, string newName, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(table), null, "!string.IsNullOrWhiteSpace(table)");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(name), null, "!string.IsNullOrWhiteSpace(name)");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(newName), null, "!string.IsNullOrWhiteSpace(newName)");
		base._002Ector(anonymousArguments);
		_table = table;
		_name = name;
		_newName = newName;
	}
}
