using System;
using System.IO;
using System.Text;

namespace ns61;

internal sealed class Class2959 : Class2958
{
	private const ushort ushort_0 = 57005;

	private const ushort ushort_1 = 3;

	private ushort ushort_2;

	private string string_0;

	private string string_1;

	private ushort ushort_3 = ushort.MaxValue;

	private byte[] byte_0;

	public override Guid MonikerClsid => Class2963.guid_1;

	public ushort CAnsi => ushort_2;

	public uint AnsiLength => (uint)(((string_0 != null) ? (string_0.Length - ushort_2 * 3) : 0) + 1);

	public string AnsiPath
	{
		get
		{
			return string_0;
		}
		set
		{
			if (value != null)
			{
				ushort num = smethod_0(value);
				if (value.Length - num * 3 > 32767)
				{
					throw new ArgumentException("AnsiPath length can't be more than 32767 (with null-terminator inclusive).");
				}
				ushort_2 = num;
				string_0 = value;
			}
			else
			{
				ushort_2 = 0;
				string_0 = null;
			}
		}
	}

	public ushort EndServer
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
		}
	}

	public uint UnicodePathSize
	{
		get
		{
			if (string_1 != null && string_1.Length > 0)
			{
				return (uint)(string_1.Length * 2 + 6);
			}
			return 0u;
		}
	}

	public uint UnicodePathBytes
	{
		get
		{
			if (string_1 != null && string_1.Length > 0)
			{
				return (uint)(string_1.Length * 2);
			}
			return 0u;
		}
	}

	public string UnicodePath
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public byte[] UnknownData
	{
		get
		{
			byte[] array = null;
			if (byte_0 != null)
			{
				array = new byte[byte_0.Length];
				byte_0.CopyTo(array, 0);
			}
			return array;
		}
	}

	public Class2959()
	{
		AnsiPath = null;
		UnicodePath = null;
	}

	public override uint vmethod_0()
	{
		return (6 + AnsiLength + 2 + 2 + 16 + 4 + 4 + UnicodePathSize != 0) ? UnicodePathSize : 0u;
	}

	public override void Read(BinaryReader reader)
	{
		ushort num = reader.ReadUInt16();
		uint num2 = reader.ReadUInt32();
		StringBuilder stringBuilder = new StringBuilder();
		if (num2 > 1)
		{
			stringBuilder.Append(Encoding.Default.GetString(reader.ReadBytes((int)(num2 - 1))));
			for (int i = 0; i < num; i++)
			{
				stringBuilder.Insert(0, Path.DirectorySeparatorChar);
				stringBuilder.Insert(0, "..");
			}
			AnsiPath = stringBuilder.ToString();
		}
		reader.ReadByte();
		EndServer = reader.ReadUInt16();
		reader.ReadBytes(16);
		reader.ReadBytes(4);
		uint num3 = reader.ReadUInt32();
		if (num3 != 0)
		{
			uint num4 = reader.ReadUInt32();
			UnicodePath = Encoding.Unicode.GetString(reader.ReadBytes((int)num4));
			if (num3 > num4 + 6)
			{
				byte_0 = reader.ReadBytes((int)(num3 - 6 - num4));
			}
		}
	}

	public override void Write(BinaryWriter writer)
	{
		writer.Write(CAnsi);
		writer.Write(AnsiLength);
		if (AnsiLength > 1)
		{
			writer.Write(Encoding.Default.GetBytes(AnsiPath.Substring(CAnsi * 3)));
		}
		writer.Write((byte)0);
		writer.Write(EndServer);
		writer.Write((ushort)57005);
		byte[] buffer = new byte[16];
		writer.Write(buffer);
		byte[] buffer2 = new byte[4];
		writer.Write(buffer2);
		writer.Write(UnicodePathSize);
		if (UnicodePathSize != 0)
		{
			writer.Write(UnicodePathBytes);
			writer.Write((ushort)3);
			writer.Write(Encoding.Unicode.GetBytes(UnicodePath));
		}
	}

	private static ushort smethod_0(string ansiPath)
	{
		if (ansiPath == null)
		{
			return 0;
		}
		ushort num = 0;
		while (ansiPath.Length > num * 3 + 3 && ansiPath[num * 3] == '.' && ansiPath[num * 3 + 1] == '.' && (ansiPath[num * 3 + 2] == '\\' || ansiPath[num * 3 + 2] == '/'))
		{
			num = (ushort)(num + 1);
		}
		return num;
	}
}
