using System;
using System.Drawing;
using System.IO;
using System.Text;
using ns233;

namespace ns239;

internal class Class6633
{
	private const int int_0 = 2540;

	private const string string_0 = "\\pard\\posx{0}\\posy{1} {{\\pict\\wmetafile8\\picw{2}\\pich{3}\\picwgoal{4}\\pichgoal{5}\\";

	private const string string_1 = "piccropt{0}\\piccropb{1}\\piccropl{2}\\piccropr{3}\\";

	private const string string_2 = "\\par ";

	private const string string_3 = "}\r\n";

	private const string string_4 = "{0:X2}";

	private StringBuilder stringBuilder_0;

	public Class6633(PointF origin, SizeF size, byte[] byteArray, Class6145 crop)
	{
		MemoryStream stream = new MemoryStream(byteArray);
		Image image = Image.FromStream(stream);
		stringBuilder_0 = new StringBuilder();
		method_0(image, crop, size, origin);
		method_1(image);
		stringBuilder_0.Append("}\r\n");
		stringBuilder_0.Append("\\par ");
	}

	private void method_0(Image image, Class6145 crop, SizeF size, PointF origin)
	{
		int num = (int)Math.Round((float)image.Width / Class6632.float_0 * 2540f);
		int num2 = (int)Math.Round((float)image.Height / Class6632.float_1 * 2540f);
		SizeF sizeF = Class6632.smethod_1(size);
		PointF pointF = Class6632.smethod_0(origin);
		stringBuilder_0.AppendFormat("\\pard\\posx{0}\\posy{1} {{\\pict\\wmetafile8\\picw{2}\\pich{3}\\picwgoal{4}\\pichgoal{5}\\", pointF.X, pointF.Y, num, num2, sizeF.Width, sizeF.Height);
		if (crop != null)
		{
			RectangleF rectangleF = default(RectangleF);
			crop.method_0(rectangleF);
			RectangleF rectangleF2 = Class6632.smethod_2(rectangleF);
			stringBuilder_0.AppendFormat("piccropt{0}\\piccropb{1}\\piccropl{2}\\piccropr{3}\\", rectangleF2.Top, rectangleF2.Bottom, rectangleF2.Left, rectangleF2.Right);
		}
		stringBuilder_0.Append(" ");
	}

	private void method_1(Image image)
	{
		byte[] array = Class6632.smethod_5(image);
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder_0.Append($"{array[i]:X2}");
		}
	}

	public override string ToString()
	{
		return stringBuilder_0.ToString();
	}
}
