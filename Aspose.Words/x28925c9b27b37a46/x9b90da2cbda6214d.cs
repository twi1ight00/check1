using Aspose.Words;

namespace x28925c9b27b37a46;

internal class x9b90da2cbda6214d : xdbbc00f1636b87bc
{
	internal override bool xd8a4d30a54634d09 => false;

	internal override bool xc313ef0c9ca8870d(Node xda5bf54deb817e37)
	{
		bool flag = false;
		x7f77ea92be0d9042 x7f77ea92be0d9043 = xdd8aa62f92df1485.x67e96301bb4dca85(xda5bf54deb817e37);
		if (x7f77ea92be0d9043 != null)
		{
			flag = x7f77ea92be0d9043.xcb78713836fcc98a;
		}
		if (!flag && xda5bf54deb817e37 is Paragraph)
		{
			flag = ((Paragraph)xda5bf54deb817e37).xcb78713836fcc98a;
		}
		return flag;
	}
}
