using System;
using System.Drawing.Drawing2D;
using ns224;
using ns233;

namespace ns264;

internal class Class6495 : Interface318
{
	private enum Enum867
	{
		const_0,
		const_1,
		const_2,
		const_3
	}

	private Enum839 enum839_0;

	private float float_0;

	private Class5998 class5998_0;

	private int int_0;

	private Enum841 enum841_0;

	private byte[] byte_0;

	private Enum867 enum867_0;

	Enum866 Interface318.Type => Enum866.const_2;

	public int Handle
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal Enum839 Style
	{
		set
		{
			enum839_0 = value;
			method_4();
		}
	}

	internal Class5998 Color
	{
		set
		{
			class5998_0 = value;
		}
	}

	internal Class6495()
	{
		enum839_0 = Enum839.flag_0;
		float_0 = 1f;
		class5998_0 = Class5998.class5998_7;
		enum841_0 = Enum841.const_0;
		enum867_0 = Enum867.const_1;
	}

	internal void method_0(Class6501 reader)
	{
		enum839_0 = (Enum839)reader.ReadInt16();
		float_0 = Math.Max(reader.ReadInt16(), (short)1);
		reader.ReadInt16();
		class5998_0 = reader.method_9();
		method_4();
	}

	internal void method_1(Class6498 reader)
	{
		int_0 = reader.ReadInt32();
		enum839_0 = (Enum839)reader.ReadInt32();
		float_0 = Math.Max(reader.ReadInt32(), 1);
		reader.ReadInt32();
		class5998_0 = reader.method_9();
		method_4();
	}

	internal void method_2(Class6498 reader)
	{
		int_0 = reader.ReadInt32();
		reader.ReadInt32();
		int headerLength = reader.ReadInt32();
		reader.ReadInt32();
		int bmpLength = reader.ReadInt32();
		enum839_0 = (Enum839)reader.ReadUInt32();
		float_0 = Math.Max(reader.ReadInt32(), 1);
		Enum840 @enum = (Enum840)reader.ReadUInt32();
		if (@enum != 0 && @enum != Enum840.const_3)
		{
			reader.ReadInt32();
		}
		else
		{
			class5998_0 = reader.method_9();
		}
		enum841_0 = (Enum841)reader.ReadInt32();
		if ((@enum & Enum840.const_3) == Enum840.const_3)
		{
			enum867_0 = Enum867.const_2;
		}
		reader.method_0();
		if (@enum == Enum840.const_7)
		{
			enum867_0 = Enum867.const_3;
			reader.ReadInt32();
			byte_0 = Class6148.smethod_22(reader, headerLength, bmpLength);
		}
		method_4();
	}

	internal Class6003 method_3(Class5998 backColor)
	{
		Class6003 result = null;
		switch (enum867_0)
		{
		case Enum867.const_0:
			return result;
		default:
			result = new Class6003(class5998_0, float_0);
			break;
		case Enum867.const_2:
		{
			Class5990 brush = new Class5996((HatchStyle)enum841_0, class5998_0, backColor);
			result = new Class6003(brush, float_0);
			break;
		}
		case Enum867.const_3:
		{
			Class5990 brush = new Class5995(byte_0, WrapMode.Tile);
			result = new Class6003(brush, float_0);
			break;
		}
		}
		smethod_0(result, enum839_0 & Enum839.flag_9);
		smethod_1(result, enum839_0 & Enum839.flag_13);
		smethod_2(result, enum839_0 & Enum839.flag_17);
		return result;
	}

	private void method_4()
	{
		if ((enum839_0 & Enum839.flag_9) == Enum839.flag_5)
		{
			enum867_0 = Enum867.const_0;
		}
	}

	private static void smethod_0(Class6003 pen, Enum839 style)
	{
		switch (style)
		{
		case Enum839.flag_0:
			pen.DashStyle = DashStyle.Solid;
			break;
		case Enum839.flag_1:
			pen.DashStyle = DashStyle.Dash;
			break;
		case Enum839.flag_2:
			pen.DashStyle = DashStyle.Dot;
			break;
		case Enum839.flag_3:
			pen.DashStyle = DashStyle.DashDot;
			break;
		case Enum839.flag_4:
			pen.DashStyle = DashStyle.DashDotDot;
			break;
		}
	}

	private static void smethod_1(Class6003 pen, Enum839 style)
	{
		LineCap endCap = (pen.StartCap = style switch
		{
			Enum839.flag_12 => LineCap.Flat, 
			Enum839.flag_11 => LineCap.Square, 
			Enum839.flag_0 => LineCap.Round, 
			_ => throw new InvalidOperationException("Unknown pen end cap style."), 
		});
		pen.EndCap = endCap;
	}

	private static void smethod_2(Class6003 pen, Enum839 style)
	{
		switch (style)
		{
		default:
			throw new InvalidOperationException("Unknown pen join style.");
		case Enum839.flag_16:
			pen.LineJoin = LineJoin.Miter;
			break;
		case Enum839.flag_15:
			pen.LineJoin = LineJoin.Bevel;
			break;
		case Enum839.flag_0:
			pen.LineJoin = LineJoin.Round;
			break;
		}
	}
}
