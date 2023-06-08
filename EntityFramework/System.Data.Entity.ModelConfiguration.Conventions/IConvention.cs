using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Identifies conventions that can be removed from a <see cref="T:System.Data.Entity.DbModelBuilder" /> instance.
/// </summary>
/// <remarks>
///     Note that implementations of this interface must be immutable.
/// </remarks>
[SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces")]
public interface IConvention
{
}
