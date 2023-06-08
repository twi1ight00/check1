using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x3d94286fe72124a8;
using x5794c252ba25e723;

namespace x120d4bb5c80fb10c;

internal class x8d0dd4e94b25f99a : xf51865b83a7a0b3b
{
	private bool x95dd18abddef96d9;

	private x1ae70714edec817d xdd659fe41ea320aa;

	private RectangleF x18847e4f94b14ff7;

	private ArrayList x1fd2519c1f5fe0e3;

	internal static x1ae70714edec817d xa78bd34efc70ec90(xb8e7e788f6d59708 x08ce8f4769eb3234, RectangleF x3c5961d0baf2cbd4)
	{
		x8d0dd4e94b25f99a x8d0dd4e94b25f99a2 = new x8d0dd4e94b25f99a();
		return x8d0dd4e94b25f99a2.x6eb5c48c97244233(x08ce8f4769eb3234, x3c5961d0baf2cbd4);
	}

	internal static RectangleF xf3819bc58c7d7fda(xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		x8d0dd4e94b25f99a x8d0dd4e94b25f99a2 = new x8d0dd4e94b25f99a();
		x8d0dd4e94b25f99a2.x95dd18abddef96d9 = true;
		x1ae70714edec817d x1ae70714edec817d2 = x8d0dd4e94b25f99a2.x6eb5c48c97244233(x08ce8f4769eb3234, RectangleF.Empty);
		return x1ae70714edec817d2.x7b2401fb9a2ead15();
	}

	public override void VisitCanvasStart(xb8e7e788f6d59708 canvas)
	{
		xf05917a59c35aa5c xf05917a59c35aa5c2 = new xf05917a59c35aa5c(canvas.x52dde376accdec7d);
		if (canvas.x0e1bf8242ad10272 != null)
		{
			x6607281c5523036c x6607281c5523036c = new x6607281c5523036c();
			xab391c46ff9a0a38 xab391c46ff9a0a = x6607281c5523036c.xe94da055c1b9a188(canvas.x0e1bf8242ad10272, x2b818897b65c872e: false, xdb73611e5c07ce94: false);
			xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(x26d9ecb4bdf0456d.x89fffa2751fdecbe);
			xab391c46ff9a0a.x9e5d5f9128c69a8f.xdc1bf80853046136 = 0f;
			xf05917a59c35aa5c2.x23571e2b1f06706c = x4550028bd6f6fe67.xa78bd34efc70ec90(xab391c46ff9a0a);
		}
		x1fd2519c1f5fe0e3.Add(xf05917a59c35aa5c2);
	}

	public override void VisitCanvasEnd(xb8e7e788f6d59708 canvas)
	{
		if (x95dd18abddef96d9 && canvas.xd44988f225497f3a == 0)
		{
			x6348589e71d87347(new x1ae70714edec817d(new x03d68de1c2f74051(new PointF[1] { PointF.Empty })));
		}
		x1fd2519c1f5fe0e3.RemoveAt(x1fd2519c1f5fe0e3.Count - 1);
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		x1ae70714edec817d xff5e24fda2dd = x74ed4bb22f1a8f34(path);
		x6348589e71d87347(xff5e24fda2dd);
	}

	public override void VisitImage(x72c34b8dbaec3734 image)
	{
		x1ae70714edec817d xff5e24fda2dd = x86d515adc7a0a302(image);
		x6348589e71d87347(xff5e24fda2dd);
	}

	public override void VisitGlyphs(xcc8c7739d82c63ba glyphs)
	{
		x1ae70714edec817d xff5e24fda2dd = new x1ae70714edec817d(new x03d68de1c2f74051(glyphs.x6ae4612a8469678e));
		x6348589e71d87347(xff5e24fda2dd);
	}

