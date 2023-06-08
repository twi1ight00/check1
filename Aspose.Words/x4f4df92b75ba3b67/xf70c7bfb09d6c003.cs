using System.Collections;
using System.Drawing;
using System.IO;

namespace x4f4df92b75ba3b67;

internal class xf70c7bfb09d6c003 : x264ba3b7aca691be, xffc14f01775a70fb
{
	private readonly xd83a9e112035523a x63512d446e05b455;

	private readonly RectangleF xd8427cc4dda1bfb0 = RectangleF.Empty;

	private readonly xd6b2a42851fedfba x0a1aee6bd4aee6ae;

	private readonly x8b1c15f4cec97314 x782b6a019952d64c;

	internal xd83a9e112035523a xca559344d394e612 => x63512d446e05b455;

	internal xf70c7bfb09d6c003(x4882ae789be6e2ef context, RectangleF activeRect, xd6b2a42851fedfba hostpage)
		: base(context)
	{
		xd8427cc4dda1bfb0 = activeRect;
		x63512d446e05b455 = new xd83a9e112035523a(context);
		x0a1aee6bd4aee6ae = hostpage;
		x782b6a019952d64c = new x8b1c15f4cec97314(context);
		x782b6a019952d64c.xe36c96d8c564b382 = new MemoryStream();
	}

	private void x68096851431ed929(x4f40d990d5bf81a6 xbdfb620b7167944b, IDictionary x740878878ef148b3)
	{
		WriteToPdf(xbdfb620b7167944b);
	}

	void xffc14f01775a70fb.x10f3680c04d77f08(x4f40d990d5bf81a6 xbdfb620b7167944b, IDictionary x740878878ef148b3)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x68096851431ed929
		this.x68096851431ed929(xbdfb620b7167944b, x740878878ef148b3);
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x1c638d277561c422(xbfbb1719d4106af2());
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		writer.xa4dc0ad8886e23a2("/Type", "/Annot");
		writer.xa4dc0ad8886e23a2("/Subtype", "/Widget");
		writer.xa4dc0ad8886e23a2("/FT", "/Sig");
		writer.xa4dc0ad8886e23a2("/DR", "<<>>");
		writer.xa4dc0ad8886e23a2("/F", 132);
		writer.xa4dc0ad8886e23a2("/Rect", xd8427cc4dda1bfb0);
		writer.xa4dc0ad8886e23a2("/V", x63512d446e05b455.x899a2110a8a35fda);
		writer.xa4dc0ad8886e23a2("/P", x0a1aee6bd4aee6ae.x899a2110a8a35fda);
		writer.x94aba205302527e1("/T", "AsposeDigitalSignature");
		writer.x241b3c2e8c3aaa86("/AP");
		writer.xafb7e6f79ed43681();
		writer.x241b3c2e8c3aaa86("/N");
		writer.x6210059f049f0d48(x782b6a019952d64c.x899a2110a8a35fda);
		writer.x693a8d6d020474f2();
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
		x63512d446e05b455.WriteToPdf(writer);
		x782b6a019952d64c.WriteToPdf(writer);
	}
}
