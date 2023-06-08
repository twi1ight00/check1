using System.Collections;
using System.Drawing.Drawing2D;
using ns312;
using ns315;

namespace ns313;

internal class Class7133 : Class7132
{
	private Enum976 enum976_1;

	private GraphicsPath graphicsPath_1;

	public override Enum976 ClipRule => enum976_1;

	public override GraphicsPath Path => graphicsPath_1;

	public Class7133()
	{
		method_2();
		graphicsPath_1 = new GraphicsPath();
	}

	public Class7133(string nodeName, Hashtable properties, Class7132 svgParent)
	{
		string_0 = nodeName;
		class7132_0 = svgParent;
		hashtable_0 = properties;
		graphicsPath_1 = new GraphicsPath();
		method_2();
	}

	private void method_2()
	{
		arrayList_1 = new ArrayList(new string[5] { "animate", "animateColor", "animateMotion", "animateTransform", "set" });
		arrayList_2 = new ArrayList(new string[3] { "desc", "metadata", "title" });
		arrayList_6 = new ArrayList(new string[3] { "requiredFeatures", "requiredExtensions", "systemLanguage" });
		arrayList_7 = new ArrayList(new string[4] { "id", "xml:base", "xml:lang", "xml:space" });
		arrayList_8 = new ArrayList(new string[10] { "onfocusin", "onfocusout", "onactivate", "onclick", "onmousedown", "onmouseup", "onmouseover", "onmousemove", "onmouseout", "onload" });
		arrayList_9 = new ArrayList(new string[59]
		{
			"alignment-baseline", "baseline-shift", "clip", "clip-path", "clip-rule", "color", "color-interpolation", "color-interpolation-filters", "color-profile", "color-rendering",
			"cursor", "direction", "display", "dominant-baseline", "enable-background", "fill", "fill-opacity", "fill-rule", "filter", "flood-color",
			"flood-opacity", "font-family", "font-size", "font-size-adjust", "font-stretch", "font-style", "font-variant", "font-weight", "glyph-orientation-horizontal", "glyph-orientation-vertical",
			"image-rendering", "kerning", "letter-spacing", "lighting-color", "marker-end", "marker-mid", "marker-start", "mask", "opacity", "overflow",
			"pointer-events", "shape-rendering", "stop-color", "stop-opacity", "stroke", "stroke-dasharray", "stroke-dashoffset", "stroke-linecap", "stroke-linejoin", "stroke-miterlimit",
			"stroke-opacity", "stroke-width", "text-anchor", "text-decoration", "text-rendering", "unicode-bidi", "visibility", "word-spacing", "writing-mode"
		});
		hashtable_1.Add("x", 0);
		hashtable_1.Add("y", 0);
	}
}
