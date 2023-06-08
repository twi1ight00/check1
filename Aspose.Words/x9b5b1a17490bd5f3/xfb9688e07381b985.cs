using Aspose.Words;
using x2697283ff424107e;

namespace x9b5b1a17490bd5f3;

internal class xfb9688e07381b985
{
	internal readonly string x6d1dc28c8a9d4c4e;

	internal readonly string x93168ed101bbb044;

	internal readonly xa3fc7dcdc8182ff6 xf5753384a1839c45;

	internal Style x20bd1b246951296e;

	internal xfb9688e07381b985(string elementName, string className, xa3fc7dcdc8182ff6 cssStyle, bool makeCopy)
	{
		x6d1dc28c8a9d4c4e = elementName;
		x93168ed101bbb044 = className;
		if (makeCopy)
		{
			xf5753384a1839c45 = new xa3fc7dcdc8182ff6();
			x3238f01fbed8df7e(cssStyle);
		}
		else
		{
			xf5753384a1839c45 = cssStyle;
		}
	}

	internal void x3238f01fbed8df7e(xa3fc7dcdc8182ff6 x36c843bef78b260f)
	{
		xf5753384a1839c45.x5b4b16238b2a05ea(x36c843bef78b260f);
	}

	internal string x9bcf3bd384d4541c(bool xbc2b3e3429425e3f)
	{
		string text = ((x6d1dc28c8a9d4c4e.Length == 0 || (!xbc2b3e3429425e3f && x93168ed101bbb044.Length != 0 && x6d1dc28c8a9d4c4e == "span")) ? string.Empty : (char.ToUpper(x6d1dc28c8a9d4c4e[0]) + x6d1dc28c8a9d4c4e.Substring(1)));
		return (text.Length == 0) ? x93168ed101bbb044 : ((x93168ed101bbb044.Length == 0) ? text : $"{text}_{x93168ed101bbb044}");
	}
}
