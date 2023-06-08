using System.Collections.Generic;
using System.IO;
using ns60;

namespace ns63;

internal class Class2887 : Class2623
{
	public const int int_0 = 6002;

	private readonly List<Class2940> list_0 = new List<Class2940>();

	public List<Class2940> Refs => list_0;

	public Class2887()
	{
		base.Header.Type = 6002;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int num = 0;
		while (num < base.Header.Length)
		{
			long num2 = reader.ReadUInt32();
			uint num3 = (uint)((ulong)num2 & 0xFFFFFuL);
			int num4 = (int)(num2 >> 20);
			num += 4;
			int num5 = 0;
			while (num5 < num4 && num < base.Header.Length)
			{
				uint offset = reader.ReadUInt32();
				list_0.Add(new Class2940(num3, offset));
				num += 4;
				num5++;
				num3++;
			}
		}
	}

	public uint method_1(List<Class2623> recs)
	{
		uint num = 0u;
		list_0.Clear();
		for (int i = 0; i < recs.Count; i++)
		{
			if (recs[i].Type != 6002 && recs[i].Type != 4085)
			{
				list_0.Add(new Class2940(((Interface44)recs[i]).PersistId, num));
				num += (uint)(recs[i].vmethod_2() + 8);
			}
		}
		List<Class2940>.Enumerator enumerator = list_0.GetEnumerator();
		uint result = 0u;
		while (enumerator.MoveNext())
		{
			result = enumerator.Current.PersitsId;
		}
		return result;
	}

	public Class2940 method_2(uint persisitId)
	{
		foreach (Class2940 item in list_0)
		{
			if (item.PersitsId == persisitId)
			{
				return item;
			}
		}
		return null;
	}

	public void method_3(uint persisitId)
	{
		int num = 0;
		while (true)
		{
			if (num < list_0.Count)
			{
				if (list_0[num].PersitsId == persisitId)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		list_0.RemoveAt(num);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		List<Class2940>.Enumerator enumerator = list_0.GetEnumerator();
		enumerator.MoveNext();
		uint num = enumerator.Current.PersitsId - 1;
		uint num2 = 0u;
		List<uint> list = new List<uint>();
		enumerator = list_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			num2 = enumerator.Current.PersitsId;
			if (num2 > num + 1 && list.Count > 0)
			{
				writer.Write((uint)((list.Count << 20) | (int)(num - list.Count + 1L)));
				for (int i = 0; i < list.Count; i++)
				{
					writer.Write(list[i]);
				}
				list.Clear();
			}
			list.Add(enumerator.Current.Offset);
			num = num2;
		}
		if (list.Count > 0)
		{
			writer.Write((uint)((list.Count << 20) | (int)(num - list.Count + 1L)));
			for (int j = 0; j < list.Count; j++)
			{
				writer.Write(list[j]);
			}
		}
	}

	public override int vmethod_2()
	{
		int num = 0;
		List<Class2940>.Enumerator enumerator = list_0.GetEnumerator();
		enumerator.MoveNext();
		uint num2 = enumerator.Current.PersitsId - 1;
		int num3 = 0;
		enumerator = list_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			uint persitsId = enumerator.Current.PersitsId;
			if (persitsId > num2 + 1 && num3 > 0)
			{
				num += (num3 + 1) * 4;
				num3 = 0;
			}
			num3++;
			num2 = persitsId;
		}
		if (num3 > 0)
		{
			num += (num3 + 1) * 4;
		}
		return num;
	}
}
