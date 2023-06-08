using System.Drawing;
using ns235;

namespace ns267;

internal class Class6610 : Class6598
{
	protected override string RootNodeName => "Bezier";

	public Class6610(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6222;
	}

	public override void vmethod_1(Class6204 node)
	{
		Class6222 @class = node as Class6222;
		base.Context.Writer.method_0(RootNodeName);
		base.vmethod_1(node);
		base.Context.Writer.method_28("CurveColor", @class.CurveColor);
		base.Context.Writer.method_14("StartPoint", @class.Curve.StartPoint);
		base.Context.Writer.method_14("ControlPoint1", @class.Curve.ControlPoint1);
		base.Context.Writer.method_14("ControlPoint2", @class.Curve.ControlPoint2);
		base.Context.Writer.method_14("EndPoint", @class.Curve.EndPoint);
	}

	protected override Class6204 vmethod_2()
	{
		if (base.Context.Reader.method_10("CurveColor", out var value))
		{
			if (base.Context.Reader.method_14("StartPoint", out var value2) && base.Context.Reader.method_14("ControlPoint1", out var value3) && base.Context.Reader.method_14("ControlPoint2", out var value4) && base.Context.Reader.method_14("EndPoint", out var value5))
			{
				Struct219 bezier = new Struct219(PointF.Empty, PointF.Empty, PointF.Empty);
				bezier.StartPoint = value2;
				bezier.ControlPoint1 = value3;
				bezier.ControlPoint2 = value4;
				bezier.EndPoint = value5;
				return new Class6222(bezier, value);
			}
			return new Class6222(value);
		}
		return null;
	}
}
