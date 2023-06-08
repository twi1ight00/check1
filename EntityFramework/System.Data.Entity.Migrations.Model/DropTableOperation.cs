using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents dropping an existing table.
/// </summary>
public class DropTableOperation : MigrationOperation
{
	private readonly string _name;

	private readonly CreateTableOperation _inverse;

	/// <summary>
	/// Gets the name of the table to be dropped.
	/// </summary>
	public virtual string Name => _name;

	/// <summary>
	/// Gets an operation that represents reverting dropping the table.
	/// The inverse cannot be automatically calculated, 
	/// if it was not supplied to the constructor this property will return null.
	/// </summary>
	public override MigrationOperation Inverse => _inverse;

	/// <inheritdoc />
	public override bool IsDestructiveChange => true;

	/// <summary>
	/// Initializes a new instance of the DropTableOperation class.
	/// </summary>
	/// <param name="name">The name of the table to be dropped.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public DropTableOperation(string name, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(name), null, "!string.IsNullOrWhiteSpace(name)");
		base._002Ector(anonymousArguments);
		_name = name;
	}

	/// <summary>
	/// Initializes a new instance of the DropTableOperation class.
	/// </summary>
	/// <param name="name">The name of the table to be dropped.</param>
	/// <param name="inverse">An operation that represents reverting dropping the table.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public DropTableOperation(string name, CreateTableOperation inverse, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(inverse != null, null, "inverse != null");
		this._002Ector(name, anonymousArguments);
		_inverse = inverse;
	}
}
