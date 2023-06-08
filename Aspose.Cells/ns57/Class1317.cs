using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ns57;

internal class Class1317
{
	private Stream stream_0;

	private Class1318 class1318_0;

	private Class1316 class1316_0;

	private Class1315 class1315_0;

	private Class1314 class1314_0;

	private MemoryStream memoryStream_0;

	private Class1319 class1319_0;

	public Class1317(Class1319 class1319_1)
	{
		class1319_0 = class1319_1;
	}

	public Class1317(Guid guid_0)
		: this(new Class1319(guid_0))
	{
	}

	public Class1317(string string_0)
	{
		using Stream stream_ = File.OpenRead(string_0);
		method_0(stream_);
		method_7();
	}

	public Class1317(Stream stream_1)
	{
		method_0(stream_1);
	}

	private void method_0(Stream stream_1)
	{
		stream_0 = stream_1;
		stream_0.Position = 0L;
		class1318_0 = new Class1318(new BinaryReader(stream_0, Encoding.Unicode));
		class1316_0 = new Class1316(stream_0, class1318_0);
		class1316_0.Read();
		method_1();
		class1315_0 = new Class1315(method_6(class1318_0.uint_2, class1318_0.method_1(), class1318_0.method_1(), bool_0: true));
		method_5();
	}

	private void method_1()
	{
		int num = Math.Min(10, class1316_0.Count);
		uint num2 = 0u;
		while (true)
		{
			if (num2 < num)
			{
				if (class1316_0[num2] == 0)
				{
					num2++;
					continue;
				}
				break;
			}
			throw new InvalidOperationException("The FAT in the structured storage document seems to be corrupted.");
		}
	}

	public void Save(string string_0)
	{
		using Stream stream_ = File.Create(string_0);
		Save(stream_);
	}

	public void Save(Stream stream_1)
	{
		stream_0 = stream_1;
		stream_0.Position = 512L;
		class1318_0 = new Class1318();
		class1316_0 = new Class1316(stream_0, class1318_0);
		class1315_0 = new Class1315();
		memoryStream_0 = new MemoryStream();
		class1314_0 = new Class1314();
		method_2(class1319_0, null);
		if (memoryStream_0.Length > 0)
		{
			class1314_0[0u].uint_4 = method_4(memoryStream_0, bool_0: true);
			class1314_0[0u].long_2 = memoryStream_0.Length;
			class1318_0.uint_2 = method_3(class1315_0.method_0(), isForceFat: true, out var sectorCount);
			class1318_0.int_2 = sectorCount;
		}
		else
		{
			class1318_0.uint_2 = 4294967294u;
		}
		class1318_0.uint_0 = method_4(class1314_0.method_1(), bool_0: true);
		class1316_0.Write();
		stream_0.Position = 0L;
		class1318_0.Write(new BinaryWriter(stream_0, Encoding.Unicode));
		stream_0.Position = stream_0.Length;
	}

	private void method_2(Class1319 class1319_1, Class1313 class1313_0)
	{
		if (class1313_0 == null)
		{
			class1313_0 = new Class1313("Root Entry", bool_1: true, class1319_1.method_1());
			class1314_0.Add(class1313_0);
		}
		if (class1319_1.Count > 0)
		{
			class1313_0.uint_2 = (uint)class1314_0.Count;
		}
		int num = 0;
		while (true)
		{
			if (num >= class1319_1.Count)
			{
				return;
			}
			string string_ = class1319_1.GetKey(num) as string;
			object byIndex = class1319_1.GetByIndex(num);
			Class1313 class2;
			if (byIndex is Class1319)
			{
				Class1319 @class = byIndex as Class1319;
				class2 = new Class1313(string_, bool_1: false, @class.method_1());
				class1314_0.Add(class2);
				method_2(@class, class2);
			}
			else
			{
				if (!(byIndex is Stream))
				{
					break;
				}
				Stream stream = (Stream)byIndex;
				class2 = new Class1313(string_, Enum191.const_2, stream.Length);
				class1314_0.Add(class2);
				class2.uint_4 = method_4(stream, bool_0: false);
			}
			if (num < class1319_1.Count - 1)
			{
				class2.uint_1 = (uint)class1314_0.Count;
			}
			num++;
		}
		throw new InvalidOperationException("Unknown object in memory storage.");
	}

