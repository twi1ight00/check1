using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Utilities;

internal class AttributeProvider
{
	public virtual IEnumerable<Attribute> GetAttributes(MemberInfo memberInfo)
	{
		Type type = memberInfo as Type;
		if (type != null)
		{
			return GetAttributes(type);
		}
		return GetAttributes((PropertyInfo)memberInfo);
	}

	public virtual IEnumerable<Attribute> GetAttributes(Type type)
	{
		HashSet<Attribute> attrs = new HashSet<Attribute>(GetTypeDescriptor(type).GetAttributes().Cast<Attribute>());
		foreach (Attribute item in from Attribute a in type.GetCustomAttributes(inherit: true)
			where a.GetType().FullName.Equals("System.Data.Services.Common.EntityPropertyMappingAttribute", StringComparison.Ordinal) && !attrs.Contains(a)
			select a)
		{
			attrs.Add(item);
		}
		return attrs;
	}

	public virtual IEnumerable<Attribute> GetAttributes(PropertyInfo propertyInfo)
	{
		if (propertyInfo == null)
		{
			throw new ArgumentNullException("propertyInfo");
		}
		ICustomTypeDescriptor typeDescriptor = GetTypeDescriptor(propertyInfo.DeclaringType);
		PropertyDescriptorCollection properties = typeDescriptor.GetProperties();
		PropertyDescriptor propertyDescriptor = properties[propertyInfo.Name];
		IEnumerable<Attribute> first = ((propertyDescriptor != null) ? propertyDescriptor.Attributes.Cast<Attribute>() : propertyInfo.GetCustomAttributes(inherit: true).Cast<Attribute>());
		IEnumerable<Attribute> attributes = GetAttributes(propertyInfo.PropertyType);
		return first.Except(attributes);
	}

	private static ICustomTypeDescriptor GetTypeDescriptor(Type type)
	{
		return new AssociatedMetadataTypeTypeDescriptionProvider(type).GetTypeDescriptor(type);
	}
}
