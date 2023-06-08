using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns215;
using ns217;
using ns235;

namespace ns216;

internal class Class5790 : Class5783
{
	internal static string Tag => "border";

	public XfaEnums.Enum687 Presence => (XfaEnums.Enum687)method_5("presence").Value;

	public Class5790()
	{
		Class5906.smethod_6(this, "break", XfaEnums.Enum686.const_0);
		Class5906.smethod_6(this, "hand", XfaEnums.Enum680.const_0);
		Class5906.smethod_6(this, "presence", XfaEnums.Enum687.const_0);
		Class5906.smethod_4(this, "relevant", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_14(this);
		base.vmethod_4(visitor);
		visitor.vmethod_15(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5790();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[5]
		{
			Class5803.Tag,
			Class5810.Tag,
			Class5816.Tag,
			Class5818.Tag,
			Class5829.Tag
		};
	}

	internal void method_8(Class6213 canvas, PointF pos, SizeF size)
	{
		XfaEnums.Enum687 presence = Presence;
		if (presence != XfaEnums.Enum687.const_1 && presence != XfaEnums.Enum687.const_3)
		{
			Class5908 @class = method_3($"#{Class5810.Tag}[*]");
			if (@class.Length == 0)
			{
				method_7(Class5810.Tag, new Class5810());
			}
			Class5842.smethod_2(this, (XfaEnums.Enum680)method_5("hand").Value, canvas, pos, size);
		}
	}
}
