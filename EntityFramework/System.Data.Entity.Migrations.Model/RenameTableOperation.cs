using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents renaming an existing table.
/// </summary>
public class RenameTableOperation : MigrationOperation
{
	private readonly string _name;

	private readonly string _newName;

	/// <summary>
	/// Gets the name of the table to be renamed.
	/// </summary>
	public virtual string Name => _name;

	/// <summary>
	/// Gets the new name for the table.
	/// </summary>
	public virtual string NewName => _newName;

	/// <summary>
	/// Gets an operation that reverts the rename.
	/// </summary>
	public override MigrationOperation Inverse => new RenameTableOperation(NewName, Name);

	/// <inheritdoc />
	public override bool IsDestructiveChange => false;

	/// <summary>
	/// Initializes a new instance of the RenameTableOperation class.
	/// </summary>
	/// <param name="name">Name of the table to be renamed.</param>
	/// <param name="newName">New name for the table.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public RenameTableOperation(string name, string newName, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(name), null, "!string.IsNullOrWhiteSpace(name)");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(newName), null, "!string.IsNullOrWhiteSpace(newName)");
		base._002Ector(anonymousArguments);
		_name = name;
		_newName = newName;
	}
}
