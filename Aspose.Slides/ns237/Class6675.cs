using ns224;

namespace ns237;

internal class Class6675
{
	private Class6002 class6002_0 = new Class6002();

	private Class6670 class6670_0 = Class6670.DeviceGray;

	private Class6670 class6670_1 = Class6670.DeviceGray;

	private Class5998 class5998_0 = Class5998.class5998_7;

	private Class5998 class5998_1 = Class5998.class5998_7;

	private float float_0 = 1f;

	private float float_1 = 1f;

	private float float_2;

	private Class6527 class6527_0;

	private float float_3;

	private int int_0;

	private float float_4;

	private float float_5 = 1f;

	private int int_1;

	private int int_2;

	private float float_6 = 10f;

	internal Class6002 TransformationMatrix
	{
		get
		{
			return class6002_0;
		}
		set
		{
			class6002_0 = value;
		}
	}

	internal Class6670 StrokingColorSpace
	{
		get
		{
			return class6670_0;
		}
		set
		{
			class6670_0 = value;
		}
	}

	internal Class6670 NonStrokingColorSpace
	{
		get
		{
			return class6670_1;
		}
		set
		{
			class6670_1 = value;
		}
	}

	internal Class5998 StrokingColor
	{
		get
		{
			return class5998_0;
		}
		set
		{
			class5998_0 = value;
		}
	}

	internal float StrokingAlpha
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	internal float NonStrokingAlpha
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	internal Class5998 NonStrokingColor
	{
		get
		{
			return class5998_1;
		}
		set
		{
			class5998_1 = value;
		}
	}

	internal float TextLeading
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	internal Class6527 TextFont
	{
		get
		{
			return class6527_0;
		}
		set
		{
			class6527_0 = value;
		}
	}

	internal float TextFontSize
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	internal int TextRenderingMode
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal float TextCharSpace
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	internal float LineWidth
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	internal int LineCap
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	internal int LineJoin
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	internal float MiterLimit
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	internal Class6675()
	{
	}

	internal Class6675 Clone()
	{
		Class6675 @class = (Class6675)MemberwiseClone();
		@class.class6002_0 = class6002_0.Clone();
		return @class;
	}
}
