using System.Drawing.Imaging;
using Aspose.Cells.Drawing;
using ns18;
using ns36;
using ns37;
using ns5;
using ns6;

namespace ns19;

internal class Class871
{
	internal static Class454 smethod_0(Interface6 interface6_0)
	{
		int int_ = Class1036.int_1;
		Class1032 @class = (Class1032)Class1036.smethod_0(int_, 1, 1, ImageFormat.Bmp, null, null, interface6_0);
		return @class.vmethod_9();
	}

	internal static Class454 smethod_1(Shape shape_0)
	{
		Interface6 interface6_ = smethod_2(shape_0);
		return smethod_0(interface6_);
	}

	private static Interface6 smethod_2(Shape shape_0)
	{
		if (shape_0.method_25().Workbook.method_23())
		{
			Class913 @class = new Class913(Class912.smethod_22(shape_0.MsoDrawingType));
			Class912.smethod_3(shape_0, @class);
			return @class;
		}
		Class898 class2 = new Class898(Class897.smethod_21(shape_0.MsoDrawingType));
		Class897.smethod_3(shape_0, class2);
		return class2;
	}
}
