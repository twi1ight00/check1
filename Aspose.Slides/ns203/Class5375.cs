using System;
using System.Reflection;

namespace ns203;

internal class Class5375 : Interface178
{
	private object object_0;

	private Class5375(object obj)
	{
		object_0 = obj;
	}

	public static object smethod_0(object obj)
	{
		return Class5373.smethod_0().method_1(new Class5375(obj), obj.GetType());
	}

	public object Invoke(object proxy, MethodInfo method, object[] parameters)
	{
		object obj = null;
		string userRole = "role";
		if (!Class5374.smethod_0(userRole, method.Name))
		{
			throw new Exception("Invalid permission to invoke " + method.Name);
		}
		return method.Invoke(object_0, parameters);
	}
}
