using System.Collections;
using System.Collections.Generic;

namespace ns73;

internal class Class3699 : IEnumerable, IEnumerable<string>, Interface57, Interface58
{
	private Interface58 interface58_0;

	public Interface58 StyleDeclaration => interface58_0;

	public string CSSText
	{
		get
		{
			return interface58_0.CSSText;
		}
		set
		{
			interface58_0.CSSText = value;
		}
	}

	public int Length
	{
		get
		{
			return interface58_0.Length;
		}
		private set
		{
		}
	}

	public string this[int index] => interface58_0[index];

	public Interface59 ParentRule
	{
		get
		{
			return interface58_0.ParentRule;
		}
		private set
		{
		}
	}

	public Class3699(Interface58 declaration)
	{
		interface58_0 = declaration;
	}

	public string imethod_0()
	{
		return interface58_0.imethod_244("azimuth");
	}

	public void imethod_1(string azimuth)
	{
		interface58_0.imethod_248("azimuth", azimuth, null);
	}

	public string imethod_2()
	{
		return interface58_0.imethod_244("background");
	}

	public void imethod_3(string background)
	{
		interface58_0.imethod_248("background", background, null);
	}

	public string imethod_4()
	{
		return interface58_0.imethod_244("background-attachment");
	}

	public void imethod_5(string backgroundAttachment)
	{
		interface58_0.imethod_248("background-attachment", backgroundAttachment, null);
	}

	public string imethod_6()
	{
		return interface58_0.imethod_244("background-color");
	}

	public void imethod_7(string backgroundColor)
	{
		interface58_0.imethod_248("background-color", backgroundColor, null);
	}

	public string imethod_8()
	{
		return interface58_0.imethod_244("background-image");
	}

	public void imethod_9(string backgroundImage)
	{
		interface58_0.imethod_248("background-image", backgroundImage, null);
	}

	public string imethod_10()
	{
		return interface58_0.imethod_244("background-position");
	}

	public void imethod_11(string backgroundPosition)
	{
		interface58_0.imethod_248("background-position", backgroundPosition, null);
	}

	public string imethod_12()
	{
		return interface58_0.imethod_244("background-repeat");
	}

	public void imethod_13(string backgroundRepeat)
	{
		interface58_0.imethod_248("background-repeat", backgroundRepeat, null);
	}

	public string imethod_14()
	{
		return interface58_0.imethod_244("border");
	}

	public void imethod_15(string border)
	{
		interface58_0.imethod_248("border", border, null);
	}

	public string imethod_16()
	{
		return interface58_0.imethod_244("border-collapse");
	}

	public void imethod_17(string borderCollapse)
	{
		interface58_0.imethod_248("border-collapse", borderCollapse, null);
	}

	public string imethod_18()
	{
		return interface58_0.imethod_244("border-color");
	}

	public void imethod_19(string borderColor)
	{
		interface58_0.imethod_248("border-color", borderColor, null);
	}

	public string imethod_20()
	{
		return interface58_0.imethod_244("border-spacing");
	}

	public void imethod_21(string borderSpacing)
	{
		interface58_0.imethod_248("border-spacing", borderSpacing, null);
	}

	public string imethod_22()
	{
		return interface58_0.imethod_244("border-style");
	}

	public void imethod_23(string borderStyle)
	{
		interface58_0.imethod_248("border-style", borderStyle, null);
	}

	public string imethod_24()
	{
		return interface58_0.imethod_244("border-top");
	}

	public void imethod_25(string borderTop)
	{
		interface58_0.imethod_248("border-top", borderTop, null);
	}

	public string imethod_26()
	{
		return interface58_0.imethod_244("border-right");
	}

	public void imethod_27(string borderRight)
	{
		interface58_0.imethod_248("border-right", borderRight, null);
	}

	public string imethod_28()
	{
		return interface58_0.imethod_244("border-bottom");
	}

