using System.Data.Objects;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Interface implemented by objects that can provide an <see cref="P:System.Data.Entity.Infrastructure.IObjectContextAdapter.ObjectContext" /> instance.
///     The <see cref="T:System.Data.Entity.DbContext" /> class implements this interface to provide access to the underlying
///     ObjectContext.
/// </summary>
public interface IObjectContextAdapter
{
	/// <summary>
	///     Gets the object context.
	/// </summary>
	/// <value>The object context.</value>
	ObjectContext ObjectContext { get; }
}
