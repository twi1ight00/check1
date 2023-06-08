using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;
using System.Linq;

namespace System.Data.Entity.Edm.Validation.Internal;

internal static class DataModelValidationHelper
{
	/// <summary>
	///     Returns true if the given two ends are similar - the relationship type that this ends belongs to is the same and the entity set refered by the ends are same and they are from the same role
	/// </summary>
	/// <param name="left"> </param>
	/// <param name="right"> </param>
	/// <returns> </returns>
	internal static bool AreRelationshipEndsEqual(KeyValuePair<EdmAssociationSet, EdmEntitySet> left, KeyValuePair<EdmAssociationSet, EdmEntitySet> right)
	{
		if (object.ReferenceEquals(left.Value, right.Value) && object.ReferenceEquals(left.Key.ElementType, right.Key.ElementType))
		{
			return true;
		}
		return false;
	}

	/// <summary>
	///     Return true if the Referential Constraint on the association is ready for further validation, otherwise return false.
	/// </summary>
	/// <param name="association"> </param>
	/// <returns> </returns>
	internal static bool IsReferentialConstraintReadyForValidation(EdmAssociationType association)
	{
		EdmAssociationConstraint constraint = association.Constraint;
		if (constraint == null)
		{
			return false;
		}
		if (constraint.PrincipalEnd(association) == null || constraint.DependentEnd == null)
		{
			return false;
		}
		if (constraint.PrincipalEnd(association).EntityType == null || constraint.DependentEnd.EntityType == null)
		{
			return false;
		}
		if (constraint.DependentProperties.Count() > 0)
		{
			foreach (EdmProperty dependentProperty in constraint.DependentProperties)
			{
				if (dependentProperty == null)
				{
					return false;
				}
				if (dependentProperty.PropertyType == null || dependentProperty.PropertyType.EdmType == null)
				{
					return false;
				}
			}
			IEnumerable<EdmProperty> validKey = constraint.PrincipalEnd(association).EntityType.GetValidKey();
			if (validKey.Count() > 0)
			{
				foreach (EdmProperty item in validKey)
				{
					if (item == null || item.PropertyType == null || item.PropertyType.EdmType == null)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		return false;
	}

	/// <summary>
	///     Resolves the given property names to the property in the item Also checks whether the properties form the key for the given type and whether all the properties are nullable or not
	/// </summary>
	/// <param name="roleProperties"> </param>
	/// <param name="roleElement"> </param>
	/// <param name="isKeyProperty"> </param>
	/// <param name="areAllPropertiesNullable"> </param>
	/// <param name="isAnyPropertyNullable"> </param>
	/// <param name="isSubsetOfKeyProperties"> </param>
	internal static void IsKeyProperty(List<EdmProperty> roleProperties, EdmAssociationEnd roleElement, out bool isKeyProperty, out bool areAllPropertiesNullable, out bool isAnyPropertyNullable, out bool isSubsetOfKeyProperties)
	{
		isKeyProperty = true;
		areAllPropertiesNullable = true;
		isAnyPropertyNullable = false;
		isSubsetOfKeyProperties = true;
		if (roleElement.EntityType.GetValidKey().Count() != roleProperties.Count())
		{
			isKeyProperty = false;
		}
		for (int i = 0; i < roleProperties.Count(); i++)
		{
			if (isSubsetOfKeyProperties)
			{
				bool flag = false;
				List<EdmProperty> list = roleElement.EntityType.GetValidKey().ToList();
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].Equals(roleProperties[i]))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					isKeyProperty = false;
					isSubsetOfKeyProperties = false;
				}
			}
			bool flag2 = true;
			if (roleProperties[i].PropertyType.IsNullable.HasValue)
			{
				flag2 = roleProperties[i].PropertyType.IsNullable.Value;
			}
			areAllPropertiesNullable &= flag2;
			isAnyPropertyNullable |= flag2;
		}
	}

	/// <summary>
	///     Return true if the namespaceName is a Edm System Namespace
	/// </summary>
	/// <param name="namespaceName"> </param>
	/// <returns> </returns>
	internal static bool IsEdmSystemNamespace(string namespaceName)
	{
		if (!(namespaceName == "Transient") && !(namespaceName == "Edm"))
		{
			return namespaceName == "System";
		}
		return true;
	}