	public void imethod_29(string borderBottom)
	{
		interface58_0.imethod_248("border-bottom", borderBottom, null);
	}

	public string imethod_30()
	{
		return interface58_0.imethod_244("border-left");
	}

	public void imethod_31(string borderLeft)
	{
		interface58_0.imethod_248("border-left", borderLeft, null);
	}

	public string imethod_32()
	{
		return interface58_0.imethod_244("border-top-color");
	}

	public void imethod_33(string borderTopColor)
	{
		interface58_0.imethod_248("border-top-color", borderTopColor, null);
	}

	public string imethod_34()
	{
		return interface58_0.imethod_244("border-right-color");
	}

	public void imethod_35(string borderRightColor)
	{
		interface58_0.imethod_248("border-right-color", borderRightColor, null);
	}

	public string imethod_36()
	{
		return interface58_0.imethod_244("border-bottom-color");
	}

	public void imethod_37(string borderBottomColor)
	{
		interface58_0.imethod_248("border-bottom-color", borderBottomColor, null);
	}

	public string imethod_38()
	{
		return interface58_0.imethod_244("border-left-color");
	}

	public void imethod_39(string borderLeftColor)
	{
		interface58_0.imethod_248("border-left-color", borderLeftColor, null);
	}

	public string imethod_40()
	{
		return interface58_0.imethod_244("border-top-style");
	}

	public void imethod_41(string borderTopStyle)
	{
		interface58_0.imethod_248("border-top-style", borderTopStyle, null);
	}

	public string imethod_42()
	{
		return interface58_0.imethod_244("border-right-style");
	}

	public void imethod_43(string borderRightStyle)
	{
		interface58_0.imethod_248("border-right-style", borderRightStyle, null);
	}

	public string imethod_44()
	{
		return interface58_0.imethod_244("border-bottom-style");
	}

	public void imethod_45(string borderBottomStyle)
	{
		interface58_0.imethod_248("border-bottom-style", borderBottomStyle, null);
	}

	public string imethod_46()
	{
		return interface58_0.imethod_244("border-left-style");
	}

	public void imethod_47(string borderLeftStyle)
	{
		interface58_0.imethod_248("border-left-style", borderLeftStyle, null);
	}

	public string imethod_48()
	{
		return interface58_0.imethod_244("border-top-width");
	}

	public void imethod_49(string borderTopWidth)
	{
		interface58_0.imethod_248("border-top-width", borderTopWidth, null);
	}

	public string imethod_50()
	{
		return interface58_0.imethod_244("border-right-width");
	}

	public void imethod_51(string borderRightWidth)
	{
		interface58_0.imethod_248("border-right-width", borderRightWidth, null);
	}

	public string imethod_52()
	{
		return interface58_0.imethod_244("border-bottom-width");
	}

	public void imethod_53(string borderBottomWidth)
	{
		interface58_0.imethod_248("border-bottom-width", borderBottomWidth, null);
	}

	public string imethod_54()
	{
		return interface58_0.imethod_244("border-left-width");
	}

	public void imethod_55(string borderLeftWidth)
	{
		interface58_0.imethod_248("border-left-width", borderLeftWidth, null);
	}

	public string imethod_56()
	{
		return interface58_0.imethod_244("border-width");
	}

	public void imethod_57(string borderWidth)
	{
		interface58_0.imethod_248("border-width", borderWidth, null);
	}

	public string imethod_58()
	{
		return interface58_0.imethod_244("bottom");
	}

	public void imethod_59(string bottom)
	{
		interface58_0.imethod_248("bottom", bottom, null);
	}

	public string imethod_60()
	{
		return interface58_0.imethod_244("caption-side");
	}

	public void imethod_61(string captionSide)
	{
		interface58_0.imethod_248("caption-side", captionSide, null);
	}

	public string imethod_62()
	{
		return interface58_0.imethod_244("clear");
	}

	public void imethod_63(string clear)
	{
		interface58_0.imethod_248("clear", clear, null);
	}

