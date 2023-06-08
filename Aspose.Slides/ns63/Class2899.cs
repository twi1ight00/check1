using System.Collections.Generic;
using System.IO;

namespace ns63;

internal class Class2899 : Class2898
{
	internal const int int_1 = 4013;

	private ushort ushort_0 = ushort.MaxValue;

	private readonly List<Class2980> list_1 = new List<Class2980>();

	public ushort CLevels
	{
		get
		{
			if (ushort_0 == ushort.MaxValue)
			{
				return (ushort)Levels.Count;
			}
			return ushort_0;
		}
	}

	public List<Class2980> Levels => list_1;

	internal Class2899()
	{
		base.Header.Type = 4013;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		ushort_0 = reader.ReadUInt16();
		Levels.Clear();
		for (int i = 0; i < ushort_0; i++)
		{
			Class2980 @class = new Class2980();
			@class.method_0(reader);
			list_1.Add(@class);
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		int count = list_1.Count;
		writer.Write((short)count);
		for (int i = 0; i < count; i++)
		{
			list_1[i].method_1(writer);
		}
	}

	public override int vmethod_2()
	{
		int num = 2;
		for (int i = 0; i < list_1.Count; i++)
		{
			num += list_1[i].method_2();
		}
		return num;
	}
}
