using System.Collections;

namespace x2697283ff424107e;

internal class x1cf08cb657f22ab0 : IComparer
{
	private static readonly SortedList x7ec23224ee6d01ce;

	private static readonly string[] xd649dd9ca9e9a7d9;

	public int Compare(object x, object y)
	{
		string text = (string)x;
		string text2 = (string)y;
		object obj = x7ec23224ee6d01ce[text];
		object obj2 = x7ec23224ee6d01ce[text2];
		int num = ((obj != null) ? ((int)obj) : int.MaxValue);
		int num2 = ((obj2 != null) ? ((int)obj2) : int.MaxValue);
		if (num != int.MaxValue || num2 != int.MaxValue)
		{
			return num.CompareTo(num2);
		}
		return text.CompareTo(text2);
	}

	static x1cf08cb657f22ab0()
	{
		xd649dd9ca9e9a7d9 = new string[61]
		{
			"size", "width", "height", "margin", "margin-top", "margin-right", "margin-left", "margin-bottom", "text-indent", "text-align",
			"page-break-before", "page-break-inside", "page-break-after", "line-height", "widows", "orphans", "writing-mode", "border", "border-style", "border-width",
			"border-color", "border-top", "border-top-style", "border-top-width", "border-top-color", "border-right", "border-right-style", "border-right-width", "border-right-color", "border-left",
			"border-left-style", "border-left-width", "border-left-color", "border-bottom", "border-bottom-style", "border-bottom-width", "border-bottom-color", "padding", "padding-top", "padding-right",
			"padding-left", "padding-bottom", "font", "font-family", "font-size", "font-weight", "font-style", "font-variant", "text-decoration", "text-transform",
			"letter-spacing", "vertical-align", "color", "background", "background-color", "display", "list-style", "list-style-type", "list-style-image", "list-style-position",
			"src"
		};
		x7ec23224ee6d01ce = new SortedList();
		int num = 0;
		string[] array = xd649dd9ca9e9a7d9;
		foreach (string key in array)
		{
			x7ec23224ee6d01ce.Add(key, ++num);
		}
	}
}