	public string imethod_64()
	{
		return interface58_0.imethod_244("clip");
	}

	public void imethod_65(string clip)
	{
		interface58_0.imethod_248("clip", clip, null);
	}

	public string imethod_66()
	{
		return interface58_0.imethod_244("color");
	}

	public void imethod_67(string color)
	{
		interface58_0.imethod_248("color", color, null);
	}

	public string imethod_68()
	{
		return interface58_0.imethod_244("content");
	}

	public void imethod_69(string content)
	{
		interface58_0.imethod_248("content", content, null);
	}

	public string imethod_70()
	{
		return interface58_0.imethod_244("counter-increment");
	}

	public void imethod_71(string counterIncrement)
	{
		interface58_0.imethod_248("counter-increment", counterIncrement, null);
	}

	public string imethod_72()
	{
		return interface58_0.imethod_244("counter-reset");
	}

	public void imethod_73(string counterReset)
	{
		interface58_0.imethod_248("counter-reset", counterReset, null);
	}

	public string imethod_74()
	{
		return interface58_0.imethod_244("cue");
	}

	public void imethod_75(string cue)
	{
		interface58_0.imethod_248("cue", cue, null);
	}

	public string imethod_76()
	{
		return interface58_0.imethod_244("cue-after");
	}

	public void imethod_77(string cueAfter)
	{
		interface58_0.imethod_248("cue-after", cueAfter, null);
	}

	public string imethod_78()
	{
		return interface58_0.imethod_244("cue-before");
	}

	public void imethod_79(string cueBefore)
	{
		interface58_0.imethod_248("cue-before", cueBefore, null);
	}

	public string imethod_80()
	{
		return interface58_0.imethod_244("cursor");
	}

	public void imethod_81(string cursor)
	{
		interface58_0.imethod_248("cursor", cursor, null);
	}

	public string imethod_82()
	{
		return interface58_0.imethod_244("direction");
	}

	public void imethod_83(string direction)
	{
		interface58_0.imethod_248("direction", direction, null);
	}

	public string imethod_84()
	{
		return interface58_0.imethod_244("display");
	}

	public void imethod_85(string display)
	{
		interface58_0.imethod_248("display", display, null);
	}

	public string imethod_86()
	{
		return interface58_0.imethod_244("elevation");
	}

	public void imethod_87(string elevation)
	{
		interface58_0.imethod_248("elevation", elevation, null);
	}

	public string imethod_88()
	{
		return interface58_0.imethod_244("empty-cells");
	}

	public void imethod_89(string emptyCells)
	{
		interface58_0.imethod_248("empty-cells", emptyCells, null);
	}

	public string imethod_90()
	{
		return interface58_0.imethod_244("float");
	}

	public void imethod_91(string cssFloat)
	{
		interface58_0.imethod_248("float", cssFloat, null);
	}

	public string imethod_92()
	{
		return interface58_0.imethod_244("font");
	}

	public void imethod_93(string font)
	{
		interface58_0.imethod_248("font", font, null);
	}

	public string imethod_94()
	{
		return interface58_0.imethod_244("font-family");
	}

	public void imethod_95(string fontFamily)
	{
		interface58_0.imethod_248("font-family", fontFamily, null);
	}

	public string imethod_96()
	{
		return interface58_0.imethod_244("font-size");
	}

	public void imethod_97(string fontSize)
	{
		interface58_0.imethod_248("font-size", fontSize, null);
	}

	public string imethod_98()
	{
		return interface58_0.imethod_244("font-size-adjust");
	}

	public void imethod_99(string fontSizeAdjust)
	{
		interface58_0.imethod_248("font-size-adjust", fontSizeAdjust, null);
	}

	public string imethod_100()
	{
		return interface58_0.imethod_244("font-stretch");
	}

	public void imethod_101(string fontStretch)
	{
		interface58_0.imethod_248("font-stretch", fontStretch, null);
	}

