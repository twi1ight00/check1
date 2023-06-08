using System.Drawing;
using ns184;
using ns271;

namespace ns185;

internal class Class5457 : Interface195
{
	private bool bool_0;

	private bool bool_1;

	public bool UseHelvetica
	{
		set
		{
			bool_1 = value;
		}
	}

	public Class5457(bool kerning)
	{
		bool_0 = kerning;
	}

	public int imethod_0(int start, Class5730 fontInfo)
	{
		if (bool_1)
		{
			fontInfo.method_5("F1", new Class5002(bool_0));
		}
		else
		{
			fontInfo.method_5("F1", new Class4987(Class6652.Instance.method_1("Arial", 1f, FontStyle.Regular), "Arial"));
		}
		fontInfo.method_5("F2", new Class4995(bool_0));
		fontInfo.method_5("F3", new Class4993(bool_0));
		fontInfo.method_5("F4", new Class4994(bool_0));
		fontInfo.method_5("F5", new Class5000(bool_0));
		fontInfo.method_5("F6", new Class4999(bool_0));
		fontInfo.method_5("F7", new Class4997(bool_0));
		fontInfo.method_5("F8", new Class4998(bool_0));
		fontInfo.method_5("F9", new Class4989(bool_0));
		fontInfo.method_5("F10", new Class4992(bool_0));
		fontInfo.method_5("F11", new Class4990(bool_0));
		fontInfo.method_5("F12", new Class4991(bool_0));
		fontInfo.method_5("F13", new Class5001());
		fontInfo.method_5("F14", new Class4987(Class6652.Instance.method_1("SimSun", 1f, FontStyle.Regular), "SimSun"));
		fontInfo.method_2("F5", "any", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F6", "any", Class5729.string_1, Class5729.int_2);
		fontInfo.method_2("F6", "any", Class5729.string_2, Class5729.int_2);
		fontInfo.method_2("F7", "any", Class5729.string_0, Class5729.int_1);
		fontInfo.method_2("F8", "any", Class5729.string_1, Class5729.int_1);
		fontInfo.method_2("F8", "any", Class5729.string_2, Class5729.int_1);
		fontInfo.method_2("F1", "sans-serif", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F2", "sans-serif", Class5729.string_2, Class5729.int_2);
		fontInfo.method_2("F2", "sans-serif", Class5729.string_1, Class5729.int_2);
		fontInfo.method_2("F3", "sans-serif", Class5729.string_0, Class5729.int_1);
		fontInfo.method_2("F4", "sans-serif", Class5729.string_2, Class5729.int_1);
		fontInfo.method_2("F4", "sans-serif", Class5729.string_1, Class5729.int_1);
		fontInfo.method_2("F1", "SansSerif", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F2", "SansSerif", Class5729.string_2, Class5729.int_2);
		fontInfo.method_2("F2", "SansSerif", Class5729.string_1, Class5729.int_2);
		fontInfo.method_2("F3", "SansSerif", Class5729.string_0, Class5729.int_1);
		fontInfo.method_2("F4", "SansSerif", Class5729.string_2, Class5729.int_1);
		fontInfo.method_2("F4", "SansSerif", Class5729.string_1, Class5729.int_1);
		fontInfo.method_2("F5", "serif", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F6", "serif", Class5729.string_2, Class5729.int_2);
		fontInfo.method_2("F6", "serif", Class5729.string_1, Class5729.int_2);
		fontInfo.method_2("F7", "serif", Class5729.string_0, Class5729.int_1);
		fontInfo.method_2("F8", "serif", Class5729.string_2, Class5729.int_1);
		fontInfo.method_2("F8", "serif", Class5729.string_1, Class5729.int_1);
		fontInfo.method_2("F9", "monospace", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F10", "monospace", Class5729.string_2, Class5729.int_2);
		fontInfo.method_2("F10", "monospace", Class5729.string_1, Class5729.int_2);
		fontInfo.method_2("F11", "monospace", Class5729.string_0, Class5729.int_1);
		fontInfo.method_2("F12", "monospace", Class5729.string_2, Class5729.int_1);
		fontInfo.method_2("F12", "monospace", Class5729.string_1, Class5729.int_1);
		fontInfo.method_2("F9", "Monospaced", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F10", "Monospaced", Class5729.string_2, Class5729.int_2);
		fontInfo.method_2("F10", "Monospaced", Class5729.string_1, Class5729.int_2);
		fontInfo.method_2("F11", "Monospaced", Class5729.string_0, Class5729.int_1);
		fontInfo.method_2("F12", "Monospaced", Class5729.string_2, Class5729.int_1);
		fontInfo.method_2("F12", "Monospaced", Class5729.string_1, Class5729.int_1);
		fontInfo.method_2("F1", "Helvetica", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F2", "Helvetica", Class5729.string_2, Class5729.int_2);
		fontInfo.method_2("F2", "Helvetica", Class5729.string_1, Class5729.int_2);
		fontInfo.method_2("F3", "Helvetica", Class5729.string_0, Class5729.int_1);
		fontInfo.method_2("F4", "Helvetica", Class5729.string_2, Class5729.int_1);
		fontInfo.method_2("F4", "Helvetica", Class5729.string_1, Class5729.int_1);
		fontInfo.method_2("F5", "Times", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F6", "Times", Class5729.string_2, Class5729.int_2);
		fontInfo.method_2("F6", "Times", Class5729.string_1, Class5729.int_2);
		fontInfo.method_2("F7", "Times", Class5729.string_0, Class5729.int_1);
		fontInfo.method_2("F8", "Times", Class5729.string_2, Class5729.int_1);
		fontInfo.method_2("F8", "Times", Class5729.string_1, Class5729.int_1);
		fontInfo.method_2("F9", "Courier", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F10", "Courier", Class5729.string_2, Class5729.int_2);
		fontInfo.method_2("F10", "Courier", Class5729.string_1, Class5729.int_2);
		fontInfo.method_2("F11", "Courier", Class5729.string_0, Class5729.int_1);
		fontInfo.method_2("F12", "Courier", Class5729.string_2, Class5729.int_1);
		fontInfo.method_2("F12", "Courier", Class5729.string_1, Class5729.int_1);
		fontInfo.method_2("F13", "ZapfDingbats", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F5", "Times-Roman", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F6", "Times-Roman", Class5729.string_2, Class5729.int_2);
		fontInfo.method_2("F6", "Times-Roman", Class5729.string_1, Class5729.int_2);
		fontInfo.method_2("F7", "Times-Roman", Class5729.string_0, Class5729.int_1);
		fontInfo.method_2("F8", "Times-Roman", Class5729.string_2, Class5729.int_1);
		fontInfo.method_2("F8", "Times-Roman", Class5729.string_1, Class5729.int_1);
		fontInfo.method_2("F5", "Times Roman", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F6", "Times Roman", Class5729.string_2, Class5729.int_2);
		fontInfo.method_2("F6", "Times Roman", Class5729.string_1, Class5729.int_2);
		fontInfo.method_2("F7", "Times Roman", Class5729.string_0, Class5729.int_1);
		fontInfo.method_2("F8", "Times Roman", Class5729.string_2, Class5729.int_1);
		fontInfo.method_2("F8", "Times Roman", Class5729.string_1, Class5729.int_1);
		fontInfo.method_2("F9", "Computer-Modern-Typewriter", Class5729.string_0, Class5729.int_2);
		fontInfo.method_2("F14", "SimSun", Class5729.string_0, Class5729.int_2);
		return 15;
	}
}
