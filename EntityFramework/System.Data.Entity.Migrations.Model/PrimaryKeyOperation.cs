using System.Collections.Generic;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
///     Common base class to represent operations affecting primary keys.
/// </summary>
public abstract class PrimaryKeyOperation : MigrationOperation
{
	private readonly List<string> _columns = new List<string>();

	private string _table;

	private string _name;

	/// <summary>
	///     Gets or sets the name of the table that contains the primary key.
	/// </summary>
	public string Table
	{
		get
		{
			return _table;
		}
		set
		{
			RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(value), null, "!string.IsNullOrWhiteSpace(value)");
			_table = value;
		}
	}

	/// <summary>
	///     Gets the column(s) that make up the primary key.
	/// </summary>
	public IList<string> Columns => _columns;

	/// <summary>
	///     Gets a value indicating if a specific name has been supplied for this primary key.
	/// </summary>
	public bool HasDefaultName => string.Equals(Name, DefaultName, StringComparison.Ordinal);

	/// <summary>
	///     Gets or sets the name of this primary key.
	///     If no name is supplied, a default name will be calculated.
	/// </summary>
	public string Name
	{
		get
		{
			return _name ?? DefaultName;
		}
		set
		{
			_name = value;
		}
	}

	/// <inheritdoc />
	public override bool IsDestructiveChange => false;

	internal string DefaultName => $"PK_{Table}".RestrictTo(128);

	/// <summary>
	///     Initializes a new instance of the PrimaryKeyOperation class.
	/// </summary>
	/// <param name="anonymousArguments">
	///     Additional arguments that may be processed by providers. 
	///     Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	protected PrimaryKeyOperation(object anonymousArguments = null)
		: base(anonymousArguments)
	{
	}
}
