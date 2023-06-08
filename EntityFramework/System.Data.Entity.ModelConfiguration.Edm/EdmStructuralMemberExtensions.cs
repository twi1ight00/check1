using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Edm;

internal static class EdmStructuralMemberExtensions
{
	public static PropertyInfo GetClrPropertyInfo(this EdmStructuralMember property)
	{
		return property.Annotations.GetClrPropertyInfo();
	}

	public static void SetClrPropertyInfo(this EdmStructuralMember property, PropertyInfo propertyInfo)
	{
		property.Annotations.SetClrPropertyInfo(propertyInfo);
	}

	public static IEnumerable<T> GetClrAttributes<T>(this EdmStructuralMember property) where T : Attribute
	{
		IList<Attribute> clrAttributes = property.Annotations.GetClrAttributes();
		if (clrAttributes == null)
		{
			return Enumerable.Empty<T>();
		}
		return clrAttributes.OfType<T>();
	}
}
