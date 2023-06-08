using System;
using System.Drawing;
using ns284;
using ns298;
using ns301;

namespace ns292;

internal class Class6795 : ICloneable
{
	private Enum951 enum951_0;

	private Color color_0;

	private Class6959 class6959_0;

	public Enum951 Style
	{
		get
		{
			return enum951_0;
		}
		set
		{
			enum951_0 = value;
		}
	}

	public Color Color
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Class6959 Length
	{
		get
		{
			return class6959_0;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6959_0 = value;
		}
	}

	public Class6795()
	{
		enum951_0 = Enum951.const_3;
		class6959_0 = new Class6959(1f, Enum955.const_4);
		color_0 = Color.Gray;
	}

	public Class6795(Class6959 length, Enum951 style, Color color)
	{
		Length = length;
		Style = style;
		Color = color;
	}

	public override string ToString()
	{
		return string.Format(arg1: enum951_0 switch
		{
			Enum951.const_0 => "none", 
			Enum951.const_1 => "dotted", 
			Enum951.const_2 => "dashed", 
			Enum951.const_3 => "solid", 
			Enum951.const_4 => "double", 
			Enum951.const_5 => "groove", 
			Enum951.const_6 => "ridge", 
			Enum951.const_7 => "inset", 
			Enum951.const_8 => "outset", 
			_ => "none", 
		}, format: "{0} {1} {2}", arg0: class6959_0, arg2: Class6872.smethod_0(color_0));
	}

	public object Clone()
	{
		return new Class6795(Length, Style, Color);
	}
}
