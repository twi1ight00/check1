using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class x0c8c298e5b4ef6f5 : xf51865b83a7a0b3b
{
	private x1c6a8d1fe5802b22 x8cedcaa9a62c6e39;

	private xab391c46ff9a0a38[] xc6b570b7fb3a2bd5;

	internal static readonly float[] x41a174bca277c948 = new float[0];

	internal static xab391c46ff9a0a38[] x757450d4e4eec6d0(xab391c46ff9a0a38 xe125219852864557)
	{
		x0c8c298e5b4ef6f5 x0c8c298e5b4ef6f6 = new x0c8c298e5b4ef6f5();
		return x0c8c298e5b4ef6f6.xe406325e56f74b46(xe125219852864557);
	}

	[JavaThrows(false)]
	internal static xab391c46ff9a0a38 x500a49d41cd9cfd5(xab391c46ff9a0a38 xe125219852864557, float xf7b90603456caad3)
	{
		x0c8c298e5b4ef6f5 x0c8c298e5b4ef6f6 = new x0c8c298e5b4ef6f5();
		return x0c8c298e5b4ef6f6.x500a49d41cd9cfd5(xe125219852864557, new x11cc26a1c529c026(1f, xf7b90603456caad3));
	}

	private xab391c46ff9a0a38[] xe406325e56f74b46(xab391c46ff9a0a38 xe125219852864557)
	{
		if (xe125219852864557.x9e5d5f9128c69a8f == null || xe125219852864557.x9e5d5f9128c69a8f.x9ba359ff37a3a63b == PenAlignment.Inset)
		{
			return new xab391c46ff9a0a38[1] { xe125219852864557 };
		}
		if (xe125219852864557.x9e5d5f9128c69a8f.x6fd1e71abf8b8121 == null || xe125219852864557.x9e5d5f9128c69a8f.x6fd1e71abf8b8121.Length == 0 || xe125219852864557.x9e5d5f9128c69a8f.x6fd1e71abf8b8121 == x41a174bca277c948 || (xe125219852864557.x9e5d5f9128c69a8f.x6fd1e71abf8b8121.Length == 2 && xe125219852864557.x9e5d5f9128c69a8f.x6fd1e71abf8b8121[0] == 0f && xe125219852864557.x9e5d5f9128c69a8f.x6fd1e71abf8b8121[1] == 1f))
		{
			return new xab391c46ff9a0a38[1] { xe125219852864557 };
		}
		if (xe125219852864557.x9e5d5f9128c69a8f.xca08e8eb525b8a1a == DashStyle.Dot && xe125219852864557.x9e5d5f9128c69a8f.x9526ba50e2183e01 == DashCap.Round)
		{
			return new xab391c46ff9a0a38[1] { xe125219852864557 };
		}
		ArrayList arrayList = new ArrayList();
		if (!x597ec252b5121681(xe125219852864557.x9e5d5f9128c69a8f, arrayList))
		{
			return new xab391c46ff9a0a38[1] { xe125219852864557 };
		}
		xc6b570b7fb3a2bd5 = new xab391c46ff9a0a38[arrayList.Count];
		for (int i = 0; i < arrayList.Count; i++)
		{
			xc6b570b7fb3a2bd5[i] = x500a49d41cd9cfd5(xe125219852864557, (x11cc26a1c529c026)arrayList[i]);
		}
		return xc6b570b7fb3a2bd5;
	}

	[JavaThrows(false)]
	private xab391c46ff9a0a38 x500a49d41cd9cfd5(xab391c46ff9a0a38 xe125219852864557, x11cc26a1c529c026 xd3311d815ca25f02)
	{
		try
		{
			x8cedcaa9a62c6e39 = new x1c6a8d1fe5802b22(xe125219852864557, xd3311d815ca25f02);
			xe125219852864557.Accept(this);
			return x8cedcaa9a62c6e39.x6cd7659ca2021746;
		}
		catch (Exception)
		{
			return new xab391c46ff9a0a38();
		}
	}

	public override void VisitPathFigureStart(x1cab6af0a41b70e2 pathFigure)
	{
		x8cedcaa9a62c6e39.xb2e3462588a64d38(pathFigure);
	}

	public override void VisitPathFigureEnd(x1cab6af0a41b70e2 pathFigure)
	{
		if (pathFigure.xd44988f225497f3a > 1 && pathFigure.x5e6c52cb3256cc85)
		{
			xdee3f4cf7afb9425();
		}
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		x8cedcaa9a62c6e39.xf06a57baef9037ce++;
		x60c040f35bb272aa x60c040f35bb272aa = xad84d4aa3e258090(segment, x8cedcaa9a62c6e39.xc9443bca5b0a56d8.xf1d9b91c9700c401);
		if (x60c040f35bb272aa != null)
		{
			x8cedcaa9a62c6e39.x2b85b58eb18ccd13.xd6b6ed77479ef68c(x60c040f35bb272aa);
		}
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		x8cedcaa9a62c6e39.xf06a57baef9037ce++;
		x519b1bd0625473ff[] xa955664f4f50999d = x908719d610993771(segment, x8cedcaa9a62c6e39.xc9443bca5b0a56d8.xf1d9b91c9700c401);
		x8cedcaa9a62c6e39.x2b85b58eb18ccd13.xf82029c4e8b4cfc3(xa955664f4f50999d);
	}

	private void xdee3f4cf7afb9425()
	{
		if (x8cedcaa9a62c6e39.x6ce296a3fb2167b3)
		{
			x08b089b25ebb6a16();
		}
		else
		{
			x78a593ecbf90a2b0();
		}
	}

	private void x08b089b25ebb6a16()
	{
		if (x8cedcaa9a62c6e39.x7e3449fd64a19b0b)
		{
			x6ed7ee1ce6cc3788();
		}
		else
		{
			x96f2536d8ac899f4();
		}
	}

	private void x78a593ecbf90a2b0()
	{
		if (x8cedcaa9a62c6e39.x7e3449fd64a19b0b)
		{
			xc39fcda37d83ff9b();
		}
		else
		{
			x6f4179a9a165b200();
		}
	}

	private void x6f4179a9a165b200()
	{
		x782108ccba597138 x782108ccba597139 = x7a17e854d3ce10e1.x0a09fa2690680f34(x8cedcaa9a62c6e39.x513b9123039071f0, x8cedcaa9a62c6e39.x8e3eeb462ebec42c, x85542bc98c560fba: true);
		if (x782108ccba597139.x43e7db181a6b7a7e)
		{
			x8cedcaa9a62c6e39.x2b85b58eb18ccd13.x8992595b6d42d9bd(new PointF[1] { x782108ccba597139.xe0124b8a28cdb2f5 });
			return;
		}
		x67293147609631f8[] xe320f2f577e6ced = x782108ccba597139.xe320f2f577e6ced9;
		x67293147609631f8[] x9cd2d8ec0df9c7c = x782108ccba597139.x9cd2d8ec0df9c7c1;
		x8cedcaa9a62c6e39.xd48c438e0c21f019(xe320f2f577e6ced);
		x8cedcaa9a62c6e39.x74d67abfce1e29fb(x9cd2d8ec0df9c7c);
	}

	private void xc39fcda37d83ff9b()
	{
		x67293147609631f8[] x011027fdb46be = x7a17e854d3ce10e1.x88708cef126ae8cf((x60c040f35bb272aa)x8cedcaa9a62c6e39.x2f4154f97e632be9, x8cedcaa9a62c6e39.x513b9123039071f0, x3c12013af6b066fd: false);
		x8cedcaa9a62c6e39.xd48c438e0c21f019(x011027fdb46be);
	}

	private void x96f2536d8ac899f4()
	{
		x67293147609631f8[] x011027fdb46be = x7a17e854d3ce10e1.x88708cef126ae8cf(x8cedcaa9a62c6e39.xcc5190a6aa809d4a, x8cedcaa9a62c6e39.x8e3eeb462ebec42c, x3c12013af6b066fd: true);
		x8cedcaa9a62c6e39.x74d67abfce1e29fb(x011027fdb46be);
	}

	private void x6ed7ee1ce6cc3788()
	{
		if (x8cedcaa9a62c6e39.xcc5190a6aa809d4a.x4d7474e8f1849803.Count >= 2 && ((x60c040f35bb272aa)x8cedcaa9a62c6e39.x2f4154f97e632be9).x4d7474e8f1849803.Count >= 2)
		{
			x60c040f35bb272aa x60c040f35bb272aa = (x60c040f35bb272aa)x8cedcaa9a62c6e39.x2f4154f97e632be9;
			x48cc0c3eaf9f5f05 x7f5704d71690aff = new x48cc0c3eaf9f5f05((PointF)x8cedcaa9a62c6e39.xcc5190a6aa809d4a.x4d7474e8f1849803[0], (PointF)x8cedcaa9a62c6e39.xcc5190a6aa809d4a.x4d7474e8f1849803[1]);
			x48cc0c3eaf9f5f05 xef563966899b6b = new x48cc0c3eaf9f5f05((PointF)x60c040f35bb272aa.x4d7474e8f1849803[x60c040f35bb272aa.x4d7474e8f1849803.Count - 2], (PointF)x60c040f35bb272aa.x4d7474e8f1849803[x60c040f35bb272aa.x4d7474e8f1849803.Count - 1]);
			PointF[] array = new PointF[1] { PointF.Empty };
			if (x48cc0c3eaf9f5f05.x07aa36934bec95f1(x7f5704d71690aff, xef563966899b6b, array, xf6b46a641abf7d02: true))
			{
				x8cedcaa9a62c6e39.xcc5190a6aa809d4a.x4d7474e8f1849803[0] = array[0];
				((x60c040f35bb272aa)x8cedcaa9a62c6e39.x2f4154f97e632be9).x4d7474e8f1849803[x60c040f35bb272aa.x4d7474e8f1849803.Count - 1] = array[0];
			}
		}
	}

	private x60c040f35bb272aa xad84d4aa3e258090(x60c040f35bb272aa x337e217cb3ba0627, float x778cad6dac263160)
	{
		int count = x337e217cb3ba0627.x4d7474e8f1849803.Count;
		if (count < 1)
		{
			return x337e217cb3ba0627;
		}
		x60c040f35bb272aa x60c040f35bb272aa = count switch
		{
			1 => x476cf93dd87700c4(x337e217cb3ba0627), 
			2 => xe2fb0313924a2b51(x337e217cb3ba0627, x778cad6dac263160), 
			_ => x1617714e03298f56(x337e217cb3ba0627, count, x778cad6dac263160), 
		};
		xe4d5bdf1dce09721(x337e217cb3ba0627, x60c040f35bb272aa);
		return x60c040f35bb272aa;
	}

	private x60c040f35bb272aa x476cf93dd87700c4(x60c040f35bb272aa x337e217cb3ba0627)
	{
		PointF pointF = PointF.Empty;
		PointF pointF2 = PointF.Empty;
		if (x8cedcaa9a62c6e39.x05b95462167f8e54 is x519b1bd0625473ff)
		{
			pointF = ((x519b1bd0625473ff)x8cedcaa9a62c6e39.x05b95462167f8e54).x56b911bdb6515aed.x2271dea312f4a835;
			if (x8cedcaa9a62c6e39.x2f4154f97e632be9 is x519b1bd0625473ff)
			{
				pointF2 = ((x519b1bd0625473ff)x8cedcaa9a62c6e39.x2f4154f97e632be9).x56b911bdb6515aed.x2271dea312f4a835;
			}
		}
		else if (x8cedcaa9a62c6e39.x05b95462167f8e54 is x60c040f35bb272aa)
		{
			x60c040f35bb272aa x60c040f35bb272aa = (x60c040f35bb272aa)x8cedcaa9a62c6e39.x05b95462167f8e54;
			pointF = (PointF)x60c040f35bb272aa.x4d7474e8f1849803[x60c040f35bb272aa.x4d7474e8f1849803.Count - 1];
			if (x8cedcaa9a62c6e39.x2f4154f97e632be9 is x60c040f35bb272aa)
			{
				x60c040f35bb272aa x60c040f35bb272aa2 = (x60c040f35bb272aa)x8cedcaa9a62c6e39.x2f4154f97e632be9;
				pointF2 = (PointF)x60c040f35bb272aa2.x4d7474e8f1849803[x60c040f35bb272aa2.x4d7474e8f1849803.Count - 1];
			}
		}
		float num = pointF2.X - pointF.X;
		float num2 = pointF2.Y - pointF.Y;
		PointF pointF3 = (PointF)x337e217cb3ba0627.x4d7474e8f1849803[0];
		PointF pointF4 = new PointF(pointF3.X + num, pointF3.Y + num2);
		return new x60c040f35bb272aa(new PointF[1] { pointF4 });
	}

	private x60c040f35bb272aa xe2fb0313924a2b51(x60c040f35bb272aa x337e217cb3ba0627, float x778cad6dac263160)
	{
		PointF[] array = new PointF[1] { PointF.Empty };
		x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f6 = new x48cc0c3eaf9f5f05((PointF)x337e217cb3ba0627.x4d7474e8f1849803[0], (PointF)x337e217cb3ba0627.x4d7474e8f1849803[1]);
		if (x609e7b8dcf3783ed((PointF)x337e217cb3ba0627.x4d7474e8f1849803[0], (PointF)x337e217cb3ba0627.x4d7474e8f1849803[1]))
		{
			x778cad6dac263160 *= -1f;
		}
		x48cc0c3eaf9f5f05 x7f5704d71690aff = x48cc0c3eaf9f5f6.x71e88a3412cd7edf(x778cad6dac263160);
		x48cc0c3eaf9f5f05 xef563966899b6b = x48cc0c3eaf9f5f6.xe2785bbd7d56b3ec((PointF)x337e217cb3ba0627.x4d7474e8f1849803[0]);
		x48cc0c3eaf9f5f05 xef563966899b6b2 = x48cc0c3eaf9f5f6.xe2785bbd7d56b3ec((PointF)x337e217cb3ba0627.x4d7474e8f1849803[1]);
		PointF[] array2 = new PointF[2]
		{
			PointF.Empty,
			PointF.Empty
		};
		x48cc0c3eaf9f5f05.x07aa36934bec95f1(x7f5704d71690aff, xef563966899b6b, array);
		ref PointF reference = ref array2[0];
		reference = array[0];
		x48cc0c3eaf9f5f05.x07aa36934bec95f1(x7f5704d71690aff, xef563966899b6b2, array);
		ref PointF reference2 = ref array2[1];
		reference2 = array[0];
		return new x60c040f35bb272aa(array2);
	}

	private x60c040f35bb272aa x1617714e03298f56(x60c040f35bb272aa x337e217cb3ba0627, int x10f4d88af727adbc, float x778cad6dac263160)
	{
		bool x6210a4dd0714ea5e = x8cedcaa9a62c6e39.x6210a4dd0714ea5e;
		if (x37d2d88f96f87b47.xd0fdca5aa42d16bc((PointF)x337e217cb3ba0627.x4d7474e8f1849803[0], (PointF)x337e217cb3ba0627.x4d7474e8f1849803[x10f4d88af727adbc - 1]))
		{
			x10f4d88af727adbc--;
			x6210a4dd0714ea5e = true;
		}
		ArrayList arrayList = new ArrayList(x10f4d88af727adbc);
		xf091e5207f77e44d(x337e217cb3ba0627, arrayList, x10f4d88af727adbc, x778cad6dac263160);
		x60c040f35bb272aa result = new x60c040f35bb272aa(xaf8417282a3a6d18(x337e217cb3ba0627, (x48cc0c3eaf9f5f05[])arrayList.ToArray(typeof(x48cc0c3eaf9f5f05)), x778cad6dac263160, x10f4d88af727adbc));
		x8cedcaa9a62c6e39.x6210a4dd0714ea5e = x6210a4dd0714ea5e;
		return result;
	}

	private void xf091e5207f77e44d(x60c040f35bb272aa x337e217cb3ba0627, ArrayList x0383ec486664fa18, int x10f4d88af727adbc, float x778cad6dac263160)
	{
		for (int i = 0; i < x10f4d88af727adbc; i++)
		{
			bool flag = i == x10f4d88af727adbc - 1;
			x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f6 = new x48cc0c3eaf9f5f05((PointF)x337e217cb3ba0627.x4d7474e8f1849803[i], (PointF)x337e217cb3ba0627.x4d7474e8f1849803[(!flag) ? (i + 1) : 0]);
			bool flag2 = x609e7b8dcf3783ed((PointF)x337e217cb3ba0627.x4d7474e8f1849803[i], (PointF)x337e217cb3ba0627.x4d7474e8f1849803[(!flag) ? (i + 1) : 0]);
			float num = x778cad6dac263160;
			if (flag2)
			{
				num *= -1f;
			}
			x0383ec486664fa18.Add(x48cc0c3eaf9f5f6.x71e88a3412cd7edf(num));
		}
	}

	private PointF[] xaf8417282a3a6d18(x60c040f35bb272aa x337e217cb3ba0627, x48cc0c3eaf9f5f05[] x0383ec486664fa18, float x778cad6dac263160, int x10f4d88af727adbc)
	{
		PointF[] array = new PointF[1] { PointF.Empty };
		PointF[] array2 = new PointF[x10f4d88af727adbc];
		for (int i = 0; i < x0383ec486664fa18.Length; i++)
		{
			bool flag = i == x0383ec486664fa18.Length - 1;
			bool flag2 = i == x0383ec486664fa18.Length - 2;
			if (!x8cedcaa9a62c6e39.x6210a4dd0714ea5e && (flag || flag2))
			{
				x48cc0c3eaf9f5f05 xef563966899b6b = new x48cc0c3eaf9f5f05((PointF)x337e217cb3ba0627.x4d7474e8f1849803[(!flag) ? (x10f4d88af727adbc - 2) : 0], (PointF)x337e217cb3ba0627.x4d7474e8f1849803[flag ? 1 : (x10f4d88af727adbc - 1)]).xe2785bbd7d56b3ec((PointF)x337e217cb3ba0627.x4d7474e8f1849803[(!flag) ? (x10f4d88af727adbc - 1) : 0]);
				x48cc0c3eaf9f5f05.x07aa36934bec95f1(x0383ec486664fa18[(!flag) ? (x10f4d88af727adbc - 2) : 0], xef563966899b6b, array);
			}
			else if (!x48cc0c3eaf9f5f05.x07aa36934bec95f1(x0383ec486664fa18[i], x0383ec486664fa18[(!flag) ? (i + 1) : 0], array, xf6b46a641abf7d02: true))
			{
				xe2484850bd46d1fc(x337e217cb3ba0627, x778cad6dac263160, x0383ec486664fa18, i, array);
			}
			ref PointF reference = ref array2[(!flag) ? (i + 1) : 0];
			reference = array[0];
		}
		return array2;
	}

	private void xe2484850bd46d1fc(x60c040f35bb272aa x337e217cb3ba0627, float x778cad6dac263160, x48cc0c3eaf9f5f05[] x0383ec486664fa18, int x7b28e8a789372508, PointF[] xdafd84ce6fc8a98e)
	{
		bool flag = x7b28e8a789372508 == x337e217cb3ba0627.x4d7474e8f1849803.Count - 1;
		bool flag2 = x609e7b8dcf3783ed((PointF)x337e217cb3ba0627.x4d7474e8f1849803[x7b28e8a789372508], (PointF)x337e217cb3ba0627.x4d7474e8f1849803[(!flag) ? (x7b28e8a789372508 + 1) : 0]);
		float num = x778cad6dac263160;
		if (!flag2)
		{
			num *= -1f;
		}
		x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f6 = x0383ec486664fa18[x7b28e8a789372508].x71e88a3412cd7edf(num);
		x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f7 = x48cc0c3eaf9f5f6.xe2785bbd7d56b3ec((PointF)x337e217cb3ba0627.x4d7474e8f1849803[x7b28e8a789372508]);
		x48cc0c3eaf9f5f05.x07aa36934bec95f1(x0383ec486664fa18[x7b28e8a789372508], x48cc0c3eaf9f5f7.x71e88a3412cd7edf(num), xdafd84ce6fc8a98e);
	}

	private x519b1bd0625473ff[] x908719d610993771(x519b1bd0625473ff x337e217cb3ba0627, float x778cad6dac263160)
	{
		x67293147609631f8[] array = x337e217cb3ba0627.x56b911bdb6515aed.xd3f5c72f5a1d6688();
		x67293147609631f8[] array2 = new x67293147609631f8[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			ref x67293147609631f8 reference = ref array2[i];
			reference = x4ecc3641da0bdd59(array[i], x778cad6dac263160);
		}
		x7a17e854d3ce10e1.x682dd48c960b2fce(array2);
		array2 = x60dcd8102e7e7b0c(array2);
		return x8302a49e3e59ce7c(x337e217cb3ba0627, array2);
	}

	private x67293147609631f8 x4ecc3641da0bdd59(x67293147609631f8 x337e217cb3ba0627, float x778cad6dac263160)
	{
		x67293147609631f8 result = default(x67293147609631f8);
		x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f6 = new x48cc0c3eaf9f5f05(x337e217cb3ba0627.xaf4e0fbe61814cf5, x337e217cb3ba0627.x2f997a78d547d657);
		x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f7 = new x48cc0c3eaf9f5f05(x337e217cb3ba0627.x2271dea312f4a835, x337e217cb3ba0627.x2f997a78d547d657);
		x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f8 = x48cc0c3eaf9f5f6.xe2785bbd7d56b3ec(x337e217cb3ba0627.xaf4e0fbe61814cf5);
		x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f9 = x48cc0c3eaf9f5f7.xe2785bbd7d56b3ec(x337e217cb3ba0627.x2271dea312f4a835);
		PointF[] array = new PointF[1] { PointF.Empty };
		float num = x778cad6dac263160;
		if (x609e7b8dcf3783ed(x337e217cb3ba0627.xaf4e0fbe61814cf5, x337e217cb3ba0627.x2f997a78d547d657))
		{
			num *= -1f;
		}
		x48cc0c3eaf9f5f8.x4a4f2059e53968cf(x337e217cb3ba0627.xaf4e0fbe61814cf5, num, array);
		PointF pointF = array[0];
		num = x778cad6dac263160;
		if (x609e7b8dcf3783ed(x337e217cb3ba0627.x2f997a78d547d657, x337e217cb3ba0627.x2271dea312f4a835))
		{
			num *= -1f;
		}
		x48cc0c3eaf9f5f9.x4a4f2059e53968cf(x337e217cb3ba0627.x2271dea312f4a835, num, array);
		PointF pointF2 = array[0];
		PointF x2f997a78d547d = x3bf1ce6a688caf42(x337e217cb3ba0627, x48cc0c3eaf9f5f6, x48cc0c3eaf9f5f7, pointF, pointF2);
		result.xaf4e0fbe61814cf5 = pointF;
		result.x2271dea312f4a835 = pointF2;
		result.x2f997a78d547d657 = x2f997a78d547d;
		return result;
	}

	private static PointF x3bf1ce6a688caf42(x67293147609631f8 x337e217cb3ba0627, x48cc0c3eaf9f5f05 x9b93aeb625a91645, x48cc0c3eaf9f5f05 x9c1ccddc74479ce9, PointF x68625b3949a5b6d5, PointF x89cf615224956538)
	{
		PointF[] array = new PointF[1] { PointF.Empty };
		bool flag = x48cc0c3eaf9f5f05.x33f7244befbb6e65(x9b93aeb625a91645, x9c1ccddc74479ce9);
		x48cc0c3eaf9f5f05 x7f5704d71690aff = x9b93aeb625a91645.xf4301eca7520f49c(x68625b3949a5b6d5);
		if (flag)
		{
			x48cc0c3eaf9f5f05 xef563966899b6b = x9b93aeb625a91645.xe2785bbd7d56b3ec(x337e217cb3ba0627.x2f997a78d547d657);
			x48cc0c3eaf9f5f05.x07aa36934bec95f1(x7f5704d71690aff, xef563966899b6b, array);
		}
		else
		{
			x48cc0c3eaf9f5f05 xef563966899b6b2 = x9c1ccddc74479ce9.xf4301eca7520f49c(x89cf615224956538);
			x48cc0c3eaf9f5f05.x07aa36934bec95f1(x7f5704d71690aff, xef563966899b6b2, array);
		}
		return array[0];
	}

	private x67293147609631f8[] x60dcd8102e7e7b0c(x67293147609631f8[] xe4f48d1ce4812c3c)
	{
		if (x8cedcaa9a62c6e39.x2f4154f97e632be9 != null)
		{
			xe4f48d1ce4812c3c = (x8cedcaa9a62c6e39.x7e3449fd64a19b0b ? x98e011d34f11fd84(xe4f48d1ce4812c3c) : x41efd807f4c77262(xe4f48d1ce4812c3c));
		}
		return xe4f48d1ce4812c3c;
	}

	private x67293147609631f8[] x41efd807f4c77262(x67293147609631f8[] xe4f48d1ce4812c3c)
	{
		x782108ccba597138 x782108ccba597139 = x7a17e854d3ce10e1.x0a09fa2690680f34(x8cedcaa9a62c6e39.x8e3eeb462ebec42c, xe4f48d1ce4812c3c, x85542bc98c560fba: false);
		if (x782108ccba597139.x43e7db181a6b7a7e)
		{
			xba2ba9e15c7c4317(x782108ccba597139, xe4f48d1ce4812c3c);
		}
		else
		{
			x67293147609631f8[] xe320f2f577e6ced = x782108ccba597139.xe320f2f577e6ced9;
			x67293147609631f8[] x9cd2d8ec0df9c7c = x782108ccba597139.x9cd2d8ec0df9c7c1;
			xe320f2f577e6ced[^1].x2271dea312f4a835 = x9cd2d8ec0df9c7c[^1].xaf4e0fbe61814cf5;
			x8cedcaa9a62c6e39.x74d67abfce1e29fb(xe320f2f577e6ced);
			if (x9cd2d8ec0df9c7c.Length != xe4f48d1ce4812c3c.Length)
			{
				xe4f48d1ce4812c3c = new x67293147609631f8[x9cd2d8ec0df9c7c.Length];
			}
			for (int i = 0; i < x9cd2d8ec0df9c7c.Length; i++)
			{
				ref x67293147609631f8 reference = ref xe4f48d1ce4812c3c[i];
				reference = x9cd2d8ec0df9c7c[x9cd2d8ec0df9c7c.Length - 1 - i];
			}
		}
		return xe4f48d1ce4812c3c;
	}

	private void xba2ba9e15c7c4317(x782108ccba597138 xe9627bbd2316c800, x67293147609631f8[] xe4f48d1ce4812c3c)
	{
		PointF pointF = x7a17e854d3ce10e1.xf683153da3c42565(xe4f48d1ce4812c3c, x3c12013af6b066fd: false, new PointF[2]
		{
			xe4f48d1ce4812c3c[^1].x2f997a78d547d657,
			xe4f48d1ce4812c3c[^1].xaf4e0fbe61814cf5
		}, xe9627bbd2316c800.xe0124b8a28cdb2f5);
		x8cedcaa9a62c6e39.x2b85b58eb18ccd13.x8992595b6d42d9bd(new PointF[1] { pointF });
	}

	private x67293147609631f8[] x98e011d34f11fd84(x67293147609631f8[] xe4f48d1ce4812c3c)
	{
		x67293147609631f8[] array = x7a17e854d3ce10e1.x88708cef126ae8cf((x60c040f35bb272aa)x8cedcaa9a62c6e39.x2f4154f97e632be9, xe4f48d1ce4812c3c, x3c12013af6b066fd: false);
		if (array.Length != xe4f48d1ce4812c3c.Length)
		{
			xe4f48d1ce4812c3c = new x67293147609631f8[array.Length];
		}
		for (int i = 0; i < array.Length; i++)
		{
			ref x67293147609631f8 reference = ref xe4f48d1ce4812c3c[i];
			reference = array[array.Length - 1 - i];
		}
		return xe4f48d1ce4812c3c;
	}

	private void xe4d5bdf1dce09721(x60c040f35bb272aa x337e217cb3ba0627, x60c040f35bb272aa x6d38ccf47434064f)
	{
		if (x8cedcaa9a62c6e39.x2f4154f97e632be9 != null)
		{
			if (x8cedcaa9a62c6e39.x7e3449fd64a19b0b)
			{
				x7a17e854d3ce10e1.x45fe46d51e17bed9(x6d38ccf47434064f, (x60c040f35bb272aa)x8cedcaa9a62c6e39.x2f4154f97e632be9);
			}
			else
			{
				x67293147609631f8[] array = x7a17e854d3ce10e1.x88708cef126ae8cf(x6d38ccf47434064f, x8cedcaa9a62c6e39.x8e3eeb462ebec42c, x3c12013af6b066fd: true);
				x8cedcaa9a62c6e39.x74d67abfce1e29fb(array);
				x8cedcaa9a62c6e39.x2f4154f97e632be9 = array[^1];
			}
		}
		x8cedcaa9a62c6e39.x569c29b9ff6e99d3(x6d38ccf47434064f, x337e217cb3ba0627);
	}

	private x519b1bd0625473ff[] x8302a49e3e59ce7c(x519b1bd0625473ff x337e217cb3ba0627, x67293147609631f8[] xe4f48d1ce4812c3c)
	{
		x519b1bd0625473ff[] array = new x519b1bd0625473ff[xe4f48d1ce4812c3c.Length];
		for (int i = 0; i < xe4f48d1ce4812c3c.Length; i++)
		{
			array[i] = new x519b1bd0625473ff(xe4f48d1ce4812c3c[i].xaf4e0fbe61814cf5, xe4f48d1ce4812c3c[i].x2f997a78d547d657, xe4f48d1ce4812c3c[i].x2271dea312f4a835);
		}
		x8cedcaa9a62c6e39.xf3a692ac08441c7c(xe4f48d1ce4812c3c, array, x337e217cb3ba0627);
		return array;
	}

	private bool x609e7b8dcf3783ed(PointF x9b61de08eafdb554, PointF x5bc3b3e534cfe6dc)
	{
		float num = x5bc3b3e534cfe6dc.X - x9b61de08eafdb554.X;
		float num2 = x5bc3b3e534cfe6dc.Y - x9b61de08eafdb554.Y;
		if (!x8cedcaa9a62c6e39.x7ba7d24657083a90)
		{
			num *= -1f;
			num2 *= -1f;
		}
		if (num != 0f)
		{
			return num > 0f;
		}
		return num2 < 0f;
	}

	private static bool x597ec252b5121681(x31c19fcb724dfaf5 x90279591611601bc, ArrayList x61216c96189ce416)
	{
		float num = 0f;
		float num2 = x90279591611601bc.xdc1bf80853046136 / 2f;
		bool flag = false;
		for (int i = 0; i < x90279591611601bc.x6fd1e71abf8b8121.Length; i++)
		{
			float num3 = x90279591611601bc.x6fd1e71abf8b8121[i];
			if (num3 < 0f || num3 > 1f || num3 < num)
			{
				return false;
			}
			if (flag)
			{
				float width = (num3 - num) * x90279591611601bc.xdc1bf80853046136;
				float num4 = x90279591611601bc.xdc1bf80853046136 * (num3 + num) / 2f;
				float offset = num4 - num2;
				x61216c96189ce416.Add(new x11cc26a1c529c026(width, offset));
				flag = false;
			}
			else
			{
				flag = true;
			}
			num = num3;
		}
		return true;
	}
}
