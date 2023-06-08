using System;
using System.Text;
using ns60;

namespace ns63;

internal class Class2764 : Class2760
{
	private string string_0;

	public string Value
	{
		get
		{
			if (string_0 == null)
			{
				vmethod_5();
			}
			return string_0;
		}
	}

	public Class2764()
	{
		base.TimeVariantType = Enum400.const_3;
	}

	public Class2764(string value)
		: this()
	{
		base.RawValue = new byte[value.Length * 2 + 2];
		base.RawValue[base.RawValue.Length - 2] = 0;
		base.RawValue[base.RawValue.Length - 1] = 0;
		Buffer.BlockCopy(value.ToCharArray(), 0, base.RawValue, 0, base.RawValue.Length - 2);
	}

	protected override void vmethod_5()
	{
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		char[] chars = unicodeEncoding.GetChars(base.RawValue);
		if (chars != null)
		{
			string_0 = new string(chars).Replace("\0", "");
		}
	}
}
