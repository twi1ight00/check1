using System.Collections;
using System.Drawing;
using Aspose.Words;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6a42c37b95e9caa1;
using x6c95d9cf46ff5f25;
using x99ec507695f2d4ff;

namespace xb3b3ff3836e35ac5;

internal class xae482498b582c4a5
{
	private const float xa410cc722804d016 = 2f;

	private const float x402a33d6b8332542 = 1f;

	private const float x8de1d53a39ac4a0f = 1.5f;

	private readonly x0e71d075aa348d2b xa68cb11d4b5dd9ab;

	private readonly Aspose.Words.Font x83cd810ab70afec3;

	private readonly x26d9ecb4bdf0456d x78e4acec873c7675;

	private readonly x26d9ecb4bdf0456d x27ac6c8ff2ddb74a;

	private x26d9ecb4bdf0456d x233904f36f6fed5c;

	private readonly float x212ae880d15d2ed1;

	private readonly float xb664a8c25c0c85cc;

	private static readonly Hashtable x2de42ed7716de792;

	private static readonly Hashtable xce921039b6ed7574;

	internal xae482498b582c4a5(x0e71d075aa348d2b underline, Aspose.Words.Font font, x26d9ecb4bdf0456d color, x26d9ecb4bdf0456d shadowColor, x26d9ecb4bdf0456d paragraphBackColor, float start, float end)
	{
		xa68cb11d4b5dd9ab = underline;
		x83cd810ab70afec3 = font;
		x78e4acec873c7675 = color;
		x27ac6c8ff2ddb74a = shadowColor;
		x233904f36f6fed5c = paragraphBackColor;
		x212ae880d15d2ed1 = start;
		xb664a8c25c0c85cc = end;
	}

	internal void xe406325e56f74b46(xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		if (x83cd810ab70afec3.Hidden || !x54afa1405121518f.x4f0ec65105795df7(x83cd810ab70afec3.Underline))
		{
			x0c42fb1f1c8ad3b1(xa68cb11d4b5dd9ab.x139412b8dea2f02b + xa68cb11d4b5dd9ab.x4e0afe70adcb4c39.x475dd4456657c57c, x0f7b23d1c393aed9);
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			x0c42fb1f1c8ad3b1(xa68cb11d4b5dd9ab.x139412b8dea2f02b + xa68cb11d4b5dd9ab.x4e0afe70adcb4c39.x3684f71bb8ea1d65[i], x0f7b23d1c393aed9);
		}
	}

	private void x0c42fb1f1c8ad3b1(float x1e218ceaee1bb583, xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		PointF xcb09bd0cee4909a = new PointF(x212ae880d15d2ed1, x1e218ceaee1bb583);
		PointF xa2da454aa40879d = new PointF(xb664a8c25c0c85cc, x1e218ceaee1bb583);
		if (x83cd810ab70afec3.Shadow)
		{
			float num = x42b8c317113a56e4.x07048d040f15c88c((float)x83cd810ab70afec3.Size);
			xa125ea84f9dec9b0(new PointF(xcb09bd0cee4909a.X + num, xcb09bd0cee4909a.Y + num), new PointF(xa2da454aa40879d.X + num, xa2da454aa40879d.Y + num), x27ac6c8ff2ddb74a, x0f7b23d1c393aed9);
		}
		else if (x83cd810ab70afec3.Engrave || x83cd810ab70afec3.Emboss)
		{
			if (x233904f36f6fed5c.x7149c962c02931b3)
			{
				x233904f36f6fed5c = x26d9ecb4bdf0456d.x8f02f53f1587477d;
			}
			x26d9ecb4bdf0456d x6c50a99faab7d = x42b8c317113a56e4.xb331151dc0f40276(x233904f36f6fed5c);
			x26d9ecb4bdf0456d x6c50a99faab7d2 = x42b8c317113a56e4.x5aba14cb467ae5d2(x233904f36f6fed5c);
			float num2 = (x83cd810ab70afec3.Engrave ? 0.8f : (-0.8f));
			xa125ea84f9dec9b0(new PointF(xcb09bd0cee4909a.X - num2, xcb09bd0cee4909a.Y - num2), new PointF(xa2da454aa40879d.X - num2, xa2da454aa40879d.Y - num2), x6c50a99faab7d, x0f7b23d1c393aed9);
			xa125ea84f9dec9b0(new PointF(xcb09bd0cee4909a.X + num2, xcb09bd0cee4909a.Y + num2), new PointF(xa2da454aa40879d.X + num2, xa2da454aa40879d.Y + num2), x6c50a99faab7d2, x0f7b23d1c393aed9);
		}
		xa125ea84f9dec9b0(xcb09bd0cee4909a, xa2da454aa40879d, x78e4acec873c7675, x0f7b23d1c393aed9);
	}

