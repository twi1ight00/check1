using System.Drawing;
using Aspose.Slides;
using ns56;

namespace ns18;

internal class Class994
{
	public static void smethod_0(ISlideSize slideSize, Class2258 sldSzElementData)
	{
		if (sldSzElementData != null)
		{
			slideSize.Size = new SizeF((float)sldSzElementData.Cx, (float)sldSzElementData.Cy);
			slideSize.Type = sldSzElementData.Type;
		}
	}

	public static void smethod_1(ISlideSize slideSize, Class2258.Delegate2521 addSldSz)
	{
		if (slideSize != null)
		{
			Class2258 @class = addSldSz();
			@class.Cx = slideSize.Size.Width;
			@class.Cy = slideSize.Size.Height;
			@class.Type = slideSize.Type;
		}
	}
}
