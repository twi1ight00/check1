using System.IO;
using System.Text;

namespace ns63;

internal class Class2851 : Class2846
{
	public const int int_1 = 4117;

	internal string string_0;

	internal string string_1;

	public string Format
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

	public string DateTimeString => string_1;

	public Class2851(Class2951 stf)
		: base(stf)
	{
		base.Header.Type = 4117;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		base.Position = reader.ReadInt32();
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		char[] chars = unicodeEncoding.GetChars(reader.ReadBytes(base.Header.Length - 4));
		int i;
		for (i = 0; i < chars.Length && chars[i + 1] != 0; i++)
		{
		}
		string_0 = new string(chars, 0, i);
		string_1 = string_0.Replace("'", "");
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(base.Position);
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		byte[] bytes = unicodeEncoding.GetBytes(string_0);
		int num = ((bytes.Length < 128) ? bytes.Length : 128);
		for (int i = 0; i < num; i++)
		{
			writer.Write(bytes[i]);
		}
		for (int j = num; j < 128; j++)
		{
			writer.Write((byte)0);
		}
	}

	public override int vmethod_2()
	{
		return 132;
	}
}
