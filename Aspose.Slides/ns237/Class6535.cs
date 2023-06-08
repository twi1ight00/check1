using System.Drawing;
using ns221;
using ns224;
using ns235;

namespace ns237;

internal abstract class Class6535 : Class6511
{
	protected const string string_1 = "/DV";

	protected const string string_2 = "/AP";

	protected const string string_3 = "/AS";

	protected const string string_4 = "/N";

	protected const string string_5 = "/DA";

	protected const string string_6 = "1 g ";

	protected const string string_7 = "0 g ";

	protected const string string_8 = " re f ";

	protected const string string_9 = " m ";

	protected const string string_10 = " l s ";

	private const bool bool_0 = true;

	private readonly string string_11;

	private readonly PointF pointF_0 = PointF.Empty;

	private readonly bool bool_1 = true;

	private RectangleF rectangleF_0 = RectangleF.Empty;

	protected readonly Class6546 class6546_0;

	private int int_1;

	internal PointF Origin => pointF_0;

	internal string Name => string_11;

	internal RectangleF BoundingBox
	{
		get
		{
			return rectangleF_0;
		}
		set
		{
			rectangleF_0 = value;
		}
	}

	internal Class6546 HostPage => class6546_0;

	protected Class6535(Class6546 hostPage, Class6205 source)
		: base(hostPage.Context)
	{
		string_11 = $"{source.Name}_{base.Id}";
		pointF_0 = source.Origin;
		bool_1 = source.IsEnabled;
		rectangleF_0 = source.BoundingBox;
		class6546_0 = hostPage;
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_28(method_0());
		writer.method_29(this);
		writer.method_6();
		writer.method_8("/Type", "/Annot");
		writer.method_8("/Subtype", "/Widget");
		writer.method_8("/P", class6546_0.IndirectReference);
		writer.method_8("/FT", Class6661.smethod_3(vmethod_2()));
		writer.method_18("/F", 4);
		RectangleF value = new RectangleF(rectangleF_0.X, class6546_0.Height - rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
		writer.method_16("/Rect", value);
		int_1 |= vmethod_3();
		if (method_3())
		{
			writer.method_18("/Ff", int_1);
		}
		writer.method_13("/T", string_11);
		vmethod_4(writer);
		writer.method_7();
		writer.method_30();
		vmethod_5(writer);
	}

	protected abstract Enum882 vmethod_2();

	protected virtual int vmethod_3()
	{
		if (!bool_1)
		{
			return 1;
		}
		return 0;
	}

	[Attribute7(true)]
	protected abstract void vmethod_4(Class6679 writer);

	[Attribute7(true)]
	protected abstract void vmethod_5(Class6679 writer);

	protected string method_1(Class5999 font, Class5998 color)
	{
		Class6527 @class = class6672_0.AcroForm.method_4(font);
		return $"{Class6678.smethod_1(color)} rg /{@class.ResourceName} {Class6678.smethod_2(font.SizePoints)} Tf ";
	}

	protected static void smethod_0(Class6678 writer, RectangleF bounds)
	{
		writer.Write("0 g ");
		writer.Write(bounds.Left);
		writer.method_1();
		writer.Write(bounds.Top);
		writer.method_1();
		writer.Write(bounds.Right);
		writer.method_1();
		writer.Write(bounds.Bottom);
		writer.Write(" re f ");
		writer.Write("1 g ");
		writer.Write(bounds.Left + 1f);
		writer.method_1();
		writer.Write(bounds.Top + 1f);
		writer.method_1();
		writer.Write(bounds.Right - 2f);
		writer.method_1();
		writer.Write(bounds.Bottom - 2f);
		writer.Write(" re f ");
	}

	protected static void smethod_1(Class6678 writer)
	{
		writer.Write(" /Tx BMC\r\n  q\r\n   BT\r\n    ");
	}

	protected static void smethod_2(Class6678 writer)
	{
		writer.Write("\r\n   ET\r\n  Q\r\n EMC");
	}

	protected static void smethod_3(Class6678 writer, Class5998 color)
	{
		writer.Write(Class6678.smethod_1(color));
		writer.Write(" rg ");
	}

	protected Class6527 method_2(Class6678 writer, Class5999 drFont)
	{
		writer.Write("/");
		Class6527 @class = class6672_0.AcroForm.method_4(drFont);
		writer.Write(@class.ResourceName);
		writer.method_1();
		writer.Write(drFont.SizePoints);
		writer.Write(" Tf ");
		return @class;
	}

	protected static void smethod_4(Class6678 writer, float baselineY)
	{
		writer.Write("1 0 0 1 2 ");
		writer.Write(baselineY);
		writer.Write(" Tm ");
	}

	protected static void smethod_5(Class6678 writer, float x, float y)
	{
		writer.method_1();
		writer.Write(x);
		writer.method_1();
		writer.Write(y);
		writer.Write(" Td ");
	}

	protected static void smethod_6(Class6678 writer, string text, Class6527 font)
	{
		if (font is Class6530 font2)
		{
			smethod_7(writer, text, font2);
		}
		else
		{
			smethod_8(writer, text, (Class6529)font);
		}
	}

	protected static void smethod_7(Class6678 writer, string text, Class6530 font)
	{
		writer.Write("(");
		font.method_3(text, writer);
		writer.Write(") Tj ");
	}

	protected static void smethod_8(Class6678 writer, string text, Class6529 font)
	{
		writer.Write("(");
		font.vmethod_4(text);
		writer.Write(text);
		writer.Write(") Tj ");
	}

	private bool method_3()
	{
		return int_1 != 0;
	}
}
