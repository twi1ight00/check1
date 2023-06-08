using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.Edm.Internal;
using System.Data.Entity.ModelConfiguration.Configuration.Properties;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration.Conventions.Sets;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Configuration;

/// <summary>
///     Allows the conventions used by a <see cref="T:System.Data.Entity.DbModelBuilder" /> instance to be customized.
///     Currently removal of one or more default conventions is the only supported operation.
///     The default conventions can be found in the System.Data.Entity.Conventions namespace.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
public class ConventionsConfiguration
{
	private class EdmConventionDispatcher : EdmModelVisitor
	{
		private readonly IConvention _convention;

		private readonly EdmModel _model;

		public EdmConventionDispatcher(IConvention convention, EdmModel model)
		{
			_convention = convention;
			_model = model;
		}

		public void Dispatch()
		{
			VisitEdmModel(_model);
		}

		private void Dispatch<TEdmDataModelItem>(TEdmDataModelItem item) where TEdmDataModelItem : EdmDataModelItem
		{
			if (_convention is IEdmConvention<TEdmDataModelItem> edmConvention)
			{
				edmConvention.Apply(item, _model);
			}
		}

		protected override void VisitEdmModel(EdmModel item)
		{
			if (_convention is IEdmConvention edmConvention)
			{
				edmConvention.Apply(item);
			}
			base.VisitEdmModel(item);
		}

		protected override void VisitEdmNavigationProperty(EdmNavigationProperty item)
		{
			Dispatch(item);
			base.VisitEdmNavigationProperty(item);
		}

		protected override void VisitEdmAssociationConstraint(EdmAssociationConstraint item)
		{
			Dispatch(item);
			if (item != null)
			{
				VisitEdmMetadataItem(item);
			}
		}

		protected override void VisitEdmAssociationEnd(EdmAssociationEnd item)
		{
			Dispatch(item);
			base.VisitEdmAssociationEnd(item);
		}

		protected override void VisitEdmProperty(EdmProperty item)
		{
			Dispatch(item);
			base.VisitEdmProperty(item);
		}

		protected override void VisitEdmDataModelItem(EdmDataModelItem item)
		{
			Dispatch(item);
			base.VisitEdmDataModelItem(item);
		}

		protected override void VisitEdmMetadataItem(EdmMetadataItem item)
		{
			Dispatch(item);
			base.VisitEdmMetadataItem(item);
		}

		protected override void VisitEdmNamedMetadataItem(EdmNamedMetadataItem item)
		{
			Dispatch(item);
			base.VisitEdmNamedMetadataItem(item);
		}

		protected override void VisitEdmNamespaceItem(EdmNamespaceItem item)
		{
			Dispatch(item);
			base.VisitEdmNamespaceItem(item);
		}

		protected override void VisitEdmEntityContainer(EdmEntityContainer item)
		{
			Dispatch(item);
			base.VisitEdmEntityContainer(item);
		}

		protected override void VisitEdmEntitySet(EdmEntitySet item)
		{
			Dispatch(item);
			base.VisitEdmEntitySet(item);
		}

		protected override void VisitEdmAssociationSet(EdmAssociationSet item)
		{
			Dispatch(item);
			base.VisitEdmAssociationSet(item);
		}

		protected override void VisitEdmAssociationSetEnd(EdmEntitySet item)
		{
			Dispatch(item);
			base.VisitEdmAssociationSetEnd(item);
		}

		protected override void VisitEdmNamespace(EdmNamespace item)
		{
			Dispatch(item);
			base.VisitEdmNamespace(item);
		}

		protected override void VisitComplexType(EdmComplexType item)
		{
			Dispatch(item);
			base.VisitComplexType(item);
		}

		protected override void VisitEdmEntityType(EdmEntityType item)
		{
			Dispatch(item);
			VisitEdmNamedMetadataItem(item);
			if (item != null)
			{
				VisitDeclaredProperties(item, item.DeclaredProperties);
				VisitDeclaredNavigationProperties(item, item.DeclaredNavigationProperties);
			}
		}

		protected override void VisitEdmAssociationType(EdmAssociationType item)
		{
			Dispatch(item);
			base.VisitEdmAssociationType(item);
		}
	}

	private class DatabaseConventionDispatcher : DbDatabaseVisitor
	{
		private readonly IConvention _convention;

		private readonly DbDatabaseMetadata _database;

		public DatabaseConventionDispatcher(IConvention convention, DbDatabaseMetadata database)
		{
			_convention = convention;
			_database = database;
		}

		public void Dispatch()
		{
			VisitDbDatabaseMetadata(_database);
		}

