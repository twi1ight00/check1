using System.Drawing;
using System.IO;
using ns235;

namespace ns237;

internal class Class6536 : Class6535
{
	private const bool bool_2 = false;

	private const string string_12 = "/On";

	private const string string_13 = "/Off";

	private const string string_14 = "0 G ";

	private readonly bool bool_3;

	private Class6520 class6520_0;

	private Class6520 class6520_1;

	internal Class6536(Class6546 hostPage, Class6207 source)
		: base(hostPage, source)
	{
		bool_3 = source.Value;
		method_4();
	}

	protected override Enum882 vmethod_2()
	{
		return Enum882.const_0;
	}

	protected override void vmethod_4(Class6679 writer)
	{
		if (bool_3)
		{
			writer.method_8("/DV", bool_3 ? "/On" : "/Off");
		}
		writer.Write("/AP");
		writer.method_6();
		writer.Write("/N");
		writer.method_6();
		writer.method_0("/Off");
		writer.method_0(class6520_1.IndirectReference);
		writer.method_0("/On");
		writer.method_0(class6520_0.IndirectReference);
		writer.method_7();
		writer.method_7();
		writer.method_8("/AS", bool_3 ? "/On" : "/Off");
	}

	protected override void vmethod_5(Class6679 writer)
	{
		class6520_0.vmethod_0(writer);
		class6520_1.vmethod_0(writer);
	}

	private void method_4()
	{
		RectangleF rectangleF = new RectangleF(0f, 0f, base.BoundingBox.Width, base.BoundingBox.Height);
		class6520_1 = new Class6520(class6672_0);
		class6520_1.BoundingBox = rectangleF;
		class6520_1.Content = new MemoryStream();
		Class6678 writer = new Class6678(class6520_1.Content);
		Class6535.smethod_0(writer, class6520_1.BoundingBox);
		class6520_0 = new Class6520(class6672_0);
		class6520_0.BoundingBox = rectangleF;
		class6520_0.Content = new MemoryStream();
		Class6678 writer2 = new Class6678(class6520_0.Content);
		Class6535.smethod_0(writer2, rectangleF);
		smethod_9(writer2, rectangleF);
	}

	private static void smethod_9(Class6678 writer, RectangleF bounds)
	{
		writer.Write("0 G ");
		writer.Write(bounds.Left);
		writer.method_1();
		writer.Write(bounds.Top);
		writer.Write(" m ");
		writer.Write(bounds.Right);
		writer.method_1();
		writer.Write(bounds.Bottom);
		writer.Write(" l s ");
		writer.Write(bounds.Left);
		writer.method_1();
		writer.Write(bounds.Bottom);
		writer.Write(" m ");
		writer.Write(bounds.Right);
		writer.method_1();
		writer.Write(bounds.Top);
		writer.Write(" l s ");
	}
}
