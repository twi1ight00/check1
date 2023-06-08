using System.Drawing;
using ns224;
using ns252;

namespace ns249;

internal class Class6362 : Interface284
{
	private Class6323 class6323_0 = new Class6323();

	private bool bool_0;

	public bool AreColorsInReverseOrder => false;

	public Class6323 Angle
	{
		get
		{
			return class6323_0;
		}
		set
		{
			class6323_0 = value;
		}
	}

	public bool IsScaled
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

	public Interface284 Clone()
	{
		Class6362 @class = new Class6362();
		@class.Angle = Angle;
		@class.IsScaled = IsScaled;
		return @class;
	}

	public Class5992 imethod_0(RectangleF tileRectangle, Class6360 brushRenderingContext, bool rotateWithShape)
	{
		Class5993 @class = new Class5993(tileRectangle, Angle.ValueInDegrees, IsScaled);
		if (rotateWithShape)
		{
			@class.Transform = Class6365.smethod_0(brushRenderingContext);
		}
		return @class;
	}
}
