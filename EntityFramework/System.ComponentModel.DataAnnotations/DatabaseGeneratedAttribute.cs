using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace System.ComponentModel.DataAnnotations;

/// <summary>
///     Specifies how the database generates values for a property.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
[SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes")]
public class DatabaseGeneratedAttribute : Attribute
{
	/// <summary>
	///     The pattern used to generate values for the property in the database.
	/// </summary>
	public DatabaseGeneratedOption DatabaseGeneratedOption { get; private set; }

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.DatabaseGeneratedAttribute" /> class.
	/// </summary>
	/// <param name="databaseGeneratedOption">The pattern used to generate values for the property in the database.</param>
	public DatabaseGeneratedAttribute(DatabaseGeneratedOption databaseGeneratedOption)
	{
		__ContractsRuntime.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(DatabaseGeneratedOption), databaseGeneratedOption), null, "Enum.IsDefined(typeof(DatabaseGeneratedOption), databaseGeneratedOption)");
		base._002Ector();
		DatabaseGeneratedOption = databaseGeneratedOption;
	}
}
