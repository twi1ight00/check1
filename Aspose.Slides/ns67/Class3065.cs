using System;
using System.Collections.Generic;
using ns69;

namespace ns67;

internal sealed class Class3065 : Class3063
{
	private readonly List<Struct159> list_0;

	public Class3065(Class3068 attributes)
		: base(attributes)
	{
		list_0 = new List<Struct159>();
	}

	public void method_1(Class3057 connectedTriangulatedRegion)
	{
		int count = connectedTriangulatedRegion.Triangles.Count;
		for (int i = 0; i < count; i++)
		{
			list_0.AddRange(connectedTriangulatedRegion.Triangles[i].AsPlanePoints);
		}
	}

	public override void vmethod_0(Interface53 device)
	{
		Class3331 shapeFillMode = base.RenderingAttributes.Attributes.ShapeFillMode;
		if (shapeFillMode is Class3336)
		{
			return;
		}
		int num = list_0.Count / 3;
		bool flag = base.RenderingAttributes.TextureId != 0;
		double num2 = 1.0;
		double num3 = 0.0;
		if (flag)
		{
			device.imethod_7(new Class3453(1f, 1f, 1f, 0f));
			device.imethod_1(base.RenderingAttributes.TextureId);
			double num4 = base.RenderingAttributes.Transform.Rotation / 60000.0 * Math.PI / 180.0;
			num2 = Math.Abs(Math.Cos(num4)) + Math.Abs(Math.Sin(num4));
			num3 = (num2 - 1.0) / 2.0;
		}
		else if (shapeFillMode is Class3339 @class)
		{
			device.imethod_7(@class.FillColor);
		}
		try
		{
			device.imethod_6();
			try
			{
				for (int i = 0; i < num; i++)
				{
					int num5 = i * 3;
					Struct159 point2D = list_0[num5];
					Struct159 point2D2 = list_0[num5 + 1];
					Struct159 point2D3 = list_0[num5 + 2];
					Class3427 class2 = method_0(point2D);
					Class3427 class3 = method_0(point2D2);
					Class3427 class4 = method_0(point2D3);
					double cx = base.RenderingAttributes.Transform.Extents.Cx;
					double cy = base.RenderingAttributes.Transform.Extents.Cy;
					double num6 = cx / 2.0;
					double num7 = cy / 2.0;
					if (flag)
					{
						double x = ((class2.X + num6) / cx + num3) / num2;
						double y = ((class2.Y + num7) / cy + num3) / num2;
						device.imethod_2(x, y);
					}
					device.imethod_8(class2.X, class2.Y, class2.Z);
					if (flag)
					{
						double x2 = ((class3.X + num6) / cx + num3) / num2;
						double y2 = ((class3.Y + num7) / cy + num3) / num2;
						device.imethod_2(x2, y2);
					}
					device.imethod_8(class3.X, class3.Y, class3.Z);
					if (flag)
					{
						double x3 = ((class4.X + num6) / cx + num3) / num2;
						double y3 = ((class4.Y + num7) / cy + num3) / num2;
						device.imethod_2(x3, y3);
					}
					device.imethod_8(class4.X, class4.Y, class4.Z);
				}
			}
			finally
			{
				device.imethod_9();
			}
		}
		finally
		{
			device.imethod_1(0u);
			device.imethod_7(new Class3453(1f, 1f, 1f, 0f));
		}
	}
}
