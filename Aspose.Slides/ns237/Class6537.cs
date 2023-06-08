using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ns224;
using ns235;

namespace ns237;

internal class Class6537 : Class6535
{
	private const byte byte_0 = 17;

	private const int int_2 = 10;

	private const int int_3 = 2;

	private readonly int int_4;

	private readonly List<string> list_0;

	private Class6520 class6520_0;

	private readonly Class5999 class5999_0;

	private readonly Class5998 class5998_0 = Class5998.class5998_7;

	internal Class6537(Class6546 hostPage, Class6209 source)
		: base(hostPage, source)
	{
		int_4 = source.Value;
		list_0 = source.Items;
		class5999_0 = source.DefaultFont;
		method_4();
		method_5();
	}

	protected override Enum882 vmethod_2()
	{
		return Enum882.const_2;
	}

	protected override int vmethod_3()
	{
		return 0x20000 | base.vmethod_3();
	}

	protected override void vmethod_4(Class6679 writer)
	{
		writer.Write("/Opt [");
		for (int i = 0; i < list_0.Count; i++)
		{
			writer.method_15(list_0[i]);
			writer.method_1();
		}
		writer.Write("]");
		writer.method_13("/V", list_0[int_4]);
		writer.method_14("/DA", method_1(class5999_0, class5998_0), isEscape: false);
		writer.Write("/AP");
		writer.method_6();
		writer.method_0("/N");
		writer.Write(class6520_0.IndirectReference);
		writer.method_7();
	}

	protected override void vmethod_5(Class6679 writer)
	{
		class6520_0.vmethod_0(writer);
	}

	private void method_4()
	{
		float num = base.BoundingBox.Right + 10f;
		float num2 = base.BoundingBox.Bottom + 2f;
		if (num2 > class6546_0.Height)
		{
			num2 = class6546_0.Height;
		}
		if (num > class6546_0.Width)
		{
			num = class6546_0.Width;
		}
		base.BoundingBox = RectangleF.FromLTRB(base.BoundingBox.Left, base.BoundingBox.Top, num, num2);
	}

	private void method_5()
	{
		class6520_0 = new Class6520(class6672_0);
		class6520_0.BoundingBox = new RectangleF(0f, 0f, base.BoundingBox.Width, base.BoundingBox.Height);
		class6520_0.Content = method_6();
	}

	private MemoryStream method_6()
	{
		MemoryStream memoryStream = new MemoryStream();
		Class6678 writer = new Class6678(memoryStream);
		Class6535.smethod_0(writer, class6520_0.BoundingBox);
		Class6535.smethod_1(writer);
		Class6535.smethod_3(writer, class5998_0);
		Class6527 font = method_2(writer, class5999_0);
		Class6535.smethod_4(writer, base.BoundingBox.Height - class5999_0.SizePoints - 1f);
		Class6535.smethod_5(writer, 0f, 0f);
		Class6535.smethod_6(writer, list_0[int_4], font);
		Class6535.smethod_2(writer);
		return memoryStream;
	}
}