	public string imethod_102()
	{
		return interface58_0.imethod_244("font-style");
	}

	public void imethod_103(string fontStyle)
	{
		interface58_0.imethod_248("font-style", fontStyle, null);
	}

	public string imethod_104()
	{
		return interface58_0.imethod_244("font-variant");
	}

	public void imethod_105(string fontVariant)
	{
		interface58_0.imethod_248("font-variant", fontVariant, null);
	}

	public string imethod_106()
	{
		return interface58_0.imethod_244("font-weight");
	}

	public void imethod_107(string fontWeight)
	{
		interface58_0.imethod_248("font-weight", fontWeight, null);
	}

	public string imethod_108()
	{
		return interface58_0.imethod_244("height");
	}

	public void imethod_109(string height)
	{
		interface58_0.imethod_248("height", height, null);
	}

	public string imethod_110()
	{
		return interface58_0.imethod_244("left");
	}

	public void imethod_111(string left)
	{
		interface58_0.imethod_248("left", left, null);
	}

	public string imethod_112()
	{
		return interface58_0.imethod_244("letter-spacing");
	}

	public void imethod_113(string letterSpacing)
	{
		interface58_0.imethod_248("letter-spacing", letterSpacing, null);
	}

	public string imethod_114()
	{
		return interface58_0.imethod_244("line-height");
	}

	public void imethod_115(string lineHeight)
	{
		interface58_0.imethod_248("line-height", lineHeight, null);
	}

	public string imethod_116()
	{
		return interface58_0.imethod_244("list-style");
	}

	public void imethod_117(string listStyle)
	{
		interface58_0.imethod_248("list-style", listStyle, null);
	}

	public string imethod_118()
	{
		return interface58_0.imethod_244("list-style-image");
	}

	public void imethod_119(string listStyleImage)
	{
		interface58_0.imethod_248("list-style-image", listStyleImage, null);
	}

	public string imethod_120()
	{
		return interface58_0.imethod_244("list-style-position");
	}

	public void imethod_121(string listStylePosition)
	{
		interface58_0.imethod_248("list-style-position", listStylePosition, null);
	}

	public string imethod_122()
	{
		return interface58_0.imethod_244("list-style-type");
	}

	public void imethod_123(string listStyleType)
	{
		interface58_0.imethod_248("list-style-type", listStyleType, null);
	}

	public string imethod_124()
	{
		return interface58_0.imethod_244("margin");
	}

	public void imethod_125(string margin)
	{
		interface58_0.imethod_248("margin", margin, null);
	}

	public string imethod_126()
	{
		return interface58_0.imethod_244("margin-top");
	}

	public void imethod_127(string marginTop)
	{
		interface58_0.imethod_248("margin-top", marginTop, null);
	}

	public string imethod_128()
	{
		return interface58_0.imethod_244("margin-right");
	}

	public void imethod_129(string marginRight)
	{
		interface58_0.imethod_248("margin-right", marginRight, null);
	}

	public string imethod_130()
	{
		return interface58_0.imethod_244("margin-bottom");
	}

	public void imethod_131(string marginBottom)
	{
		interface58_0.imethod_248("margin-bottom", marginBottom, null);
	}

	public string imethod_132()
	{
		return interface58_0.imethod_244("margin-left");
	}

	public void imethod_133(string marginLeft)
	{
		interface58_0.imethod_248("margin-left", marginLeft, null);
	}

	public string imethod_134()
	{
		return interface58_0.imethod_244("marker-offset");
	}

	public void imethod_135(string markerOffset)
	{
		interface58_0.imethod_248("marker-offset", markerOffset, null);
	}

	public string imethod_136()
	{
		return interface58_0.imethod_244("marks");
	}

	public void imethod_137(string marks)
	{
		interface58_0.imethod_248("marks", marks, null);
	}

	public string imethod_138()
	{
		return interface58_0.imethod_244("max-height");
	}