	private uint method_3(Stream srcStream, bool isForceFat, out int sectorCount)
	{
		sectorCount = 0;
		if (srcStream.Length == 0)
		{
			return 4294967294u;
		}
		bool flag;
		Class1315 @class = ((flag = class1318_0.method_0(srcStream.Length) || isForceFat) ? class1316_0 : class1315_0);
		Stream stream = (flag ? stream_0 : memoryStream_0);
		int int_ = (flag ? 512 : 64);
		uint num = Class1327.smethod_1(stream.Position, flag);
		srcStream.Position = 0L;
		Class1321.smethod_3(srcStream, stream);
		Class1321.smethod_2(stream, int_);
		sectorCount = Class1321.smethod_0(srcStream.Length, int_);
		for (uint num2 = 1u; num2 < sectorCount; num2++)
		{
			@class.Add(num + num2);
		}
		@class.Add(4294967294u);
		return num;
	}

	private uint method_4(Stream stream_1, bool bool_0)
	{
		int sectorCount;
		return method_3(stream_1, bool_0, out sectorCount);
	}

	private void method_5()
	{
		class1314_0 = new Class1314();
		BinaryReader binaryReader_ = new BinaryReader(stream_0, Encoding.Unicode);
		for (uint num = class1318_0.uint_0; num != 4294967294u; num = class1316_0[num])
		{
			stream_0.Position = Class1327.smethod_0(num, bool_0: true);
			for (int i = 0; i < 4; i++)
			{
				class1314_0.Add(new Class1313(binaryReader_));
			}
		}
	}

	private MemoryStream method_6(uint uint_0, int int_0, int int_1, bool bool_0)
	{
		int_1 = Math.Min(int_0, int_1);
		MemoryStream memoryStream = new MemoryStream(int_1);
		memoryStream.SetLength(int_1);
		bool flag;
		if (!(flag = bool_0 || class1318_0.method_0(int_0)))
		{
			Class1313 @class = class1314_0[0u];
			if (@class.uint_4 != uint.MaxValue && memoryStream_0 == null)
			{
				memoryStream_0 = method_6(@class.uint_4, (int)@class.long_2, (int)@class.long_2, bool_0: true);
			}
			if (class1318_0.method_1() == 0 || memoryStream_0 == null)
			{
				memoryStream.SetLength(0L);
				return memoryStream;
			}
		}
		Class1315 class2 = (flag ? class1316_0 : class1315_0);
		Stream stream = (flag ? stream_0 : memoryStream_0);
		int val = (flag ? 512 : 64);
		int num = 0;
		long num2 = stream.Position;
		for (uint num3 = uint_0; num3 != 4294967294u; num3 = class2[num3])
		{
			long num4 = Class1327.smethod_0(num3, flag);
			if (num2 != num4)
			{
				num2 = (stream.Position = num4);
			}
			int num6 = int_1 - num;
			if (num6 == 0)
			{
				break;
			}
			int num7 = Math.Min(val, num6);
			stream.Read(memoryStream.GetBuffer(), num, num7);
			num += num7;
			num2 += num7;
		}
		return memoryStream;
	}

	private void method_7()
	{
		method_8(class1314_0[0u], null);
	}

	private void method_8(Class1313 class1313_0, Class1319 class1319_1)
	{
		if (class1313_0.bool_0)
		{
			return;
		}
		class1313_0.bool_0 = true;
		switch (class1313_0.enum191_0)
		{
		case Enum191.const_0:
			return;
		case Enum191.const_2:
			class1319_1.Add(class1313_0.string_0, method_6(class1313_0.uint_4, (int)class1313_0.long_2, (int)class1313_0.long_2, bool_0: false));
			break;
		default:
			throw new InvalidOperationException("Unknown type of directory entry in the structured storage.");
		case Enum191.const_1:
		case Enum191.const_5:
		{
			Class1319 class1319_2 = new Class1319(class1313_0.guid_0);
			if (class1313_0.enum191_0 == Enum191.const_5 && class1319_0 == null)
			{
				class1319_0 = class1319_2;
			}
			else
			{
				class1319_1.Add(class1313_0.string_0, class1319_2);
			}
			Class1313 @class = class1314_0.method_0(class1313_0, class1313_0.uint_2);
			if (@class != null)
			{
				method_8(@class, class1319_2);
			}
			break;
		}
		}
		Class1313 class2 = class1314_0.method_0(class1313_0, class1313_0.uint_0);
		if (class2 != null)
		{
			method_8(class2, class1319_1);
		}
		Class1313 class3 = class1314_0.method_0(class1313_0, class1313_0.uint_1);
		if (class3 != null)
		{
			method_8(class3, class1319_1);
		}
	}

	[SpecialName]
	public Class1319 method_9()
	{
		if (class1319_0 == null)
		{
			method_7();
		}
		return class1319_0;
	}
}
