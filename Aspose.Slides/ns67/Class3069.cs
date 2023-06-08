namespace ns67;

internal sealed class Class3069
{
	private readonly Class3406 class3406_0;

	private readonly Class3030 class3030_0;

	public Class3406 Properties => class3406_0;

	public Class3030 ContourList => class3030_0;

	public Class3069(Class3030 contourList, Class3406 properties)
	{
		class3030_0 = contourList;
		class3406_0 = properties;
	}

	internal Class3434 method_0(Class3434 parentAttributes)
	{
		Class3434 @class = parentAttributes.method_0();
		Class3331 fillMode = class3406_0.FillMode;
		if (fillMode != null)
		{
			@class.ShapeFillMode = fillMode;
		}
		Class3331 lineFillMode = class3406_0.LineFillMode;
		if (lineFillMode != null)
		{
			@class.LineFillMode = lineFillMode;
		}
		else
		{
			@class.LineFillMode = new Class3336();
		}
		return @class;
	}
}
