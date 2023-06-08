using System;
using System.IO;
using System.Text;
using ns60;

namespace ns63;

internal class Class2843 : Class2623
{
	internal const int int_0 = 4026;

	private string string_0;

	public string String
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

	public Class2843()
	{
		base.Header.Type = 4026;
	}

	public Class2843(string str, short inst)
	{
		if (str == null)
		{
			throw new ArgumentNullException();
		}
		base.Header.Type = 4026;
		string_0 = str;
		base.Header.Instance = inst;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		string_0 = "";
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		char[] chars = unicodeEncoding.GetChars(reader.ReadBytes(base.Header.Length));
		if (chars != null)
		{
			string_0 = new string(chars);
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		byte[] bytes = unicodeEncoding.GetBytes(string_0.ToCharArray());
		writer.Write(bytes);
	}

	public override int vmethod_2()
	{
		return string_0.Length * 2;
	}
}
