using System.Security;

namespace ns187;

internal class Class5749
{
	private bool bool_0;

	public Class5749()
	{
		bool flag;
		try
		{
			flag = false;
		}
		catch (SecurityException)
		{
			flag = true;
		}
		bool_0 = flag;
	}

	public object method_0(object obj)
	{
		if (!bool_0)
		{
			return obj;
		}
		if (obj == null)
		{
			return null;
		}
		return null;
	}

	private static void smethod_0()
	{
	}

	private void method_1()
	{
	}
}
