using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using ns234;
using ns33;
using ns4;
using ns45;

namespace ns63;

internal class Class2791 : Class2789, Interface44
{
	public const int int_0 = 4113;

	private static readonly string[] string_0 = new string[2] { "package", "package_stream" };

	private static byte[] byte_1 = new byte[16]
	{
		0, 3, 0, 0, 0, 0, 0, 0, 192, 0,
		0, 0, 0, 0, 0, 70
	};

	private static readonly byte[] byte_2 = new byte[16]
	{
		3, 3, 0, 0, 0, 0, 0, 0, 192, 0,
		0, 0, 0, 0, 0, 70
	};

	private static readonly byte[] byte_3 = new byte[0];

	[CompilerGenerated]
	private uint uint_0;

	public byte[] RawUnpackedData
	{
		get
		{
			if (byte_0 == null)
			{
				return new byte[0];
			}
			try
			{
				uint uncompressedLength = (uint)Class1162.smethod_6(byte_0, 0);
				MemoryStream srcStream = new MemoryStream(byte_0, 4, base.Header.Length - 4);
				return Class6171.smethod_1(srcStream, (int)uncompressedLength, Enum794.const_1);
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
				return new byte[0];
			}
		}
		set
		{
			byte[] array = Class6171.smethod_2(value, Enum794.const_1);
			byte_0 = new byte[array.Length + 4];
			Class1162.smethod_16(byte_0, 0, value.Length);
			for (int i = 0; i < array.Length; i++)
			{
				byte_0[i + 4] = array[i];
			}
			base.Header.Length = byte_0.Length;
		}
	}

	public byte[] OleData
	{
		get
		{
			byte[] rawUnpackedData = RawUnpackedData;
			try
			{
				MemoryStream inputStream = new MemoryStream(rawUnpackedData, writable: false);
				Class1110 fs = new Class1110(inputStream);
				if (smethod_2(fs))
				{
					byte[] array = smethod_0(fs);
					if (array != null)
					{
						return array;
					}
				}
				return rawUnpackedData;
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
			}
			return null;
		}
	}

	public string ShortFilePath
	{
		get
		{
			method_1(Encoding.Default, out var _, out var shortPath, out var _, out var _, null);
			if (shortPath == null)
			{
				return "";
			}
			return shortPath;
		}
	}

	public string LongFilePath
	{
		get
		{
			method_1(Encoding.Default, out var longPath, out var _, out var _, out var _, null);
			if (longPath == null)
			{
				return "";
			}
			return longPath;
		}
	}

	public string RelativeFilePath
	{
		get
		{
			method_1(Encoding.Default, out var _, out var _, out var relativePath, out var ansiRelativePath, null);
			if (relativePath == null)
			{
				relativePath = ansiRelativePath;
			}
			if (relativePath == null)
			{
				relativePath = "";
			}
			return relativePath;
		}
	}

	public uint PersistId
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	public Class2791()
	{
		base.Header.Type = 4113;
		base.Header.Instance = 1;
	}

	internal static byte[] smethod_0(Class1110 fs)
	{
		if (smethod_2(fs))
		{
			if (smethod_3(fs))
			{
				return smethod_4(fs);
			}
			if (smethod_5(fs))
			{
				return smethod_8(fs);
			}
			if (smethod_6(fs))
			{
				return smethod_9(fs);
			}
		}
		return null;
	}

	private static byte[] smethod_1(Class1110 fs)
	{
		fs.RootFolder.Remove("\u0001CompObj");
		fs.RootFolder.Remove("\u0001Ole");
		MemoryStream memoryStream = new MemoryStream();
		fs.Write(memoryStream);
		return memoryStream.ToArray();
	}

