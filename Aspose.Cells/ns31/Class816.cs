using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;

namespace ns31;

internal class Class816 : IDisposable, Interface33
{
	private Class787 class787_0;

	private Class788 class788_0;

	private Class806 class806_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private bool bool_0;

	public Interface25 Border => class806_0;

	public Interface8 Area => class788_0;

	internal float X
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

	internal float Y
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

	internal float Width
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

	internal float Depth
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

	internal float Height
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

	internal Class816(Class787 class787_1)
	{
		class787_0 = class787_1;
		class806_0 = new Class806(class787_1);
		class788_0 = new Class788(class787_1);
		Area.Formatting = Enum71.const_1;
		Area.ForegroundColor = Color.White;
		Border.Formatting = Enum71.const_1;
		Border.Color = Color.Black;
	}

	[SpecialName]
	internal Class806 method_0()
	{
		return class806_0;
	}

	[SpecialName]
	internal Class788 method_1()
	{
		return class788_0;
	}

	[SpecialName]
	internal float method_2()
	{
		return X + Width / 2f;
	}

	internal float method_3(bool bool_1, int int_0, int int_1)
	{
		float num = (float)class787_0.GapWidth / 100f;
		float num2 = 0f;
		num2 = ((!bool_1) ? (Width / (float)int_0) : (Height / (float)int_0));
		return num2 / ((float)int_1 + num);
	}

	internal float method_4()
	{
		float num = (float)class787_0.GapDepth / 100f;
		return Depth / (1f + num);
	}

	~Class816()
	{
		Dispose(bool_1: false);
	}

	public void Dispose()
	{
		Dispose(bool_1: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_1)
	{
		if (!bool_0)
		{
			if (bool_1 && class788_0 != null)
			{
				class788_0.Dispose();
			}
			bool_0 = true;
		}
	}
}
