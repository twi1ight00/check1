using System.Drawing;
using System.IO;
using System.Text;
using ns224;
using ns235;

namespace ns239;

internal class Class6195 : Class6176
{
	private Class6562 class6562_0 = new Class6564(null);

	public void method_0(Class6204 node, string fileName)
	{
		node.vmethod_0(this);
		if (File.Exists(fileName))
		{
			File.Delete(fileName);
		}
		FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
		byte[] bytes = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(class6562_0.ToString());
		fileStream.Write(bytes, 0, bytes.Length);
		fileStream.Close();
	}

	public override void vmethod_4(Class6219 glyphs)
	{
		class6562_0.vmethod_0(glyphs.Font, glyphs.Color, glyphs.OutlineColor, glyphs.Origin, glyphs.Text, glyphs.Size, glyphs.CharSpace, smethod_0(glyphs.Hyperlink));
	}

	public override void vmethod_9(Class6223 segment)
	{
		class6562_0.vmethod_3(segment.Points);
	}

	public override void vmethod_10(Class6222 segment)
	{
		Struct219 curve = segment.Curve;
		class6562_0.vmethod_1(curve.StartPoint, curve.ControlPoint1, curve.ControlPoint2, curve.EndPoint);
	}

	public override void vmethod_12(Class6211 bookmark)
	{
		class6562_0.vmethod_2(bookmark.Origin, bookmark.Name);
	}

	public override void vmethod_13(Class6221 outlineItem)
	{
		class6562_0.vmethod_9(outlineItem.Origin, outlineItem.Title, outlineItem.Level);
	}

	public override void vmethod_16(Class6209 field)
	{
		class6562_0.vmethod_5(field.Origin, field.Name, field.Items, field.Value, field.BoundingBox);
	}

	public override void vmethod_15(Class6207 field)
	{
		class6562_0.vmethod_6(field.Origin, field.Name, field.IsEnabled, field.BoundingBox);
	}

	public override void vmethod_14(Class6210 field)
	{
		class6562_0.vmethod_4(field.Origin, field.Name, field.Size, field.IsRichText);
	}

	public override void vmethod_5(Class6217 path)
	{
		class6562_0 = new Class6563(class6562_0);
		if (path.Pen != null)
		{
			Class5990 brush = path.Pen.Brush;
			(class6562_0 as Class6563).Pen = new Pen(((Class5997)brush).Color.method_0());
		}
	}

	public override void vmethod_2(Class6213 canvas)
	{
		class6562_0 = new Class6563(class6562_0);
		(class6562_0 as Class6563).Hyperlink = ((canvas.Hyperlink == null) ? string.Empty : canvas.Hyperlink.Target);
	}

	public override void vmethod_3(Class6213 canvas)
	{
		class6562_0.Builder.vmethod_8(class6562_0 as Class6563);
		class6562_0 = class6562_0.Builder;
	}

	public override void vmethod_6(Class6217 path)
	{
		class6562_0.Builder.vmethod_8(class6562_0 as Class6563);
		class6562_0 = class6562_0.Builder;
	}

	public override void vmethod_11(Class6220 image)
	{
		class6562_0.AddImage(image.Size, image.Origin, image.ImageBytes, image.Crop, smethod_0(image.Hyperlink));
	}

	private static string smethod_0(Class6270 hyperlink)
	{
		if (hyperlink != null)
		{
			return hyperlink.Target;
		}
		return string.Empty;
	}
}
