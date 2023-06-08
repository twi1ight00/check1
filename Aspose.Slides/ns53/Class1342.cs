using System;
using System.Collections.Generic;
using System.IO;
using ns223;
using ns276;
using ns55;

namespace ns53;

internal class Class1342
{
	private long long_0 = long.MinValue;

	private string string_0;

	private Class1223 class1223_0;

	private byte[] byte_0;

	private Class6751 class6751_0;

	private Class1348 class1348_0;

	private Class1183 class1183_0;

	private bool bool_0;

	public long Crc32
	{
		get
		{
			if (long_0 == long.MinValue)
			{
				long_0 = ((byte_0 != null) ? Class5979.smethod_2(byte_0) : long.MinValue);
			}
			return long_0;
		}
	}

	public long Size
	{
		get
		{
			if (class6751_0 != null)
			{
				return class6751_0.UncompressedSize;
			}
			if (byte_0 != null)
			{
				return byte_0.Length;
			}
			return -1L;
		}
	}

	public string PartPath => string_0;

	public Class1223 ContentType => class1223_0;

	public byte[] Data
	{
		get
		{
			if (byte_0 == null)
			{
				method_7();
			}
			return byte_0;
		}
		set
		{
			byte_0 = value;
			class6751_0 = null;
			long_0 = long.MinValue;
		}
	}

	public Class1348 Relationships => class1348_0;

	internal Class6751 ZipEntry => class6751_0;

	public bool Processed
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class1183 ParentPackage => class1183_0;

	public override string ToString()
	{
		return string_0;
	}

	internal Class1342(Class1183 parentPackage, Class6751 zentry)
	{
		class1183_0 = parentPackage;
		string_0 = "/" + zentry.FileName;
		class6751_0 = zentry;
		long_0 = zentry.Crc;
	}

	internal Class1342(Class1183 parentPackage, string partPath, Class1223 contentType, byte[] data)
	{
		class1183_0 = parentPackage;
		string_0 = partPath;
		method_5(contentType);
		byte_0 = data;
	}

	public MemoryStream method_0()
	{
		if (byte_0 != null)
		{
			return new MemoryStream(byte_0);
		}
		if (class6751_0 != null)
		{
			MemoryStream memoryStream = new MemoryStream();
			class6751_0.method_8(memoryStream);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return memoryStream;
		}
		return null;
	}

	public Class1342[] method_1(Class1338 typeAttribute)
	{
		List<Class1342> list = new List<Class1342>();
		Class1347[] array = Relationships.method_0(typeAttribute);
		Class1347[] array2 = array;
		foreach (Class1347 @class in array2)
		{
			if (@class.TargetMode != Enum180.const_2)
			{
				Class1342 class2 = ParentPackage.method_3(@class.Target);
				if (class2 != null)
				{
					list.Add(class2);
				}
			}
		}
		return list.ToArray();
	}

	public Class1342[] method_2(Class1223 partType)
	{
		return method_1(partType.TypeAttributeOfSourceRelationship);
	}

	public Class1342 method_3()
	{
		if (Relationships != null)
		{
			throw new Exception("Relationships is already exists.");
		}
		string partPath = Class1183.smethod_0(PartPath);
		Class1342 @class = new Class1342(class1183_0, partPath, new Class1296(), null);
		@class.method_6(new Class1348(class1183_0));
		class1183_0.method_6(@class);
		method_6(@class.Relationships);
		return @class;
	}

	public Class1342 Clone()
	{
		Class1342 @class = new Class1342(null, string_0, class1223_0, new byte[Data.Length]);
		byte_0.CopyTo(@class.byte_0, 0);
		return @class;
	}

	internal void method_4(Class1183 package)
	{
		class1183_0 = package;
	}

	internal void method_5(Class1223 contentType)
	{
		class1223_0 = contentType;
	}

	public void method_6(Class1348 relationships)
	{
		class1348_0 = relationships;
	}

	private void method_7()
	{
		if (byte_0 == null)
		{
			byte_0 = smethod_0(class6751_0);
		}
	}

	private static byte[] smethod_0(Class6751 zentry)
	{
		byte[] array = new byte[zentry.UncompressedSize];
		using Stream stream = zentry.method_19();
		for (int i = 0; i < array.Length; i += stream.Read(array, i, array.Length - i))
		{
		}
		return array;
	}
}