	private void xa125ea84f9dec9b0(PointF xcb09bd0cee4909a3, PointF xa2da454aa40879d2, x26d9ecb4bdf0456d x6c50a99faab7d741, xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		if (x83cd810ab70afec3.Hidden || !x54afa1405121518f.x5b7e2f4dd312775f(x83cd810ab70afec3.Underline))
		{
			x67b49bdb9868eebf(xcb09bd0cee4909a3, xa2da454aa40879d2, x6c50a99faab7d741, x0f7b23d1c393aed9);
		}
		else
		{
			xdd784f34fac606bd(xcb09bd0cee4909a3, xa2da454aa40879d2, x6c50a99faab7d741, x0f7b23d1c393aed9, x83cd810ab70afec3.Underline);
		}
	}

	private void x67b49bdb9868eebf(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, x26d9ecb4bdf0456d x6c50a99faab7d741, xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		float num = ((!x83cd810ab70afec3.Hidden) ? xa68cb11d4b5dd9ab.x4e0afe70adcb4c39.x3e678b4c8e5924ae : 1f);
		x31c19fcb724dfaf5 x31c19fcb724dfaf = new x31c19fcb724dfaf5(x6c50a99faab7d741, num);
		float[] array = xfddcf003f8c48200(num);
		if (array != null)
		{
			x31c19fcb724dfaf.x358988d12e56bf69 = array;
			x31c19fcb724dfaf.xc19b368b60309472 = x7722f2a3518cfc93(x10aaa7cdfa38f254.X, num);
		}
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xb471d14948c54f27(x0f7b23d1c393aed9.xce92de628aa023cf(x10aaa7cdfa38f254), x0f7b23d1c393aed9.xce92de628aa023cf(xca09b6c2b5b18485));
		xab391c46ff9a0a.x9e5d5f9128c69a8f = x31c19fcb724dfaf;
		x0f7b23d1c393aed9.x1fa9148f6731ff24(xab391c46ff9a0a);
	}

	private void xdd784f34fac606bd(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, x26d9ecb4bdf0456d x6c50a99faab7d741, xe6a5f3ec802a6d51 x0f7b23d1c393aed9, Underline x98e3d870f2952584)
	{
		x10aaa7cdfa38f254 = x0f7b23d1c393aed9.xce92de628aa023cf(x10aaa7cdfa38f254);
		xca09b6c2b5b18485 = x0f7b23d1c393aed9.xce92de628aa023cf(xca09b6c2b5b18485);
		float width = ((x98e3d870f2952584 == Underline.WavyHeavy) ? 1.5f : 1f);
		x31c19fcb724dfaf5 pen = new x31c19fcb724dfaf5(x6c50a99faab7d741, width);
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38(pen);
		x0f7b23d1c393aed9.x1fa9148f6731ff24(xab391c46ff9a0a);
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e.x5e6c52cb3256cc85 = false;
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		int num = (int)((xca09b6c2b5b18485.X - x10aaa7cdfa38f254.X) / 2f) + 1;
		float[] array = new float[num * 2];
		array[0] = x10aaa7cdfa38f254.X;
		array[1] = x10aaa7cdfa38f254.Y;
		float x3e678b4c8e5924ae = xa68cb11d4b5dd9ab.x4e0afe70adcb4c39.x3e678b4c8e5924ae;
		for (int i = 0; i < num - 1; i++)
		{
			array[i * 2 + 2] = x10aaa7cdfa38f254.X + (float)i * 2f;
			if (x0d299f323d241756.x7e32f71c3f39b6bc(i))
			{
				array[i * 2 + 3] = x10aaa7cdfa38f254.Y - x3e678b4c8e5924ae / 2f;
			}
			else
			{
				array[i * 2 + 3] = x10aaa7cdfa38f254.Y + x3e678b4c8e5924ae / 2f;
			}
		}
		x60c040f35bb272aa xda5bf54deb817e = new x60c040f35bb272aa(array);
		x1cab6af0a41b70e.xd6b6ed77479ef68c(xda5bf54deb817e);
	}

