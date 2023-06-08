using System.Collections;
using System.Drawing;
using x66dd9eaee57cfba4;

namespace x4f4df92b75ba3b67;

internal class x00ecacea06b9b181 : xba2f911354958a68
{
	private const string xf525b57b949a745f = "Symbol";

	private const string x6c901b7605746bdd = "Symbol";

	private readonly string x8756913c23d46cb8;

	private static readonly Hashtable xa6c34559de430e37;

	public x00ecacea06b9b181(x4882ae789be6e2ef context, FontStyle requestedStyle, xcb3d00e64f2216e5 fontData, string fontName)
		: base(context, requestedStyle, (fontName == "Symbol") ? ((x6abbea4951acbffd)new x057ba80c693197ea()) : ((x6abbea4951acbffd)new x7819ee089c842c62()), fontData)
	{
		x8756913c23d46cb8 = fontName;
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		writer.xa4dc0ad8886e23a2("/Type", "/Font");
		writer.xa4dc0ad8886e23a2("/Subtype", "/Type1");
		writer.xa4dc0ad8886e23a2("/BaseFont", $"/{x8756913c23d46cb8}");
		x9ee491ab5579b9fc.WriteEncodingToFontDictionary(writer);
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
	}

	internal static bool xe28de3e3c9d9d2f4(x6b1a899052c71a60 x26094932cf7a9139)
	{
		return xa6c34559de430e37.ContainsKey(x26094932cf7a9139.x0a4b32fbe2e5933b);
	}

	internal static string x050b26a5b6e831ac(x6b1a899052c71a60 x26094932cf7a9139)
	{
		return (string)xa6c34559de430e37[x26094932cf7a9139.x0a4b32fbe2e5933b];
	}

	static x00ecacea06b9b181()
	{
		xa6c34559de430e37 = new Hashtable();
		xa6c34559de430e37.Add("Arial", "Helvetica");
		xa6c34559de430e37.Add("Arial Italic", "Helvetica-Oblique");
		xa6c34559de430e37.Add("Arial Bold", "Helvetica-Bold");
		xa6c34559de430e37.Add("Arial Bold Italic", "Helvetica-BoldOblique");
		xa6c34559de430e37.Add("Courier New", "Courier");
		xa6c34559de430e37.Add("Courier New Italic", "Courier-Oblique");
		xa6c34559de430e37.Add("Courier New Bold", "Courier-Bold");
		xa6c34559de430e37.Add("Courier New Bold Italic", "Courier-BoldOblique");
		xa6c34559de430e37.Add("Times New Roman", "Times-Roman");
		xa6c34559de430e37.Add("Times New Roman Italic", "Times-Italic");
		xa6c34559de430e37.Add("Times New Roman Bold", "Times-Bold");
		xa6c34559de430e37.Add("Times New Roman Bold Italic", "Times-BoldItalic");
		xa6c34559de430e37.Add("Symbol", "Symbol");
	}
}