	internal static bool smethod_2(Class1110 fs)
	{
		IEnumerator enumerator = fs.RootFolder.method_3().GetEnumerator();
		bool flag = false;
		bool result = false;
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (enumerator.Current is Class1105 @class && @class is Class1106)
				{
					if (@class.EntryName.Equals("\u0001Ole"))
					{
						break;
					}
					if (@class.EntryName.Equals("\u0001Ole10Native"))
					{
						flag = true;
					}
					else if (@class.EntryName.Equals("\u0001CompObj"))
					{
						result = true;
					}
				}
				continue;
			}
			if (flag)
			{
				return result;
			}
			return false;
		}
		return true;
	}

	internal static bool smethod_3(Class1110 fs)
	{
		IEnumerator enumerator = fs.RootFolder.method_3().GetEnumerator();
		do
		{
			if (!enumerator.MoveNext())
			{
				return false;
			}
		}
		while (!(enumerator.Current is Class1105 @class) || !(@class is Class1106) || !@class.EntryName.ToUpper().Equals("CONTENTS"));
		return true;
	}

	internal static byte[] smethod_4(Class1110 fs)
	{
		IEnumerator enumerator = fs.RootFolder.method_3().GetEnumerator();
		string entryName;
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (enumerator.Current is Class1105 @class && @class is Class1106)
				{
					entryName = @class.EntryName;
					if (entryName.ToUpper().Equals("CONTENTS"))
					{
						break;
					}
				}
				continue;
			}
			return null;
		}
		return ((Class1106)fs.RootFolder.method_2(entryName)).method_8();
	}

	internal static bool smethod_5(Class1110 fs)
	{
		IEnumerator enumerator = fs.RootFolder.method_3().GetEnumerator();
		do
		{
			if (!enumerator.MoveNext())
			{
				return false;
			}
		}
		while (!(enumerator.Current is Class1105 @class) || !(@class is Class1106) || !@class.EntryName.Equals("\u0001Ole10Native"));
		return true;
	}

	internal static bool smethod_6(Class1110 fs)
	{
		IEnumerator enumerator = fs.RootFolder.method_3().GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (!(enumerator.Current is Class1105 @class) || !(@class is Class1106))
			{
				continue;
			}
			string text = @class.EntryName.ToLower();
			for (int i = 0; i < string_0.Length; i++)
			{
				if (text == string_0[i])
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool smethod_7(byte[] arr1, byte[] arr2)
	{
		if (arr1.Length != arr2.Length)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < arr1.Length)
			{
				if (arr1[num] != arr2[num])
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	internal static byte[] smethod_8(Class1110 fs)
	{
		try
		{
			Stream stream = new MemoryStream(((Class1106)fs.RootFolder.method_2("\u0001CompObj")).method_7());
			byte[] array = new byte[16];
			stream.Read(array, 0, 12);
			stream.Read(array, 0, 16);
			byte[] arr = new byte[16]
			{
				12, 0, 3, 0, 0, 0, 0, 0, 192, 0,
				0, 0, 0, 0, 0, 70
			};
			stream = new MemoryStream(((Class1106)fs.RootFolder.method_2("\u0001Ole10Native")).method_7());
			if (smethod_7(array, arr) && smethod_10(stream, parseHeader: true, out var bytes))
			{
				return bytes;
			}
			stream.Position = 0L;
			if (smethod_10(stream, parseHeader: false, out bytes))
			{
				return bytes;
			}
			stream = new MemoryStream(((Class1106)fs.RootFolder.method_2("\u0002OlePres000")).method_7());
			if (smethod_7(array, arr) && smethod_10(stream, parseHeader: true, out bytes))
			{
				return bytes;
			}
			stream.Position = 0L;
			if (smethod_10(stream, parseHeader: false, out bytes))
			{
				return bytes;
			}
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
		return null;
	}

	internal static byte[] smethod_9(Class1110 fs)
	{
		try
		{
			IEnumerator enumerator = fs.RootFolder.method_3().GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (!(enumerator.Current is Class1105 @class) || !(@class is Class1106))
				{
					continue;
				}
				string text = @class.EntryName.ToLower();
				for (int i = 0; i < string_0.Length; i++)
				{
					if (text == string_0[i])
					{
						return ((Class1106)@class).method_8();
					}
				}
			}
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
		return null;
	}

	private static bool smethod_10(Stream stream, bool parseHeader, out byte[] bytes)
	{
		bytes = new byte[0];
		BinaryReader binaryReader = new BinaryReader(stream);
		if (parseHeader)
		{
			try
			{
				binaryReader.ReadInt32();
				if (binaryReader.ReadUInt16() != 2)
				{
					return false;
				}
				while (binaryReader.ReadByte() != 0)
				{
				}
				while (binaryReader.ReadByte() != 0)
				{
				}
				if (binaryReader.ReadUInt16() != 0)
				{
					return false;
				}
				if (binaryReader.ReadUInt16() != 3)
				{
					return false;
				}
				int count = binaryReader.ReadInt32();
				binaryReader.ReadBytes(count);
				count = binaryReader.ReadInt32();
				bytes = binaryReader.ReadBytes(count);
				return true;
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
				return false;
			}
		}
		try
		{
			byte[] array = binaryReader.ReadBytes(8);
			if (array[0] == byte.MaxValue && array[1] == byte.MaxValue && array[2] == byte.MaxValue && array[3] == byte.MaxValue && (array[4] == 2 || array[4] == 3) && array[5] == 0 && array[6] == 0 && array[7] == 0)
			{
				stream.Position = 40L;
				int count2 = (int)(stream.Length - stream.Position);
				bytes = binaryReader.ReadBytes(count2);
			}
			else
			{
				int num = Class1162.smethod_6(array, 0);
				stream.Position = 4L;
				if (num != stream.Length - stream.Position)
				{
					return false;
				}
				bytes = binaryReader.ReadBytes(num);
			}
			return true;
		}
		catch (Exception ex2)
		{
			Class1165.smethod_28(ex2);
			return false;
		}
	}

	public void method_1(Encoding ansiEncoding, out string longPath, out string shortPath, out string relativePath, out string ansiRelativePath, byte[] clsId)
	{
		longPath = (shortPath = (ansiRelativePath = (relativePath = null)));
		byte[] rawUnpackedData = RawUnpackedData;
		try
		{
			MemoryStream inputStream = new MemoryStream(rawUnpackedData, writable: false);
			Class1110 @class = new Class1110();
			@class.Read(inputStream);
			if (!smethod_2(@class) || smethod_5(@class))
			{
				return;
			}
			Class1106 class2 = (Class1106)@class.RootFolder.method_2("\u0001Ole");
			if (class2 == null)
			{
				return;
			}
			byte[] array = class2.method_7();
			if (Class1162.smethod_6(array, 0) != 33554433)
			{
				return;
			}
			int num = 16;
			int num2 = Class1162.smethod_6(array, 16);
			num = 16 + ((num2 == 0) ? 4 : num2);
			num2 = Class1162.smethod_6(array, num);
			if (num2 >= 20)
			{
				method_2(array, num + 4 + 16, num2 - 4 - 16, ansiEncoding, out ansiRelativePath, out relativePath);
				num += num2;
			}
			else
			{
				num += ((num2 == 0) ? 4 : num2);
			}
			num2 = Class1162.smethod_6(array, num);
			if (num2 >= 20)
			{
				method_2(array, num + 4 + 16, num2 - 4 - 16, ansiEncoding, out shortPath, out longPath);
				num += num2;
			}
			else
			{
				num += ((num2 == 0) ? 4 : num2);
			}
			num += 4;
			if (clsId != null)
			{
				int num3 = 0;
				while (num3 < 16)
				{
					clsId[num3] = array[num];
					num3++;
					num++;
				}
			}
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
	}

	private void method_2(byte[] data, int offset, int length, Encoding ansiEncoding, out string ansiPath, out string unicodePath)
	{
		int num = Class1162.smethod_0(data, offset);
		offset += 2;
		int num2 = Class1162.smethod_6(data, offset);
		offset += 4;
		if (num2 > 0)
		{
			StreamReader streamReader = new StreamReader(new MemoryStream(data, offset, num2 - 1), ansiEncoding);
			ansiPath = streamReader.ReadLine();
			while (!streamReader.EndOfStream)
			{
				ansiPath += streamReader.ReadLine();
			}
			if (ansiPath != null && num > 1 && !Path.IsPathRooted(ansiPath))
			{
				int num3 = num - 1;
				while (num3-- > 0)
				{
					ansiPath = Path.Combine("..", ansiPath);
				}
			}
		}
		else
		{
			ansiPath = null;
		}
		offset += num2;
		offset += 4;
		if (Class1162.smethod_1(data, offset - 2) != 57005)
		{
			unicodePath = null;
			return;
		}
		offset += 16;
		offset += 4;
		if (Class1162.smethod_6(data, offset) <= 6)
		{
			unicodePath = null;
			return;
		}
		offset += 4;
		int num4 = Class1162.smethod_6(data, offset);
		offset += 4;
		if (num4 > 0)
		{
			offset += 2;
			int num5 = num4 / 2;
			char[] array = new char[num5];
			int num6 = 0;
			int num7 = offset;
			while (num6 < num5)
			{
				array[num6] = (char)(data[num7] + data[num7 + 1] * 256);
				num6++;
				num7 += 2;
			}
			unicodePath = new string(array);
			offset += num4;
			if (unicodePath != null && num > 1 && !Path.IsPathRooted(unicodePath))
			{
				int num8 = num - 1;
				while (num8-- > 0)
				{
					unicodePath = Path.Combine("..", unicodePath);
				}
			}
		}
		else
		{
			unicodePath = null;
		}
	}

	public void method_3(string longPath, string shortPath, string relativePath)
	{
		Encoding @default = Encoding.Default;
		byte[] array = new byte[16];
		method_1(@default, out var _, out var _, out var _, out var _, array);
		method_4(@default, longPath, shortPath, relativePath, array);
	}

	public void method_4(Encoding ansiEncoding, string longPath, string shortPath, string relativePath, byte[] clsid)
	{
		byte[] rawUnpackedData = RawUnpackedData;
		Class1110 @class = new Class1110();
		try
		{
			@class.Read(new MemoryStream(rawUnpackedData, writable: false));
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			@class = new Class1110();
		}
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(33554433);
		binaryWriter.Write(1);
		binaryWriter.Write(0);
		binaryWriter.Write(0);
		binaryWriter.Write(0);
		smethod_11(binaryWriter, relativePath, null, ansiEncoding);
		smethod_11(binaryWriter, (shortPath != null) ? shortPath : "", longPath, ansiEncoding);
		binaryWriter.Write(-1);
		binaryWriter.Write(clsid);
		binaryWriter.Write(0);
		binaryWriter.Write(0);
		long value = (long)((DateTime.UtcNow - new DateTime(1601, 1, 1)).TotalMilliseconds * 10000.0);
		binaryWriter.Write(value);
		binaryWriter.Write(value);
		if (File.Exists(longPath))
		{
			value = (long)((File.GetLastWriteTimeUtc(longPath) - new DateTime(1601, 1, 1)).TotalMilliseconds * 10000.0);
			binaryWriter.Write(value);
		}
		else
		{
			binaryWriter.Write(0L);
		}
		string name = "\u0001Ole";
		Class1106 class2 = new Class1106(name);
		class2.method_1(memoryStream.ToArray());
		if (@class.RootFolder.method_1(name))
		{
			@class.RootFolder.Remove(name);
		}
		@class.RootFolder.Add(class2);
		@class.RootFolder.UId = byte_1;
		memoryStream = new MemoryStream();
		@class.Write(memoryStream);
		RawUnpackedData = memoryStream.ToArray();
	}

	private static void smethod_11(BinaryWriter bw, string ansiPath, string unicodePath, Encoding ansiEncoding)
	{
		if (ansiPath == null && unicodePath == null)
		{
			bw.Write(0);
			return;
		}
		int parentDirCount = 0;
		int parentDirCount2 = 0;
		if (ansiPath != null)
		{
			ansiPath = smethod_12(ansiPath, out parentDirCount);
		}
		if (unicodePath != null)
		{
			unicodePath = smethod_12(unicodePath, out parentDirCount2);
		}
		int num = Math.Max(parentDirCount, parentDirCount2);
		byte[] array = ((ansiPath != null) ? ansiEncoding.GetBytes(ansiPath) : byte_3);
		_ = bw.BaseStream.Position;
		int value = 26 + (array.Length + 1) + 2 + 2 + 16 + 4 + 4 + ((unicodePath != null) ? (6 + unicodePath.Length * 2) : 0);
		bw.Write(value);
		bw.Write(byte_2);
		bw.Write((short)num);
		bw.Write(array.Length + 1);
		bw.Write(array);
		bw.Write((byte)0);
		bw.Write((short)(-1));
		bw.Write((ushort)57005);
		bw.Write(0);
		bw.Write(0);
		bw.Write(0);
		bw.Write(0);
		bw.Write(0);
		if (unicodePath != null)
		{
			bw.Write(unicodePath.Length * 2 + 6);
			bw.Write(unicodePath.Length * 2);
			bw.Write((short)3);
			bw.Write(Encoding.Unicode.GetBytes(unicodePath));
		}
		else
		{
			bw.Write(0);
		}
	}

	private static string smethod_12(string path, out int parentDirCount)
	{
		parentDirCount = 0;
		if (!Path.IsPathRooted(path))
		{
			parentDirCount = 1;
			int i;
			for (i = 0; i + 3 < path.Length && path[i] == '.' && path[i + 1] == '.'; i += 3)
			{
				if (path[2] != Path.PathSeparator && path[2] != Path.AltDirectorySeparatorChar)
				{
					break;
				}
				parentDirCount++;
			}
			if (i <= 0)
			{
				return path;
			}
			return path.Substring(i);
		}
		return path;
	}
}
