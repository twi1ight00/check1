using System.Collections.Generic;
using System.IO;

namespace ns63;

internal class Class2861 : Class2845
{
	public const int int_0 = 4010;

	private Class2986[] class2986_0 = new Class2986[1]
	{
		new Class2986()
	};

	public Class2986[] RgTextSIRun
	{
		get
		{
			return class2986_0;
		}
		set
		{
			class2986_0 = value;
		}
	}

	public Class2861(Class2951 stf)
		: base(stf)
	{
		base.Header.Type = 4010;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int num = base.Header.Length;
		List<Class2986> list = new List<Class2986>();
		while (num > 0)
		{
			Class2986 @class = new Class2986();
			@class.method_0(reader);
			num -= @class.method_2();
			list.Add(@class);
		}
		if (list.Count > 0)
		{
			class2986_0 = list.ToArray();
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		for (int i = 0; i < class2986_0.Length; i++)
		{
			class2986_0[i].method_1(writer);
		}
	}

	public override int vmethod_2()
	{
		int num = 0;
		for (int i = 0; i < class2986_0.Length; i++)
		{
			num += class2986_0[i].method_2();
		}
		return num;
	}

	internal void method_1()
	{
		if (class2986_0 == null || class2986_0.Length < 2)
		{
			return;
		}
		List<Class2986> list = new List<Class2986>();
		Class2986 @class = class2986_0[0];
		list.Add(@class);
		for (int i = 1; i < class2986_0.Length; i++)
		{
			if (class2986_0[i].method_3(@class))
			{
				@class.Count += class2986_0[i].Count;
				continue;
			}
			@class = class2986_0[i];
			list.Add(@class);
		}
		class2986_0 = list.ToArray();
	}
}