	private void x6348589e71d87347(x1ae70714edec817d xff5e24fda2dd7271)
	{
		xae8263a087ff35c1(xff5e24fda2dd7271);
		for (int i = 0; i < xff5e24fda2dd7271.xe9e87df45862c20a; i++)
		{
			x891b55aaff8e39df(xff5e24fda2dd7271.get_xe6d4b1b411ed94b5(i));
			if (x95dd18abddef96d9)
			{
				xdd659fe41ea320aa.xcacd30c6b3be9db7(xff5e24fda2dd7271.get_xe6d4b1b411ed94b5(i));
			}
			else
			{
				xdd659fe41ea320aa.x89d9fcfbcec41d3c(xff5e24fda2dd7271.get_xe6d4b1b411ed94b5(i));
			}
		}
	}

	private x1ae70714edec817d x6eb5c48c97244233(xb8e7e788f6d59708 x08ce8f4769eb3234, RectangleF x3c5961d0baf2cbd4)
	{
		x18847e4f94b14ff7 = x3c5961d0baf2cbd4;
		xdd659fe41ea320aa = new x1ae70714edec817d();
		x1fd2519c1f5fe0e3 = new ArrayList();
		x08ce8f4769eb3234.Accept(this);
		return xdd659fe41ea320aa;
	}

	private x1ae70714edec817d x74ed4bb22f1a8f34(xab391c46ff9a0a38 xe125219852864557)
	{
		x1ae70714edec817d x1ae70714edec817d2 = null;
		if (!x95dd18abddef96d9)
		{
			x1ae70714edec817d2 = xff6b565db98b31b6(xe125219852864557);
		}
		if (x1ae70714edec817d2 == null)
		{
			x1ae70714edec817d2 = new x1ae70714edec817d(x4550028bd6f6fe67.xa78bd34efc70ec90(xe125219852864557));
		}
		return x1ae70714edec817d2;
	}

	private x1ae70714edec817d xff6b565db98b31b6(xab391c46ff9a0a38 xe125219852864557)
	{
		if (xe125219852864557.x9e5d5f9128c69a8f != null)
		{
			return null;
		}
		if (xe125219852864557.x60465f602599d327 is x5e9754e56a4f759f x5e9754e56a4f759f)
		{
			return x225ce39bf4d3057e.xa78bd34efc70ec90(x5e9754e56a4f759f.xcc18177a965e0313, x18847e4f94b14ff7);
		}
		return null;
	}

	private void xae8263a087ff35c1(x1ae70714edec817d xd6398ac5382774e3)
	{
		xf05917a59c35aa5c xf05917a59c35aa5c2 = (xf05917a59c35aa5c)x1fd2519c1f5fe0e3[x1fd2519c1f5fe0e3.Count - 1];
		if (xf05917a59c35aa5c2.x23571e2b1f06706c != null)
		{
			xd6398ac5382774e3.x0e1bf8242ad10272(xf05917a59c35aa5c2.x23571e2b1f06706c);
		}
	}

	private void x891b55aaff8e39df(x03d68de1c2f74051 xe41c5c767887b961)
	{
		for (int num = x1fd2519c1f5fe0e3.Count - 1; num >= 0; num--)
		{
			xf05917a59c35aa5c xf05917a59c35aa5c2 = (xf05917a59c35aa5c)x1fd2519c1f5fe0e3[num];
			x54366fa5f75a02f7 x54366fa5f75a02f = ((xf05917a59c35aa5c2.x52dde376accdec7d != null) ? xf05917a59c35aa5c2.x52dde376accdec7d : null);
			if (x54366fa5f75a02f != null)
			{
				xe41c5c767887b961.x4fdf47a12306c1b7(x54366fa5f75a02f);
			}
		}
	}

	private static x1ae70714edec817d x86d515adc7a0a302(x72c34b8dbaec3734 xe058541ca798c059)
	{
		return x225ce39bf4d3057e.xa78bd34efc70ec90(xe058541ca798c059.xcc18177a965e0313, xe058541ca798c059.x6ae4612a8469678e);
	}
}
