using System.Collections.Generic;
using System.IO;
using ns60;

namespace ns63;

internal class Class2898 : Class2623
{
	public const int int_0 = 4012;

	internal List<Class2968> list_0 = new List<Class2968>();

	public List<Class2968> RgStyleTextProp9 => list_0;

	public Class2898()
	{
		base.Header.Type = 4012;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int num = base.Header.Length;
		list_0.Clear();
		while (num > 0)
		{
			Class2968 @class = new Class2968();
			@class.method_0(reader);
			list_0.Add(@class);
			num -= @class.method_2();
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			list_0[i].method_1(writer);
		}
	}

	public override int vmethod_2()
	{
		int num = 0;
		for (int i = 0; i < list_0.Count; i++)
		{
			num += list_0[i].method_2();
		}
		return num;
	}

	public int method_1(Class2968 styleTextProp9)
	{
		if (styleTextProp9 == null)
		{
			return -1;
		}
		if (list_0.Count == 0)
		{
			list_0.Add(new Class2968());
		}
		int num = list_0.Count - 1;
		if (list_0[num].method_3(styleTextProp9))
		{
			return num;
		}
		num = list_0.Count;
		list_0.Add(styleTextProp9);
		return num;
	}
}