	/// <summary>
	///     Return true if the entityType is a subtype of any entity type in the dictionary keys, and return the corresponding entry EntitySet value. Otherwise return false.
	/// </summary>
	/// <param name="entityType"> </param>
	/// <param name="baseEntitySetTypes"> </param>
	/// <param name="set"> </param>
	/// <returns> </returns>
	internal static bool TypeIsSubTypeOf(EdmEntityType entityType, Dictionary<EdmEntityType, EdmEntitySet> baseEntitySetTypes, out EdmEntitySet set)
	{
		if (entityType.IsTypeHierarchyRoot())
		{
			set = null;
			return false;
		}
		foreach (EdmEntityType item in entityType.ToHierarchy())
		{
			if (baseEntitySetTypes.ContainsKey(item))
			{
				set = baseEntitySetTypes[item];
				return true;
			}
		}
		set = null;
		return false;
	}

	/// <summary>
	///     Return true if any of the properties in the EdmEntityType defines ConcurrencyMode. Otherwise return false.
	/// </summary>
	/// <param name="entityType"> </param>
	/// <returns> </returns>
	internal static bool IsTypeDefinesNewConcurrencyProperties(EdmEntityType entityType)
	{
		foreach (EdmProperty declaredProperty in entityType.DeclaredProperties)
		{
			if (declaredProperty.PropertyType != null && declaredProperty.PropertyType.PrimitiveType != null && declaredProperty.ConcurrencyMode != 0)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	///     Add member name to the Hash set, raise an error if the name exists already.
	/// </summary>
	/// <param name="item"> </param>
	/// <param name="memberNameList"> </param>
	/// <param name="context"> </param>
	/// <param name="getErrorString"> </param>
	internal static void AddMemberNameToHashSet(EdmNamedMetadataItem item, HashSet<string> memberNameList, DataModelValidationContext context, Func<string, string> getErrorString)
	{
		if (item.Name.HasContent() && !memberNameList.Add(item.Name))
		{
			context.AddError(item, "Name", getErrorString(item.Name), 19);
		}
	}

	/// <summary>
	///     If the string is null, empty, or only whitespace, return false, otherwise return true
	/// </summary>
	/// <param name="stringToCheck"> </param>
	/// <returns> </returns>
	internal static bool HasContent(this string stringToCheck)
	{
		if (!string.IsNullOrWhiteSpace(stringToCheck))
		{
			return !string.IsNullOrEmpty(stringToCheck);
		}
		return false;
	}

	/// <summary>
	///     Determine if a cycle exists in the type hierarchy: use two pointers to walk the chain, if one catches up with the other, we have a cycle.
	/// </summary>
	/// <returns> true if a cycle exists in the type hierarchy, false otherwise </returns>
	internal static bool CheckForInheritanceCycle<T>(T type, Func<T, T> getBaseType) where T : class
	{
		T val = getBaseType(type);
		if (val != null)
		{
			T val2 = val;
			T val3 = val;
			do
			{
				val3 = getBaseType(val3);
				if (object.ReferenceEquals(val2, val3))
				{
					return true;
				}
				if (val2 == null)
				{
					return false;
				}
				val2 = getBaseType(val2);
				if (val3 != null)
				{
					val3 = getBaseType(val3);
				}
			}
			while (val3 != null);
		}
		return false;
	}

	internal static bool IsPrimitiveTypesEqual(EdmTypeReference primitiveType1, EdmTypeReference primitiveType2)
	{
		if (primitiveType1.PrimitiveType.PrimitiveTypeKind == primitiveType2.PrimitiveType.PrimitiveTypeKind)
		{
			return true;
		}
		return false;
	}

	internal static bool IsEdmTypeReferenceValid(EdmTypeReference typeReference)
	{
		HashSet<EdmTypeReference> visitedValidTypeReferences = new HashSet<EdmTypeReference>();
		return IsEdmTypeReferenceValid(typeReference, visitedValidTypeReferences);
	}

	private static bool IsEdmTypeReferenceValid(EdmTypeReference typeReference, HashSet<EdmTypeReference> visitedValidTypeReferences)
	{
		if (visitedValidTypeReferences.Contains(typeReference))
		{
			return false;
		}
		if (typeReference.EdmType == null)
		{
			return false;
		}
		visitedValidTypeReferences.Add(typeReference);
		return true;
	}
}
