using System.Drawing;
using System.Xml;
using Aspose.XfaConverter.Elements;
using ns215;
using ns235;

namespace ns216;

internal class Class5891 : Class5782, Interface253
{
	private Class6210 class6210_0;

	internal static string Tag => "timeStamp";

	public Class5891()
	{
		Class5906.smethod_4(this, "server", string.Empty);
		Class5906.smethod_6(this, "type", XfaEnums.Enum692.const_0);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_167(this);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		Class5817 @class = Class5804.smethod_2(base.Parent);
		if (@class != null)
		{
			class6210_0 = new Class6210(PointF.Empty, string.Empty, Size.Empty, isRichText: true);
			class6210_0.IsEnabled = @class.Access != XfaEnums.Enum705.const_3 && @class.Access != XfaEnums.Enum705.const_1;
		}
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5891();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	public void imethod_0(Class6213 canvas, Class6213 textCanvas, Class5912 builder, PointF pos, SizeF size)
	{
		if (class6210_0 != null)
		{
			class6210_0.Size = size;
			class6210_0.Origin = pos;
			class6210_0.CustomDraw = canvas;
			builder.method_2(class6210_0);
		}
		builder.method_5(canvas);
	}
}
