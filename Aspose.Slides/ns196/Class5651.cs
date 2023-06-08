using System;
using System.Collections;
using ns183;

namespace ns196;

internal class Class5651
{
	internal interface Interface228
	{
		void imethod_0(ArrayList elementList, string category, string id);
	}

	private static ArrayList arrayList_0;

	private Class5651()
	{
	}

	public static void smethod_0(Interface228 observer)
	{
		if (!smethod_3())
		{
			arrayList_0 = new ArrayList();
		}
		arrayList_0.Add(observer);
	}

	public static void smethod_1(Interface228 observer)
	{
		if (smethod_3())
		{
			arrayList_0.Remove(observer);
		}
	}

	public static void smethod_2(ArrayList elementList, string category, string id)
	{
		if (smethod_3())
		{
			if (category == null)
			{
				throw new NullReferenceException("category must not be null");
			}
			Interface208 @interface = new Class5495(arrayList_0);
			while (@interface.imethod_0())
			{
				((Interface228)@interface.imethod_1()).imethod_0(elementList, category, id);
			}
		}
	}

	public static bool smethod_3()
	{
		return arrayList_0 != null;
	}
}
