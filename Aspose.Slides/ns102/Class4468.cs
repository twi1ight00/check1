using ns121;
using ns99;

namespace ns102;

internal class Class4468 : Class4465
{
	private Class4413 class4413_0;

	private uint uint_1;

	private Class4518 class4518_1;

	private Class4509 class4509_1;

	private object object_0 = new object();

	private object object_1 = new object();

	private string string_0;

	private string string_1;

	private string string_2;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	private double double_6;

	internal double double_7 = double.MinValue;

	internal double double_8 = double.MinValue;

	private double double_9;

	private double double_10;

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

	public string FamilyName
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

	public string Weight
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public double ItalicAngle
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double UnderlinePosition
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public double UnderlineThickness
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public double CapHeight
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
		}
	}

	public double XHeight
	{
		get
		{
			return double_6;
		}
		set
		{
			double_6 = value;
		}
	}

	public override double Ascender
	{
		get
		{
			if (double_7 == double.MinValue)
			{
				double_7 = FontBBox.double_3;
			}
			return double_7;
		}
	}

	public override double Descender
	{
		get
		{
			if (double_8 == double.MinValue)
			{
				double_8 = FontBBox.double_1;
			}
			return double_8;
		}
	}

	public double StdHW
	{
		get
		{
			return double_9;
		}
		set
		{
			double_9 = value;
		}
	}

	public double StdVW
	{
		get
		{
			return double_10;
		}
		set
		{
			double_10 = value;
		}
	}

	public override Class4518 FontBBox
	{
		get
		{
			if (class4518_1 == null)
			{
				lock (object_0)
				{
					if (class4518_1 == null)
					{
						if (!(class4413_0 is Class4414))
						{
							class4518_1 = new Class4518(class4413_0.Type1FontDictionary.FontBBox.Array[0], class4413_0.Type1FontDictionary.FontBBox.Array[1], class4413_0.Type1FontDictionary.FontBBox.Array[2], class4413_0.Type1FontDictionary.FontBBox.Array[3]);
						}
						else
						{
							class4518_1 = new Class4518();
						}
					}
				}
			}
			return class4518_1;
		}
		set
		{
			class4518_1 = value;
		}
	}

	public override Class4509 FontMatrix
	{
		get
		{
			if (class4509_1 == null)
			{
				lock (object_1)
				{
					if (class4509_1 == null)
					{
						if (!(class4413_0 is Class4414))
						{
							class4509_1 = new Class4509(class4413_0.Type1FontDictionary.FontMatrix.Matrix);
						}
						else
						{
							class4509_1 = new Class4509();
						}
					}
				}
			}
			return class4509_1;
		}
		set
		{
			class4509_1 = value;
		}
	}

	public override uint UnitsPerEM
	{
		get
		{
			if (uint_1 == 0)
			{
				lock (object_0)
				{
					if (uint_1 == 0)
					{
						if (!(class4413_0 is Class4414))
						{
							uint_1 = (uint)(1.0 / class4413_0.Type1FontDictionary.FontMatrix.Matrix[0]);
						}
						else
						{
							uint_1 = 1000u;
						}
					}
				}
			}
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	internal Class4468(Class4413 font)
	{
		class4413_0 = font;
	}

	internal override int vmethod_0(Class4506 glyphID)
	{
		Class4507 @class = glyphID as Class4507;
		if (@class != null)
		{
			return @class.Value.GetHashCode();
		}
		return glyphID.GetHashCode();
	}

	public override double imethod_1(Class4506 glyphID)
	{
		double num = base.imethod_1(glyphID);
		if (num == 0.0 && !(class4413_0 is Class4414))
		{
			Class4480 @class = class4413_0.imethod_0(glyphID);
			if (@class != null)
			{
				return @class.WidthVectorX;
			}
		}
		return num;
	}
}
