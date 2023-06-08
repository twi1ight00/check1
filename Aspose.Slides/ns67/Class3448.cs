using System;
using System.Drawing.Drawing2D;

namespace ns67;

internal sealed class Class3448 : ICloneable
{
	private bool bool_0;

	private bool bool_1;

	private double double_0;

	private Class3456 class3456_0 = new Class3456(0.0, 0.0);

	private Class3455 class3455_0 = new Class3455(0.0, 0.0);

	public Class3456 Offset
	{
		get
		{
			return class3456_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class3456_0 = value.method_0();
		}
	}

	public Class3455 Extents
	{
		get
		{
			return class3455_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class3455_0 = value.method_0();
		}
	}

	public bool HorizontalFlip
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool VerticalFlip
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public double Rotation
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value % 21600000.0;
		}
	}

	public Class3448()
		: this(new Class3456(0.0, 0.0), new Class3455(0.0, 0.0))
	{
	}

	public Class3448(Class3456 offset, Class3455 extents, double rotation, bool horizontalFlip, bool verticalFlip)
	{
		bool_0 = horizontalFlip;
		bool_1 = verticalFlip;
		double_0 = rotation;
		Offset = offset;
		Extents = extents;
	}

	public Class3448(Class3456 offset, Class3455 extents)
		: this(offset, extents, 0.0, horizontalFlip: false, verticalFlip: false)
	{
	}

	public object Clone()
	{
		return new Class3448(class3456_0, class3455_0, double_0, bool_0, bool_1);
	}

	public Class3448 method_0()
	{
		return (Class3448)Clone();
	}

	internal Matrix method_1()
	{
		Matrix matrix = new Matrix(bool_0 ? (-1f) : 1f, 0f, 0f, bool_1 ? (-1f) : 1f, 0f, 0f);
		if (0.0 != double_0)
		{
			double num = double_0 / 60000.0;
			matrix.Rotate((float)num);
		}
		return matrix;
	}
}
