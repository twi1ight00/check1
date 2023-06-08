using System.Drawing;
using System.IO;
using ns235;

namespace ns243;

internal class Class6234 : Class6225
{
	private readonly Image image_0;

	private Class6220 class6220_0;

	public override SizeF Size => new SizeF((float)image_0.Size.Width + Margin.float_1 + Margin.float_2, (float)image_0.Size.Height + Margin.float_0 + Margin.float_3);

	public Class6234(Image image, Struct220 margin)
	{
		image_0 = image;
		Margin = margin;
	}

	public override Class6204[] vmethod_2()
	{
		return new Class6204[1] { method_4() };
	}

	public Class6220 method_4()
	{
		if (class6220_0 == null)
		{
			using MemoryStream memoryStream = new MemoryStream();
			image_0.Save(memoryStream, image_0.RawFormat);
			memoryStream.Flush();
			PointF origin = new PointF(Location.X + Margin.float_1, Location.Y + Margin.float_0);
			class6220_0 = new Class6220(origin, image_0.Size, memoryStream.GetBuffer());
		}
		return class6220_0;
	}
}
