using System.Drawing;

namespace ns24;

internal class Class1148
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private uint uint_0;

	public float X
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			method_5();
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
			method_5();
		}
	}

	public float Width
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
			method_5();
		}
	}

	public float Height
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
			method_5();
		}
	}

	public float Left
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			method_5();
		}
	}

	public float Top
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
			method_5();
		}
	}

	public float Right
	{
		get
		{
			return float_0 + float_3;
		}
		set
		{
			float_3 = value - float_0;
			method_5();
		}
	}

	public float Bottom
	{
		get
		{
			return float_1 + float_2;
		}
		set
		{
			float_2 = value - float_1;
			method_5();
		}
	}

	public uint Version => uint_0;

	public Class1148()
	{
		Reset();
	}

	public Class1148(float x, float y, float width, float height)
	{
		float_0 = x;
		float_1 = y;
		float_3 = width;
		float_2 = height;
	}

	public Class1148(Class1148 source)
	{
		method_0(source);
	}

	public void method_0(Class1148 source)
	{
		float_0 = source.X;
		float_1 = source.Y;
		float_3 = source.Width;
		float_2 = source.Height;
		method_5();
	}

	internal static Class1148 smethod_0(float left, float top, float right, float bottom)
	{
		return new Class1148(left, top, right - left, bottom - top);
	}

	public RectangleF method_1(RectangleF rect)
	{
		return new RectangleF(rect.X + float_0 * rect.Width, rect.Y + float_1 * rect.Height, float_3 * rect.Width, float_2 * rect.Height);
	}

	public Class1148 method_2(Class1148 rect)
	{
		return new Class1148(rect.X + float_0 * rect.Width, rect.Y + float_1 * rect.Height, float_3 * rect.Width, float_2 * rect.Height);
	}

	public bool method_3()
	{
		if (float_0 == 0f && float_1 == 0f && float_2 == 1f && float_3 == 1f)
		{
			return false;
		}
		return true;
	}

	public void Reset()
	{
		float_0 = 0f;
		float_1 = 0f;
		float_2 = 1f;
		float_3 = 1f;
		method_5();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Class1148 obj2))
		{
			return false;
		}
		return method_4(obj2);
	}

	public bool method_4(Class1148 obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (float_0 != obj.float_0)
		{
			return false;
		}
		if (float_1 != obj.float_1)
		{
			return false;
		}
		if (float_3 != obj.float_3)
		{
			return false;
		}
		if (float_2 != obj.float_2)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return 23454;
	}

	private void method_5()
	{
		uint_0++;
	}
}
