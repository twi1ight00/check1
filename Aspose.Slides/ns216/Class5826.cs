using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns215;
using ns224;
using ns235;

namespace ns216;

internal class Class5826 : Class5783
{
	internal static string Tag => "line";

	public Class5826()
	{
		Class5906.smethod_6(this, "hand", XfaEnums.Enum680.const_0);
		Class5906.smethod_5(this, "slope", '\\');
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_99(this);
		base.vmethod_4(visitor);
		visitor.vmethod_100(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5826();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5810.Tag };
	}

	internal void method_8(Class6213 canvas, PointF pos, SizeF size)
	{
		if (method_6(Class5810.Tag) is Class5810 @class && @class.Presence != XfaEnums.Enum687.const_1 && @class.Presence != XfaEnums.Enum687.const_3)
		{
			Class6217 class2 = new Class6217(new Class6003(Class5998.class5998_7, @class.Thickness));
			Class6218 class3 = new Class6218();
			class2.Add(class3);
			class3.method_2(pos, new PointF(pos.X + size.Width, pos.Y + size.Height));
			canvas.Add(class2);
		}
	}
}
