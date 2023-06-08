using System;
using System.Collections;
using Aspose.Words;
using x5794c252ba25e723;
using x59d6a4fc5007b7a4;
using x6a42c37b95e9caa1;
using x99ec507695f2d4ff;

namespace xb3b3ff3836e35ac5;

internal class x0e71d075aa348d2b
{
	private float x5357185abd812af1;

	private x442fa4fe5ac3b905 xb8c2d2630ae18c71;

	private ArrayList xc65240355eabb303 = new ArrayList();

	private x038d2057eb729fcf x535b4f6396c77279;

	private Font x626940c8c2dc696c;

	private x26d9ecb4bdf0456d xc2d3ebac96a81948;

	private x26d9ecb4bdf0456d x6a3806ed14a63a8b;

	private x26d9ecb4bdf0456d x300bcbd9d58da383;

	private float x5b4c2379d9e4e500;

	internal float x139412b8dea2f02b => x5357185abd812af1;

	internal x442fa4fe5ac3b905 x4e0afe70adcb4c39 => xb8c2d2630ae18c71;

	internal x0e71d075aa348d2b(x038d2057eb729fcf span, x26d9ecb4bdf0456d underlineColor)
	{
		xb8c2d2630ae18c71 = new x442fa4fe5ac3b905(span);
		xf94f66c79b1b75b8(span, underlineColor);
	}

	internal void x794f16de9842a7a0(x038d2057eb729fcf x5906905c888d3d98)
	{
		x5357185abd812af1 = Math.Max(x5357185abd812af1, x5906905c888d3d98.xc22eade24b085d91.Y);
		xb8c2d2630ae18c71.x9682faecb1d1a8a5(x5906905c888d3d98);
		x535b4f6396c77279 = x5906905c888d3d98;
	}

	internal void xf94f66c79b1b75b8(x038d2057eb729fcf x5906905c888d3d98, x26d9ecb4bdf0456d xe900e239db103668)
	{
		x626940c8c2dc696c = x5906905c888d3d98.xc2d4efc42998d87b;
		xc2d3ebac96a81948 = xe900e239db103668;
		x6a3806ed14a63a8b = x42b8c317113a56e4.x6a843a40faf5e532(x5906905c888d3d98);
		x300bcbd9d58da383 = x42b8c317113a56e4.xc54e4d79e1c0e1c7(x5906905c888d3d98);
		x5b4c2379d9e4e500 = (x5906905c888d3d98.x56410a8dd70087c5.x5a7799e1836857e3.x8786efe6471e0521 ? (x5906905c888d3d98.xc22eade24b085d91.X + x5906905c888d3d98.x887b872a95caaab5) : x5906905c888d3d98.xc22eade24b085d91.X);
	}

	internal void x4f4ae086f5e6747b(x038d2057eb729fcf x5906905c888d3d98, bool xf7b442ce3fc67ee7)
	{
		float num = x5906905c888d3d98.xc22eade24b085d91.X;
		bool x8786efe6471e = x5906905c888d3d98.x56410a8dd70087c5.x5a7799e1836857e3.x8786efe6471e0521;
		if ((xf7b442ce3fc67ee7 && !x8786efe6471e) || (!xf7b442ce3fc67ee7 && x8786efe6471e))
		{
			num += x5906905c888d3d98.x887b872a95caaab5;
		}
		if (x8786efe6471e)
		{
			float num2 = x5b4c2379d9e4e500;
			x5b4c2379d9e4e500 = num;
			num = num2;
		}
		xae482498b582c4a5 value = new xae482498b582c4a5(this, x626940c8c2dc696c, xc2d3ebac96a81948, x6a3806ed14a63a8b, x300bcbd9d58da383, x5b4c2379d9e4e500, num);
		xc65240355eabb303.Add(value);
	}

	internal void xe406325e56f74b46(x038d2057eb729fcf x5906905c888d3d98, bool xf7b442ce3fc67ee7, xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		x4f4ae086f5e6747b(x5906905c888d3d98, xf7b442ce3fc67ee7);
		for (int i = 0; i < xc65240355eabb303.Count; i++)
		{
			xae482498b582c4a5 xae482498b582c4a6 = (xae482498b582c4a5)xc65240355eabb303[i];
			xae482498b582c4a6.xe406325e56f74b46(x0f7b23d1c393aed9);
		}
	}

	private static x85106f43f5d73b18 xe721cbadd5b85b25(x038d2057eb729fcf x5906905c888d3d98)
	{
		if (x5906905c888d3d98.xc2d4efc42998d87b.Position < 0.0 || (x5906905c888d3d98.xc2d4efc42998d87b.Position == 0.0 && !x5906905c888d3d98.xc2d4efc42998d87b.Subscript))
		{
			return x85106f43f5d73b18.xe74f26d8f4cfb63f;
		}
		if (x5906905c888d3d98.xc2d4efc42998d87b.Subscript || x5906905c888d3d98.xc2d4efc42998d87b.Superscript)
		{
			return x85106f43f5d73b18.xdfa0490820a0e418;
		}
		return x85106f43f5d73b18.x6e07d9be9e6a1f61;
	}

	internal bool x823021dd17f3ec66(x038d2057eb729fcf x5906905c888d3d98)
	{
		x85106f43f5d73b18 x85106f43f5d73b19 = xe721cbadd5b85b25(x5906905c888d3d98);
		x85106f43f5d73b18 x85106f43f5d73b20 = xe721cbadd5b85b25(x535b4f6396c77279);
		if (x5906905c888d3d98.xc2d4efc42998d87b.Hidden == x626940c8c2dc696c.Hidden && (x5906905c888d3d98.xc2d4efc42998d87b.Hidden || x626940c8c2dc696c.Hidden || x5906905c888d3d98.xc2d4efc42998d87b.Underline == x626940c8c2dc696c.Underline) && x85106f43f5d73b19 == x85106f43f5d73b20 && x85106f43f5d73b19 != x85106f43f5d73b18.xdfa0490820a0e418 && x85106f43f5d73b20 != x85106f43f5d73b18.xdfa0490820a0e418)
		{
			if (x85106f43f5d73b19 == x85106f43f5d73b18.x6e07d9be9e6a1f61 && x85106f43f5d73b20 == x85106f43f5d73b18.x6e07d9be9e6a1f61)
			{
				return x5906905c888d3d98.xc2d4efc42998d87b.Position != x535b4f6396c77279.xc2d4efc42998d87b.Position;
			}
			return false;
		}
		return true;
	}

	internal bool x04dee9c3c9004d60(x038d2057eb729fcf x5906905c888d3d98, x26d9ecb4bdf0456d xe900e239db103668)
	{
		if (xe900e239db103668 != xc2d3ebac96a81948 || x5906905c888d3d98.xc2d4efc42998d87b.Emboss != x626940c8c2dc696c.Emboss || x5906905c888d3d98.xc2d4efc42998d87b.Engrave != x626940c8c2dc696c.Engrave || x5906905c888d3d98.xc2d4efc42998d87b.Shadow != x626940c8c2dc696c.Shadow)
		{
			return true;
		}
		return false;
	}
}
