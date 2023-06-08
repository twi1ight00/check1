using System;

namespace ns67;

internal sealed class Class3373 : ICloneable
{
	private double double_0;

	private double double_1;

	private Enum466 enum466_0 = Enum466.const_2;

	public double Width
	{
		get
		{
			return double_0;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_0 = value;
		}
	}

	public double Height
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_1 = value;
		}
	}

	public Enum466 PresetBevel
	{
		get
		{
			return enum466_0;
		}
		set
		{
			enum466_0 = value;
		}
	}

	public Class3373()
	{
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3373 method_0()
	{
		return new Class3373(this);
	}

	private Class3373(Class3373 src)
	{
		double_0 = src.double_0;
		double_1 = src.double_0;
		enum466_0 = src.enum466_0;
	}
}