	private float[] xfddcf003f8c48200(float xce90ee8e49859281)
	{
		if (x83cd810ab70afec3.Hidden)
		{
			return new float[2] { 1f, 2f };
		}
		float[] array = (float[])x2de42ed7716de792[x83cd810ab70afec3.Underline];
		if (array == null)
		{
			return null;
		}
		array = (float[])array.Clone();
		if (xce90ee8e49859281 > 1f)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] /= xce90ee8e49859281;
			}
		}
		return array;
	}

	private float x7722f2a3518cfc93(float x08db3aeabb253cb1, float xce90ee8e49859281)
	{
		if (x83cd810ab70afec3.Hidden)
		{
			return 0f;
		}
		float num = (float)xce921039b6ed7574[x83cd810ab70afec3.Underline];
		return x08db3aeabb253cb1 % num / xce90ee8e49859281;
	}

	static xae482498b582c4a5()
	{
		x2de42ed7716de792 = new Hashtable();
		x2de42ed7716de792.Add(Underline.Dotted, new float[2] { 1.5f, 1.5f });
		x2de42ed7716de792.Add(Underline.DottedHeavy, new float[2] { 1.5f, 1.5f });
		x2de42ed7716de792.Add(Underline.Dash, new float[2] { 6f, 3f });
		x2de42ed7716de792.Add(Underline.DashHeavy, new float[2] { 6f, 3f });
		x2de42ed7716de792.Add(Underline.DotDash, new float[4] { 6f, 1.5f, 1.5f, 1.5f });
		x2de42ed7716de792.Add(Underline.DotDashHeavy, new float[4] { 6f, 1.5f, 1.5f, 1.5f });
		x2de42ed7716de792.Add(Underline.DotDotDash, new float[6] { 4.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f });
		x2de42ed7716de792.Add(Underline.DotDotDashHeavy, new float[6] { 4.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f });
		x2de42ed7716de792.Add(Underline.DashLong, new float[2] { 12f, 6f });
		x2de42ed7716de792.Add(Underline.DashLongHeavy, new float[2] { 12f, 6f });
		xce921039b6ed7574 = new Hashtable();
		xce921039b6ed7574.Add(Underline.Dotted, 3f);
		xce921039b6ed7574.Add(Underline.DottedHeavy, 3f);
		xce921039b6ed7574.Add(Underline.Dash, 9f);
		xce921039b6ed7574.Add(Underline.DashHeavy, 9f);
		xce921039b6ed7574.Add(Underline.DotDash, 10.5f);
		xce921039b6ed7574.Add(Underline.DotDashHeavy, 10.5f);
		xce921039b6ed7574.Add(Underline.DotDotDash, 12f);
		xce921039b6ed7574.Add(Underline.DotDotDashHeavy, 12f);
		xce921039b6ed7574.Add(Underline.DashLong, 18f);
		xce921039b6ed7574.Add(Underline.DashLongHeavy, 18f);
	}
}
