using System.Collections;
using System.Drawing;
using Aspose.Words;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x59d6a4fc5007b7a4;

namespace x6a42c37b95e9caa1;

internal class xe6a5f3ec802a6d51
{
	private readonly xdeb77ea37ad74c56 xd5f4d4b5bdd8e58a;

	private readonly x9df536d98415d2d0 xa737d500a7554634 = new x9df536d98415d2d0();

	private xbaec545ec01f92ca x437fa02210b98bec;

	private readonly Stack xc71979c9a7aaaa87 = new Stack();

	private PointF x62d9bfcf54e338cb = PointF.Empty;

	internal xbaec545ec01f92ca xc255c495fd9232ca => x437fa02210b98bec;

	internal xdeb77ea37ad74c56 xdeb77ea37ad74c56 => xd5f4d4b5bdd8e58a;

	internal xe6a5f3ec802a6d51(xbaec545ec01f92ca container, xdeb77ea37ad74c56 layoutOptions)
	{
		x437fa02210b98bec = container;
		xd5f4d4b5bdd8e58a = layoutOptions;
	}

	internal xbaec545ec01f92ca x490834a62c46f14d(xbaec545ec01f92ca x1abafc112c220cac)
	{
		xc71979c9a7aaaa87.Push(x437fa02210b98bec);
		x437fa02210b98bec.xd6b6ed77479ef68c(x1abafc112c220cac);
		x437fa02210b98bec = x1abafc112c220cac;
		return x437fa02210b98bec;
	}

	internal xb8e7e788f6d59708 xd53690ab1592eec8(PointF x9c3c185e7046dc72)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xb8e7e788f6d.x52dde376accdec7d = x779d03b9e20d92f5(x9c3c185e7046dc72);
		x490834a62c46f14d(xb8e7e788f6d);
		return xb8e7e788f6d;
	}

	internal xdc4867bff1715a4b x98c00ccab44bf40d(x5b0ea7c4a9d65903 x6f02b6a80bf6b36f)
	{
		xdc4867bff1715a4b xdc4867bff1715a4b = new xdc4867bff1715a4b();
		if (x6f02b6a80bf6b36f != 0)
		{
			xdc4867bff1715a4b.xd229d86af0f16fb0 = x6f02b6a80bf6b36f;
		}
		x490834a62c46f14d(xdc4867bff1715a4b);
		return xdc4867bff1715a4b;
	}

	private static x54366fa5f75a02f7 x779d03b9e20d92f5(PointF x9c3c185e7046dc72)
	{
		return new x54366fa5f75a02f7(1f, 0f, 0f, 1f, x9c3c185e7046dc72.X, x9c3c185e7046dc72.Y);
	}

	internal void xf5b0b9b6ff7ac462()
	{
		x437fa02210b98bec = (xbaec545ec01f92ca)xc71979c9a7aaaa87.Pop();
	}

	internal void x1fa9148f6731ff24(x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		x437fa02210b98bec.xd6b6ed77479ef68c(xda5bf54deb817e37);
	}

	internal void xee63d905da8ff550(RectangleF x26545669838eb36e, x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(x26545669838eb36e);
		xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(x6c50a99faab7d741);
		x1fa9148f6731ff24(xab391c46ff9a0a);
	}

	internal void x00149f2495b0f026(Shading xb570fd99925d4b54)
	{
		xa737d500a7554634.x00149f2495b0f026(xb570fd99925d4b54);
	}

	internal void xbcd358ebb8d4e95e()
	{
		xa737d500a7554634.xbcd358ebb8d4e95e();
	}

	internal x26d9ecb4bdf0456d xa6dfa2703204e9f0(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		return xa737d500a7554634.xa6dfa2703204e9f0(x6c50a99faab7d741);
	}

	internal void xd26f731b334aa0f8(PointF x374ea4fe62468d0f)
	{
		x62d9bfcf54e338cb = x374ea4fe62468d0f;
	}

	internal PointF xce92de628aa023cf(PointF x2f7096dac971d6ec)
	{
		return new PointF(x62d9bfcf54e338cb.X + x2f7096dac971d6ec.X, x62d9bfcf54e338cb.Y + x2f7096dac971d6ec.Y);
	}

	internal RectangleF xce92de628aa023cf(RectangleF x26545669838eb36e)
	{
		return new RectangleF(xce92de628aa023cf(x26545669838eb36e.Location), x26545669838eb36e.Size);
	}
}
