using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace System.Data.Entity;

/// <summary>
///     This attribute can be applied to a class derived from <see cref="T:System.Data.Entity.DbContext" /> to set which
///     version of the DbContext and <see cref="T:System.Data.Entity.DbModelBuilder" /> conventions should be used when building
///     a model from code--also know as "Code First". See the <see cref="T:System.Data.Entity.DbModelBuilderVersion" />
///     enumeration for details about DbModelBuilder versions.
/// </summary>
/// <remarks>
///     If the attribute is missing from DbContextthen DbContext will always use the latest
///     version of the conventions.  This is equivalent to using DbModelBuilderVersion.Latest.
/// </remarks>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
public sealed class DbModelBuilderVersionAttribute : Attribute
{
	/// <summary>
	///     Gets the <see cref="T:System.Data.Entity.DbModelBuilder" /> conventions version.
	/// </summary>
	/// <value>The <see cref="T:System.Data.Entity.DbModelBuilder" /> conventions version.</value>
	public DbModelBuilderVersion Version { get; private set; }

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.DbModelBuilderVersionAttribute" /> class.
	/// </summary>
	/// <param name="version">The <see cref="T:System.Data.Entity.DbModelBuilder" /> conventions version to use.</param>
	public DbModelBuilderVersionAttribute(DbModelBuilderVersion version)
	{
		__ContractsRuntime.Requires<ArgumentException>(Enum.IsDefined(typeof(DbModelBuilderVersion), version), null, "Enum.IsDefined(typeof(DbModelBuilderVersion), version)");
		base._002Ector();
		Version = version;
	}
}
