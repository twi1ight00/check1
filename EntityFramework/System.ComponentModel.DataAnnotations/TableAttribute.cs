using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel.DataAnnotations;

/// <summary>
///     Specifies the database table that a class is mapped to.
/// </summary>
[SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes")]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class TableAttribute : Attribute
{
	private readonly string _name;

	private string _schema;

	/// <summary>
	///     The name of the table the class is mapped to.
	/// </summary>
	public string Name => _name;

	/// <summary>
	///     The schema of the table the class is mapped to.
	/// </summary>
	public string Schema
	{
		get
		{
			return _schema;
		}
		set
		{
			RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(value), null, "!string.IsNullOrWhiteSpace(value)");
			_schema = value;
		}
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.TableAttribute" /> class.
	/// </summary>
	/// <param name="name">The name of the table the class is mapped to.</param>
	public TableAttribute(string name)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(name), null, "!string.IsNullOrWhiteSpace(name)");
		base._002Ector();
		_name = name;
	}
}
