using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents dropping an existing index.
/// </summary>
public class DropIndexOperation : IndexOperation
{
	private readonly CreateIndexOperation _inverse;

	/// <summary>
	/// Gets an operation that represents reverting dropping the index.
	/// The inverse cannot be automatically calculated, 
	/// if it was not supplied to the constructor this property will return null.
	/// </summary>
	public override MigrationOperation Inverse => _inverse;

	/// <inheritdoc />
	public override bool IsDestructiveChange => false;

	/// <summary>
	/// Initializes a new instance of the DropIndexOperation class.
	/// </summary>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public DropIndexOperation(object anonymousArguments = null)
		: base(anonymousArguments)
	{
	}

	/// <summary>
	/// Initializes a new instance of the DropIndexOperation class.
	/// </summary>
	/// <param name="inverse">The operation that represents reverting dropping the index.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public DropIndexOperation(CreateIndexOperation inverse, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(inverse != null, null, "inverse != null");
		base._002Ector(anonymousArguments);
		_inverse = inverse;
	}
}
