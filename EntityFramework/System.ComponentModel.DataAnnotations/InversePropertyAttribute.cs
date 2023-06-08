using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel.DataAnnotations;

/// <summary>
///     Specifies the inverse of a navigation property that represents the other end of the same relationship.
/// </summary>
[SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "We want users to be able to extend this class")]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
[SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments")]
public class InversePropertyAttribute : Attribute
{
	private readonly string _property;

	/// <summary>
	///     The navigation property representing the other end of the same relationship.
	/// </summary>
	public string Property => _property;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.InversePropertyAttribute" /> class.
	/// </summary>
	/// <param name="property">The navigation property representing the other end of the same relationship.</param>
	public InversePropertyAttribute(string property)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(property), null, "!string.IsNullOrWhiteSpace(property)");
		base._002Ector();
		_property = property;
	}
}
