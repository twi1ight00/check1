using System;
using System.Collections;
using System.Drawing;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using x1c8faa688b1f0b0c;
using x3d94286fe72124a8;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class x2450078883332f11 : xfc96716110004aef
{
	private xdeb77ea37ad74c56 xd5f4d4b5bdd8e58a = new xdeb77ea37ad74c56();

	private float x8918dc7c534575e5;

	private float xd74c65b8d28b1740;

	private HeightRule xb337e0facd4aad8c;

	private xa67197c42bddc7dc x7b3f79285ffeaa1b;

	private Hashtable x420910cb1a23963b = new Hashtable();

	private bool xf063044e5dc4bc55;

	public xdeb77ea37ad74c56 xdeb77ea37ad74c56
	{
		get
		{
			return xd5f4d4b5bdd8e58a;
		}
		set
		{
			xd5f4d4b5bdd8e58a = value;
		}
	}

	public bool x77b539f715547c1c => xf063044e5dc4bc55;

	public HeightRule x85e9ab4255d7e70c
	{
		get
		{
			return xb337e0facd4aad8c;
		}
		set
		{
			xb337e0facd4aad8c = value;
		}
	}

	public float xdc1bf80853046136
	{
		get
		{
			return xd74c65b8d28b1740;
		}
		set
		{
			xd74c65b8d28b1740 = value;
		}
	}

	public float xb0f146032f47c24e
	{
		get
		{
			return x8918dc7c534575e5;
		}
		set
		{
			x8918dc7c534575e5 = value;
		}
	}

	public x2450078883332f11(xa67197c42bddc7dc spanShape)
	{
		xa67197c42bddc7dc.x2b3f292c0023faa6(spanShape, x420910cb1a23963b);
		x7b3f79285ffeaa1b = spanShape;
		xf063044e5dc4bc55 = spanShape.x92adfed6f1d8efe4 != null || spanShape.xd8cde6b694c3af46 != null;
	}

	public RectangleF x9f6920a8cea20237(object xc46371921b1b5eeb)
	{
		xc2b4bc12e20fb0df(xc46371921b1b5eeb);
		x00b4e2c077f699df x00b4e2c077f699df = x3f22add0e3668260(xc46371921b1b5eeb);
		x1073233de8252b3e x1073233de8252b3e = (x1073233de8252b3e)x00b4e2c077f699df.xce4443deee105995(x954503abc583f675.x4c38e800e85b21ad | x954503abc583f675.x924e4e3967c494db);
		if (x1073233de8252b3e.x954503abc583f675 == x954503abc583f675.x924e4e3967c494db)
		{
			return x4574ea26106f0edb.xc96d70553223ee04(x1073233de8252b3e.x39e5557bea338558());
		}
		x852fe8bb5ac31098 x852fe8bb5ac = (x852fe8bb5ac31098)x1073233de8252b3e;
		Point point = x852fe8bb5ac.x902d63c74e3c13c4.x588d7683a6d1fbd5();
		x852fe8bb5ac31098 x852fe8bb5ac2 = x852fe8bb5ac.x5458a425704f77fe();
		Point point2 = x852fe8bb5ac2.x588d7683a6d1fbd5();
		Rectangle xf671230c49fb86ad = Rectangle.FromLTRB(point.X, point.Y, point2.X + x852fe8bb5ac2.xdc1bf80853046136, point2.Y + x852fe8bb5ac2.xb0f146032f47c24e);
		return x4574ea26106f0edb.xc96d70553223ee04(xf671230c49fb86ad);
	}

	public RectangleF xfcaf0e648797de87(object xc46371921b1b5eeb)
	{
		xc2b4bc12e20fb0df(xc46371921b1b5eeb);
		x1073233de8252b3e xd3311d815ca25f = x287701ca1ba079d3(xc46371921b1b5eeb);
		return x981b28ceaa73be45(xd3311d815ca25f);
	}

	public PointF x372fb5730e3f2c73(object xc46371921b1b5eeb)
	{
		xc2b4bc12e20fb0df(xc46371921b1b5eeb);
		x00b4e2c077f699df x00b4e2c077f699df = x3f22add0e3668260(xc46371921b1b5eeb);
		return x4574ea26106f0edb.xc96d70553223ee04(((x3ee7f5c70fde3f94)x00b4e2c077f699df.x53111d6596d16a99).x1452024de1251c74.x588d7683a6d1fbd5());
	}

	public int xc76a12855c75c651(object xc46371921b1b5eeb)
	{
		xc2b4bc12e20fb0df(xc46371921b1b5eeb);
		x00b4e2c077f699df x00b4e2c077f699df = x3f22add0e3668260(xc46371921b1b5eeb);
		xc7f90d9c7c51cede xc7f90d9c7c51cede = x00b4e2c077f699df.x776fd7c2f7270172();
		return xc7f90d9c7c51cede.x5138ebdd7c56c151();
	}

	public RectangleF x23a6444b1ff787e7(object xc46371921b1b5eeb)
	{
		xc2b4bc12e20fb0df(xc46371921b1b5eeb);
		x00b4e2c077f699df x00b4e2c077f699df = x3f22add0e3668260(xc46371921b1b5eeb);
		xc7f90d9c7c51cede xc7f90d9c7c51cede = x00b4e2c077f699df.x776fd7c2f7270172();
		return new RectangleF(0f, 0f, x4574ea26106f0edb.xc96d70553223ee04(xc7f90d9c7c51cede.xdc1bf80853046136), x4574ea26106f0edb.xc96d70553223ee04(xc7f90d9c7c51cede.xb0f146032f47c24e));
	}

	[JavaConvertCheckedExceptions]
	public object xc3819e13f60dd8e6(Shape x5770cdefd8931aa9, x795369ba3068bc66 x520676b4e3be819b)
	{
		xa67197c42bddc7dc xa67197c42bddc7dc = (xa67197c42bddc7dc)x420910cb1a23963b[x5770cdefd8931aa9];
		if (xa67197c42bddc7dc == null)
		{
			return null;
		}
		x1073233de8252b3e xd3311d815ca25f = (x1073233de8252b3e)xa67197c42bddc7dc.xce4443deee105995(x954503abc583f675.xa65184d44a47025b | x954503abc583f675.x4c38e800e85b21ad | x954503abc583f675.x11db8fc7f469a2fc);
		x3ee7f5c70fde3f94 x3ee7f5c70fde3f = xa67197c42bddc7dc.x0cdfd951d792f320(x5aa7d09b258e0f23: false);
		xa67197c42bddc7dc xa67197c42bddc7dc2 = xa67197c42bddc7dc.x058e06676018641d();
		if (x3ee7f5c70fde3f == null)
		{
			x3ee7f5c70fde3f = xa67197c42bddc7dc2.x0cdfd951d792f320(x5aa7d09b258e0f23: false);
			if (x3ee7f5c70fde3f.xe5764fe5359a6d91)
			{
				return x1f97d3b3f302fa3e(x5770cdefd8931aa9, xa67197c42bddc7dc, x3ee7f5c70fde3f, xa67197c42bddc7dc.x00b4e2c077f699df, xd3311d815ca25f);
			}
		}
		xdeb77ea37ad74c56 xdeb77ea37ad74c57 = x3ee7f5c70fde3f.x2c8c6741422a1298.xdeb77ea37ad74c56;
		x3ee7f5c70fde3f.x2c8c6741422a1298.xdeb77ea37ad74c56 = xd5f4d4b5bdd8e58a;
		SizeF[] x66e167dd04a48f1c;
		if (xa67197c42bddc7dc2.x92adfed6f1d8efe4 != null)
		{
			Shape[] x5dba01b2084e8c = x089e111706ea17b2(xa67197c42bddc7dc2);
			x66e167dd04a48f1c = x520676b4e3be819b.xbe0f01716f917f22(x5dba01b2084e8c);
		}
		else
		{
			x66e167dd04a48f1c = new SizeF[1] { xaf0fffb624993714(xd3311d815ca25f) };
		}
		x3ee7f5c70fde3f.xdff44e884fce055f(x66e167dd04a48f1c);
		x67ea92afb6a4c6e6(xa67197c42bddc7dc.x00b4e2c077f699df);
		x3ee7f5c70fde3f.x2c8c6741422a1298.xdeb77ea37ad74c56 = xdeb77ea37ad74c57;
		return x1f97d3b3f302fa3e(x5770cdefd8931aa9, xa67197c42bddc7dc, x3ee7f5c70fde3f, xa67197c42bddc7dc.x00b4e2c077f699df, xd3311d815ca25f);
	}

	[JavaConvertCheckedExceptions]
	public xb8e7e788f6d59708 xe406325e56f74b46(object xc46371921b1b5eeb, SizeF x0ceec69a97f73617, float x575a59e879c6e332, Color x1872d0ea7fb29885)
	{
		xc2b4bc12e20fb0df(xc46371921b1b5eeb);
		x00b4e2c077f699df x00b4e2c077f699df = x3f22add0e3668260(xc46371921b1b5eeb);
		x00b4e2c077f699df.x1b75e1aaf09e9fd8 = x1872d0ea7fb29885;
		x00b4e2c077f699df.xdc1bf80853046136 = x4574ea26106f0edb.x8d50b8a62ba1cd84(x0ceec69a97f73617.Width);
		x00b4e2c077f699df.xb0f146032f47c24e = x4574ea26106f0edb.x8d50b8a62ba1cd84(x0ceec69a97f73617.Height);
		x00b4e2c077f699df.xfe73c0e9e2aad0f2 = x4574ea26106f0edb.x8d50b8a62ba1cd84(x575a59e879c6e332);
		return (xb8e7e788f6d59708)x00b4e2c077f699df.x2d6658ad60c6ebe9;
	}

	public bool xc368ac20e836d506(Shape x5770cdefd8931aa9)
	{
		return x420910cb1a23963b[x5770cdefd8931aa9] != null;
	}

	private static Shape[] x089e111706ea17b2(xa67197c42bddc7dc x62584df2cb5d40dd)
	{
		ArrayList arrayList = new ArrayList();
		while (x62584df2cb5d40dd != null)
		{
			arrayList.Add(x62584df2cb5d40dd.x40212106aad8a8b0);
			x62584df2cb5d40dd = x62584df2cb5d40dd.x92adfed6f1d8efe4;
		}
		Shape[] array = new Shape[arrayList.Count];
		for (int i = 0; i < arrayList.Count; i++)
		{
			array[i] = (Shape)arrayList[i];
		}
		return array;
	}

	private SizeF xaf0fffb624993714(x1073233de8252b3e xd3311d815ca25f02)
	{
		RectangleF rectangleF = x981b28ceaa73be45(xd3311d815ca25f02);
		float width = xd74c65b8d28b1740;
		float num = x8918dc7c534575e5;
		if (0f == xd74c65b8d28b1740)
		{
			width = rectangleF.Width;
		}
		switch (xb337e0facd4aad8c)
		{
		case HeightRule.AtLeast:
			num = Math.Max(num, rectangleF.Height);
			break;
		case HeightRule.Auto:
			num = rectangleF.Height;
			break;
		}
		return new SizeF(width, num);
	}

	private void x67ea92afb6a4c6e6(x00b4e2c077f699df xd3311d815ca25f02)
	{
		int num = int.MaxValue;
		int num2 = int.MinValue;
		int num3 = int.MaxValue;
		int num4 = int.MinValue;
		for (x398b3bd0acd94b61 x398b3bd0acd94b = xd3311d815ca25f02.x8b8a0a04b3aeaf3a; x398b3bd0acd94b != null; x398b3bd0acd94b = x398b3bd0acd94b.xf432ece93e450408())
		{
			int num5;
			if (x398b3bd0acd94b.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05)
			{
				xf6937c72cebe4ad1 xf6937c72cebe4ad = (xf6937c72cebe4ad1)x398b3bd0acd94b;
				num5 = xf6937c72cebe4ad1.x0ecd6606a49619ac(xf6937c72cebe4ad) + xf6937c72cebe4ad.x406d8cd2af514771.xa79651e2f1a1416e.xc0741c7ff92cf1aa;
			}
			else
			{
				num5 = x398b3bd0acd94b.xdc1bf80853046136;
			}
			num = Math.Min(num, x398b3bd0acd94b.x8df91a2f90079e88);
			num2 = Math.Max(num2, x398b3bd0acd94b.x8df91a2f90079e88 + num5);
			num3 = Math.Min(num3, x398b3bd0acd94b.xc821290d7ecc08bf);
			num4 = Math.Max(num4, x398b3bd0acd94b.xc821290d7ecc08bf + x398b3bd0acd94b.xb0f146032f47c24e);
		}
		xd74c65b8d28b1740 = x4574ea26106f0edb.xc96d70553223ee04(num2 - num);
		x8918dc7c534575e5 = x4574ea26106f0edb.xc96d70553223ee04(num4 - num3);
		if (xb337e0facd4aad8c == HeightRule.AtLeast)
		{
			x8918dc7c534575e5 = Math.Max(0f - x8918dc7c534575e5, x8918dc7c534575e5);
		}
	}

	private static void xc2b4bc12e20fb0df(object xc46371921b1b5eeb)
	{
		if (xc46371921b1b5eeb is object[])
		{
			object[] array = (object[])xc46371921b1b5eeb;
			if (array.Length == 5 && array[0] is Shape && array[1] is xa67197c42bddc7dc && array[2] is x3ee7f5c70fde3f94 && array[3] is x00b4e2c077f699df && array[4] is x1073233de8252b3e)
			{
				return;
			}
		}
		throw new ArgumentException("Invalid object", "opaque");
	}

	private static object x1f97d3b3f302fa3e(Shape x5770cdefd8931aa9, xa67197c42bddc7dc x5906905c888d3d98, x3ee7f5c70fde3f94 x2612f62f94df47de, x00b4e2c077f699df xd7e5673853e47af4, x1073233de8252b3e xd3311d815ca25f02)
	{
		return new object[5] { x5770cdefd8931aa9, x5906905c888d3d98, x2612f62f94df47de, xd7e5673853e47af4, xd3311d815ca25f02 };
	}

	private static x00b4e2c077f699df x3f22add0e3668260(object xc46371921b1b5eeb)
	{
		return (x00b4e2c077f699df)((object[])xc46371921b1b5eeb)[3];
	}

	private static x1073233de8252b3e x287701ca1ba079d3(object xc46371921b1b5eeb)
	{
		return (x1073233de8252b3e)((object[])xc46371921b1b5eeb)[4];
	}

	private static RectangleF x981b28ceaa73be45(x398b3bd0acd94b61 xd3311d815ca25f02)
	{
		Rectangle xf671230c49fb86ad = new Rectangle(xd3311d815ca25f02.x588d7683a6d1fbd5(), xd3311d815ca25f02.x56933a86bfcf89a1());
		return x4574ea26106f0edb.xc96d70553223ee04(xf671230c49fb86ad);
	}
}
