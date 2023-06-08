using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace System.ComponentModel.DataAnnotations;

/// <summary>
///     Specifies the database column that a property is mapped to.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
[SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes")]
public class ColumnAttribute : Attribute
{
	private readonly string _name;

	private string _typeName;

	private int _order;

	/// <summary>
	///     The name of the column the property is mapped to.
	/// </summary>
	public string Name => _name;

	/// <summary>
	///     The zero-based order of the column the property is mapped to.
	/// </summary>
	public int Order
	{
		get
		{
			return _order;
		}
		set
		{
			__ContractsRuntime.Requires<ArgumentOutOfRangeException>(value >= 0, null, "value >= 0");
			_order = value;
		}
	}

	/// <summary>
	///     The database provider specific data type of the column the property is mapped to.
	/// </summary>
	public string TypeName
	{
		get
		{
			return _typeName;
		}
		set
		{
			RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(value), null, "!string.IsNullOrWhiteSpace(value)");
			_typeName = value;
		}
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ColumnAttribute" /> class.
	/// </summary>
	public ColumnAttribute()
	{
		_order = -1;
		base._002Ector();
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ColumnAttribute" /> class.
	/// </summary>
	/// <param name="name">The name of the column the property is mapped to.</param>
	public ColumnAttribute(string name)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(name), null, "!string.IsNullOrWhiteSpace(name)");
		_order = -1;
		base._002Ector();
		_name = name;
	}
}
