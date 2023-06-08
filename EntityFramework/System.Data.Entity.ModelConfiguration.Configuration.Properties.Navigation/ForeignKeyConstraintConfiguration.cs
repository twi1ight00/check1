using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;

internal class ForeignKeyConstraintConfiguration : ConstraintConfiguration
{
	private readonly List<PropertyInfo> _dependentProperties = new List<PropertyInfo>();

	private readonly bool _isFullySpecified;

	internal override bool IsFullySpecified => _isFullySpecified;

	internal IEnumerable<PropertyInfo> DependentProperties => _dependentProperties;

	internal ForeignKeyConstraintConfiguration()
	{
	}

	internal ForeignKeyConstraintConfiguration(IEnumerable<PropertyInfo> dependentProperties)
	{
		_dependentProperties.AddRange(dependentProperties);
		_isFullySpecified = true;
	}

	private ForeignKeyConstraintConfiguration(ForeignKeyConstraintConfiguration source)
	{
		_dependentProperties.AddRange(source._dependentProperties);
		_isFullySpecified = source._isFullySpecified;
	}

	internal override ConstraintConfiguration Clone()
	{
		return new ForeignKeyConstraintConfiguration(this);
	}

	internal void AddColumn(PropertyInfo propertyInfo)
	{
		if (!_dependentProperties.ContainsSame(propertyInfo))
		{
			_dependentProperties.Add(propertyInfo);
		}
	}

	internal override void Configure(EdmAssociationType associationType, EdmAssociationEnd dependentEnd, EntityTypeConfiguration entityTypeConfiguration)
	{
		if (!_dependentProperties.Any())
		{
			return;
		}
		EdmAssociationConstraint edmAssociationConstraint = new EdmAssociationConstraint();
		edmAssociationConstraint.DependentEnd = dependentEnd;
		EdmAssociationConstraint edmAssociationConstraint2 = edmAssociationConstraint;
		IEnumerable<PropertyInfo> enumerable = Enumerable.AsEnumerable(_dependentProperties);
		if (!IsFullySpecified)
		{
			var source = _dependentProperties.Select((PropertyInfo p) => new
			{
				PropertyInfo = p,
				ColumnOrder = entityTypeConfiguration.Property(new PropertyPath(p)).ColumnOrder
			});
			if (_dependentProperties.Count > 1 && source.Any(p => !p.ColumnOrder.HasValue))
			{
				IList<EdmProperty> dependentKeys = dependentEnd.EntityType.DeclaredKeyProperties;
				if (dependentKeys.Count != _dependentProperties.Count || !source.All(fk => dependentKeys.Any((EdmProperty p) => p.GetClrPropertyInfo().IsSameAs(fk.PropertyInfo))))
				{
					throw Error.ForeignKeyAttributeConvention_OrderRequired(entityTypeConfiguration.ClrType);
				}
				enumerable = dependentKeys.Select((EdmProperty p) => p.GetClrPropertyInfo());
			}
			else
			{
				enumerable = from p in source
					orderby p.ColumnOrder
					select p.PropertyInfo;
			}
		}
		foreach (PropertyInfo item in enumerable)
		{
			EdmProperty declaredPrimitiveProperty = edmAssociationConstraint2.DependentEnd.EntityType.GetDeclaredPrimitiveProperty(item);
			if (declaredPrimitiveProperty == null)
			{
				throw Error.ForeignKeyPropertyNotFound(item.Name, edmAssociationConstraint2.DependentEnd.EntityType.Name);
			}
			edmAssociationConstraint2.DependentProperties.Add(declaredPrimitiveProperty);
		}
		associationType.Constraint = edmAssociationConstraint2;
		EdmAssociationEnd otherEnd = associationType.GetOtherEnd(dependentEnd);
		if (otherEnd.IsRequired())
		{
			associationType.Constraint.DependentProperties.Each((EdmProperty p) => p.PropertyType.IsNullable = false);
		}
	}

	public bool Equals(ForeignKeyConstraintConfiguration other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		return other.DependentProperties.SequenceEqual(DependentProperties, new DynamicEqualityComparer<PropertyInfo>((PropertyInfo p1, PropertyInfo p2) => p1.IsSameAs(p2)));
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(ForeignKeyConstraintConfiguration))
		{
			return false;
		}
		return Equals((ForeignKeyConstraintConfiguration)obj);
	}

	public override int GetHashCode()
	{
		return DependentProperties.Aggregate(0, (int t, PropertyInfo p) => t + p.GetHashCode());
	}
}
