using System.Drawing;
using ns219;
using ns235;
using ns259;
using ns262;
using ns263;

namespace ns253;

internal class Class6451
{
	private Class6447 class6447_0;

	private Class6473 class6473_0;

	private bool bool_0;

	public Class6473 Transform
	{
		get
		{
			if (class6473_0 == null)
			{
				class6473_0 = new Class6473();
			}
			return class6473_0;
		}
		set
		{
			class6473_0 = value;
		}
	}

	public bool UseShapeTextRectangle
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class6447 TextBody
	{
		get
		{
			if (class6447_0 == null)
			{
				class6447_0 = new Class6447();
			}
			return class6447_0;
		}
		set
		{
			class6447_0 = value;
		}
	}

	public Class6204 method_0(Class6340 nodeRenderParams, RectangleF targetRect, Class6412 drawingContext)
	{
		Class6458 serviceLocator = new Class6458(nodeRenderParams.DataProvider, drawingContext);
		Class6455 @class = new Class6455(serviceLocator);
		@class.method_0(this, targetRect);
		return @class.method_1();
	}
}
