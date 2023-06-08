using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Configuration;

/// <summary>
///     Allows derived configuration classes for entities and complex types to be registered with a <see cref="T:System.Data.Entity.DbModelBuilder" />.
/// </summary>
/// <remarks>
///     Derived configuration classes are created by deriving from <see cref="T:System.Data.Entity.ModelConfiguration.Configuration.Types.EntityTypeConfiguration" />
///     or <see cref="T:System.Data.Entity.ModelConfiguration.Configuration.Types.ComplexTypeConfiguration" /> and using a type to be included in the model as the generic
///     parameter.
///
///     Configuration can be performed without creating derived configuration classes via the Entity and ComplexType
///     methods on <see cref="T:System.Data.Entity.DbModelBuilder" />.
/// </remarks>
public class ConfigurationRegistrar
{
	private readonly ModelConfiguration _modelConfiguration;

	internal ConfigurationRegistrar(ModelConfiguration modelConfiguration)
	{
		_modelConfiguration = modelConfiguration;
	}

	/// <summary>
	///     Adds an <see cref="T:System.Data.Entity.ModelConfiguration.Configuration.Types.EntityTypeConfiguration" /> to the <see cref="T:System.Data.Entity.DbModelBuilder" />.
	///     Only one <see cref="T:System.Data.Entity.ModelConfiguration.Configuration.Types.EntityTypeConfiguration" /> can be added for each type in a model.
	/// </summary>
	/// <typeparam name="TEntityType">The entity type being configured.</typeparam>
	/// <param name="entityTypeConfiguration">The entity type configuration to be added.</param>
	/// <returns>The same ConfigurationRegistrar instance so that multiple calls can be chained.</returns>
	public virtual ConfigurationRegistrar Add<TEntityType>(EntityTypeConfiguration<TEntityType> entityTypeConfiguration) where TEntityType : class
	{
		RuntimeFailureMethods.Requires(entityTypeConfiguration != null, null, "entityTypeConfiguration != null");
		_modelConfiguration.Add((EntityTypeConfiguration)entityTypeConfiguration.Configuration);
		return this;
	}

	/// <summary>
	///     Adds an <see cref="T:System.Data.Entity.ModelConfiguration.Configuration.Types.ComplexTypeConfiguration" /> to the <see cref="T:System.Data.Entity.DbModelBuilder" />.
	///     Only one <see cref="T:System.Data.Entity.ModelConfiguration.Configuration.Types.ComplexTypeConfiguration" /> can be added for each type in a model.
	/// </summary>
	/// <typeparam name="TComplexType">The complex type being configured.</typeparam>
	/// <param name="complexTypeConfiguration">The complex type configuration to be added</param>
	/// <returns>The same ConfigurationRegistrar instance so that multiple calls can be chained.</returns>
	public virtual ConfigurationRegistrar Add<TComplexType>(ComplexTypeConfiguration<TComplexType> complexTypeConfiguration) where TComplexType : class
	{
		RuntimeFailureMethods.Requires(complexTypeConfiguration != null, null, "complexTypeConfiguration != null");
		_modelConfiguration.Add((ComplexTypeConfiguration)complexTypeConfiguration.Configuration);
		return this;
	}

	internal virtual IEnumerable<Type> GetConfiguredTypes()
	{
		return _modelConfiguration.ConfiguredTypes.ToList();
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
