using System;
using ns175;

namespace ns200;

internal abstract class Class5470
{
	private static string string_0 = "mime";

	protected Class5738 class5738_0;

	public Class5470(Class5738 userAgent)
	{
		class5738_0 = userAgent;
	}

	protected Interface201 method_0(string mimeType)
	{
		Interface201 @interface = class5738_0.method_0().method_47();
		if (@interface == null)
		{
			return null;
		}
		Interface201 result = null;
		string text = vmethod_0();
		Interface201[] array = @interface.imethod_3(text + "s").imethod_6(text);
		foreach (Interface201 interface2 in array)
		{
			try
			{
				if (interface2.imethod_8(string_0).Equals(mimeType))
				{
					result = interface2;
					break;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		return result;
	}

	public abstract string vmethod_0();
}