	public void imethod_139(string maxHeight)
	{
		interface58_0.imethod_248("max-height", maxHeight, null);
	}

	public string imethod_140()
	{
		return interface58_0.imethod_244("max-width");
	}

	public void imethod_141(string maxWidth)
	{
		interface58_0.imethod_248("max-width", maxWidth, null);
	}

	public string imethod_142()
	{
		return interface58_0.imethod_244("min-height");
	}

	public void imethod_143(string minHeight)
	{
		interface58_0.imethod_248("min-height", minHeight, null);
	}

	public string imethod_144()
	{
		return interface58_0.imethod_244("min-width");
	}

	public void imethod_145(string minWidth)
	{
		interface58_0.imethod_248("min-width", minWidth, null);
	}

	public string imethod_146()
	{
		return interface58_0.imethod_244("orphans");
	}

	public void imethod_147(string orphans)
	{
		interface58_0.imethod_248("orphans", orphans, null);
	}

	public string imethod_148()
	{
		return interface58_0.imethod_244("outline");
	}

	public void imethod_149(string outline)
	{
		interface58_0.imethod_248("outline", outline, null);
	}

	public string imethod_150()
	{
		return interface58_0.imethod_244("outline-color");
	}

	public void imethod_151(string outlineColor)
	{
		interface58_0.imethod_248("outline-color", outlineColor, null);
	}

	public string imethod_152()
	{
		return interface58_0.imethod_244("outline-style");
	}

	public void imethod_153(string outlineStyle)
	{
		interface58_0.imethod_248("outline-style", outlineStyle, null);
	}

	public string imethod_154()
	{
		return interface58_0.imethod_244("outline-width");
	}

	public void imethod_155(string outlineWidth)
	{
		interface58_0.imethod_248("outline-width", outlineWidth, null);
	}

	public string imethod_156()
	{
		return interface58_0.imethod_244("overflow");
	}

	public void imethod_157(string overflow)
	{
		interface58_0.imethod_248("overflow", overflow, null);
	}

	public string imethod_158()
	{
		return interface58_0.imethod_244("padding");
	}

	public void imethod_159(string padding)
	{
		interface58_0.imethod_248("padding", padding, null);
	}

	public string imethod_160()
	{
		return interface58_0.imethod_244("padding-top");
	}

	public void imethod_161(string paddingTop)
	{
		interface58_0.imethod_248("padding-top", paddingTop, null);
	}

	public string imethod_162()
	{
		return interface58_0.imethod_244("padding-right");
	}

	public void imethod_163(string paddingRight)
	{
		interface58_0.imethod_248("padding-right", paddingRight, null);
	}

	public string imethod_164()
	{
		return interface58_0.imethod_244("padding-bottom");
	}

	public void imethod_165(string paddingBottom)
	{
		interface58_0.imethod_248("padding-bottom", paddingBottom, null);
	}

	public string imethod_166()
	{
		return interface58_0.imethod_244("padding-left");
	}

	public void imethod_167(string paddingLeft)
	{
		interface58_0.imethod_248("padding-left", paddingLeft, null);
	}

	public string imethod_168()
	{
		return interface58_0.imethod_244("page");
	}

	public void imethod_169(string page)
	{
		interface58_0.imethod_248("page", page, null);
	}

	public string imethod_170()
	{
		return interface58_0.imethod_244("page-break-after");
	}

	public void imethod_171(string pageBreakAfter)
	{
		interface58_0.imethod_248("page-break-after", pageBreakAfter, null);
	}

	public string imethod_172()
	{
		return interface58_0.imethod_244("page-break-before");
	}

	public void imethod_173(string pageBreakBefore)
	{
		interface58_0.imethod_248("page-break-before", pageBreakBefore, null);
	}

	public string imethod_174()
	{
		return interface58_0.imethod_244("page-break-inside");
	}

