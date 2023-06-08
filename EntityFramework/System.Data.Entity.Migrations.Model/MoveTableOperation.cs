using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents moving a table from one schema to another.
/// </summary>
public class MoveTableOperation : MigrationOperation
{
	private readonly string _name;

	private readonly string _newSchema;

	/// <summary>
	/// Gets the name of the table to be moved.
	/// </summary>
	public virtual string Name => _name;

	/// <summary>
	/// Gets the name of the schema to move the table to.
	/// </summary>
	public virtual string NewSchema => _newSchema;

	/// <summary>
	/// Gets an operation that moves the table back to its original schema.
	/// </summary>
	public override MigrationOperation Inverse
	{
		get
		{
			string newSchema = null;
			string[] array = _name.Split(new char[1] { '.' }, 2);
			if (array.Length > 1)
			{
				newSchema = array[0];
			}
			string text = array.Last();
			return new MoveTableOperation(NewSchema + '.' + text, newSchema);
		}
	}

	/// <inheritdoc />
	public override bool IsDestructiveChange => false;

	/// <summary>
	/// Initializes a new instance of the MoveTableOperation class.
	/// </summary>
	/// <param name="name">Name of the table to be moved.</param>
	/// <param name="newSchema">Name of the schema to move the table to.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public MoveTableOperation(string name, string newSchema, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(name), null, "!string.IsNullOrWhiteSpace(name)");
		base._002Ector(anonymousArguments);
		_name = name;
		_newSchema = newSchema;
	}
}
