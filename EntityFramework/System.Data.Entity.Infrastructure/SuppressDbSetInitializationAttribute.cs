using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     This attribute can be applied to either an entire derived <see cref="T:System.Data.Entity.DbContext" /> class or to
///     individual <see cref="T:System.Data.Entity.DbSet`1" /> or <see cref="T:System.Data.Entity.IDbSet`1" /> properties on that class.  When applied
///     any discovered <see cref="T:System.Data.Entity.DbSet`1" /> or <see cref="T:System.Data.Entity.IDbSet`1" /> properties will still be included
///     in the model but will not be automatically initialized.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
public sealed class SuppressDbSetInitializationAttribute : Attribute
{
}
