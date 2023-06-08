using System.Data.Entity.Migrations.Extensions;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents creating a database index.
/// </summary>
public class CreateIndexOperation : IndexOperation
{
	/// <summary>
	/// Gets or sets a value indicating if this is a unique index.
	/// </summary>
	public bool IsUnique { get; set; }

	/// <summary>
	/// Gets an operation to drop this index.
	/// </summary>
	public override MigrationOperation Inverse
	{
		get
		{
			DropIndexOperation dropIndexOperation = new DropIndexOperation(this)
			{
				Name = base.Name,
				Table = base.Table
			};
			base.Columns.Each(delegate(string c)
			{
				dropIndexOperation.Columns.Add(c);
			});
			return dropIndexOperation;
		}
	}

	/// <inheritdoc />
	public override bool IsDestructiveChange => false;

	/// <summary>
	/// Initializes a new instance of the CreateIndexOperation class.
	/// The Table and Columns properties should also be populated.
	/// </summary>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public CreateIndexOperation(object anonymousArguments = null)
		: base(anonymousArguments)
	{
	}
}