	public void imethod_175(string pageBreakInside)
	{
		interface58_0.imethod_248("page-break-inside", pageBreakInside, null);
	}

	public string imethod_176()
	{
		return interface58_0.imethod_244("pause");
	}

	public void imethod_177(string pause)
	{
		interface58_0.imethod_248("pause", pause, null);
	}

	public string imethod_178()
	{
		return interface58_0.imethod_244("pause-after");
	}

	public void imethod_179(string pauseAfter)
	{
		interface58_0.imethod_248("pause-after", pauseAfter, null);
	}

	public string imethod_180()
	{
		return interface58_0.imethod_244("pause-before");
	}

	public void imethod_181(string pauseBefore)
	{
		interface58_0.imethod_248("pause-before", pauseBefore, null);
	}

	public string imethod_182()
	{
		return interface58_0.imethod_244("pitch");
	}

	public void imethod_183(string pitch)
	{
		interface58_0.imethod_248("pitch", pitch, null);
	}

	public string imethod_184()
	{
		return interface58_0.imethod_244("pitch-range");
	}

	public void imethod_185(string pitchRange)
	{
		interface58_0.imethod_248("pitch-range", pitchRange, null);
	}

	public string imethod_186()
	{
		return interface58_0.imethod_244("play-during");
	}

	public void imethod_187(string playDuring)
	{
		interface58_0.imethod_248("play-during", playDuring, null);
	}

	public string imethod_188()
	{
		return interface58_0.imethod_244("position");
	}

	public void imethod_189(string position)
	{
		interface58_0.imethod_248("position", position, null);
	}

	public string imethod_190()
	{
		return interface58_0.imethod_244("quotes");
	}

	public void imethod_191(string quotes)
	{
		interface58_0.imethod_248("quotes", quotes, null);
	}

	public string imethod_192()
	{
		return interface58_0.imethod_244("richness");
	}

	public void imethod_193(string richness)
	{
		interface58_0.imethod_248("richness", richness, null);
	}

	public string imethod_194()
	{
		return interface58_0.imethod_244("right");
	}

	public void imethod_195(string right)
	{
		interface58_0.imethod_248("right", right, null);
	}

	public string imethod_196()
	{
		return interface58_0.imethod_244("size");
	}

	public void imethod_197(string size)
	{
		interface58_0.imethod_248("size", size, null);
	}

	public string imethod_198()
	{
		return interface58_0.imethod_244("speak");
	}

	public void imethod_199(string speak)
	{
		interface58_0.imethod_248("speak", speak, null);
	}

	public string imethod_200()
	{
		return interface58_0.imethod_244("speak-header");
	}

	public void imethod_201(string speakHeader)
	{
		interface58_0.imethod_248("speak-header", speakHeader, null);
	}

	public string imethod_202()
	{
		return interface58_0.imethod_244("speak-numeral");
	}

	public void imethod_203(string speakNumeral)
	{
		interface58_0.imethod_248("speak-numeral", speakNumeral, null);
	}

	public string imethod_204()
	{
		return interface58_0.imethod_244("speak-punctuation");
	}

	public void imethod_205(string speakPunctuation)
	{
		interface58_0.imethod_248("speak-punctuation", speakPunctuation, null);
	}

	public string imethod_206()
	{
		return interface58_0.imethod_244("speech-rate");
	}

	public void imethod_207(string speechRate)
	{
		interface58_0.imethod_248("speech-rate", speechRate, null);
	}

	public string imethod_208()
	{
		return interface58_0.imethod_244("stress");
	}

	public void imethod_209(string stress)
	{
		interface58_0.imethod_248("stress", stress, null);
	}

	public string imethod_210()
	{
		return interface58_0.imethod_244("table-layout");
	}

	public void imethod_211(string tableLayout)
	{
		interface58_0.imethod_248("table-layout", tableLayout, null);
	}

	public string imethod_212()
	{
		return interface58_0.imethod_244("text-align");
	}

