using System;
using System.Text;
using Aspose.Slides;

namespace ns63;

internal class Class2971 : Class2969, ICloneable
{
	public NullableBool Bold
	{
		get
		{
			return method_8(Enum422.flag_0);
		}
		set
		{
			method_9(Enum422.flag_0, value);
		}
	}

	public NullableBool Italic
	{
		get
		{
			return method_8(Enum422.flag_1);
		}
		set
		{
			method_9(Enum422.flag_1, value);
		}
	}

	public NullableBool Underline
	{
		get
		{
			return method_8(Enum422.flag_2);
		}
		set
		{
			method_9(Enum422.flag_2, value);
		}
	}

	public NullableBool Shadow
	{
		get
		{
			return method_8(Enum422.flag_4);
		}
		set
		{
			method_9(Enum422.flag_4, value);
		}
	}

	public NullableBool Fehint
	{
		get
		{
			return method_8(Enum422.flag_5);
		}
		set
		{
			method_9(Enum422.flag_5, value);
		}
	}

	public NullableBool Kumi
	{
		get
		{
			return method_8(Enum422.flag_7);
		}
		set
		{
			method_9(Enum422.flag_7, value);
		}
	}

	public NullableBool Emboss
	{
		get
		{
			return method_8(Enum422.flag_9);
		}
		set
		{
			method_9(Enum422.flag_9, value);
		}
	}

	public byte? PP9RT
	{
		get
		{
			if (method_6(Enum421.flag_10))
			{
				return (byte)((uint)(enum422_0 & Enum422.flag_10) >> 10);
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				enum422_0 = (enum422_0 | Enum422.flag_10) ^ Enum422.flag_10;
				enum422_0 |= (Enum422)((value.Value & 0xF) << 10);
			}
			method_7(Enum421.flag_10, value.HasValue);
		}
	}

	public ushort? FontRef
	{
		get
		{
			if (method_6(Enum421.flag_12))
			{
				return ushort_0;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				ushort_0 = value.Value;
			}
			method_7(Enum421.flag_12, value.HasValue);
		}
	}

	public ushort? OldEAFontRef
	{
		get
		{
			if (method_6(Enum421.flag_17))
			{
				return ushort_1;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				ushort_1 = value.Value;
			}
			method_7(Enum421.flag_17, value.HasValue);
		}
	}

	public ushort? AnsiFontRef
	{
		get
		{
			if (method_6(Enum421.flag_18))
			{
				return ushort_2;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				ushort_2 = value.Value;
			}
			method_7(Enum421.flag_18, value.HasValue);
		}
	}

	public ushort? SymbolFontRef
	{
		get
		{
			if (method_6(Enum421.flag_19))
			{
				return ushort_3;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				ushort_3 = value.Value;
			}
			method_7(Enum421.flag_19, value.HasValue);
		}
	}

	public short? FontSize
	{
		get
		{
			if (method_6(Enum421.flag_13))
			{
				return short_0;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				short_0 = value.Value;
			}
			method_7(Enum421.flag_13, value.HasValue);
		}
	}

	public Class2966 Color
	{
		get
		{
			if (method_6(Enum421.flag_14))
			{
				return class2966_0;
			}
			return null;
		}
		set
		{
			class2966_0 = value;
			method_7(Enum421.flag_14, value != null);
		}
	}

	public short? Position
	{
		get
		{
			if (method_6(Enum421.flag_15))
			{
				return short_1;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				short_1 = value.Value;
			}
			method_7(Enum421.flag_15, value.HasValue);
		}
	}

	public bool IncludeUnusedFlags
	{
		get
		{
			return method_6(Enum421.flag_11 | Enum421.flag_3 | Enum421.flag_6 | Enum421.flag_8);
		}
		set
		{
			method_7(Enum421.flag_11 | Enum421.flag_3 | Enum421.flag_6 | Enum421.flag_8, value);
		}
	}

	public override void vmethod_0(Class2969 textCFExceptionBase)
	{
		base.vmethod_0(textCFExceptionBase);
		if (textCFExceptionBase is Class2971)
		{
			Class2971 @class = (Class2971)textCFExceptionBase;
			if (Bold == NullableBool.False && @class.Bold != NullableBool.True)
			{
				Bold = NullableBool.NotDefined;
			}
			if (Italic == NullableBool.False && @class.Italic != NullableBool.True)
			{
				Italic = NullableBool.NotDefined;
			}
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("TextCFException");
		stringBuilder.Append(base.ToString());
		return stringBuilder.ToString();
	}

	public object Clone()
	{
		Class2971 @class = new Class2971();
		@class.method_3(this);
		return @class;
	}
}
