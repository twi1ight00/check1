using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Mappers;

internal sealed class PropertyFilter
{
	private const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	public IEnumerable<PropertyInfo> GetProperties(Type type, bool declaredOnly, IEnumerable<PropertyInfo> nonPublicProperties = null, IEnumerable<Type> knownTypes = null)
	{
		nonPublicProperties = nonPublicProperties ?? Enumerable.Empty<PropertyInfo>();
		knownTypes = knownTypes ?? Enumerable.Empty<Type>();
		BindingFlags bindingAttr = (declaredOnly ? (BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
		return from p in type.GetProperties(bindingAttr)
			where p.IsValidStructuralProperty()
			let m = p.GetGetMethod(nonPublic: true)
			where (m.IsPublic || nonPublicProperties.Contains(p) || knownTypes.Contains(p.PropertyType)) && (!declaredOnly || !type.BaseType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Any((PropertyInfo bp) => bp.Name == p.Name))
			select p;
	}
}
