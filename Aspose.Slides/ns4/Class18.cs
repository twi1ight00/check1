using System;
using System.Drawing;
using Aspose.Slides;

namespace ns4;

internal class Class18
{
	private Color color_0;

	private Class21.Delegate2 delegate2_0;

	private bool bool_0;

	internal Color Color
	{
		get
		{
			if (!bool_0)
			{
				throw new InvalidOperationException("Color is not resolved yet.");
			}
			return color_0;
		}
	}

	internal Class21.Delegate2 ColorResolver
	{
		get
		{
			return delegate2_0;
		}
		set
		{
			delegate2_0 = value;
			bool_0 = false;
		}
	}

	internal Class18()
	{
	}

	internal Class18(Class21.Delegate2 colorResolver)
	{
		delegate2_0 = colorResolver;
	}

	internal void method_0(IBaseSlide slide, FloatColor styleColor)
	{
		color_0 = delegate2_0(slide, styleColor);
		bool_0 = true;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Class18 obj2))
		{
			return false;
		}
		return method_1(obj2);
	}

	internal bool method_1(Class18 obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (bool_0 && obj.bool_0)
		{
			if (!color_0.Equals(obj.color_0))
			{
				return false;
			}
			return true;
		}
		return false;
	}
}
