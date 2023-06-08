using System.Data.Entity.Internal;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Instances of this class are returned from the ComplexProperty method of
///     <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> and allow access to the state of a complex property.
/// </summary>
/// <typeparam name="TEntity">The type of the entity to which this property belongs.</typeparam>
/// <typeparam name="TComplexProperty">The type of the property.</typeparam>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbComplexPropertyEntry<TEntity, TComplexProperty> : DbPropertyEntry<TEntity, TComplexProperty> where TEntity : class
{
	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbComplexPropertyEntry" /> from information in the given <see cref="T:System.Data.Entity.Internal.InternalPropertyEntry" />.
	///     Use this method in preference to the constructor since it may potentially create a subclass depending on
	///     the type of member represented by the InternalCollectionEntry instance.
	/// </summary>
	/// <param name="internalPropertyEntry">The internal property entry.</param>
	/// <returns>The new entry.</returns>
	internal new static DbComplexPropertyEntry<TEntity, TComplexProperty> Create(InternalPropertyEntry internalPropertyEntry)
	{
		return (DbComplexPropertyEntry<TEntity, TComplexProperty>)internalPropertyEntry.CreateDbMemberEntry<TEntity, TComplexProperty>();
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbComplexPropertyEntry`2" /> class.
	/// </summary>
	/// <param name="internalPropertyEntry">The internal entry.</param>
	internal DbComplexPropertyEntry(InternalPropertyEntry internalPropertyEntry)
		: base(internalPropertyEntry)
	{
	}

	/// <summary>
	///     Returns a new instance of the non-generic <see cref="T:System.Data.Entity.Infrastructure.DbComplexPropertyEntry" /> class for 
	///     the property represented by this object.
	/// </summary>
	/// <returns>A non-generic version.</returns>
	[SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Intentionally just implicit to reduce API clutter.")]
	public static implicit operator DbComplexPropertyEntry(DbComplexPropertyEntry<TEntity, TComplexProperty> entry)
	{
		return DbComplexPropertyEntry.Create(entry.InternalPropertyEntry);
	}

	/// <summary>
	///     Gets an object that represents a nested property of this property.
	///     This method can be used for both scalar or complex properties.
	/// </summary>
	/// <param name="propertyName">The name of the nested property.</param>
	/// <returns>An object representing the nested property.</returns>
	public DbPropertyEntry Property(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		return DbPropertyEntry.Create(base.InternalPropertyEntry.Property(propertyName));
	}

	/// <summary>
	///     Gets an object that represents a nested property of this property.
	///     This method can be used for both scalar or complex properties.
	/// </summary>
	/// <typeparam name="TNestedProperty">The type of the nested property.</typeparam>
	/// <param name="propertyName">The name of the nested property.</param>
	/// <returns>An object representing the nested property.</returns>
	public DbPropertyEntry<TEntity, TNestedProperty> Property<TNestedProperty>(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		return DbPropertyEntry<TEntity, TNestedProperty>.Create(base.InternalPropertyEntry.Property(propertyName, typeof(TNestedProperty)));
	}

	/// <summary>
	///     Gets an object that represents a nested property of this property.
	///     This method can be used for both scalar or complex properties.
	/// </summary>
	/// <typeparam name="TNestedProperty">The type of the nested property.</typeparam>
	/// <param name="navigationProperty">An expression representing the nested property.</param>
	/// <returns>An object representing the nested property.</returns>
	[SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "0#", Justification = "Rule predates more fluent naming conventions.")]
	public DbPropertyEntry<TEntity, TNestedProperty> Property<TNestedProperty>(Expression<Func<TComplexProperty, TNestedProperty>> property)
	{
		RuntimeFailureMethods.Requires(property != null, null, "property != null");
		return Property<TNestedProperty>(DbHelpers.ParsePropertySelector(property, "Property", "property"));
	}

	/// <summary>
	///     Gets an object that represents a nested complex property of this property.
	/// </summary>
	/// <param name="propertyName">The name of the nested property.</param>
	/// <returns>An object representing the nested property.</returns>
	public DbComplexPropertyEntry ComplexProperty(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		InternalPropertyEntry internalPropertyEntry = base.InternalPropertyEntry;
		bool requireComplex = true;
		return DbComplexPropertyEntry.Create(internalPropertyEntry.Property(propertyName, null, requireComplex));
	}

	/// <summary>
	///     Gets an object that represents a nested complex property of this property.
	/// </summary>
	/// <typeparam name="TNestedComplexProperty">The type of the nested property.</typeparam>
	/// <param name="propertyName">The name of the nested property.</param>
	/// <returns>An object representing the nested property.</returns>
	public DbComplexPropertyEntry<TEntity, TNestedComplexProperty> ComplexProperty<TNestedComplexProperty>(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		InternalPropertyEntry internalPropertyEntry = base.InternalPropertyEntry;
		bool requireComplex = true;
		return DbComplexPropertyEntry<TEntity, TNestedComplexProperty>.Create(internalPropertyEntry.Property(propertyName, typeof(TNestedComplexProperty), requireComplex));
	}

	/// <summary>
	///     Gets an object that represents a nested complex property of this property.
	/// </summary>
	/// <typeparam name="TNestedComplexProperty">The type of the nested property.</typeparam>
	/// <param name="navigationProperty">An expression representing the nested property.</param>
	/// <returns>An object representing the nested property.</returns>
	[SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "0#", Justification = "Rule predates more fluent naming conventions.")]
	public DbComplexPropertyEntry<TEntity, TNestedComplexProperty> ComplexProperty<TNestedComplexProperty>(Expression<Func<TComplexProperty, TNestedComplexProperty>> property)
	{
		RuntimeFailureMethods.Requires(property != null, null, "property != null");
		return ComplexProperty<TNestedComplexProperty>(DbHelpers.ParsePropertySelector(property, "Property", "property"));
	}
}
/// <summary>
///     A non-generic version of the <see cref="T:System.Data.Entity.Infrastructure.DbComplexPropertyEntry`2" /> class.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbComplexPropertyEntry : DbPropertyEntry
{
	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbComplexPropertyEntry`2" /> from information in the given <see cref="T:System.Data.Entity.Internal.InternalPropertyEntry" />.
	///     Use this method in preference to the constructor since it may potentially create a subclass depending on
	///     the type of member represented by the InternalCollectionEntry instance.
	/// </summary>
	/// <param name="internalPropertyEntry">The internal property entry.</param>
	/// <returns>The new entry.</returns>
	internal new static DbComplexPropertyEntry Create(InternalPropertyEntry internalPropertyEntry)
	{
		return (DbComplexPropertyEntry)internalPropertyEntry.CreateDbMemberEntry();
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry" /> class.
	/// </summary>
	/// <param name="internalPropertyEntry">The internal entry.</param>
	internal DbComplexPropertyEntry(InternalPropertyEntry internalPropertyEntry)
		: base(internalPropertyEntry)
	{
	}

	/// <summary>
	///     Gets an object that represents a nested property of this property.
	///     This method can be used for both scalar or complex properties.
	/// </summary>
	/// <param name="propertyName">The name of the nested property.</param>
	/// <returns>An object representing the nested property.</returns>
	public DbPropertyEntry Property(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		return DbPropertyEntry.Create(((InternalPropertyEntry)InternalMemberEntry).Property(propertyName));
	}

	/// <summary>
	///     Gets an object that represents a nested complex property of this property.
	/// </summary>
	/// <param name="propertyName">The name of the nested property.</param>
	/// <returns>An object representing the nested property.</returns>
	[SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "0#", Justification = "Rule predates more fluent naming conventions.")]
	public DbComplexPropertyEntry ComplexProperty(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		InternalPropertyEntry obj = (InternalPropertyEntry)InternalMemberEntry;
		bool requireComplex = true;
		return Create(obj.Property(propertyName, null, requireComplex));
	}

	/// <summary>
	///     Returns the equivalent generic <see cref="T:System.Data.Entity.Infrastructure.DbComplexPropertyEntry`2" /> object.
	/// </summary>
	/// <typeparam name="TEntity">The type of entity on which the member is declared.</typeparam>
	/// <typeparam name="TComplexProperty">The type of the complex property.</typeparam>
	/// <returns>The equivalent generic object.</returns>
	public new DbComplexPropertyEntry<TEntity, TComplexProperty> Cast<TEntity, TComplexProperty>() where TEntity : class
	{
		MemberEntryMetadata entryMetadata = InternalMemberEntry.EntryMetadata;
		if (!typeof(TEntity).IsAssignableFrom(entryMetadata.DeclaringType) || !typeof(TComplexProperty).IsAssignableFrom(entryMetadata.ElementType))
		{
			throw Error.DbMember_BadTypeForCast(typeof(DbComplexPropertyEntry).Name, typeof(TEntity).Name, typeof(TComplexProperty).Name, entryMetadata.DeclaringType.Name, entryMetadata.MemberType.Name);
		}
		return DbComplexPropertyEntry<TEntity, TComplexProperty>.Create((InternalPropertyEntry)InternalMemberEntry);
	}
}