	public void imethod_213(string textAlign)
	{
		interface58_0.imethod_248("text-align", textAlign, null);
	}

	public string imethod_214()
	{
		return interface58_0.imethod_244("text-decoration");
	}

	public void imethod_215(string textDecoration)
	{
		interface58_0.imethod_248("text-decoration", textDecoration, null);
	}

	public string imethod_216()
	{
		return interface58_0.imethod_244("text-indent");
	}

	public void imethod_217(string textIndent)
	{
		interface58_0.imethod_248("text-indent", textIndent, null);
	}

	public string imethod_218()
	{
		return interface58_0.imethod_244("text-shadow");
	}

	public void imethod_219(string textShadow)
	{
		interface58_0.imethod_248("text-shadow", textShadow, null);
	}

	public string imethod_220()
	{
		return interface58_0.imethod_244("text-transform");
	}

	public void imethod_221(string textTransform)
	{
		interface58_0.imethod_248("text-transform", textTransform, null);
	}

	public string imethod_222()
	{
		return interface58_0.imethod_244("top");
	}

	public void imethod_223(string top)
	{
		interface58_0.imethod_248("top", top, null);
	}

	public string imethod_224()
	{
		return interface58_0.imethod_244("unicode-bidi");
	}

	public void imethod_225(string unicodeBidi)
	{
		interface58_0.imethod_248("unicode-bidi", unicodeBidi, null);
	}

	public string imethod_226()
	{
		return interface58_0.imethod_244("vertical-align");
	}

	public void imethod_227(string verticalAlign)
	{
		interface58_0.imethod_248("vertical-align", verticalAlign, null);
	}

	public string imethod_228()
	{
		return interface58_0.imethod_244("visibility");
	}

	public void imethod_229(string visibility)
	{
		interface58_0.imethod_248("visibility", visibility, null);
	}

	public string imethod_230()
	{
		return interface58_0.imethod_244("voice-family");
	}

	public void imethod_231(string voiceFamily)
	{
		interface58_0.imethod_248("voice-family", voiceFamily, null);
	}

	public string imethod_232()
	{
		return interface58_0.imethod_244("volume");
	}

	public void imethod_233(string volume)
	{
		interface58_0.imethod_248("volume", volume, null);
	}

	public string imethod_234()
	{
		return interface58_0.imethod_244("white-space");
	}

	public void imethod_235(string whiteSpace)
	{
		interface58_0.imethod_248("white-space", whiteSpace, null);
	}

	public string imethod_236()
	{
		return interface58_0.imethod_244("widows");
	}

	public void imethod_237(string widows)
	{
		interface58_0.imethod_248("widows", widows, null);
	}

	public string imethod_238()
	{
		return interface58_0.imethod_244("width");
	}

	public void imethod_239(string width)
	{
		interface58_0.imethod_248("width", width, null);
	}

	public string imethod_240()
	{
		return interface58_0.imethod_244("word-spacing");
	}

	public void imethod_241(string wordSpacing)
	{
		interface58_0.imethod_248("word-spacing", wordSpacing, null);
	}

	public string imethod_242()
	{
		return interface58_0.imethod_244("z-index");
	}

	public void imethod_243(string zIndex)
	{
		interface58_0.imethod_248("z-index", zIndex, null);
	}

	public IEnumerator<string> GetEnumerator()
	{
		return interface58_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public string imethod_244(string propertyName)
	{
		return interface58_0.imethod_244(propertyName);
	}

	public Class3679 imethod_245(string propertyName)
	{
		return interface58_0.imethod_245(propertyName);
	}

	public string imethod_246(string propertyName)
	{
		return interface58_0.imethod_246(propertyName);
	}

	public string imethod_247(string propertyName)
	{
		return interface58_0.imethod_247(propertyName);
	}

	public void imethod_248(string propertyName, string value, string priority)
	{
		interface58_0.imethod_248(propertyName, value, priority);
	}
}
