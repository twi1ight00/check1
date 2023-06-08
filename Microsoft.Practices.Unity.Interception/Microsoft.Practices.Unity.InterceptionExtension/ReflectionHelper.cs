using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A collection of utility functions to encapsulate details of
/// reflection and finding attributes.
/// </summary>
public static class ReflectionHelper
{
	/// <summary>
	/// Given a MethodBase for a property's get or set method,
	/// return the corresponding property info.
	/// </summary>
	/// <param name="method">MethodBase for the property's get or set method.</param>
	/// <returns>PropertyInfo for the property, or null if method is not part of a property.</returns>
	public static PropertyInfo GetPropertyFromMethod(MethodBase method)
	{
		Guard.ArgumentNotNull(method, "method");
		if (method is MethodInfo method2)
		{
			return GetPropertyFromMethod(method2);
		}
		return null;
	}

	/// <summary>
	/// Given a MethodInfo for a property's get or set method,
	/// return the corresponding property info.
	/// </summary>
	/// <param name="method">MethodBase for the property's get or set method.</param>
	/// <returns>PropertyInfo for the property, or null if method is not part of a property.</returns>
	public static PropertyInfo GetPropertyFromMethod(MethodInfo method)
	{
		Guard.ArgumentNotNull(method, "method");
		PropertyInfo result = null;
		if (method.IsSpecialName)
		{
			Type declaringType = method.DeclaringType;
			if (declaringType != null)
			{
				bool flag = method.Name.StartsWith("get_", StringComparison.Ordinal);
				if (method.Name.StartsWith("set_", StringComparison.Ordinal) || flag)
				{
					string name = method.Name.Substring(4);
					GetPropertyTypes(method, flag, out var propertyType, out var indexerTypes);
					result = declaringType.GetProperty(name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public, null, propertyType, indexerTypes, null);
				}
			}
		}
		return result;
	}

	private static void GetPropertyTypes(MethodInfo method, bool isGetter, out Type propertyType, out Type[] indexerTypes)
	{
		ParameterInfo[] parameters = method.GetParameters();
		if (isGetter)
		{
			propertyType = method.ReturnType;
			indexerTypes = ((parameters.Length == 0) ? Type.EmptyTypes : parameters.Select((ParameterInfo pi) => pi.ParameterType).ToArray());
		}
		else
		{
			propertyType = parameters[parameters.Length - 1].ParameterType;
			indexerTypes = ((parameters.Length == 1) ? Type.EmptyTypes : (from pi in parameters.Take(parameters.Length - 1)
				select pi.ParameterType).ToArray());
		}
	}

	/// <summary>
	/// Given a particular MemberInfo, return the custom attributes of the
	/// given type on that member.
	/// </summary>
	/// <typeparam name="TAttribute">Type of attribute to retrieve.</typeparam>
	/// <param name="member">The member to look at.</param>
	/// <param name="inherits">True to include attributes inherited from base classes.</param>
	/// <returns>Array of found attributes.</returns>
	public static TAttribute[] GetAttributes<TAttribute>(MemberInfo member, bool inherits) where TAttribute : Attribute
	{
		object[] customAttributes = member.GetCustomAttributes(typeof(TAttribute), inherits);
		TAttribute[] attributes = new TAttribute[customAttributes.Length];
		int index = 0;
		Array.ForEach(customAttributes, delegate(object o)
		{
			attributes[index++] = (TAttribute)o;
		});
		return attributes;
	}

	/// <summary>
	/// Given a particular MemberInfo, find all the attributes that apply to this
	/// member. Specifically, it returns the attributes on the type, then (if it's a
	/// property accessor) on the property, then on the member itself.
	/// </summary>
	/// <typeparam name="TAttribute">Type of attribute to retrieve.</typeparam>
	/// <param name="member">The member to look at.</param>
	/// <param name="inherits">true to include attributes inherited from base classes.</param>
	/// <returns>Array of found attributes.</returns>
	public static TAttribute[] GetAllAttributes<TAttribute>(MemberInfo member, bool inherits) where TAttribute : Attribute
	{
		List<TAttribute> list = new List<TAttribute>();
		if (member.DeclaringType != null)
		{
			list.AddRange(GetAttributes<TAttribute>(member.DeclaringType, inherits));
			if (member is MethodInfo method)
			{
				PropertyInfo propertyFromMethod = GetPropertyFromMethod(method);
				if (propertyFromMethod != null)
				{
					list.AddRange(GetAttributes<TAttribute>(propertyFromMethod, inherits));
				}
			}
		}
		list.AddRange(GetAttributes<TAttribute>(member, inherits));
		return list.ToArray();
	}
}
