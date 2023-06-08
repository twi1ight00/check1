using System;
using System.Collections;
using ns171;
using ns183;
using ns188;

namespace ns191;

internal class Class5183 : Class5180
{
	private class Class5188 : Class5185
	{
		public override Class5088 vmethod_0(Class5088 parent)
		{
			return new Class5093(parent);
		}
	}

	private class Class5189 : Class5185
	{
		public override Class5088 vmethod_0(Class5088 parent)
		{
			return new Class5126(parent);
		}
	}

	public const string string_2 = "http://xmlgraphics.apache.org/fop/extensions";

	public static string string_3;

	private static ArrayList arrayList_0;

	static Class5183()
	{
		string_3 = "fox";
		arrayList_0 = new ArrayList();
		arrayList_0.Add("block-progression-unit");
		arrayList_0.Add("widow-content-limit");
		arrayList_0.Add("orphan-content-limit");
		arrayList_0.Add("internal-destination");
		arrayList_0.Add("disable-column-balancing");
		arrayList_0.Add("alt-text");
	}

	public Class5183()
	{
		string_1 = "http://xmlgraphics.apache.org/fop/extensions";
	}

	protected override void vmethod_2()
	{
		if (hashtable_0 == null)
		{
			hashtable_0 = new Hashtable();
			hashtable_0.Add("outline", new Class5092.Class5190("http://xmlgraphics.apache.org/fop/extensions"));
			hashtable_0.Add("label", new Class5092.Class5190("http://xmlgraphics.apache.org/fop/extensions"));
			hashtable_0.Add("destination", new Class5188());
			hashtable_0.Add("external-document", new Class5189());
		}
	}

	public override string vmethod_0()
	{
		return string_3;
	}

	public override bool vmethod_1(Class5619 attributeName)
	{
		if (!"http://xmlgraphics.apache.org/fop/extensions".Equals(attributeName.method_0()))
		{
			throw new ArgumentException("The namespace URIs don't match");
		}
		return arrayList_0.Contains(attributeName.method_2());
	}
}
