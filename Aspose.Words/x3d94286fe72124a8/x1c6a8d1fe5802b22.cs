using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class x1c6a8d1fe5802b22
{
	private const float x2e6beb50a5f29a38 = 0.1f;

	private readonly x11cc26a1c529c026 x3f6331a327cf433a;

	private readonly xab391c46ff9a0a38 x792944894802ea12;

	private x1cab6af0a41b70e2 xb5c5edea9f40a9ab;

	private x4fdf549af9de6b97 x6a242a2cab523235;

	private object x0fe79d310e5cdb35;

	private bool x4627755f0c05205c;

	private bool x4aff6c4c6edd8bf7;

	private bool xba75c7d55fccd167;

	private x60c040f35bb272aa x73ca5b7126f5d0d2;

	private x67293147609631f8[] x212e0fc6c39f9ea8;

	private x67293147609631f8[] xcf3002d6f2165e58;

	private x519b1bd0625473ff[] x57108ce6afbb739d;

	private x519b1bd0625473ff[] x88fca48397bc3f2a;

	private bool x7ba067d6755ba839;

	private bool x7de4f5891449e700;

	private int x5fd3173862d009b7;

	internal x1cab6af0a41b70e2 x2b85b58eb18ccd13 => xb5c5edea9f40a9ab;

	internal x11cc26a1c529c026 xc9443bca5b0a56d8 => x3f6331a327cf433a;

	internal xab391c46ff9a0a38 x6cd7659ca2021746 => x792944894802ea12;

	internal x4fdf549af9de6b97 x05b95462167f8e54 => x6a242a2cab523235;

	internal object x2f4154f97e632be9
	{
		get
		{
			return x0fe79d310e5cdb35;
		}
		set
		{
			x0fe79d310e5cdb35 = value;
		}
	}

	internal bool x7e3449fd64a19b0b => x4aff6c4c6edd8bf7;

	internal bool x6ce296a3fb2167b3 => xba75c7d55fccd167;

	internal x60c040f35bb272aa xcc5190a6aa809d4a => x73ca5b7126f5d0d2;

	internal x67293147609631f8[] x8e3eeb462ebec42c => x212e0fc6c39f9ea8;

	internal x67293147609631f8[] x513b9123039071f0 => xcf3002d6f2165e58;

	internal bool x6210a4dd0714ea5e
	{
		get
		{
			return x7ba067d6755ba839;
		}
		set
		{
			x7ba067d6755ba839 = value;
		}
	}

	internal bool x7ba7d24657083a90 => x7de4f5891449e700;

	internal int xf06a57baef9037ce
	{
		get
		{
			return x5fd3173862d009b7;
		}
		set
		{
			x5fd3173862d009b7 = value;
		}
	}

	internal x1c6a8d1fe5802b22(xab391c46ff9a0a38 path, x11cc26a1c529c026 container)
	{
		x3f6331a327cf433a = container;
		x792944894802ea12 = new xab391c46ff9a0a38();
		x6cd7659ca2021746.x9e5d5f9128c69a8f = path.x9e5d5f9128c69a8f.xfe8f67360e300e88();
		x6cd7659ca2021746.x9e5d5f9128c69a8f.x6fd1e71abf8b8121 = x0c8c298e5b4ef6f5.x41a174bca277c948;
		x6cd7659ca2021746.x9e5d5f9128c69a8f.xdc1bf80853046136 = ((xc9443bca5b0a56d8.xdc1bf80853046136 > 1f) ? xc9443bca5b0a56d8.xdc1bf80853046136 : 1f);
		if (x6cd7659ca2021746.x9e5d5f9128c69a8f.xca08e8eb525b8a1a != 0)
		{
			x6cd7659ca2021746.x9e5d5f9128c69a8f.x358988d12e56bf69 = xe0054a1fe601814e(path.x9e5d5f9128c69a8f.x358988d12e56bf69, path.x9e5d5f9128c69a8f.xdc1bf80853046136, x6cd7659ca2021746.x9e5d5f9128c69a8f.xdc1bf80853046136);
		}
	}

	internal void xb2e3462588a64d38(x1cab6af0a41b70e2 x6ac16bf6efd00832)
	{
		xb5c5edea9f40a9ab = new x1cab6af0a41b70e2();
		x2b85b58eb18ccd13.x5e6c52cb3256cc85 = x6ac16bf6efd00832.x5e6c52cb3256cc85;
		x6210a4dd0714ea5e = x6ac16bf6efd00832.x5e6c52cb3256cc85;
		x6cd7659ca2021746.xd6b6ed77479ef68c(x2b85b58eb18ccd13);
		x6a242a2cab523235 = null;
		x0fe79d310e5cdb35 = null;
		x73ca5b7126f5d0d2 = null;
		x4627755f0c05205c = false;
		xf06a57baef9037ce = 0;
		ArrayList x6fa2570084b2ad = x7566f6ca3fe600f8(x6ac16bf6efd00832);
		x7de4f5891449e700 = x37d2d88f96f87b47.xb81c335b66ecc867(x6fa2570084b2ad);
	}

	internal void x74d67abfce1e29fb(x67293147609631f8[] x011027fdb46be048)
	{
		PointF pointF = PointF.Empty;
		for (int i = 0; i < x57108ce6afbb739d.Length; i++)
		{
			if (x011027fdb46be048.Length > i)
			{
				x57108ce6afbb739d[i].x56b911bdb6515aed = new x9fe47a4de491f4aa(x011027fdb46be048[i].xaf4e0fbe61814cf5, x011027fdb46be048[i].x2f997a78d547d657, x011027fdb46be048[i].x2271dea312f4a835);
				pointF = x011027fdb46be048[i].x2271dea312f4a835;
			}
			else
			{
				x57108ce6afbb739d[i].x56b911bdb6515aed = new x9fe47a4de491f4aa(pointF, pointF, pointF);
			}
		}
		if (xf06a57baef9037ce == 2 && !x6ce296a3fb2167b3)
		{
			xcf3002d6f2165e58 = x011027fdb46be048;
		}
	}

	internal void xd48c438e0c21f019(x67293147609631f8[] x011027fdb46be048)
	{
		PointF pointF = PointF.Empty;
		for (int i = 0; i < x88fca48397bc3f2a.Length; i++)
		{
			if (x011027fdb46be048.Length > i)
			{
				x88fca48397bc3f2a[x88fca48397bc3f2a.Length - 1 - i].x56b911bdb6515aed = new x9fe47a4de491f4aa(x011027fdb46be048[i].xaf4e0fbe61814cf5, x011027fdb46be048[i].x2f997a78d547d657, x011027fdb46be048[i].x2271dea312f4a835);
				pointF = x011027fdb46be048[i].x2271dea312f4a835;
			}
			else
			{
				x88fca48397bc3f2a[x88fca48397bc3f2a.Length - 1 - i].x56b911bdb6515aed = new x9fe47a4de491f4aa(pointF, pointF, pointF);
			}
		}
	}

	internal void x569c29b9ff6e99d3(x60c040f35bb272aa x6d38ccf47434064f, x60c040f35bb272aa x337e217cb3ba0627)
	{
		x6a242a2cab523235 = x337e217cb3ba0627;
		x0fe79d310e5cdb35 = x6d38ccf47434064f;
		x4aff6c4c6edd8bf7 = true;
		if (!x4627755f0c05205c)
		{
			x4627755f0c05205c = true;
			x73ca5b7126f5d0d2 = x6d38ccf47434064f;
			xba75c7d55fccd167 = true;
		}
	}

	internal void xf3a692ac08441c7c(x67293147609631f8[] xe4f48d1ce4812c3c, x519b1bd0625473ff[] xf32ad9fb70fa57f2, x519b1bd0625473ff x337e217cb3ba0627)
	{
		x0fe79d310e5cdb35 = xe4f48d1ce4812c3c[^1];
		x212e0fc6c39f9ea8 = xe4f48d1ce4812c3c;
		x57108ce6afbb739d = xf32ad9fb70fa57f2;
		if (!x4627755f0c05205c)
		{
			x4627755f0c05205c = true;
			xba75c7d55fccd167 = false;
			xcf3002d6f2165e58 = xe4f48d1ce4812c3c;
			x88fca48397bc3f2a = xf32ad9fb70fa57f2;
		}
		x6a242a2cab523235 = x337e217cb3ba0627;
		x4aff6c4c6edd8bf7 = false;
	}

	private static ArrayList x7566f6ca3fe600f8(x1cab6af0a41b70e2 x6ac16bf6efd00832)
	{
		ArrayList arrayList = new ArrayList();
		bool x75764f6cff9a7fc = false;
		x4fdf549af9de6b97 xd9ff4dee1dba180e = null;
		for (int i = 0; i < x6ac16bf6efd00832.xd44988f225497f3a; i++)
		{
			x4fdf549af9de6b97 x4fdf549af9de6b = ((xbaec545ec01f92ca)x6ac16bf6efd00832).get_xe6d4b1b411ed94b5(i);
			if (x4fdf549af9de6b is x60c040f35bb272aa)
			{
				x797df88216218068((x60c040f35bb272aa)x4fdf549af9de6b, x6ac16bf6efd00832, i, arrayList, xd9ff4dee1dba180e, x75764f6cff9a7fc);
				x75764f6cff9a7fc = true;
			}
			else if (x4fdf549af9de6b is x519b1bd0625473ff)
			{
				if (xc0d8aa13adea2bdc((x519b1bd0625473ff)x4fdf549af9de6b, x6ac16bf6efd00832, i, arrayList, xd9ff4dee1dba180e, x75764f6cff9a7fc))
				{
					i++;
				}
				x75764f6cff9a7fc = false;
			}
			xd9ff4dee1dba180e = x4fdf549af9de6b;
		}
		return arrayList;
	}

	private static bool xc0d8aa13adea2bdc(x519b1bd0625473ff xf7b33f565ba74aee, x1cab6af0a41b70e2 x6ac16bf6efd00832, int x7b28e8a789372508, ArrayList xa55760d8d6555155, x4fdf549af9de6b97 xd9ff4dee1dba180e, bool x75764f6cff9a7fc8)
	{
		bool result = false;
		xa55760d8d6555155.Add(xf7b33f565ba74aee.x56b911bdb6515aed.xaf4e0fbe61814cf5);
		xa55760d8d6555155.Add(xf7b33f565ba74aee.x56b911bdb6515aed.x2271dea312f4a835);
		if (xd9ff4dee1dba180e != null)
		{
			if (x5817e969b116b2b1(xf7b33f565ba74aee, xd9ff4dee1dba180e, xfeec4401a77dbe62: false, x75764f6cff9a7fc8, x6ac16bf6efd00832, x7b28e8a789372508))
			{
				result = true;
			}
		}
		else if (x6ac16bf6efd00832.xd44988f225497f3a != 1 && x6ac16bf6efd00832.x5e6c52cb3256cc85 && x5817e969b116b2b1(xf7b33f565ba74aee, ((xbaec545ec01f92ca)x6ac16bf6efd00832).get_xe6d4b1b411ed94b5(x6ac16bf6efd00832.xd44988f225497f3a - 1), xfeec4401a77dbe62: false, ((xbaec545ec01f92ca)x6ac16bf6efd00832).get_xe6d4b1b411ed94b5(x6ac16bf6efd00832.xd44988f225497f3a - 1) is x60c040f35bb272aa, x6ac16bf6efd00832, x7b28e8a789372508))
		{
			result = true;
		}
		return result;
	}

	private static void x797df88216218068(x60c040f35bb272aa xe405f90180315c89, x1cab6af0a41b70e2 x6ac16bf6efd00832, int x7b28e8a789372508, ArrayList xa55760d8d6555155, x4fdf549af9de6b97 xd9ff4dee1dba180e, bool x75764f6cff9a7fc8)
	{
		xa55760d8d6555155.AddRange(xe405f90180315c89.x4d7474e8f1849803);
		if (xd9ff4dee1dba180e != null)
		{
			x5817e969b116b2b1(xe405f90180315c89, xd9ff4dee1dba180e, xfeec4401a77dbe62: true, x75764f6cff9a7fc8, x6ac16bf6efd00832, x7b28e8a789372508);
		}
		else if (x6ac16bf6efd00832.xd44988f225497f3a != 1 && x6ac16bf6efd00832.x5e6c52cb3256cc85)
		{
			x5817e969b116b2b1(xe405f90180315c89, ((xbaec545ec01f92ca)x6ac16bf6efd00832).get_xe6d4b1b411ed94b5(x6ac16bf6efd00832.xd44988f225497f3a - 1), xfeec4401a77dbe62: true, ((xbaec545ec01f92ca)x6ac16bf6efd00832).get_xe6d4b1b411ed94b5(x6ac16bf6efd00832.xd44988f225497f3a - 1) is x60c040f35bb272aa, x6ac16bf6efd00832, x7b28e8a789372508);
		}
	}

	private static bool x5817e969b116b2b1(x4fdf549af9de6b97 x3bd62873fafa6252, x4fdf549af9de6b97 xd9ff4dee1dba180e, bool xfeec4401a77dbe62, bool x75764f6cff9a7fc8, x1cab6af0a41b70e2 x6ac16bf6efd00832, int xfd5c89d61a5fe3c2)
	{
		if (xfeec4401a77dbe62)
		{
			xcb7572ed07669aa2(x3bd62873fafa6252, xd9ff4dee1dba180e, x75764f6cff9a7fc8);
			return false;
		}
		return x205dca7a5cc0ed8e(x3bd62873fafa6252, xd9ff4dee1dba180e, x75764f6cff9a7fc8, x6ac16bf6efd00832, xfd5c89d61a5fe3c2);
	}

	private static bool x205dca7a5cc0ed8e(x4fdf549af9de6b97 x3bd62873fafa6252, x4fdf549af9de6b97 xd9ff4dee1dba180e, bool x75764f6cff9a7fc8, x1cab6af0a41b70e2 x6ac16bf6efd00832, int xfd5c89d61a5fe3c2)
	{
		x519b1bd0625473ff x519b1bd0625473ff = (x519b1bd0625473ff)x3bd62873fafa6252;
		if (x75764f6cff9a7fc8)
		{
			x91a60a1f084251aa(xd9ff4dee1dba180e, x519b1bd0625473ff.x56b911bdb6515aed.xaf4e0fbe61814cf5);
		}
		else
		{
			x519b1bd0625473ff x519b1bd0625473ff2 = (x519b1bd0625473ff)xd9ff4dee1dba180e;
			if (!x37d2d88f96f87b47.x5a48dddfe8c0ac5b(x519b1bd0625473ff2.x56b911bdb6515aed.x2271dea312f4a835, x519b1bd0625473ff.x56b911bdb6515aed.xaf4e0fbe61814cf5, 0.1f))
			{
				x60c040f35bb272aa xda5bf54deb817e = new x60c040f35bb272aa(new PointF[2]
				{
					x519b1bd0625473ff2.x56b911bdb6515aed.x2271dea312f4a835,
					x519b1bd0625473ff.x56b911bdb6515aed.xaf4e0fbe61814cf5
				});
				x6ac16bf6efd00832.xef23aa45e7612fdd(xfd5c89d61a5fe3c2, xda5bf54deb817e);
				return true;
			}
		}
		return false;
	}

	private static void xcb7572ed07669aa2(x4fdf549af9de6b97 x3bd62873fafa6252, x4fdf549af9de6b97 xd9ff4dee1dba180e, bool x75764f6cff9a7fc8)
	{
		x60c040f35bb272aa x60c040f35bb272aa = (x60c040f35bb272aa)x3bd62873fafa6252;
		if (x75764f6cff9a7fc8)
		{
			x91a60a1f084251aa(xd9ff4dee1dba180e, (PointF)x60c040f35bb272aa.x4d7474e8f1849803[0]);
			return;
		}
		x519b1bd0625473ff x519b1bd0625473ff = (x519b1bd0625473ff)xd9ff4dee1dba180e;
		if (!x37d2d88f96f87b47.x5a48dddfe8c0ac5b(x519b1bd0625473ff.x56b911bdb6515aed.x2271dea312f4a835, (PointF)x60c040f35bb272aa.x4d7474e8f1849803[0], 0.1f))
		{
			x60c040f35bb272aa.x4d7474e8f1849803.Insert(0, x519b1bd0625473ff.x56b911bdb6515aed.x2271dea312f4a835);
		}
	}

	private static void x91a60a1f084251aa(x4fdf549af9de6b97 xd9ff4dee1dba180e, PointF x2f7096dac971d6ec)
	{
		x60c040f35bb272aa x60c040f35bb272aa = (x60c040f35bb272aa)xd9ff4dee1dba180e;
		if (!x37d2d88f96f87b47.x5a48dddfe8c0ac5b((PointF)x60c040f35bb272aa.x4d7474e8f1849803[x60c040f35bb272aa.x4d7474e8f1849803.Count - 1], x2f7096dac971d6ec, 0.1f))
		{
			x60c040f35bb272aa.x4d7474e8f1849803.Add(x2f7096dac971d6ec);
		}
	}

	private static float[] xe0054a1fe601814e(float[] x456d4c99fdd5ee70, float x6259272b45c4f696, float x6e304abf38447e30)
	{
		float[] array = new float[x456d4c99fdd5ee70.Length];
		for (int i = 0; i < x456d4c99fdd5ee70.Length; i++)
		{
			array[i] = x456d4c99fdd5ee70[i] * x6259272b45c4f696 / x6e304abf38447e30;
		}
		return array;
	}
}
