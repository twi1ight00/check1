using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns22;

namespace ns18;

internal class Class1413 : Interface46
{
	private enum Enum204
	{
		const_0,
		const_1,
		const_2,
		const_3
	}

	private Enum156 enum156_0;

	private float float_0;

	private Color color_0;

	private uint uint_0;

	private Enum151 enum151_0;

	private Image image_0;

	private Enum204 enum204_0;

	internal Enum156 Style
	{
		set
		{
			enum156_0 = value;
			method_4();
		}
	}

	internal Color Color
	{
		set
		{
			color_0 = value;
		}
	}

	internal Class1413()
	{
		enum156_0 = Enum156.flag_0;
		float_0 = 1f;
		color_0 = Color.Black;
		enum151_0 = Enum151.const_0;
		enum204_0 = Enum204.const_1;
	}

	internal void method_0(Class1429 class1429_0)
	{
		enum156_0 = (Enum156)class1429_0.ReadInt16();
		float_0 = Math.Max(class1429_0.ReadInt16(), (short)1);
		class1429_0.ReadInt16();
		color_0 = class1429_0.method_6();
		method_4();
	}

	internal void method_1(Class1420 class1420_0)
	{
		uint_0 = class1420_0.ReadUInt32();
		enum156_0 = (Enum156)class1420_0.ReadInt32();
		float_0 = Math.Max(class1420_0.ReadInt32(), 1);
		class1420_0.ReadInt32();
		color_0 = class1420_0.method_6();
		method_4();
	}

	internal void method_2(Class1420 class1420_0)
	{
		uint_0 = class1420_0.ReadUInt32();
		class1420_0.ReadInt32();
		int int_ = class1420_0.ReadInt32();
		class1420_0.ReadInt32();
		int int_2 = class1420_0.ReadInt32();
		enum156_0 = (Enum156)class1420_0.ReadUInt32();
		float_0 = Math.Max(class1420_0.ReadInt32(), 1);
		Enum146 @enum = (Enum146)class1420_0.ReadUInt32();
		if (@enum != 0 && @enum != Enum146.const_3)
		{
			class1420_0.ReadInt32();
		}
		else
		{
			color_0 = class1420_0.method_6();
		}
		enum151_0 = (Enum151)class1420_0.ReadInt32();
		if ((@enum & Enum146.const_3) == Enum146.const_3)
		{
			enum204_0 = Enum204.const_2;
		}
		class1420_0.method_0();
		if (@enum == Enum146.const_7)
		{
			enum204_0 = Enum204.const_3;
			class1420_0.ReadInt32();
			image_0 = Class1404.smethod_20(class1420_0, int_, int_2);
		}
		method_4();
	}

	internal Pen method_3(Color color_1)
	{
		Pen result = null;
		switch (enum204_0)
		{
		case Enum204.const_0:
			return result;
		default:
			result = new Pen(color_0, float_0);
			break;
		case Enum204.const_2:
		{
			Brush brush = new HatchBrush((HatchStyle)enum151_0, color_0, color_1);
			result = new Pen(brush, float_0);
			break;
		}
		case Enum204.const_3:
		{
			Brush brush = new TextureBrush(image_0);
			result = new Pen(brush, float_0);
			break;
		}
		}
		smethod_0(result, enum156_0 & Enum156.flag_9);
		smethod_1(result, enum156_0 & Enum156.flag_13);
		smethod_2(result, enum156_0 & Enum156.flag_17);
		return result;
	}

	private void method_4()
	{
		if ((enum156_0 & Enum156.flag_9) == Enum156.flag_5)
		{
			enum204_0 = Enum204.const_0;
		}
	}

	private static void smethod_0(Pen pen_0, Enum156 enum156_1)
	{
		switch (enum156_1)
		{
		case Enum156.flag_0:
			pen_0.DashStyle = DashStyle.Solid;
			break;
		case Enum156.flag_1:
			pen_0.DashStyle = DashStyle.Dash;
			break;
		case Enum156.flag_2:
			pen_0.DashStyle = DashStyle.Dot;
			break;
		case Enum156.flag_3:
			pen_0.DashStyle = DashStyle.DashDot;
			break;
		case Enum156.flag_4:
			pen_0.DashStyle = DashStyle.DashDotDot;
			break;
		}
	}

	[Attribute0(true)]
	private static void smethod_1(Pen pen_0, Enum156 enum156_1)
	{
		LineCap endCap = (pen_0.StartCap = enum156_1 switch
		{
			Enum156.flag_12 => LineCap.Flat, 
			Enum156.flag_11 => LineCap.Square, 
			Enum156.flag_0 => LineCap.Round, 
			_ => throw new Exception("Unknown pen end cap style."), 
		});
		pen_0.EndCap = endCap;
	}

	[Attribute0(true)]
	private static void smethod_2(Pen pen_0, Enum156 enum156_1)
	{
		switch (enum156_1)
		{
		default:
			throw new Exception("Unknown pen join style.");
		case Enum156.flag_16:
			pen_0.LineJoin = LineJoin.Miter;
			break;
		case Enum156.flag_15:
			pen_0.LineJoin = LineJoin.Bevel;
			break;
		case Enum156.flag_0:
			pen_0.LineJoin = LineJoin.Round;
			break;
		}
	}

	[SpecialName]
	Enum203 Interface46.get_Type()
	{
		return Enum203.const_2;
	}

	[SpecialName]
	public uint imethod_0()
	{
		return uint_0;
	}

	[SpecialName]
	public void imethod_1(uint uint_1)
	{
		uint_0 = uint_1;
	}
}
