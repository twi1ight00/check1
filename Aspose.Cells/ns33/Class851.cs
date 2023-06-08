using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;

namespace ns33;

internal class Class851 : IDisposable, Interface33
{
	private Class821 class821_0;

	private Class822 class822_0;

	private Class840 class840_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private bool bool_0;

	public Interface25 Border => class840_0;

	public Interface8 Area => class822_0;

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

	internal Class851(Class821 class821_1)
	{
		class821_0 = class821_1;
		class840_0 = new Class840(class821_1, Enum57.const_6);
		class822_0 = new Class822(class821_1, this, Enum52.const_4);
		class822_0.Formatting = Enum71.const_1;
		class822_0.ForegroundColor = Color.Empty;
		class840_0.Formatting = Enum71.const_1;
		class840_0.Color = Color.Empty;
	}

	[SpecialName]
	public Class840 method_0()
	{
		return class840_0;
	}

	[SpecialName]
	internal Class822 method_1()
	{
		return class822_0;
	}

	[SpecialName]
	internal float method_2()
	{
		return X + Width / 2f;
	}

	internal float method_3(bool bool_1, int int_0, int int_1)
	{
		float num = (float)class821_0.GapWidth / 100f;
		float num2 = 0f;
		num2 = ((!bool_1) ? (Width / (float)int_0) : (Height / (float)int_0));
		return num2 / ((float)int_1 + num);
	}

	internal float method_4()
	{
		float num = (float)class821_0.GapDepth / 100f;
		return Depth / (1f + num);
	}

	~Class851()
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
			if (bool_1 && class822_0 != null)
			{
				class822_0.Dispose();
			}
			bool_0 = true;
		}
	}
}
