using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns215;
using ns235;

namespace ns216;

internal class Class5794 : Class5783, Interface253
{
	private Class6206 class6206_0;

	internal static string Tag => "button";

	public override object Clone()
	{
		return base.Clone();
	}

	public Class5794()
	{
		Class5906.smethod_6(this, "highlight", XfaEnums.Enum689.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_22(this);
		base.vmethod_4(visitor);
		visitor.vmethod_23(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5794();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5816.Tag };
	}

	public void imethod_0(Class6213 canvas, Class6213 textCanvas, Class5912 builder, PointF pos, SizeF size)
	{
		if (class6206_0 == null)
		{
			class6206_0 = new Class6206(PointF.Empty, string.Empty, SizeF.Empty);
			if (base.Parent.Parent.Nodes.method_3("#value") is Class5893 @class)
			{
				class6206_0.Caption = @class.method_6();
			}
		}
		class6206_0.Origin = pos;
		class6206_0.Size = size;
		class6206_0.CustomDraw = canvas;
		builder.method_2(class6206_0);
		builder.method_5(canvas);
		if (textCanvas != null)
		{
			builder.method_5(textCanvas);
		}
	}
}
