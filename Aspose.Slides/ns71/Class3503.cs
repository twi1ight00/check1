using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns71;

internal class Class3503 : Class3483
{
	[CompilerGenerated]
	private sealed class Class3521
	{
		public string string_0;

		public bool method_0(Class3482 m)
		{
			return m.StreamName.StreamName == string_0;
		}
	}

	private readonly int int_0;

	private uint uint_0;

	private ushort ushort_0;

	private Class3496 class3496_0 = new Class3496();

	private readonly List<Class3482> list_0 = new List<Class3482>();

	public override ushort Id => 15;

	public uint Size
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public List<Class3482> Modules => list_0;

	public ushort Count
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	internal Class3496 ProjectCookieRecord
	{
		get
		{
			return class3496_0;
		}
		set
		{
			class3496_0 = value;
		}
	}

	internal Class3503(int codePage)
	{
		int_0 = codePage;
	}

	protected override void vmethod_2(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		ushort_0 = reader.ReadUInt16();
		class3496_0.vmethod_0(reader);
		while (Class3522.smethod_0(reader) == 25)
		{
			Class3482 @class = new Class3482(int_0);
			@class.vmethod_0(reader);
			list_0.Add(@class);
		}
	}

	protected override void vmethod_3(BinaryWriter writer)
	{
		writer.Write(2u);
		writer.Write((ushort)list_0.Count);
		class3496_0.vmethod_1(writer);
		foreach (Class3482 item in list_0)
		{
			item.vmethod_1(writer);
		}
	}

	internal void method_0(string name)
	{
		Class3482 @class = method_1(name);
		if (@class == null)
		{
			throw new ArgumentException($"Module with name {name} is not exists");
		}
		list_0.Remove(@class);
	}

	private Class3482 method_1(string name)
	{
		return list_0.Find((Class3482 m) => m.StreamName.StreamName == name);
	}
}
