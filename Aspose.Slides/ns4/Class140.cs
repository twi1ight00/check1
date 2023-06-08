using Aspose.Slides;
using ns224;

namespace ns4;

internal class Class140
{
	private bool bool_0 = true;

	internal Class66 class66_0;

	internal Class140(ILineFormat userLineFormat, Class6002 UserToDevice, Class145 supportWrapper)
	{
		if (userLineFormat.FillFormat.FillType != FillType.NotDefined)
		{
			class66_0 = new Class66(supportWrapper.method_1(UserToDevice), (LineFormat)userLineFormat);
			bool_0 = false;
		}
	}

	internal void method_0(Class66 sourceLineStyle)
	{
		if (bool_0 && sourceLineStyle != null)
		{
			class66_0 = sourceLineStyle;
		}
	}
}
