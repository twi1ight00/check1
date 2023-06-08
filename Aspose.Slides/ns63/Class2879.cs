using System;
using System.IO;
using System.Text;
using ns60;

namespace ns63;

internal class Class2879 : Class2623
{
	internal const int int_0 = 4023;

	private string string_0;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	public string LfFaceName
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

	public byte LfCharSet
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public byte FEmbedSubsetted
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public byte Family
	{
		get
		{
			return (byte)(byte_3 & 0xF0u);
		}
		set
		{
			byte_3 &= 15;
			byte_3 |= value;
		}
	}

	public byte Quality
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	public byte Pitch
	{
		get
		{
			return (byte)(byte_3 & 0xFu);
		}
		set
		{
			byte_3 &= 240;
			byte_3 |= value;
		}
	}

	public byte LfPitchAndFamily
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	public Class2879()
	{
		base.Header.Type = 4023;
	}

	internal void method_1()
	{
		string_0 = "Arial";
		byte_0 = 0;
		byte_1 = 0;
		byte_2 = 4;
		byte_3 = 0;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		string_0 = "";
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		char[] chars = unicodeEncoding.GetChars(reader.ReadBytes(64));
		if (chars != null)
		{
			string_0 = new string(chars);
			int length = string_0.IndexOf('\0');
			string_0 = string_0.Substring(0, length);
		}
		byte_0 = reader.ReadByte();
		byte_1 = reader.ReadByte();
		byte_2 = reader.ReadByte();
		byte_3 = reader.ReadByte();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		byte[] bytes = unicodeEncoding.GetBytes(string_0.ToCharArray());
		byte[] array = new byte[64];
		Array.Copy(bytes, 0, array, 0, bytes.Length);
		writer.Write(array);
		writer.Write(byte_0);
		writer.Write(byte_1);
		writer.Write(byte_2);
		writer.Write(byte_3);
	}

	public override int vmethod_2()
	{
		return 68;
	}
}
