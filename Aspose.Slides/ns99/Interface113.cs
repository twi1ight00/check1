using System.IO;
using ns119;

namespace ns99;

internal interface Interface113
{
	Enum639 FontType { get; }

	string Style { get; }

	Enum640 FontStyle { get; }

	string FontFamily { get; }

	string FontName { get; }

	Class4519 FontNames { get; }

	Class4519 PostscriptNames { get; }

	int NumGlyphs { get; }

	Interface118 Metrics { get; }

	Interface114 Encoding { get; }

	Enum643 GlyphIDType { get; }

	Class4490 FontDefinition { get; }

	Class4480 imethod_0(Class4506 id);

	Class4506[] imethod_1();

	double imethod_2(string unicode, double fontSize);

	void Save(Stream stream);

	void Save(string fileName);

	Interface119 imethod_3();

	Class4408 imethod_4(Enum639 fontType);
}
