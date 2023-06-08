using System.Collections.Generic;
using System.IO;
using Aspose.Slides;

namespace ns47;

internal class Class1145
{
	internal static string string_0 = "_PID_HLINKS";

	public static string string_1 = "_PID_LINKBASE";

	private readonly SortedList<uint, Interface37> sortedList_0 = new SortedList<uint, Interface37>();

	private readonly ushort ushort_0 = 1252;

	private Class1143 class1143_0;

	private readonly Class1144 class1144_0;

	internal ushort Codepage => ushort_0;

	public SortedList<uint, Interface37> Properties => sortedList_0;

	public Class1143 Dictionary => class1143_0;

	public uint NextPid => sortedList_0.Keys[sortedList_0.Count - 1] + 1;

	public Class1145()
	{
		class1143_0 = new Class1143();
		sortedList_0[0u] = class1143_0;
		ushort_0 = 1200;
		sortedList_0[1u] = new Class1147((short)ushort_0);
		class1143_0.Entries[string_0] = 2u;
		class1144_0 = new Class1144();
		sortedList_0[2u] = class1144_0;
	}

	public void method_0()
	{
		class1143_0 = new Class1143();
		sortedList_0[0u] = class1143_0;
	}

	internal Class1145(Stream stream, uint offset, int set)
	{
		stream.Seek(offset, SeekOrigin.Begin);
		BinaryReader binaryReader = new BinaryReader(stream);
		uint num = binaryReader.ReadUInt32();
		uint num2 = binaryReader.ReadUInt32();
		if ((num & 0x1111) == 0 && (num & 0x11110000u) != 0)
		{
			throw new PptReadException("Property set stored in BigEndian format");
		}
		if ((num2 & 0x1111) == 0 && (num2 & 0x11110000u) != 0)
		{
			throw new PptReadException("Property set stored in BigEndian format");
		}
		SortedList<uint, uint> sortedList = new SortedList<uint, uint>();
		SortedList<uint, uint> sortedList2 = new SortedList<uint, uint>();
		for (int i = 0; i < num2; i++)
		{
			uint value = binaryReader.ReadUInt32();
			uint key = binaryReader.ReadUInt32();
			sortedList[key] = value;
		}
		for (int j = 0; j < sortedList.Count; j++)
		{
			uint num3 = sortedList.Keys[j];
			uint key2 = sortedList[num3];
			uint value2 = ((j + 1 >= sortedList.Count) ? (num - num3) : (sortedList.Keys[j + 1] - num3));
			sortedList2[key2] = value2;
		}
		foreach (KeyValuePair<uint, uint> item in sortedList)
		{
			uint key3 = item.Key;
			uint value3 = item.Value;
			uint count = sortedList2[value3];
			stream.Seek(offset + key3, SeekOrigin.Begin);
			byte[] bytes = binaryReader.ReadBytes((int)count);
			if (value3 != 0)
			{
				sortedList_0[value3] = new Class1147(bytes);
			}
		}
		sortedList_0.TryGetValue(1u, out var value4);
		ushort_0 = 1252;
		if (value4 != null)
		{
			object obj = Class1147.smethod_0((Class1147)value4, 0);
			if (obj != null)
			{
				ushort_0 = (ushort)(short)obj;
			}
		}
		foreach (KeyValuePair<uint, uint> item2 in sortedList)
		{
			uint value5 = item2.Value;
			if (value5 == 0)
			{
				uint key4 = item2.Key;
				uint count2 = sortedList2[value5];
				stream.Seek(offset + key4, SeekOrigin.Begin);
				byte[] bytes2 = binaryReader.ReadBytes((int)count2);
				class1143_0 = new Class1143(bytes2, ushort_0);
				sortedList_0[value5] = class1143_0;
			}
		}
		if (set == 1 && class1143_0 != null)
		{
			object obj2 = null;
			if (class1143_0.Entries.ContainsKey(string_0))
			{
				obj2 = class1143_0.Entries[string_0];
			}
			if (obj2 != null)
			{
				uint key5 = (uint)obj2;
				Class1147 srcprop = (Class1147)sortedList_0[key5];
				class1144_0 = new Class1144(srcprop);
				sortedList_0[key5] = class1144_0;
			}
		}
	}

	public byte[] Write()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(0u);
		binaryWriter.Write(0u);
		int count = sortedList_0.Count;
		binaryWriter.Write(new byte[count * 8]);
		int[] array = new int[count];
		int num = 0;
		foreach (KeyValuePair<uint, Interface37> item in sortedList_0)
		{
			byte[] array2 = item.Value.Write();
			binaryWriter.Write(array2);
			array[num++] = array2.Length;
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		binaryWriter.Write((uint)memoryStream.Length);
		binaryWriter.Write((uint)count);
		int num2 = 8 + count * 8;
		num = 0;
		foreach (KeyValuePair<uint, Interface37> item2 in sortedList_0)
		{
			uint key = item2.Key;
			binaryWriter.Write(key);
			binaryWriter.Write((uint)num2);
			num2 += array[num++];
		}
		binaryWriter.Close();
		return memoryStream.ToArray();
	}

	public object method_1(uint pid)
	{
		object obj = null;
		if (sortedList_0.ContainsKey(pid))
		{
			obj = sortedList_0[pid];
		}
		if (obj != null)
		{
			if (obj is Class1147)
			{
				Class1147 prop = (Class1147)obj;
				return Class1147.smethod_0(prop, ushort_0);
			}
			return obj;
		}
		return null;
	}

	public object method_2(string name)
	{
		if (class1143_0 != null && class1143_0.Entries.ContainsKey(name))
		{
			return method_1(class1143_0.Entries[name]);
		}
		return null;
	}

	public void method_3(string name, Interface37 property)
	{
		if (class1143_0 == null)
		{
			method_0();
		}
		if (class1143_0.Entries.ContainsKey(name))
		{
			uint key = class1143_0.Entries[name];
			sortedList_0[key] = property;
			return;
		}
		uint num;
		for (num = 2u; sortedList_0.ContainsKey(num); num++)
		{
		}
		class1143_0.Entries.Add(name, num);
		sortedList_0.Add(num, property);
	}

	public void method_4(string name)
	{
		if (class1143_0 != null && class1143_0.Entries.ContainsKey(name))
		{
			uint key = class1143_0.Entries[name];
			class1143_0.Entries.Remove(name);
			sortedList_0.Remove(key);
		}
	}
}
