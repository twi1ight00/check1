using System.Collections;
using x1c8faa688b1f0b0c;

namespace x3d94286fe72124a8;

internal class xdf3c9fa4d48100a3 : xf51865b83a7a0b3b
{
	private x0d668e8def1e62e6 x18905bdeafa10a12;

	private readonly ArrayList x195c9f799b75127d = new ArrayList();

	internal static void x757450d4e4eec6d0(xb8e7e788f6d59708 x11a78291278f8309)
	{
		xdf3c9fa4d48100a3 xdf3c9fa4d48100a4 = new xdf3c9fa4d48100a3();
		xdf3c9fa4d48100a4.xe406325e56f74b46(x11a78291278f8309);
	}

	private void xe406325e56f74b46(xb8e7e788f6d59708 x11a78291278f8309)
	{
		x11a78291278f8309.Accept(this);
	}

	public override void VisitCanvasStart(xb8e7e788f6d59708 canvas)
	{
		x0d668e8def1e62e6 value = new x0d668e8def1e62e6(canvas);
		x195c9f799b75127d.Add(value);
		x18905bdeafa10a12 = value;
	}

	public override void VisitCanvasEnd(xb8e7e788f6d59708 canvas)
	{
		x18905bdeafa10a12.x63f57747c3aa8228();
		int count = x195c9f799b75127d.Count;
		x195c9f799b75127d.RemoveAt(count - 1);
		if (count - 1 > 0)
		{
			x18905bdeafa10a12 = (x0d668e8def1e62e6)x195c9f799b75127d[count - 2];
		}
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		xab391c46ff9a0a38[] xee75ad616e9ea85f = x0c8c298e5b4ef6f5.x757450d4e4eec6d0(path);
		x18905bdeafa10a12.x74ed4bb22f1a8f34(path, xee75ad616e9ea85f);
	}
}
