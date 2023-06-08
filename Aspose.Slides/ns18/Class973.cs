using Aspose.Slides;
using ns56;

namespace ns18;

internal class Class973
{
	public static void smethod_0(IPatternFormat patternFormat, Class1900 patternElementData)
	{
		if (patternElementData != null)
		{
			patternFormat.PatternStyle = patternElementData.Prst;
			Class930.smethod_0(patternFormat.ForeColor, patternElementData.FgClr);
			Class930.smethod_0(patternFormat.BackColor, patternElementData.BgClr);
		}
	}

	public static void smethod_1(IPatternFormat patternFormat, Class1900 patternElementData)
	{
		if (patternFormat != null)
		{
			patternElementData.Prst = patternFormat.PatternStyle;
			Class930.smethod_2(patternFormat.ForeColor, patternElementData.delegate1321_0);
			Class930.smethod_2(patternFormat.BackColor, patternElementData.delegate1321_1);
		}
	}
}
