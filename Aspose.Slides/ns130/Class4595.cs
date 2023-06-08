using System;
using System.IO;
using System.Text;

namespace ns130;

internal class Class4595
{
	private uint uint_0;

	private uint uint_1;

	private Struct178 struct178_0;

	private Enum649 enum649_0;

	private Class4596 class4596_0;

	private Enum646 enum646_0;

	private bool bool_0;

	private Enum648 enum648_0;

	private Enum647 enum647_0;

	private uint uint_2;

	private Enum649 enum649_1;

	private string string_0;

	private uint uint_3;

	private uint uint_4;

	private string string_1;

	private string string_2;

	private string string_3;

	private uint uint_5;

	private string string_4;

	private string string_5;

	private uint[] uint_6;

	private uint[] uint_7;

	private uint[] uint_8;

	public uint FileSize
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

	public uint FontDataSize
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public Struct178 Version
	{
		get
		{
			return struct178_0;
		}
		set
		{
			struct178_0 = value;
		}
	}

	public Enum649 Flags
	{
		get
		{
			return enum649_0;
		}
		set
		{
			enum649_0 = value;
		}
	}

	public Class4596 FontPanose
	{
		get
		{
			return class4596_0;
		}
		set
		{
			class4596_0 = value;
		}
	}

	public Enum646 Charset
	{
		get
		{
			return enum646_0;
		}
		set
		{
			enum646_0 = value;
		}
	}

	public bool IsItalic
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

	public Enum648 Weight
	{
		get
		{
			return enum648_0;
		}
		set
		{
			enum648_0 = value;
		}
	}

	public Enum647 Permissions
	{
		get
		{
			return enum647_0;
		}
		set
		{
			enum647_0 = value;
		}
	}

	public uint[] UnicodeRange
	{
		get
		{
			return uint_6;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.Length != 4)
			{
				throw new ArgumentException("Length of array must be 4");
			}
			uint_6 = value;
		}
	}

	public uint[] CodePageRange
	{
		get
		{
			return uint_8;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.Length != 2)
			{
				throw new ArgumentException("Length of array must be 2");
			}
			uint_8 = value;
		}
	}

	public uint CheckSumAdjustment
	{
		get
		{
			return uint_5;
		}
		set
		{
			uint_5 = value;
		}
	}

	public uint[] Reserved
	{
		get
		{
			return uint_7;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.Length != 4)
			{
				throw new ArgumentException("Length of array must be 4");
			}
			uint_7 = value;
		}
	}

	public string FamilyName
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string StyleName
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public string VersionName
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string FullName
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public string _rootString
	{
		get
		{
			return _rootString;
		}
		set
		{
			_rootString = value;
		}
	}

	public uint RootStringCheckSum
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

	public uint EudcCodePage
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public string Signature
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Enum649 EudcFlags
	{
		get
		{
			return enum649_1;
		}
		set
		{
			enum649_1 = value;
		}
	}

	public uint EudcFontSize
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	internal Class4595(BinaryReader reader)
	{
		if (reader != null)
		{
			method_0(reader);
		}
	}

	internal Class4595()
		: this(null)
	{
	}

	internal void method_0(BinaryReader reader)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		FileSize = reader.ReadUInt32();
		FontDataSize = reader.ReadUInt32();
		Version = Struct178.smethod_1(reader.ReadUInt32());
		Flags = (Enum649)reader.ReadUInt32();
		FontPanose = new Class4596(reader.ReadBytes(10));
		Charset = (Enum646)reader.ReadByte();
		IsItalic = reader.ReadByte() == 1;
		Weight = (Enum648)reader.ReadUInt32();
		Permissions = (Enum647)reader.ReadUInt16();
		if (reader.ReadUInt16() != 20556)
		{
			throw new InvalidOperationException("Magic number for EOT file is incorrect. Maybe file is corrupted");
		}
		UnicodeRange = smethod_2(reader, 4);
		CodePageRange = smethod_2(reader, 2);
		CheckSumAdjustment = reader.ReadUInt32();
		Reserved = smethod_2(reader, 4);
		if (reader.ReadUInt16() != 0)
		{
			throw new InvalidOperationException("Padding1 is not zero. Maybe file is corrupted");
		}
		FamilyName = method_1(reader);
		if (reader.ReadUInt16() != 0)
		{
			throw new InvalidOperationException("Padding2 is not zero. Maybe file is corrupted");
		}
		StyleName = method_1(reader);
		if (reader.ReadUInt16() != 0)
		{
			throw new InvalidOperationException("Padding3 is not zero. Maybe file is corrupted");
		}
		VersionName = method_1(reader);
		if (reader.ReadUInt16() != 0)
		{
			throw new InvalidOperationException("Padding4 is not zero. Maybe file is corrupted");
		}
		FullName = method_1(reader);
		if (Version.ushort_0 != 2)
		{
			return;
		}
		if (reader.ReadUInt16() != 0)
		{
			throw new InvalidOperationException("Padding5 is not zero. Maybe file is corrupted");
		}
		ushort count = reader.ReadUInt16();
		byte[] data = reader.ReadBytes(count);
		string_1 = smethod_1(data);
		if (Version.ushort_1 == 2)
		{
			RootStringCheckSum = reader.ReadUInt32();
			if (RootStringCheckSum != smethod_0(data))
			{
				throw new InvalidOperationException("RootString checksum is incorrect. Maybe file is corrupted");
			}
			EudcCodePage = reader.ReadUInt32();
			if (reader.ReadUInt16() != 0)
			{
				throw new InvalidOperationException("Padding6 is not zero. Maybe file is corrupted");
			}
			Signature = method_1(reader);
			EudcFlags = (Enum649)reader.ReadUInt32();
			EudcFontSize = reader.ReadUInt32();
		}
	}

	private static uint smethod_0(byte[] data)
	{
		uint num = 0u;
		for (int i = 0; i < data.Length; i++)
		{
			num += data[i];
		}
		return num ^ 0x50475342u;
	}

	private static string smethod_1(byte[] data)
	{
		string text = Encoding.Unicode.GetString(data);
		if (text.Length > 0 && text[text.Length - 1] == '\0')
		{
			text = text.Substring(0, text.Length - 1);
		}
		return text;
	}

	private string method_1(BinaryReader reader)
	{
		ushort count = reader.ReadUInt16();
		byte[] data = reader.ReadBytes(count);
		return smethod_1(data);
	}

	private static uint[] smethod_2(BinaryReader reader, int length)
	{
		uint[] array = new uint[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = reader.ReadUInt32();
		}
		return array;
	}
}
