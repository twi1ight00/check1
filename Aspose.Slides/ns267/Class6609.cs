using System.Collections.Generic;
using System.Drawing;
using ns235;

namespace ns267;

internal class Class6609 : Class6598
{
	protected override string RootNodeName => "PolyLine";

	public Class6609(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6223;
	}

	public override void vmethod_1(Class6204 node)
	{
		Class6223 @class = node as Class6223;
		base.Context.Writer.method_0(RootNodeName);
		base.vmethod_1(node);
		base.Context.Writer.method_28("LineColor", @class.LineColor);
		foreach (PointF point in @class.Points)
		{
			base.Context.Writer.method_14("Point", point);
		}
	}

	protected override Class6204 vmethod_2()
	{
		List<PointF> list = new List<PointF>();
		if (base.Context.Reader.method_10("LineColor", out var value))
		{
			base.Context.Reader.method_1();
			do
			{
				if (base.Context.Reader.method_16(out var value2))
				{
					list.Add(value2);
				}
			}
			while (base.Context.Reader.method_0());
			base.Context.Reader.method_2();
			return new Class6223(list.ToArray(), value);
		}
		return null;
	}
}
