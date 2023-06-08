using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel.DataAnnotations;

/// <summary>
///     Denotes a property used as a foreign key in a relationship.
///     The annotation may be placed on the foreign key property and specify the associated navigation property name, 
///     or placed on a navigation property and specify the associated foreign key name.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
[SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "We want users to be able to extend this class")]
[SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments")]
public class ForeignKeyAttribute : Attribute
{
	private readonly string _name;

	/// <summary>
	///     If placed on a foreign key property, the name of the associated navigation property.
	///     If placed on a navigation property, the name of the associated foreign key(s).
	/// </summary>
	public string Name => _name;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ForeignKeyAttribute" /> class.
	/// </summary>
	/// <param name="name">
	///     If placed on a foreign key property, the name of the associated navigation property.
	///     If placed on a navigation property, the name of the associated foreign key(s).
	///     If a navigation property has multiple foreign keys, a comma separated list should be supplied.
	/// </param>
	public ForeignKeyAttribute(string name)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(name), null, "!string.IsNullOrWhiteSpace(name)");
		base._002Ector();
		_name = name;
	}
}
