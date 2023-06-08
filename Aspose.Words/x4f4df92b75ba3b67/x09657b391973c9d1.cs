using System.Collections;
using System.Drawing;
using xcb49d7911c704e1a;

namespace x4f4df92b75ba3b67;

internal class x09657b391973c9d1 : x264ba3b7aca691be, xffc14f01775a70fb
{
	private readonly RectangleF xd8427cc4dda1bfb0 = RectangleF.Empty;

	private readonly bool xa21ac38bde2a77c5;

	private readonly string xbe39036341e55b02;

	private x3b40d431d373c41d x71f716c560c48e24;

	private x63bb1ea2bf3c6ff8 xfbb7a7e515ad5c3a;

	internal x3b40d431d373c41d xca4d557d535fa375
	{
		get
		{
			return x71f716c560c48e24;
		}
		set
		{
			x71f716c560c48e24 = value;
		}
	}

	internal string x42f4c234c9358072 => xbe39036341e55b02;

	internal bool x23ae6e0c44b8e6a2 => xa21ac38bde2a77c5;

	internal x09657b391973c9d1(x4882ae789be6e2ef context, RectangleF activeRect, string target, bool isLocal)
		: base(context)
	{
		xd8427cc4dda1bfb0 = activeRect;
		xbe39036341e55b02 = target;
		xa21ac38bde2a77c5 = isLocal;
		if (!xa21ac38bde2a77c5)
		{
			xfbb7a7e515ad5c3a = new x63bb1ea2bf3c6ff8(target);
		}
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x1c638d277561c422(xbfbb1719d4106af2());
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		writer.xa4dc0ad8886e23a2("/Type", "/Annot");
		writer.xa4dc0ad8886e23a2("/Subtype", "/Link");
		if (x8cedcaa9a62c6e39.x5ba9693d4c3c102e)
		{
			writer.xa4dc0ad8886e23a2("/F", 28);
		}
		writer.xa4dc0ad8886e23a2("/Rect", xd8427cc4dda1bfb0);
		if (!x8cedcaa9a62c6e39.x73979cef1002ed01.x954076483240dd0e)
		{
			writer.xa4dc0ad8886e23a2("/BS", "<</Type/Border/S/S/W 0>>");
		}
		if (xa21ac38bde2a77c5)
		{
			if (x71f716c560c48e24 != null)
			{
				writer.x6210059f049f0d48("/Dest");
				x71f716c560c48e24.x10f3680c04d77f08(writer);
			}
		}
		else
		{
			writer.x6210059f049f0d48("/A");
			xfbb7a7e515ad5c3a.x10f3680c04d77f08(writer);
		}
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
	}

	private void x68096851431ed929(x4f40d990d5bf81a6 xbdfb620b7167944b, IDictionary x740878878ef148b3)
	{
		x0efaba2efb43d7a5(x740878878ef148b3);
		WriteToPdf(xbdfb620b7167944b);
	}

	void xffc14f01775a70fb.x10f3680c04d77f08(x4f40d990d5bf81a6 xbdfb620b7167944b, IDictionary x740878878ef148b3)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x68096851431ed929
		this.x68096851431ed929(xbdfb620b7167944b, x740878878ef148b3);
	}

	private void x0efaba2efb43d7a5(IDictionary x740878878ef148b3)
	{
		if (xa21ac38bde2a77c5)
		{
			x71f716c560c48e24 = (x3b40d431d373c41d)x740878878ef148b3[xbe39036341e55b02];
			if (x71f716c560c48e24 == null)
			{
				x71f716c560c48e24 = (x3b40d431d373c41d)x740878878ef148b3['#' + xbe39036341e55b02];
			}
		}
	}
}
