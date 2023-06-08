using ns224;

namespace ns237;

internal class Class6557 : Interface319
{
	private Class5998 class5998_0;

	private Class5998 class5998_1;

	public Class6557()
	{
	}

	public Class6557(Class5998 start, Class5998 finish)
	{
		class5998_0 = start;
		class5998_1 = finish;
	}

	public string imethod_0()
	{
		string format = " {1} {0} sub mul {0} add 255 div";
		string text = " pop dup";
		text += string.Format(format, class5998_0.R, class5998_1.R);
		text += " exch dup";
		text += string.Format(format, class5998_0.G, class5998_1.G);
		text += " exch";
		text += string.Format(format, class5998_0.B, class5998_1.B);
		string text2 = "2 copy 0 lt exch 0 lt or { pop pop 256 256 256 } { " + text + " } ifelse";
		return "2 copy 1 gt exch 1 gt or { pop pop 256 256 256 } { " + text2 + " } ifelse ";
	}
}
