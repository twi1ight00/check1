using System;

namespace ns67;

internal sealed class Class3449 : ICloneable
{
	private Enum494 enum494_0 = Enum494.const_1;

	private Enum495 enum495_0;

	private byte[] byte_0 = new byte[0];

	private string string_0;

	public string Typeface
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

	public Enum494 Charset
	{
		get
		{
			return enum494_0;
		}
		set
		{
			enum494_0 = value;
		}
	}

	public byte[] Panose
	{
		get
		{
			return byte_0;
		}
		set
		{
			if (value == byte_0)
			{
				return;
			}
			if (value == null)
			{
				byte_0 = new byte[0];
				return;
			}
			byte_0 = new byte[value.Length];
			for (int i = 0; i < value.Length; i++)
			{
				byte_0[i] = value[i];
			}
		}
	}

	public Enum495 PitchFamily
	{
		get
		{
			return enum495_0;
		}
		set
		{
			enum495_0 = value;
		}
	}

	public Class3449(string typeface)
	{
		Typeface = typeface;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3449 method_0()
	{
		return new Class3449(this);
	}

	private Class3449(Class3449 src)
	{
		Typeface = src.Typeface;
		Charset = src.Charset;
		PitchFamily = src.PitchFamily;
		Panose = src.Panose;
	}
}
