using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents creating a table.
/// </summary>
public class CreateTableOperation : MigrationOperation
{
	private readonly string _name;

	private readonly List<ColumnModel> _columns;

	private AddPrimaryKeyOperation _primaryKey;

	/// <summary>
	/// Gets the name of the table to be created.
	/// </summary>
	public virtual string Name => _name;

	/// <summary>
	/// Gets the columns to be included in the new table.
	/// </summary>
	public virtual ICollection<ColumnModel> Columns => _columns;

	/// <summary>
	/// Gets or sets the primary key for the new table.
	/// </summary>
	public AddPrimaryKeyOperation PrimaryKey
	{
		get
		{
			return _primaryKey;
		}
		set
		{
			RuntimeFailureMethods.Requires(value != null, null, "value != null");
			_primaryKey = value;
			_primaryKey.Table = Name;
		}
	}

	/// <summary>
	/// Gets an operation to drop the table.
	/// </summary>
	public override MigrationOperation Inverse => new DropTableOperation(Name);

	/// <inheritdoc />
	public override bool IsDestructiveChange => false;

	/// <summary>
	/// Initializes a new instance of the CreateTableOperation class.
	/// </summary>
	/// <param name="name">Name of the table to be created.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public CreateTableOperation(string name, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(name), null, "!string.IsNullOrWhiteSpace(name)");
		_columns = new List<ColumnModel>();
		base._002Ector(anonymousArguments);
		_name = name;
	}
}
