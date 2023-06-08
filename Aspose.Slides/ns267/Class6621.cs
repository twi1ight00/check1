using System;
using System.Drawing;
using System.IO;
using System.Text;
using ns218;
using ns224;
using ns233;
using ns234;
using ns235;

namespace ns267;

internal class Class6621
{
	private Class5946 class5946_0;

	private Class6616 class6616_0;

	public Class6621(Class6616 context, Stream stream)
	{
		class5946_0 = new Class5946(stream, isPrettyFormat: true);
		class6616_0 = context;
	}

	public void method_0(string element)
	{
		class5946_0.method_2(element);
	}

	public void method_1(string rootName)
	{
		class5946_0.method_0(rootName);
	}

	public void method_2()
	{
		class5946_0.method_3();
	}

	public void method_3()
	{
		class5946_0.method_1();
	}

	public void method_4(string name, int value)
	{
		method_0(name);
		method_30(value.ToString(class6616_0.CurrentCulture));
		method_2();
	}

	public void method_5(string name, Class6002 value)
	{
		method_0(name);
		method_30(string.Format("{0} {1} {2} {3} {4} {5}", value.M11.ToString("r", class6616_0.CurrentCulture), value.M12.ToString("r", class6616_0.CurrentCulture), value.M21.ToString("r", class6616_0.CurrentCulture), value.M22.ToString("r", class6616_0.CurrentCulture), value.M31.ToString("r", class6616_0.CurrentCulture), value.M32.ToString("r", class6616_0.CurrentCulture)));
		method_2();
	}

	public void method_6(string name, Class6140 value)
	{
		method_0(name);
		method_28("HighColor", value.HighColor);
		method_28("LowColor", value.LowColor);
		method_2();
	}

	public void method_7(string name, Class6145 value)
	{
		method_0(name);
		method_21("CropLeft", value.CropLeft);
		method_21("CropRight", value.CropRight);
		method_21("CropTop", value.CropTop);
		method_21("CropBottom", value.CropBottom);
		method_2();
	}

	public void method_8(string name, Class6204 node)
	{
		method_0(name);
		class6616_0.method_0().method_2(node);
		method_2();
	}

	public void method_9(string name, Class5990 brush)
	{
		method_0(name);
		new Class6620(class6616_0).Write(brush);
		method_2();
	}

	public void method_10(string name, Enum value)
	{
		method_0(name);
		method_30(Class6625.smethod_1(value));
		method_2();
	}

	public void method_11(string name, float[] value)
	{
		method_0(name);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < value.Length; i++)
		{
			stringBuilder.Append(value[i].ToString("r", class6616_0.CurrentCulture));
			if (i != value.Length - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		method_30(stringBuilder.ToString());
		method_2();
	}

	public void method_12(string name, Class6270 hyperlink)
	{
		method_0(name);
		method_27("JumpType", hyperlink.JumpType);
		if (hyperlink.Page != -1)
		{
			method_23("Page", hyperlink.Page);
		}
		if (Class5964.smethod_20(hyperlink.Target))
		{
			method_25("Target", hyperlink.Target);
		}
		method_13("ActiveRect", hyperlink.ActiveRect);
		method_2();
	}

	public void method_13(string name, RectangleF value)
	{
		method_0(name);
		method_22("X", value.X);
		method_22("Y", value.Y);
		method_22("Width", value.Width);
		method_22("Height", value.Height);
		method_2();
	}

	public void method_14(string name, PointF value)
	{
		method_0(name);
		method_22("X", value.X);
		method_22("Y", value.Y);
		method_2();
	}

	public void method_15(string name, SizeF value)
	{
		method_0(name);
		method_22("Width", value.Width);
		method_22("Height", value.Height);
		method_2();
	}

	public void method_16(string name, Class6003 pen)
	{
		method_0(name);
		method_27("Alignment", pen.Alignment);
		if (pen.CompoundArray != null && pen.CompoundArray.Length != 0)
		{
			method_29("CompoundArray", pen.CompoundArray);
		}
		method_27("DashCap", pen.DashCap);
		method_22("DashOffset", pen.DashOffset);
		if (pen.DashPattern != null && pen.DashPattern.Length != 0)
		{
			method_29("DashPattern", pen.DashPattern);
		}
		method_27("DashStyle", pen.DashStyle);
		method_27("EndCap", pen.EndCap);
		method_27("LineJoin", pen.LineJoin);
		method_22("MiterLimit", pen.MiterLimit);
		method_27("StartCap", pen.StartCap);
		method_22("Width", pen.Width);
		method_9("Brush", pen.Brush);
		method_2();
	}

	public void method_17(string name, Class5999 value)
	{
		method_0(name);
		method_22("SizePoints", value.SizePoints);
		method_27("Style", value.Style);
		method_25("FamilyName", value.FamilyName);
		if (class6616_0.SerializeTtfFonts)
		{
			using Stream stream = value.TrueTypeFont.Data.vmethod_0();
			stream.Seek(0L, SeekOrigin.Begin);
			byte[] resource = ((!(stream is MemoryStream)) ? Class5964.smethod_11(stream) : ((MemoryStream)stream).ToArray());
			int value2 = class6616_0.Resources.Write(resource);
			class6616_0.Writer.method_23("ResourceId", value2);
		}
		method_2();
	}

	public void method_18(string name, byte[] value)
	{
		method_0(name);
		int value2 = class6616_0.Resources.Write(value);
		class6616_0.Writer.method_23("ResourceId", value2);
		method_2();
	}

	public void method_19(string name, string value)
	{
		method_0(name);
		method_30(value);
		method_2();
	}

	public void method_20(string name, string[] value)
	{
		method_0(name);
		foreach (string value2 in value)
		{
			method_19("Item", value2);
		}
		method_2();
	}

	public void method_21(string name, double value)
	{
		method_25(name, value.ToString("r", class6616_0.CurrentCulture));
	}

	public void method_22(string name, float value)
	{
		method_25(name, value.ToString("r", class6616_0.CurrentCulture));
	}

	public void method_23(string name, int value)
	{
		method_25(name, value.ToString(class6616_0.CurrentCulture));
	}

	public void method_24(string name, bool value)
	{
		method_25(name, value.ToString(class6616_0.CurrentCulture));
	}

	public void method_25(string name, string value)
	{
		class5946_0.method_14(name, value);
	}

	public void method_26(string name, Class6002 value)
	{
		method_25(name, string.Format("{0} {1} {2} {3} {4} {5}", value.M11.ToString("r", class6616_0.CurrentCulture), value.M12.ToString("r", class6616_0.CurrentCulture), value.M21.ToString("r", class6616_0.CurrentCulture), value.M22.ToString("r", class6616_0.CurrentCulture), value.M31.ToString("r", class6616_0.CurrentCulture), value.M32.ToString("r", class6616_0.CurrentCulture)));
	}

	public void method_27(string name, Enum value)
	{
		method_25(name, Class6625.smethod_1(value));
	}

	public void method_28(string name, Class5998 value)
	{
		method_25(name, $"#{Class6159.smethod_37(value.method_1())}");
	}

	public void method_29(string name, float[] value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < value.Length; i++)
		{
			stringBuilder.Append(value[i].ToString(class6616_0.CurrentCulture));
			if (i != value.Length - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		method_25(name, stringBuilder.ToString());
	}

	public void method_30(string value)
	{
		class5946_0.method_13(value);
	}
}
