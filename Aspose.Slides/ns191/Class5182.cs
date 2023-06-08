using System;
using System.Collections;
using ns171;
using ns183;

namespace ns191;

internal class Class5182 : Class5180
{
	public static string string_2;

	public static string string_3;

	public static string string_4;

	public static string string_5;

	private static ArrayList arrayList_0;

	static Class5182()
	{
		string_2 = "http://xmlgraphics.apache.org/fop/internal";
		string_3 = "foi";
		string_4 = "struct-id";
		string_5 = "struct-ref";
		arrayList_0 = new ArrayList();
		arrayList_0.Add(string_4);
		arrayList_0.Add(string_5);
	}

	public Class5182()
	{
		string_1 = string_2;
	}

	protected override void vmethod_2()
	{
		if (hashtable_0 == null)
		{
			hashtable_0 = new Hashtable();
		}
	}

	public override string vmethod_0()
	{
		return string_3;
	}

	public override bool vmethod_1(Class5619 attributeName)
	{
		if (!string_2.Equals(attributeName.method_0()))
		{
			throw new ArgumentException("The namespace URIs don't match");
		}
		return arrayList_0.Contains(attributeName.method_2());
	}
}
