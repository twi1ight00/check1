using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns270;

internal class Class6708
{
	private readonly List<Class6707> list_0 = new List<Class6707>();

	internal Class6707 this[uint index]
	{
		get
		{
			return list_0[(int)index];
		}
		set
		{
			list_0[(int)index] = value;
		}
	}

	internal int Count => list_0.Count;

	internal void Add(Class6707 dirEntry)
	{
		list_0.Add(dirEntry);
	}

	internal Class6707 method_0(string name)
	{
		Class6707 entry = method_2(this[0u], this[0u].uint_3);
		return method_1(entry, name);
	}

	private Class6707 method_1(Class6707 entry, string name)
	{
		if (entry.string_0 == name)
		{
			return entry;
		}
		Class6707 @class = method_2(entry, entry.uint_1);
		if (@class != null)
		{
			Class6707 class2 = method_1(@class, name);
			if (class2 != null)
			{
				return class2;
			}
		}
		Class6707 class3 = method_2(entry, entry.uint_2);
		if (class3 != null)
		{
			Class6707 class4 = method_1(class3, name);
			if (class4 != null)
			{
				return class4;
			}
		}
		return null;
	}

	internal Class6707 method_2(Class6707 parentEntry, uint childIndex)
	{
		if (childIndex != uint.MaxValue && childIndex < list_0.Count && parentEntry != this[childIndex])
		{
			return this[childIndex];
		}
		return null;
	}

	internal MemoryStream method_3()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter writer = new BinaryWriter(memoryStream, Encoding.Unicode);
		for (uint num = 0u; num < list_0.Count; num++)
		{
			this[num].Write(writer);
		}
		Class6707 @class = new Class6707();
		while (memoryStream.Length % 512L != 0L)
		{
			@class.Write(writer);
		}
		return memoryStream;
	}
}
