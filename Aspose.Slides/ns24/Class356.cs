using Aspose.Slides;
using ns16;
using ns56;

namespace ns24;

internal class Class356 : Class278
{
	private Enum378 enum378_0 = Enum378.const_0;

	private Class520 class520_0 = new Class520();

	private NullableBool nullableBool_0 = NullableBool.NotDefined;

	private float float_0 = 1f;

	private float float_1;

	private float float_2 = float.NaN;

	private NullableBool nullableBool_1 = NullableBool.NotDefined;

	private TextVerticalOverflowType textVerticalOverflowType_0 = TextVerticalOverflowType.NotDefined;

	private int int_0 = -1;

	private double double_0 = double.NaN;

	private NullableBool nullableBool_2 = NullableBool.NotDefined;

	private NullableBool nullableBool_3 = NullableBool.NotDefined;

	private bool bool_0;

	private NullableBool nullableBool_4 = NullableBool.NotDefined;

	private Class2605 class2605_0;

	private Class1885 class1885_0;

	private NullableBool nullableBool_5 = NullableBool.NotDefined;

	private Class1916 class1916_0;

	private uint uint_0;

	public Enum378 TextHorizontalOverflowType
	{
		get
		{
			return enum378_0;
		}
		set
		{
			enum378_0 = value;
			method_2();
		}
	}

	public Class520 TextShape => class520_0;

	public NullableBool RightToLeftColumns
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			nullableBool_0 = value;
			method_2();
		}
	}

	public float NormalAutofitFontScale
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			method_2();
		}
	}

	public float NormalAutofitLineSpaceReduction
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
			method_2();
		}
	}

	public Class2605 Text3DFormat
	{
		get
		{
			return class2605_0;
		}
		set
		{
			class2605_0 = value;
			method_2();
		}
	}

	public float RotationAngle
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
			method_2();
		}
	}

	public NullableBool FirstLastParagraphSpacing
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			nullableBool_1 = value;
			method_2();
		}
	}

	public TextVerticalOverflowType TextVerticalOverflowType
	{
		get
		{
			return textVerticalOverflowType_0;
		}
		set
		{
			textVerticalOverflowType_0 = value;
			method_2();
		}
	}

	public int ColumnCount
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			method_2();
		}
	}

	public double ColumnSpacing
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			method_2();
		}
	}

	public NullableBool FromWordArt
	{
		get
		{
			return nullableBool_2;
		}
		set
		{
			nullableBool_2 = value;
			method_2();
		}
	}

	public NullableBool ForceAntiAliased
	{
		get
		{
			return nullableBool_3;
		}
		set
		{
			nullableBool_3 = value;
			method_2();
		}
	}

	public bool RemainUpright
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			method_2();
		}
	}

	public NullableBool CompatibleLineSpacing
	{
		get
		{
			return nullableBool_4;
		}
		set
		{
			nullableBool_4 = value;
			method_2();
		}
	}

	public Class1885 ExtensionList
	{
		get
		{
			return class1885_0;
		}
		set
		{
			class1885_0 = value;
		}
	}

	public NullableBool Wrap
	{
		get
		{
			return nullableBool_5;
		}
		set
		{
			nullableBool_5 = value;
			method_2();
		}
	}

	public Class1916 Scene3d
	{
		get
		{
			return class1916_0;
		}
		set
		{
			class1916_0 = value;
			method_2();
		}
	}

	internal uint Version => uint_0 + class520_0.Version;

	public void method_0(Class356 source)
	{
		enum378_0 = source.enum378_0;
		class520_0.method_0(source.class520_0);
		nullableBool_0 = source.nullableBool_0;
		float_0 = source.float_0;
		float_1 = source.float_1;
		float_2 = source.float_2;
		nullableBool_1 = source.nullableBool_1;
		textVerticalOverflowType_0 = source.textVerticalOverflowType_0;
		int_0 = source.int_0;
		double_0 = source.double_0;
		nullableBool_2 = source.nullableBool_2;
		nullableBool_3 = source.nullableBool_3;
		bool_0 = source.bool_0;
		nullableBool_4 = source.nullableBool_4;
		class2605_0 = source.class2605_0;
		if (source.class1885_0 != null)
		{
			class1885_0 = source.class1885_0.Clone();
		}
		nullableBool_5 = source.nullableBool_5;
		class1916_0 = source.class1916_0;
		method_2();
	}

	public bool method_1(Class356 propertiesOfTextBlock)
	{
		if (float_2.Equals(propertiesOfTextBlock.float_2) && nullableBool_4 == propertiesOfTextBlock.nullableBool_4 && class1885_0 == propertiesOfTextBlock.class1885_0 && nullableBool_1 == propertiesOfTextBlock.nullableBool_1 && nullableBool_3 == propertiesOfTextBlock.nullableBool_3 && enum378_0 == propertiesOfTextBlock.enum378_0 && textVerticalOverflowType_0 == propertiesOfTextBlock.textVerticalOverflowType_0)
		{
			return true;
		}
		return false;
	}

	private void method_2()
	{
		uint_0++;
	}
}
