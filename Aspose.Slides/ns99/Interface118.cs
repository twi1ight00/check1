using ns121;

namespace ns99;

internal interface Interface118
{
	bool IsFixedPitch { get; }

	Class4518 FontBBox { get; }

	Class4509 FontMatrix { get; }

	uint UnitsPerEM { get; set; }

	double Ascender { get; set; }

	double TypoAscender { get; set; }

	double Descender { get; set; }

	double TypoDescender { get; set; }

	double LineGap { get; }

	double TypoLineGap { get; }

	double imethod_0(Class4506 prevGlyphId, Class4506 nextGlyphId);

	double imethod_1(Class4506 glyphId);

	Class4518 imethod_2(Class4506 glyphId);

	double imethod_3(double fontSize);

	double imethod_4(double fontSize);

	double imethod_5(double fontSize);

	double imethod_6(double fontSize);

	double imethod_7(double fontSize);
}
