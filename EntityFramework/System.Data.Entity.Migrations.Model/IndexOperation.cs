using System.Collections.Generic;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Common base class for operations affecting indexes. 
/// </summary>
public abstract class IndexOperation : MigrationOperation
{
	private string _table;

	private readonly List<string> _columns = new List<string>();

	private string _name;

	/// <summary>
	/// Gets or sets the table the index belongs to.
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
	/// Gets or sets the columns that are indexed.
	/// </summary>
	public IList<string> Columns => _columns;

	/// <summary>
	/// Gets a value indicating if a specific name has been supplied for this index.
	/// </summary>
	public bool HasDefaultName => string.Equals(Name, DefaultName, StringComparison.Ordinal);

	/// <summary>
	/// Gets or sets the name of this index.
	/// If no name is supplied, a default name will be calculated.
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
			string separator = "_";
			return $"IX_{Columns.Join(null, separator)}".RestrictTo(128);
		}
	}

	/// <summary>
	/// Initializes a new instance of the IndexOperation class.
	/// </summary>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	protected IndexOperation(object anonymousArguments = null)
		: base(anonymousArguments)
	{
	}
}
