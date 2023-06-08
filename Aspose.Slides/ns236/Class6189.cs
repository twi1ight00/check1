using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns234;
using ns235;

namespace ns236;

internal class Class6189 : Class6188
{
	private readonly Stack<GraphicsPath> stack_0;

	private Region region_0;

	public Region Region => region_0;

	public Class6189()
	{
		stack_0 = new Stack<GraphicsPath>();
	}

	public override void vmethod_5(Class6217 path)
	{
		if (base.GraphicsPath != null)
		{
			stack_0.Push(base.GraphicsPath);
		}
		base.vmethod_5(path);
	}

	public override void vmethod_6(Class6217 path)
	{
		if (path.RenderTransform != null)
		{
			using Matrix matrix = Class6161.smethod_0(path.RenderTransform);
			base.GraphicsPath.Transform(matrix);
		}
		if (region_0 == null)
		{
			region_0 = new Region(base.GraphicsPath);
		}
		else
		{
			region_0.Union(base.GraphicsPath);
		}
		if (stack_0.Count != 0)
		{
			base.GraphicsPath = stack_0.Pop();
		}
	}
}
