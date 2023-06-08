using System.Drawing;
using ns235;
using ns249;
using ns255;
using ns258;
using ns259;
using ns261;
using ns263;

namespace ns219;

internal abstract class Class6337 : Class6333
{
	private Class6366 class6366_0;

	private Interface294 interface294_0;

	private Class6420 class6420_0;

	private Class6473 class6473_0;

	public Class6366 Geometry
	{
		get
		{
			if (class6366_0 == null)
			{
				class6366_0 = new Class6366();
			}
			return class6366_0;
		}
		set
		{
			class6366_0 = value;
		}
	}

	public Interface294 Outline
	{
		get
		{
			if (interface294_0 == null)
			{
				interface294_0 = new Class6401();
			}
			return interface294_0;
		}
		set
		{
			interface294_0 = value;
		}
	}

	public Class6420 Style
	{
		get
		{
			if (class6420_0 == null)
			{
				class6420_0 = new Class6420();
			}
			return class6420_0;
		}
		set
		{
			class6420_0 = value;
		}
	}

	public override Class6473 vmethod_1()
	{
		if (class6473_0 == null)
		{
			class6473_0 = new Class6473();
		}
		return class6473_0;
	}

	public void method_0(Class6473 transform)
	{
		class6473_0 = transform;
	}

	protected Class6412 method_1(Class6340 nodeRenderParams)
	{
		Class6360 @class = new Class6360(this, nodeRenderParams.ThemeProvider, nodeRenderParams.DataProvider, Style);
		@class.ShapeBoundingBox = vmethod_1().BoundingBox;
		@class.ShapeRotationAngle = nodeRenderParams.CurrentAccumulatedAngle;
		return new Class6412(vmethod_1().Width, vmethod_1().Length, Outline, base.Fill, @class, Geometry.Guides);
	}

	protected void method_2(Class6477 transformStack, Class6213 canvas)
	{
		RectangleF bbox = ((base.Parent != null) ? base.Parent.vmethod_1().BoundingBox : vmethod_1().BoundingBox);
		Class6475 @class = transformStack.method_2(bbox);
		for (int i = 0; i < canvas.Count; i++)
		{
			if (canvas[i] is Class6217 class2)
			{
				class2.method_3(@class.ShapeTransformation);
			}
		}
		canvas.RenderTransform = @class.ShapeOffset;
	}
}
