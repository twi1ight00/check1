using System.Collections;
using System.IO;
using System.Text;

namespace ns57;

internal class Class1314
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	internal Class1313 this[uint uint_0]
	{
		get
		{
			return (Class1313)arrayList_0[(int)uint_0];
		}
		set
		{
			arrayList_0[(int)uint_0] = value;
		}
	}

	internal int Count => arrayList_0.Count;

	internal void Add(Class1313 class1313_0)
	{
		arrayList_0.Add(class1313_0);
	}

	internal Class1313 method_0(Class1313 class1313_0, uint uint_0)
	{
		if (uint_0 != uint.MaxValue && uint_0 < arrayList_0.Count && class1313_0 != this[uint_0])
		{
			return this[uint_0];
		}
		return null;
	}

	internal MemoryStream method_1()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter_ = new BinaryWriter(memoryStream, Encoding.Unicode);
		for (uint num = 0u; num < arrayList_0.Count; num++)
		{
			this[num].Write(binaryWriter_);
		}
		Class1313 @class = new Class1313();
		while (memoryStream.Length % 512 != 0)
		{
			@class.Write(binaryWriter_);
		}
		return memoryStream;
	}
}
