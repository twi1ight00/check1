using System;
using System.IO;
using System.Text;
using ns218;

namespace ns270;

internal class Class6711
{
	private Stream stream_0;

	private Class6712 class6712_0;

	private Class6710 class6710_0;

	private Class6709 class6709_0;

	private Class6708 class6708_0;

	private MemoryStream memoryStream_0;

	private Class6630 class6630_0;

	public Class6630 Root
	{
		get
		{
			if (class6630_0 == null)
			{
				method_8();
			}
			return class6630_0;
		}
	}

	internal Class6710 Fat => class6710_0;

	public Class6711()
	{
	}

	public static bool smethod_0(Stream stream)
	{
		long position = stream.Position;
		byte[] array = new byte[4];
		int bytesRead = stream.Read(array, 0, 4);
		stream.Position = position;
		return smethod_1(array, bytesRead);
	}

	public static bool smethod_1(byte[] data, int bytesRead)
	{
		if (bytesRead >= 4 && data[0] == 208 && data[1] == 207 && data[2] == 17)
		{
			return data[3] == 224;
		}
		return false;
	}

	public Class6711(Class6630 root)
	{
		class6630_0 = root;
	}

	public Class6711(Guid clsid)
		: this(new Class6630(clsid))
	{
	}

	public Class6711(string fileName)
	{
		using Stream stream = File.OpenRead(fileName);
		method_0(stream);
		method_8();
	}

	public Class6711(Stream stream)
	{
		method_0(stream);
	}

	private void method_0(Stream stream)
	{
		stream_0 = stream;
		stream_0.Position = 0L;
		class6712_0 = new Class6712(new BinaryReader(stream_0, Encoding.Unicode));
		class6710_0 = new Class6710(stream_0, class6712_0);
		class6710_0.Read();
		method_1();
		class6709_0 = new Class6709(method_6(class6712_0.uint_2, class6712_0.MiniFatLength, class6712_0.MiniFatLength, isForceFat: true));
		method_5();
	}

	private void method_1()
	{
		int num = Math.Min(10, class6710_0.Count);
		uint num2 = 0u;
		while (true)
		{
			if (num2 < num)
			{
				if (class6710_0[num2] == 0)
				{
					num2++;
					continue;
				}
				break;
			}
			throw new InvalidOperationException("The FAT in the structured storage document seems to be corrupted.");
		}
	}

	public void Save(string fileName)
	{
		using Stream stream = File.Create(fileName);
		Save(stream);
	}

	public void Save(Stream stream)
	{
		stream_0 = stream;
		stream_0.Position = 512L;
		class6712_0 = new Class6712();
		class6710_0 = new Class6710(stream_0, class6712_0);
		class6709_0 = new Class6709();
		memoryStream_0 = new MemoryStream();
		class6708_0 = new Class6708();
		method_2(class6630_0, null);
		if (memoryStream_0.Length > 0L)
		{
			class6708_0[0u].uint_5 = method_4(memoryStream_0, isForceFat: true);
			class6708_0[0u].long_2 = memoryStream_0.Length;
			class6712_0.uint_2 = method_3(class6709_0.method_0(), isForceFat: true, out var sectorCount);
			class6712_0.int_6 = sectorCount;
		}
		else
		{
			class6712_0.uint_2 = 4294967294u;
		}
		class6712_0.uint_0 = method_4(class6708_0.method_3(), isForceFat: true);
		class6710_0.Write();
		stream_0.Position = 0L;
		class6712_0.Write(new BinaryWriter(stream_0, Encoding.Unicode));
		stream_0.Position = stream_0.Length;
	}

	private void method_2(Class6630 storage, Class6707 storageEntry)
	{
		if (storageEntry == null)
		{
			storageEntry = new Class6707("Root Entry", isRoot: true, storage.Clsid);
			class6708_0.Add(storageEntry);
		}
		if (storage.Count > 0)
		{
			storageEntry.uint_3 = (uint)class6708_0.Count;
		}
		int num = 0;
		while (true)
		{
			if (num >= storage.Count)
			{
				return;
			}
			string name = storage.GetKey(num) as string;
			object byIndex = storage.GetByIndex(num);
			Class6707 class2;
			if (byIndex is Class6630 @class)
			{
				class2 = new Class6707(name, isRoot: false, @class.Clsid);
				class6708_0.Add(class2);
				method_2(@class, class2);
			}
			else
			{
				if (!(byIndex is Stream stream))
				{
					break;
				}
				class2 = new Class6707(name, Enum893.const_2, stream.Length);
				class6708_0.Add(class2);
				class2.uint_5 = method_4(stream, isForceFat: false);
			}
			if (num < storage.Count - 1)
			{
				class2.uint_2 = (uint)class6708_0.Count;
			}
			num++;
		}
		throw new InvalidOperationException("Unknown object in memory storage.");
	}

