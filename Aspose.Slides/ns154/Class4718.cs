using System;

namespace ns154;

internal class Class4718
{
	private Class4710 class4710_0;

	private Class4719 class4719_0;

	private string string_0;

	[Obsolete("please use Type1Font.Encoding instead")]
	private Class4716 class4716_0;

	private int int_0;

	private int int_1;

	private Class4720 class4720_0;

	private Class4717 class4717_0;

	private int int_2;

	private Class4721 class4721_0;

	private double double_0;

	private Class4730 class4730_0;

	private Class4709 class4709_0;

	private byte[] byte_0;

	public byte[] EexecRaw
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

	public Class4710 Comments
	{
		get
		{
			return class4710_0;
		}
		set
		{
			class4710_0 = value;
		}
	}

	public Class4719 FontInfo
	{
		get
		{
			return class4719_0;
		}
		set
		{
			class4719_0 = value;
		}
	}

	public string FontName
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

	internal Class4716 Encoding
	{
		get
		{
			return class4716_0;
		}
		set
		{
			class4716_0 = value;
		}
	}

	public int PaintType
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

	public int FontType
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

	public Class4720 FontMatrix
	{
		get
		{
			return class4720_0;
		}
		set
		{
			class4720_0 = value;
		}
	}

	public Class4717 FontBBox
	{
		get
		{
			return class4717_0;
		}
		set
		{
			class4717_0 = value;
		}
	}

	public int UniqueID
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

	public Class4721 Metrics
	{
		get
		{
			return class4721_0;
		}
		set
		{
			class4721_0 = value;
		}
	}

	public double StrokeWidth
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public Class4730 Private
	{
		get
		{
			return class4730_0;
		}
		set
		{
			class4730_0 = value;
		}
	}

	public Class4709 CharStrings
	{
		get
		{
			return class4709_0;
		}
		set
		{
			class4709_0 = value;
		}
	}

	public Class4718()
	{
		class4710_0 = new Class4710();
		class4719_0 = new Class4719();
		class4716_0 = new Class4716();
		class4720_0 = new Class4720();
		class4717_0 = new Class4717();
		class4721_0 = new Class4721();
		class4730_0 = new Class4730();
		class4709_0 = new Class4709();
		class4720_0.Matrix = new double[6] { 1.0, 0.0, 0.0, 1.0, 0.0, 0.0 };
		Class4717 @class = class4717_0;
		double[] array = new double[4];
		@class.Array = array;
	}
}
