using System.Drawing;
using System.Xml;
using Aspose.XfaConverter.Elements;
using ns215;
using ns224;
using ns235;

namespace ns216;

internal class Class5818 : Class5783
{
	private XfaEnums.Enum687 enum687_0;

	internal static string Tag => "fill";

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_77(this);
		base.vmethod_4(visitor);
		visitor.vmethod_78(this);
	}

	internal Class5818()
	{
		Class5906.smethod_6(this, "presence", XfaEnums.Enum687.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		Class5931 @class = new Class5931(new string[5]
		{
			Class5827.Tag,
			Class5838.Tag,
			Class5840.Tag,
			Class5846.Tag,
			Class5847.Tag
		}, this);
		@class.method_0(reader, node, this);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5818();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal void method_8(Class6213 canvas, PointF pos, SizeF size)
	{
		if (enum687_0 != 0 && enum687_0 != XfaEnums.Enum687.const_2)
		{
			return;
		}
		Class5800 @class = method_6(Class5800.Tag) as Class5800;
		Class6217 class2 = new Class6217();
		if (@class != null)
		{
			if (@class.method_9() && @class.Value != null)
			{
				string[] array = @class.Value.Split(',');
				class2.Brush = new Class5997(new Class5998(int.Parse(array[0].Trim(' ')), int.Parse(array[1].Trim(' ')), int.Parse(array[2].Trim(' '))));
			}
			Class6218 class3 = new Class6218();
			class2.Add(class3);
			class3.method_3(new RectangleF(pos.X, pos.Y, size.Width, size.Height));
			canvas.Add(class2);
		}
	}

	internal override string[] vmethod_10()
	{
		return new string[2]
		{
			Class5800.Tag,
			Class5816.Tag
		};
	}
}
