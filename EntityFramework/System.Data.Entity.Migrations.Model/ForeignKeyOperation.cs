using System.Collections.Generic;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
///     Base class for changes that affect foreign key constraints.
/// </summary>
public abstract class ForeignKeyOperation : MigrationOperation
{
	private string _principalTable;

	private string _dependentTable;

	private readonly List<string> _dependentColumns = new List<string>();

	private string _name;

	/// <summary>
	///     Gets or sets the name of the table that the foreign key constraint targets.
	/// </summary>
	public string PrincipalTable
	{
		get
		{
			return _principalTable;
		}
		set
		{
			RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(value), null, "!string.IsNullOrWhiteSpace(value)");
			_principalTable = value;
		}
	}

	/// <summary>
	///     Gets or sets the name of the table that the foreign key columns exist in.
	/// </summary>
	public string DependentTable
	{
		get
		{
			return _dependentTable;
		}
		set
		{
			RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(value), null, "!string.IsNullOrWhiteSpace(value)");
			_dependentTable = value;
		}
	}

	/// <summary>
	///     The names of the foreign key column(s).
	/// </summary>
	public IList<string> DependentColumns => _dependentColumns;

	/// <summary>
	///     Gets a value indicating if a specific name has been supplied for this foreign key constraint.
	/// </summary>
	public bool HasDefaultName => string.Equals(Name, DefaultName, StringComparison.Ordinal);

	/// <summary>
	///     Gets or sets the name of this foreign key constraint.
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

	internal string DefaultName
	{
		get
		{
			string dependentTable = DependentTable;
			string principalTable = PrincipalTable;
			string separator = "_";
			return $"FK_{dependentTable}_{principalTable}_{DependentColumns.Join(null, separator)}".RestrictTo(128);
		}
	}

	/// <summary>
	///     Initializes a new instance of the ForeignKeyOperation class.
	/// </summary>
	/// <param name="anonymousArguments">
	///     Additional arguments that may be processed by providers. 
	///     Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	protected ForeignKeyOperation(object anonymousArguments = null)
		: base(anonymousArguments)
	{
	}
}