		private void Dispatch<TDbDataModelItem>(TDbDataModelItem item) where TDbDataModelItem : DbDataModelItem
		{
			if (_convention is IDbConvention<TDbDataModelItem> dbConvention)
			{
				dbConvention.Apply(item, _database);
			}
		}

		protected override void VisitDbDatabaseMetadata(DbDatabaseMetadata item)
		{
			if (_convention is IDbConvention dbConvention)
			{
				dbConvention.Apply(item);
			}
			base.VisitDbDatabaseMetadata(item);
		}

		protected override void VisitDbSchemaMetadata(DbSchemaMetadata item)
		{
			Dispatch(item);
			base.VisitDbSchemaMetadata(item);
		}

		protected override void VisitDbAliasedMetadataItem(DbAliasedMetadataItem item)
		{
			Dispatch(item);
			base.VisitDbAliasedMetadataItem(item);
		}

		protected override void VisitDbNamedMetadataItem(DbNamedMetadataItem item)
		{
			Dispatch(item);
			base.VisitDbNamedMetadataItem(item);
		}

		protected override void VisitDbMetadataItem(DbMetadataItem item)
		{
			Dispatch(item);
			base.VisitDbMetadataItem(item);
		}

		protected override void VisitDbDataModelItem(DbDataModelItem item)
		{
			Dispatch(item);
			base.VisitDbDataModelItem(item);
		}

		protected override void VisitDbTableMetadata(DbTableMetadata item)
		{
			Dispatch(item);
			base.VisitDbTableMetadata(item);
		}

		protected override void VisitDbTypeMetadata(DbTypeMetadata item)
		{
			Dispatch(item);
			base.VisitDbTypeMetadata(item);
		}

		protected override void VisitDbTableColumnMetadata(DbTableColumnMetadata item)
		{
			Dispatch(item);
			base.VisitDbTableColumnMetadata(item);
		}

		protected override void VisitDbForeignKeyConstraintMetadata(DbForeignKeyConstraintMetadata item)
		{
			Dispatch(item);
		}

		protected override void VisitDbConstraintMetadata(DbConstraintMetadata item)
		{
			Dispatch(item);
			base.VisitDbConstraintMetadata(item);
		}
	}

	private class PropertyConfigurationConventionDispatcher
	{
		private readonly IConvention _convention;

		private readonly Type _propertyConfigurationType;

		private readonly PropertyInfo _propertyInfo;

		private readonly Func<PropertyConfiguration> _propertyConfiguration;

		public PropertyConfigurationConventionDispatcher(IConvention convention, Type propertyConfigurationType, PropertyInfo propertyInfo, Func<PropertyConfiguration> propertyConfiguration)
		{
			_convention = convention;
			_propertyConfigurationType = propertyConfigurationType;
			_propertyInfo = propertyInfo;
			_propertyConfiguration = propertyConfiguration;
		}

		public void Dispatch()
		{
			Dispatch<PropertyConfiguration>();
			Dispatch<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration>();
			Dispatch<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.LengthPropertyConfiguration>();
			Dispatch<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.DateTimePropertyConfiguration>();
			Dispatch<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.DecimalPropertyConfiguration>();
			Dispatch<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.StringPropertyConfiguration>();
			Dispatch<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.BinaryPropertyConfiguration>();
			Dispatch<NavigationPropertyConfiguration>();
		}

		private void Dispatch<TPropertyConfiguration>() where TPropertyConfiguration : PropertyConfiguration
		{
			if (_convention is IConfigurationConvention<PropertyInfo, TPropertyConfiguration> configurationConvention && typeof(TPropertyConfiguration).IsAssignableFrom(_propertyConfigurationType))
			{
				configurationConvention.Apply(_propertyInfo, () => (TPropertyConfiguration)_propertyConfiguration());
			}
		}
	}

	private readonly List<IConvention> _conventions = new List<IConvention>();

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	internal IEnumerable<IConvention> Conventions => _conventions;

	internal ConventionsConfiguration()
		: this(V1ConventionSet.Conventions)
	{
	}

	internal ConventionsConfiguration(IEnumerable<IConvention> conventionSet)
	{
		_conventions.AddRange(conventionSet);
	}

	private ConventionsConfiguration(ConventionsConfiguration source)
	{
		_conventions.AddRange(source._conventions);
	}

	internal virtual ConventionsConfiguration Clone()
	{
		return new ConventionsConfiguration(this);
	}

	internal void Add(params IConvention[] conventions)
	{
		conventions.Each(delegate(IConvention c)
		{
			_conventions.Add(c);
		});
	}

