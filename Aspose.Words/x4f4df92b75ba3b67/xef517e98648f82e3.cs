using System.Drawing;

namespace x4f4df92b75ba3b67;

internal class xef517e98648f82e3 : xba2f911354958a68
{
	private readonly xa4f1070b7f6449f0 x2bfc64a47e9abe5c;

	public xef517e98648f82e3(x4882ae789be6e2ef context, FontStyle requestedStyle, xcb3d00e64f2216e5 fontData)
		: base(context, requestedStyle, new x7819ee089c842c62(), fontData)
	{
		x2bfc64a47e9abe5c = new xa4f1070b7f6449f0(context, this, fontData);
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		x51cf2b3953f93541(writer);
		x2bfc64a47e9abe5c.WriteToPdf(writer);
	}

	private void x51cf2b3953f93541(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x7a67b9beb30292d6(this);
		xbdfb620b7167944b.xafb7e6f79ed43681();
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Type", "/Font");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Subtype", "/TrueType");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/BaseFont", $"/{base.xd47a98a7600d6b65}");
		x9ee491ab5579b9fc.WriteEncodingToFontDictionary(xbdfb620b7167944b);
		int num = base.x25998da3963930e9.x5827fed50444ba26();
		int num2 = base.x25998da3963930e9.xb6ce281bc6a25482();
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/FirstChar", num);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/LastChar", num2);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Widths", base.x25998da3963930e9.x192c5bb32da97748(num, num2));
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/FontDescriptor", x2bfc64a47e9abe5c.x899a2110a8a35fda);
		xbdfb620b7167944b.x693a8d6d020474f2();
		xbdfb620b7167944b.x5155d7b9dab28280();
	}
}
