using System.Data.Entity.Migrations.Extensions;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents adding a primary key to a table.
/// </summary>
public class AddPrimaryKeyOperation : PrimaryKeyOperation
{
	/// <summary>
	/// Gets an operation to drop the primary key.
	/// </summary>
	public override MigrationOperation Inverse
	{
		get
		{
			DropPrimaryKeyOperation dropPrimaryKeyOperation = new DropPrimaryKeyOperation
			{
				Name = base.Name,
				Table = base.Table
			};
			base.Columns.Each(delegate(string c)
			{
				dropPrimaryKeyOperation.Columns.Add(c);
			});
			return dropPrimaryKeyOperation;
		}
	}

	/// <summary>
	/// Initializes a new instance of the AddPrimaryKeyOperation class.
	/// The Table and Columns properties should also be populated.
	/// </summary>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public AddPrimaryKeyOperation(object anonymousArguments = null)
		: base(anonymousArguments)
	{
	}
}
