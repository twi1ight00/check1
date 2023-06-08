using System;

namespace ns67;

internal sealed class Class3374 : ICloneable
{
	private double double_0;

	private double double_1;

	private Enum467 enum467_0 = Enum467.const_9;

	private double double_2;

	private Class3373 class3373_0;

	private Class3373 class3373_1;

	private Class3453 class3453_0;

	private Class3453 class3453_1;

	public double ContourWidth
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

	public double ExtrusionHeight
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

	public Enum467 PresetMaterial
	{
		get
		{
			return enum467_0;
		}
		set
		{
			enum467_0 = value;
		}
	}

	public double ShapeDepth
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

	public Class3373 TopBevel
	{
		get
		{
			return class3373_0;
		}
		set
		{
			if (class3373_0 != value)
			{
				class3373_0 = value?.method_0();
			}
		}
	}

	public Class3373 BottomBevel
	{
		get
		{
			return class3373_1;
		}
		set
		{
			if (class3373_1 != value)
			{
				class3373_1 = value?.method_0();
			}
		}
	}

	public Class3453 ContourColor
	{
		get
		{
			return class3453_0;
		}
		set
		{
			if (class3453_0 != value)
			{
				class3453_0 = value?.method_1();
			}
		}
	}

	public Class3453 ExtrusionColor
	{
		get
		{
			return class3453_1;
		}
		set
		{
			if (class3453_1 != value)
			{
				class3453_1 = value?.method_1();
			}
		}
	}

	public Class3374()
	{
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3374 method_0()
	{
		return new Class3374(this);
	}

	private Class3374(Class3374 src)
	{
		ContourWidth = src.ContourWidth;
		ExtrusionHeight = src.ExtrusionHeight;
		PresetMaterial = src.PresetMaterial;
		ShapeDepth = src.ShapeDepth;
		TopBevel = src.TopBevel;
		BottomBevel = src.BottomBevel;
		ContourColor = src.ContourColor;
		ExtrusionColor = src.ExtrusionColor;
	}
}