	internal void Add<TConvention>() where TConvention : IConvention, new()
	{
		Add(new TConvention());
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	internal void AddAfter<TExistingConvention>(IConvention newConvention) where TExistingConvention : IConvention
	{
		int index = 0;
		_conventions.Each(delegate(IConvention c)
		{
			if (!(c.GetType() == typeof(TExistingConvention)))
			{
				index++;
			}
		});
		if (index < _conventions.Count)
		{
			_conventions.Insert(index + 1, newConvention);
			return;
		}
		throw Error.ConventionNotFound(newConvention.GetType(), typeof(TExistingConvention));
	}

	/// <summary>
	///     Disables a convention for the <see cref="T:System.Data.Entity.DbModelBuilder" />.
	///     The default conventions that are available for removal can be found in the System.Data.Entity.Conventions namespace.
	/// </summary>
	/// <typeparam name="TConvention">The type of the convention to be disabled.</typeparam>
	public void Remove<TConvention>() where TConvention : IConvention
	{
		_conventions.RemoveAll((IConvention c) => c.GetType() == typeof(TConvention));
	}

	internal void ApplyModel(EdmModel model)
	{
		foreach (IConvention convention in _conventions)
		{
			new EdmConventionDispatcher(convention, model).Dispatch();
		}
	}

	internal void ApplyDatabase(DbDatabaseMetadata database)
	{
		foreach (IConvention convention in _conventions)
		{
			new DatabaseConventionDispatcher(convention, database).Dispatch();
		}
	}

	internal void ApplyMapping(DbDatabaseMapping databaseMapping)
	{
		foreach (IConvention convention in _conventions)
		{
			if (convention is IDbMappingConvention dbMappingConvention)
			{
				dbMappingConvention.Apply(databaseMapping);
			}
		}
	}

	internal void ApplyModelConfiguration(ModelConfiguration modelConfiguration)
	{
		foreach (IConfigurationConvention item in _conventions.OfType<IConfigurationConvention>())
		{
			item.Apply(modelConfiguration);
		}
	}

	internal void ApplyModelConfiguration(Type type, ModelConfiguration modelConfiguration)
	{
		foreach (IConfigurationConvention<Type, ModelConfiguration> item in _conventions.OfType<IConfigurationConvention<Type, ModelConfiguration>>())
		{
			item.Apply(type, () => modelConfiguration);
		}
	}

	internal void ApplyTypeConfiguration<TStructuralTypeConfiguration>(Type type, Func<TStructuralTypeConfiguration> structuralTypeConfiguration) where TStructuralTypeConfiguration : StructuralTypeConfiguration
	{
		foreach (IConvention convention in _conventions)
		{
			if (convention is IConfigurationConvention<Type, TStructuralTypeConfiguration> configurationConvention)
			{
				configurationConvention.Apply(type, structuralTypeConfiguration);
			}
			if (convention is IConfigurationConvention<Type, StructuralTypeConfiguration> configurationConvention2)
			{
				configurationConvention2.Apply(type, structuralTypeConfiguration);
			}
		}
	}

	internal void ApplyPropertyConfiguration(PropertyInfo propertyInfo, ModelConfiguration modelConfiguration)
	{
		foreach (IConfigurationConvention<PropertyInfo, ModelConfiguration> item in _conventions.OfType<IConfigurationConvention<PropertyInfo, ModelConfiguration>>())
		{
			item.Apply(propertyInfo, () => modelConfiguration);
		}
	}

	internal void ApplyPropertyConfiguration(PropertyInfo propertyInfo, Func<PropertyConfiguration> propertyConfiguration)
	{
		Type propertyConfigurationType = StructuralTypeConfiguration.GetPropertyConfigurationType(propertyInfo.PropertyType);
		foreach (IConvention convention in _conventions)
		{
			new PropertyConfigurationConventionDispatcher(convention, propertyConfigurationType, propertyInfo, propertyConfiguration).Dispatch();
		}
	}

	internal void ApplyPropertyTypeConfiguration<TStructuralTypeConfiguration>(PropertyInfo propertyInfo, Func<TStructuralTypeConfiguration> structuralTypeConfiguration) where TStructuralTypeConfiguration : StructuralTypeConfiguration
	{
		foreach (IConvention convention in _conventions)
		{
			if (convention is IConfigurationConvention<PropertyInfo, TStructuralTypeConfiguration> configurationConvention)
			{
				configurationConvention.Apply(propertyInfo, structuralTypeConfiguration);
			}
			if (convention is IConfigurationConvention<PropertyInfo, StructuralTypeConfiguration> configurationConvention2)
			{
				configurationConvention2.Apply(propertyInfo, structuralTypeConfiguration);
			}
		}
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
