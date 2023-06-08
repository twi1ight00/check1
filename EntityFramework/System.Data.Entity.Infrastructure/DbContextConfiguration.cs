using System.ComponentModel;
using System.Data.Entity.Internal;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Returned by the Configuration method of <see cref="T:System.Data.Entity.DbContext" /> to provide access to configuration
///     options for the context.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
public class DbContextConfiguration
{
	private readonly InternalContext _internalContext;

	/// <summary>
	///     Gets or sets a value indicating whether lazy loading of relationships exposed as
	///     navigation properties is enabled.  Lazy loading is enabled by default.
	/// </summary>
	/// <value><c>true</c> if lazy loading is enabled; otherwise, <c>false</c>.</value>
	public bool LazyLoadingEnabled
	{
		get
		{
			return _internalContext.LazyLoadingEnabled;
		}
		set
		{
			_internalContext.LazyLoadingEnabled = value;
		}
	}

	/// <summary>
	///     Gets or sets a value indicating whether or not the framework will create instances of
	///     dynamically generated proxy classes whenever it creates an instance of an entity type.
	///     Note that even if proxy creation is enabled with this flag, proxy instances will only
	///     be created for entity types that meet the requirements for being proxied.
	///     Proxy creation is enabled by default.
	/// </summary>
	/// <value><c>true</c> if proxy creation is enabled; otherwise, <c>false</c>.</value>
	public bool ProxyCreationEnabled
	{
		get
		{
			return _internalContext.ProxyCreationEnabled;
		}
		set
		{
			_internalContext.ProxyCreationEnabled = value;
		}
	}

	public bool AutoDetectChangesEnabled
	{
		get
		{
			return _internalContext.AutoDetectChangesEnabled;
		}
		set
		{
			_internalContext.AutoDetectChangesEnabled = value;
		}
	}

	/// <summary>
	///     Gets or sets a value indicating whether tracked entities should be validated automatically when
	///     <see cref="M:System.Data.Entity.DbContext.SaveChanges" /> is invoked.
	///     The default value is true.
	/// </summary>
	public bool ValidateOnSaveEnabled
	{
		get
		{
			return _internalContext.ValidateOnSaveEnabled;
		}
		set
		{
			_internalContext.ValidateOnSaveEnabled = value;
		}
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbContextConfiguration" /> class.
	/// </summary>
	/// <param name="internalContext">The internal context.</param>
	internal DbContextConfiguration(InternalContext internalContext)
	{
		_internalContext = internalContext;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString()
	{
		return base.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}
}
