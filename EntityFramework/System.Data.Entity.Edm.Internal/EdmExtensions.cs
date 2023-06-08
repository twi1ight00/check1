using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Linq;

namespace System.Data.Entity.Edm.Internal;

internal static class EdmExtensions
{
	internal static IEnumerable<EdmProperty> GetValidKey(this EdmEntityType entityType)
	{
		List<EdmProperty> list = null;
		foreach (EdmEntityType item in entityType.ToHierarchy().Reverse())
		{
			if (item.DeclaredKeyProperties.Count() <= 0)
			{
				continue;
			}
			if (list != null)
			{
				list = null;
				return Enumerable.Empty<EdmProperty>();
			}
			list = new List<EdmProperty>();
			HashSet<EdmProperty> hashSet = new HashSet<EdmProperty>();
			HashSet<string> hashSet2 = new HashSet<string>();
			HashSet<EdmProperty> hashSet3 = new HashSet<EdmProperty>(item.DeclaredProperties.Where((EdmProperty p) => p != null));
			foreach (EdmProperty declaredKeyProperty in item.DeclaredKeyProperties)
			{
				if (declaredKeyProperty != null && !hashSet.Contains(declaredKeyProperty) && hashSet3.Contains(declaredKeyProperty) && !string.IsNullOrEmpty(declaredKeyProperty.Name) && !string.IsNullOrWhiteSpace(declaredKeyProperty.Name) && !hashSet2.Contains(declaredKeyProperty.Name))
				{
					list.Add(declaredKeyProperty);
					hashSet.Add(declaredKeyProperty);
					hashSet2.Add(declaredKeyProperty.Name);
					continue;
				}
				return Enumerable.Empty<EdmProperty>();
			}
		}
		return list ?? Enumerable.Empty<EdmProperty>();
	}

	public static List<EdmProperty> GetKeyProperties(this EdmEntityType entityType)
	{
		HashSet<EdmEntityType> visitedTypes = new HashSet<EdmEntityType>();
		List<EdmProperty> list = new List<EdmProperty>();
		GetKeyProperties(visitedTypes, entityType, list);
		return list;
	}

	private static void GetKeyProperties(HashSet<EdmEntityType> visitedTypes, EdmEntityType visitingType, List<EdmProperty> keyProperties)
	{
		if (!visitedTypes.Contains(visitingType))
		{
			visitedTypes.Add(visitingType);
			if (visitingType.BaseType != null)
			{
				GetKeyProperties(visitedTypes, visitingType.BaseType, keyProperties);
			}
			else if (visitingType.DeclaredKeyProperties != null)
			{
				keyProperties.AddRange(visitingType.DeclaredKeyProperties);
			}
		}
	}

	internal static IEnumerable<EdmEntityType> ToHierarchy(this EdmEntityType edmType)
	{
		return SafeTraverseHierarchy(edmType);
	}

	internal static IEnumerable<EdmComplexType> ToHierarchy(this EdmComplexType edmType)
	{
		return SafeTraverseHierarchy(edmType);
	}

	private static IEnumerable<T> SafeTraverseHierarchy<T>(T startFrom) where T : EdmDataModelType
	{
		HashSet<T> visitedTypes = new HashSet<T>();
		T thisType = startFrom;
		while (thisType != null && !visitedTypes.Contains(thisType))
		{
			visitedTypes.Add(thisType);
			yield return thisType;
			thisType = thisType.BaseType as T;
		}
	}

	internal static EdmAssociationEnd GetFromEnd(this EdmNavigationProperty navProp)
	{
		if (navProp.Association.SourceEnd != navProp.ResultEnd)
		{
			return navProp.Association.SourceEnd;
		}
		return navProp.Association.TargetEnd;
	}

	internal static EdmAssociationEnd PrincipalEnd(this EdmAssociationConstraint constraint, EdmAssociationType association)
	{
		if (constraint.DependentEnd != association.SourceEnd)
		{
			return association.SourceEnd;
		}
		return association.TargetEnd;
	}

	internal static bool IsTypeHierarchyRoot(this EdmEntityType entityType)
	{
		return entityType.BaseType == null;
	}

	internal static string GetQualifiedName(this EdmNamedMetadataItem item, string qualifiedPrefix)
	{
		return qualifiedPrefix + "." + item.Name;
	}

	internal static bool IsForeignKey(this EdmAssociationType association, double version)
	{
		if (version >= DataModelVersions.Version2 && association.Constraint != null)
		{
			return true;
		}
		return false;
	}
}
