using System;
using System.ComponentModel;
using System.Reflection;

namespace ns22;

internal class Class507
{
	internal static object smethod_0(string[] string_0, object object_0)
	{
		if (object_0 is ICustomTypeDescriptor)
		{
			for (int i = 0; i < string_0.Length; i++)
			{
				object_0.GetType();
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(string_0[i]);
				if (properties != null)
				{
					PropertyDescriptor propertyDescriptor = properties[string_0[i]];
					if (propertyDescriptor != null)
					{
						object_0 = propertyDescriptor.GetValue(object_0);
					}
				}
			}
		}
		else
		{
			for (int j = 0; j < string_0.Length; j++)
			{
				Type type = object_0.GetType();
				PropertyInfo property = type.GetProperty(string_0[j]);
				if (property != null)
				{
					object_0 = property.GetValue(object_0, null);
				}
			}
		}
		return object_0;
	}
}
