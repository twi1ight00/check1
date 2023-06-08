using System;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Slides;
using ns60;

namespace ns63;

internal class Class2974 : Class2972, ICloneable
{
	[CompilerGenerated]
	private short short_9;

	[CompilerGenerated]
	private short short_10;

	[CompilerGenerated]
	private short short_11;

	[CompilerGenerated]
	private short short_12;

	public NullableBool HasBullet
	{
		get
		{
			return method_7(Enum446.flag_0);
		}
		set
		{
			method_8(Enum446.flag_0, value);
		}
	}

	public NullableBool BulletHasFont
	{
		get
		{
			return method_7(Enum446.flag_1);
		}
		set
		{
			method_8(Enum446.flag_1, value);
		}
	}

	public NullableBool BulletHasColor
	{
		get
		{
			return method_7(Enum446.flag_2);
		}
		set
		{
			method_8(Enum446.flag_2, value);
		}
	}

	public NullableBool BulletHasSize
	{
		get
		{
			return method_7(Enum446.flag_3);
		}
		set
		{
			method_8(Enum446.flag_3, value);
		}
	}

	public short? BulletChar
	{
		get
		{
			if (method_5(Enum450.flag_7))
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
			method_6(Enum450.flag_7, value.HasValue);
		}
	}

	public ushort? BulletFontRef
	{
		get
		{
			if (method_5(Enum450.flag_4))
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
			method_6(Enum450.flag_4, value.HasValue);
		}
	}

	public short? BulletSize
	{
		get
		{
			if (method_5(Enum450.flag_6))
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
			method_6(Enum450.flag_6, value.HasValue);
		}
	}

	public Class2966 BulletColor
	{
		get
		{
			if (method_5(Enum450.flag_5))
			{
				return class2966_0;
			}
			return null;
		}
		set
		{
			class2966_0 = value;
			method_6(Enum450.flag_5, value != null);
		}
	}

	public Enum455? TextAlignment
	{
		get
		{
			if (method_5(Enum450.flag_11))
			{
				return enum455_0;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				enum455_0 = value.Value;
			}
			method_6(Enum450.flag_11, value.HasValue);
		}
	}

	public short? LineSpacing
	{
		get
		{
			if (method_5(Enum450.flag_12))
			{
				return short_2;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				short_2 = value.Value;
			}
			method_6(Enum450.flag_12, value.HasValue);
		}
	}

	public short? SpaceBefore
	{
		get
		{
			if (method_5(Enum450.flag_13))
			{
				return short_3;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				short_3 = value.Value;
			}
			method_6(Enum450.flag_13, value.HasValue);
		}
	}

	public short? SpaceAfter
	{
		get
		{
			if (method_5(Enum450.flag_14))
			{
				return short_4;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				short_4 = value.Value;
			}
			method_6(Enum450.flag_14, value.HasValue);
		}
	}

	public short? LeftMargin
	{
		get
		{
			if (method_5(Enum450.flag_8))
			{
				return short_5;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				short_5 = value.Value;
			}
			method_6(Enum450.flag_8, value.HasValue);
		}
	}

	public short? Indent
	{
		get
		{
			if (method_5(Enum450.flag_10))
			{
				return short_6;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				short_6 = value.Value;
			}
			method_6(Enum450.flag_10, value.HasValue);
		}
	}

	public short? DefaultTabSize
	{
		get
		{
			if (method_5(Enum450.flag_15))
			{
				return short_7;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				short_7 = value.Value;
			}
			method_6(Enum450.flag_15, value.HasValue);
		}
	}

	public Class2942 TabStops
	{
		get
		{
			if (method_5(Enum450.flag_20))
			{
				return class2942_0;
			}
			return null;
		}
		set
		{
			class2942_0 = value;
			method_6(Enum450.flag_20, value != null);
		}
	}

	public Enum380? FontAlign
	{
		get
		{
			if (method_5(Enum450.flag_16))
			{
				return enum380_0;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				enum380_0 = value.Value;
			}
			method_6(Enum450.flag_16, value.HasValue);
		}
	}

	public NullableBool CharWrap
	{
		get
		{
			return method_10(Enum440.flag_0);
		}
		set
		{
			method_11(Enum440.flag_0, value);
		}
	}

	public NullableBool WordWrap
	{
		get
		{
			return method_10(Enum440.flag_1);
		}
		set
		{
			method_11(Enum440.flag_1, value);
		}
	}

	public NullableBool Overflow
	{
		get
		{
			return method_10(Enum440.flag_2);
		}
		set
		{
			method_11(Enum440.flag_2, value);
		}
	}

	public Enum445? TextDirection
	{
		get
		{
			if (method_5(Enum450.flag_21))
			{
				return enum445_0;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				enum445_0 = value.Value;
			}
			method_6(Enum450.flag_21, value.HasValue);
		}
	}

	[Obsolete]
	public short BulletId
	{
		[CompilerGenerated]
		get
		{
			return short_9;
		}
		[CompilerGenerated]
		set
		{
			short_9 = value;
		}
	}

	[Obsolete]
	public short BulletStart
	{
		[CompilerGenerated]
		get
		{
			return short_10;
		}
		[CompilerGenerated]
		set
		{
			short_10 = value;
		}
	}

	[Obsolete]
	public short NumberingType
	{
		[CompilerGenerated]
		get
		{
			return short_11;
		}
		[CompilerGenerated]
		set
		{
			short_11 = value;
		}
	}

	[Obsolete]
	public short HasAutoNumbering
	{
		[CompilerGenerated]
		get
		{
			return short_12;
		}
		[CompilerGenerated]
		set
		{
			short_12 = value;
		}
	}

	public Class2974()
	{
		BulletId = -1;
		BulletStart = -1;
		NumberingType = -1;
		HasAutoNumbering = -1;
	}

	public override void vmethod_1(Class2972 textPFExceptionBase)
	{
		base.vmethod_1(textPFExceptionBase);
		if (textPFExceptionBase is Class2974)
		{
			Class2974 @class = (Class2974)textPFExceptionBase;
			if (HasBullet == NullableBool.False && @class.HasBullet != NullableBool.True)
			{
				HasBullet = NullableBool.NotDefined;
			}
			if (BulletHasFont == NullableBool.False && @class.BulletHasFont != NullableBool.True)
			{
				BulletHasFont = NullableBool.NotDefined;
			}
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("TextPFException");
		stringBuilder.Append(base.ToString());
		return stringBuilder.ToString();
	}

	public object Clone()
	{
		Class2974 @class = new Class2974();
		@class.vmethod_0(this);
		return @class;
	}
}
