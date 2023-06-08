using ns56;

namespace ns25;

internal class Class885
{
	private float float_0 = float.NaN;

	private float float_1 = float.NaN;

	private float float_2 = float.NaN;

	private float float_3 = float.NaN;

	private Class2081 class2081_0;

	private Class2081 class2081_1;

	private Class2081 class2081_2;

	private Class2081 class2081_3;

	private Class1885 class1885_0;

	private Class1885 class1885_1;

	public float X
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

	public float Y
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

	public float Width
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

	public float Height
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

	public float Right => float_0 + float_2;

	public float Bottom => float_1 + float_3;

	public Class2081 XMode
	{
		get
		{
			return class2081_0;
		}
		set
		{
			class2081_0 = value;
		}
	}

	public Class2081 YMode
	{
		get
		{
			return class2081_1;
		}
		set
		{
			class2081_1 = value;
		}
	}

	public Class2081 WMode
	{
		get
		{
			return class2081_2;
		}
		set
		{
			class2081_2 = value;
		}
	}

	public Class2081 HMode
	{
		get
		{
			return class2081_3;
		}
		set
		{
			class2081_3 = value;
		}
	}

	public Class1885 ExtensionListOfLayout
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

	public Class1885 ExtensionListOfManualLayout
	{
		get
		{
			return class1885_1;
		}
		set
		{
			class1885_1 = value;
		}
	}
}