	private uint method_3(Stream srcStream, bool isForceFat, out int sectorCount)
	{
		sectorCount = 0;
		if (srcStream.Length == 0L)
		{
			return 4294967294u;
		}
		bool flag;
		Class6709 @class = ((flag = class6712_0.method_0(srcStream.Length) || isForceFat) ? class6710_0 : class6709_0);
		Stream stream = (flag ? stream_0 : memoryStream_0);
		int num = (flag ? 512 : 64);
		uint num2 = Class6720.smethod_1(stream.Position, flag);
		srcStream.Position = 0L;
		Class5964.smethod_9(srcStream, stream);
		Class5964.smethod_7(stream, num);
		sectorCount = Class5964.smethod_5(srcStream.Length, num);
		for (uint num3 = 1u; num3 < sectorCount; num3++)
		{
			@class.Add(num2 + num3);
		}
		@class.Add(4294967294u);
		return num2;
	}

	private uint method_4(Stream srcStream, bool isForceFat)
	{
		int sectorCount;
		return method_3(srcStream, isForceFat, out sectorCount);
	}

	private void method_5()
	{
		class6708_0 = new Class6708();
		BinaryReader reader = new BinaryReader(stream_0, Encoding.Unicode);
		for (uint num = class6712_0.uint_0; num != 4294967294u; num = class6710_0[num])
		{
			stream_0.Position = Class6720.smethod_0(num, isNormalSector: true);
			for (int i = 0; i < 4; i++)
			{
				class6708_0.Add(new Class6707(reader));
			}
		}
	}

	private MemoryStream method_6(uint sectStart, int streamLength, int lengthToRead, bool isForceFat)
	{
		lengthToRead = Math.Min(streamLength, lengthToRead);
		MemoryStream memoryStream = new MemoryStream(lengthToRead);
		memoryStream.SetLength(lengthToRead);
		bool flag;
		if (!(flag = isForceFat || class6712_0.method_0(streamLength)))
		{
			Class6707 @class = class6708_0[0u];
			if (@class.uint_5 != uint.MaxValue && memoryStream_0 == null)
			{
				memoryStream_0 = method_6(@class.uint_5, (int)@class.long_2, (int)@class.long_2, isForceFat: true);
			}
			if (class6712_0.MiniFatLength == 0 || memoryStream_0 == null)
			{
				memoryStream.SetLength(0L);
				return memoryStream;
			}
		}
		Class6709 class2 = (flag ? class6710_0 : class6709_0);
		Stream stream = (flag ? stream_0 : memoryStream_0);
		int val = (flag ? 512 : 64);
		int num = 0;
		long num2 = stream.Position;
		uint num3 = sectStart;
		while (num3 != 4294967294u && num3 != uint.MaxValue)
		{
			long num4 = Class6720.smethod_0(num3, flag);
			if (num2 != num4)
			{
				num2 = (stream.Position = num4);
			}
			int num6 = lengthToRead - num;
			if (num6 == 0)
			{
				break;
			}
			int num7 = Math.Min(val, num6);
			stream.Read(memoryStream.GetBuffer(), num, num7);
			num += num7;
			num2 += num7;
			num3 = class2[num3];
		}
		return memoryStream;
	}

	public MemoryStream method_7(string streamName)
	{
		Class6707 @class = class6708_0.method_0(streamName);
		if (@class == null)
		{
			throw new InvalidOperationException($"Cannot find directory entry {streamName}.");
		}
		return method_6(@class.uint_5, (int)@class.long_2, 512, isForceFat: false);
	}

	private void method_8()
	{
		method_9(class6708_0[0u], null);
	}

	private void method_9(Class6707 dirEntry, Class6630 parent)
	{
		if (dirEntry.bool_0)
		{
			return;
		}
		dirEntry.bool_0 = true;
		switch (dirEntry.enum893_0)
		{
		case Enum893.const_0:
			return;
		case Enum893.const_2:
			parent.Add(dirEntry.string_0, method_6(dirEntry.uint_5, (int)dirEntry.long_2, (int)dirEntry.long_2, isForceFat: false));
			break;
		default:
			throw new InvalidOperationException("Unknown type of directory entry in the structured storage.");
		case Enum893.const_1:
		case Enum893.const_5:
		{
			Class6630 @class = new Class6630(dirEntry.guid_0);
			if (dirEntry.enum893_0 == Enum893.const_5 && class6630_0 == null)
			{
				class6630_0 = @class;
			}
			else
			{
				parent.Add(dirEntry.string_0, @class);
			}
			Class6707 class2 = class6708_0.method_2(dirEntry, dirEntry.uint_3);
			if (class2 != null)
			{
				method_9(class2, @class);
			}
			break;
		}
		}
		Class6707 class3 = class6708_0.method_2(dirEntry, dirEntry.uint_1);
		if (class3 != null)
		{
			method_9(class3, parent);
		}
		Class6707 class4 = class6708_0.method_2(dirEntry, dirEntry.uint_2);
		if (class4 != null)
		{
			method_9(class4, parent);
		}
	}

	public bool method_10(string name)
	{
		return class6708_0.method_0(name) != null;
	}
}
