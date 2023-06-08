using System.Collections.Generic;
using ns215;

namespace ns216;

internal class Class5784 : Class5783
{
	private Dictionary<string, Class5782> dictionary_1 = new Dictionary<string, Class5782>();

	private Class5910 class5910_0;

	public Dictionary<string, Class5782> IdElementsDictionary
	{
		get
		{
			return dictionary_1;
		}
		set
		{
			dictionary_1 = value;
		}
	}

	internal Class5910 LayoutModel
	{
		get
		{
			return class5910_0;
		}
		set
		{
			class5910_0 = value;
		}
	}

	internal static string Tag => "xfa";

	internal override Class5782 vmethod_7()
	{
		return new Class5784();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5852.Tag };
	}

	public override object Clone()
	{
		return null;
	}
}
