using Aspose.Words.Fonts;
using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class x5e566bc77f5325de
{
	internal const int x95a4d1d40049d74b = -1;

	private readonly int xd656800c832b4906;

	private readonly FontInfoCollection xcf7aa3cc906cdb68;

	private readonly x09ce2c02826e31a6 xacd2d7f6e68cacd5 = new x09ce2c02826e31a6();

	private readonly x09ce2c02826e31a6 xa738d2e730088a23 = new x09ce2c02826e31a6();

	internal x5e566bc77f5325de(FontInfoCollection fontInfos, int defaultFontCode)
	{
		xcf7aa3cc906cdb68 = fontInfos;
		xd656800c832b4906 = defaultFontCode;
	}

	internal void xd6b6ed77479ef68c(int x3d2dde7c72e020a4, FontInfo xfa5e135bae569bda)
	{
		xcf7aa3cc906cdb68.xd5da23b762ce52a2(xfa5e135bae569bda);
		xacd2d7f6e68cacd5.set_xe6d4b1b411ed94b5(x3d2dde7c72e020a4, (object)xfa5e135bae569bda.Name);
		xa738d2e730088a23.set_xe6d4b1b411ed94b5(x3d2dde7c72e020a4, (object)xfa5e135bae569bda.Charset);
	}

	internal string x7bcd2fb72fb7aae6(int x3d2dde7c72e020a4)
	{
		object obj = xacd2d7f6e68cacd5.get_xe6d4b1b411ed94b5(x3d2dde7c72e020a4);
		if (obj == null)
		{
			obj = xacd2d7f6e68cacd5.get_xe6d4b1b411ed94b5(xd656800c832b4906);
		}
		if (obj == null)
		{
			xd6b6ed77479ef68c(x3d2dde7c72e020a4, new FontInfo("Times New Roman"));
			obj = xacd2d7f6e68cacd5.get_xe6d4b1b411ed94b5(x3d2dde7c72e020a4);
		}
		return (string)obj;
	}

	internal int x17e389ec6532245f(int x3d2dde7c72e020a4)
	{
		object obj = xa738d2e730088a23.get_xe6d4b1b411ed94b5(x3d2dde7c72e020a4);
		if (obj != null)
		{
			return (int)obj;
		}
		return int.MinValue;
	}
}
