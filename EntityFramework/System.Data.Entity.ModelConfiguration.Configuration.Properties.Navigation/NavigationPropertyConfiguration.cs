using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Entity.Resources;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;

internal class NavigationPropertyConfiguration : PropertyConfiguration
{
	private readonly PropertyInfo _navigationProperty;

	private EdmAssociationEndKind? _endKind;

	private PropertyInfo _inverseNavigationProperty;

	private EdmAssociationEndKind? _inverseEndKind;

	private ConstraintConfiguration _constraint;

	private AssociationMappingConfiguration _associationMappingConfiguration;

	public EdmOperationAction? DeleteAction { get; set; }

	internal PropertyInfo NavigationProperty => _navigationProperty;

	public EdmAssociationEndKind? EndKind
	{
		get
		{
			return _endKind;
		}
		set
		{
			_endKind = value;
		}
	}

	internal PropertyInfo InverseNavigationProperty
	{
		get
		{
			return _inverseNavigationProperty;
		}
		set
		{
			if (value == _navigationProperty)
			{
				throw Error.NavigationInverseItself(value.Name, value.ReflectedType);
			}
			_inverseNavigationProperty = value;
		}
	}

	internal EdmAssociationEndKind? InverseEndKind
	{
		get
		{
			return _inverseEndKind;
		}
		set
		{
			_inverseEndKind = value;
		}
	}

	public ConstraintConfiguration Constraint
	{
		get
		{
			return _constraint;
		}
		set
		{
			_constraint = value;
		}
	}

	/// <summary>
	///     True if the NavigationProperty's declaring type is the principal end, false if it is not, null if it is not known
	/// </summary>
	internal bool? IsNavigationPropertyDeclaringTypePrincipal { get; set; }

	internal AssociationMappingConfiguration AssociationMappingConfiguration
	{
		get
		{
			return _associationMappingConfiguration;
		}
		set
		{
			_associationMappingConfiguration = value;
		}
	}

	internal NavigationPropertyConfiguration(PropertyInfo navigationProperty)
	{
		_navigationProperty = navigationProperty;
	}

	private NavigationPropertyConfiguration(NavigationPropertyConfiguration source)
	{
		_navigationProperty = source._navigationProperty;
		_endKind = source._endKind;
		_inverseNavigationProperty = source._inverseNavigationProperty;
		_inverseEndKind = source._inverseEndKind;
		_constraint = ((source._constraint == null) ? null : source._constraint.Clone());
		_associationMappingConfiguration = ((source._associationMappingConfiguration == null) ? null : source._associationMappingConfiguration.Clone());
		DeleteAction = source.DeleteAction;
		IsNavigationPropertyDeclaringTypePrincipal = source.IsNavigationPropertyDeclaringTypePrincipal;
	}

	internal virtual NavigationPropertyConfiguration Clone()
	{
		return new NavigationPropertyConfiguration(this);
	}

	internal void Configure(EdmNavigationProperty navigationProperty, EdmModel model, EntityTypeConfiguration entityTypeConfiguration)
	{
		navigationProperty.SetConfiguration(this);
		EdmAssociationType association = navigationProperty.Association;
		NavigationPropertyConfiguration navigationPropertyConfiguration = association.GetConfiguration() as NavigationPropertyConfiguration;
		if (navigationPropertyConfiguration == null)
		{
			association.SetConfiguration(this);
		}
		else
		{
			ValidateConsistency(navigationPropertyConfiguration);
		}
		ConfigureInverse(association, model);
		ConfigureEndKinds(association, navigationPropertyConfiguration);
		ConfigureDependentBehavior(association, model, entityTypeConfiguration);
	}

	internal void Configure(DbDatabaseMapping databaseMapping)
	{
		if (AssociationMappingConfiguration == null)
		{
			return;
		}
		IEnumerable<DbAssociationSetMapping> associationSetMappings = databaseMapping.GetAssociationSetMappings();
		Func<DbAssociationSetMapping, bool> func = default(Func<DbAssociationSetMapping, bool>);
		if (func == null)
		{
			func = (DbAssociationSetMapping a) => a.GetConfiguration() == null && a.AssociationSet.ElementType.GetConfiguration() == this;
		}
		DbAssociationSetMapping dbAssociationSetMapping = associationSetMappings.Where(func).SingleOrDefault();
		if (dbAssociationSetMapping != null)
		{
			dbAssociationSetMapping.SetConfiguration(this);
			AssociationMappingConfiguration.Configure(dbAssociationSetMapping, databaseMapping.Database);
		}
	}

	private void ConfigureInverse(EdmAssociationType associationType, EdmModel model)
	{
		if (!(_inverseNavigationProperty == null))
		{
			EdmNavigationProperty navigationProperty = model.GetNavigationProperty(_inverseNavigationProperty);
			if (navigationProperty != null && navigationProperty.Association != associationType)
			{
				associationType.SourceEnd.EndKind = navigationProperty.Association.TargetEnd.EndKind;
				model.RemoveAssociationType(navigationProperty.Association);
				navigationProperty.Association = associationType;
				navigationProperty.ResultEnd = associationType.SourceEnd;
			}
		}
	}

	private void ConfigureEndKinds(EdmAssociationType associationType, NavigationPropertyConfiguration configuration)
	{
		EdmAssociationEnd edmAssociationEnd = associationType.SourceEnd;
		EdmAssociationEnd edmAssociationEnd2 = associationType.TargetEnd;
		if (configuration != null && configuration.InverseNavigationProperty != null)
		{
			edmAssociationEnd = associationType.TargetEnd;
			edmAssociationEnd2 = associationType.SourceEnd;
		}
		if (_inverseEndKind.HasValue)
		{
			edmAssociationEnd.EndKind = _inverseEndKind.Value;
		}
		if (_endKind.HasValue)
		{
			edmAssociationEnd2.EndKind = _endKind.Value;
		}
	}

