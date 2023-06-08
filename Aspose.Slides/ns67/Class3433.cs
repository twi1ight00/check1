using System;

namespace ns67;

internal sealed class Class3433 : Class3431
{
	private readonly Class3090 class3090_0;

	private readonly Class3450 class3450_0;

	public Class3090 Geometry => class3090_0;

	public Class3450 TextBody => class3450_0;

	public Class3433(Class3452 slide, Class3432 parent, Class3090 geometry)
		: base(slide, parent)
	{
		if (slide == null)
		{
			throw new ArgumentNullException("slide");
		}
		if (geometry == null)
		{
			throw new ArgumentNullException("geometry");
		}
		class3090_0 = geometry;
		class3450_0 = new Class3450(this);
	}

	internal override void vmethod_0(Class3428 renderer, Class3434 parentAttributes)
	{
		Class3434 @class = base.Attributes;
		if (parentAttributes != null)
		{
			@class = base.Attributes.method_0();
			@class.method_1(parentAttributes);
		}
		Class3279 geometry = method_3();
		renderer.method_0(geometry, @class);
		renderer.method_1(this, @class);
	}

	internal Class3448 method_2()
	{
		Class3279 @class = class3090_0 as Class3279;
		Class3448 class2;
		if (@class == null)
		{
			@class = ((Class3091)class3090_0).vmethod_1();
			class2 = @class.Transform2D.method_0();
			class2.Offset = new Class3456(@class.Transform2D.Offset.X + @class.TextRectangle.Offset.X, @class.Transform2D.Offset.Y + @class.TextRectangle.Offset.Y);
		}
		else
		{
			class2 = @class.Transform2D.method_0();
			class2.Offset = @class.TextRectangle.Offset;
		}
		class2.Extents = @class.TextRectangle.Extents;
		return class2;
	}

	private Class3279 method_3()
	{
		if (class3090_0 is Class3091)
		{
			return ((Class3091)class3090_0).vmethod_1();
		}
		if (!(class3090_0 is Class3279))
		{
			throw new InvalidCastException("Shape geometry can't cast to CustomGeometry");
		}
		return (Class3279)class3090_0;
	}
}