	private void ValidateConsistency(NavigationPropertyConfiguration navigationPropertyConfiguration)
	{
		if (navigationPropertyConfiguration.InverseEndKind.HasValue && EndKind.HasValue && navigationPropertyConfiguration.InverseEndKind != EndKind)
		{
			throw Error.ConflictingMultiplicities(NavigationProperty.Name, NavigationProperty.ReflectedType);
		}
		if (navigationPropertyConfiguration.EndKind.HasValue && InverseEndKind.HasValue && navigationPropertyConfiguration.EndKind != InverseEndKind)
		{
			throw Error.ConflictingMultiplicities(InverseNavigationProperty.Name, InverseNavigationProperty.ReflectedType);
		}
		if (navigationPropertyConfiguration.DeleteAction.HasValue && DeleteAction.HasValue && navigationPropertyConfiguration.DeleteAction != DeleteAction)
		{
			throw Error.ConflictingCascadeDeleteOperation(NavigationProperty.Name, NavigationProperty.ReflectedType);
		}
		if (navigationPropertyConfiguration.Constraint != null && Constraint != null && !object.Equals(navigationPropertyConfiguration.Constraint, Constraint))
		{
			throw Error.ConflictingConstraint(NavigationProperty.Name, NavigationProperty.ReflectedType);
		}
		if (navigationPropertyConfiguration.IsNavigationPropertyDeclaringTypePrincipal.HasValue && IsNavigationPropertyDeclaringTypePrincipal.HasValue && navigationPropertyConfiguration.IsNavigationPropertyDeclaringTypePrincipal == IsNavigationPropertyDeclaringTypePrincipal)
		{
			throw Error.ConflictingConstraint(NavigationProperty.Name, NavigationProperty.ReflectedType);
		}
		if (navigationPropertyConfiguration.AssociationMappingConfiguration != null && AssociationMappingConfiguration != null && !object.Equals(navigationPropertyConfiguration.AssociationMappingConfiguration, AssociationMappingConfiguration))
		{
			throw Error.ConflictingMapping(NavigationProperty.Name, NavigationProperty.ReflectedType);
		}
	}

	private void ConfigureDependentBehavior(EdmAssociationType associationType, EdmModel model, EntityTypeConfiguration entityTypeConfiguration)
	{
		if (!associationType.TryGuessPrincipalAndDependentEnds(out var principalEnd, out var dependentEnd))
		{
			if (IsNavigationPropertyDeclaringTypePrincipal.HasValue)
			{
				associationType.MarkPrincipalConfigured();
				EdmNavigationProperty edmNavigationProperty = (from np in model.Namespaces.SelectMany((EdmNamespace ns) => ns.EntityTypes).SelectMany((EdmEntityType et) => et.DeclaredNavigationProperties)
					where np.GetClrPropertyInfo() == NavigationProperty
					select np).Single();
				principalEnd = (IsNavigationPropertyDeclaringTypePrincipal.Value ? associationType.GetOtherEnd(edmNavigationProperty.ResultEnd) : edmNavigationProperty.ResultEnd);
				dependentEnd = associationType.GetOtherEnd(principalEnd);
				if (associationType.SourceEnd != principalEnd)
				{
					associationType.SourceEnd = principalEnd;
					associationType.TargetEnd = dependentEnd;
					EdmAssociationSet edmAssociationSet = (from aset in model.Containers.SelectMany((EdmEntityContainer ct) => ct.AssociationSets)
						where aset.ElementType == associationType
						select aset).Single();
					EdmEntitySet sourceSet = edmAssociationSet.SourceSet;
					edmAssociationSet.SourceSet = edmAssociationSet.TargetSet;
					edmAssociationSet.TargetSet = sourceSet;
				}
			}
			if (principalEnd == null)
			{
				dependentEnd = associationType.TargetEnd;
			}
		}
		ConfigureConstraint(associationType, dependentEnd, entityTypeConfiguration);
		ConfigureDeleteAction(associationType, associationType.GetOtherEnd(dependentEnd));
	}

	private void ConfigureConstraint(EdmAssociationType associationType, EdmAssociationEnd dependentEnd, EntityTypeConfiguration entityTypeConfiguration)
	{
		if (_constraint != null)
		{
			_constraint.Configure(associationType, dependentEnd, entityTypeConfiguration);
			EdmAssociationConstraint constraint = associationType.Constraint;
			if (constraint != null && constraint.DependentProperties.SequenceEqual(constraint.DependentEnd.EntityType.DeclaredKeyProperties) && !_inverseEndKind.HasValue && associationType.SourceEnd.IsMany())
			{
				associationType.SourceEnd.EndKind = associationType.TargetEnd.EndKind;
				associationType.TargetEnd.EndKind = EdmAssociationEndKind.Required;
			}
		}
	}

	private void ConfigureDeleteAction(EdmAssociationType associationType, EdmAssociationEnd principalEnd)
	{
		if (DeleteAction.HasValue)
		{
			principalEnd.DeleteAction = DeleteAction.Value;
		}
	}

	internal void Reset()
	{
		_endKind = null;
		_inverseNavigationProperty = null;
		_inverseEndKind = null;
		_constraint = null;
		_associationMappingConfiguration = null;
	}
}
