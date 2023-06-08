using System;
using x0a3ff9616df4cd36;
using x1c8faa688b1f0b0c;

namespace xf84f8427dc22d095;

internal class xf796701adb7bc194 : xf51865b83a7a0b3b
{
	private readonly x2bfc048c6117997a[] x661ff97aad146326;

	private xf796701adb7bc194(x2bfc048c6117997a[] effects)
	{
		if (effects == null)
		{
			throw new ArgumentNullException();
		}
		x661ff97aad146326 = effects;
	}

	internal static void x550781f8db1cf5f2(x4fdf549af9de6b97 x5f50d4ed5375c1fe, x2bfc048c6117997a[] x45bd840e09b7c920)
	{
		if (x45bd840e09b7c920 != null && x45bd840e09b7c920.Length != 0)
		{
			xf796701adb7bc194 visitor = new xf796701adb7bc194(x45bd840e09b7c920);
			x5f50d4ed5375c1fe.Accept(visitor);
		}
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		for (int i = 0; i < x661ff97aad146326.Length; i++)
		{
			x661ff97aad146326[i].x550781f8db1cf5f2(path);
		}
	}

	public override void VisitImage(x72c34b8dbaec3734 image)
	{
		using x1844bb3f2776c1ac x1844bb3f2776c1ac = new x1844bb3f2776c1ac(image.xcc18177a965e0313);
		for (int i = 0; i < x661ff97aad146326.Length; i++)
		{
			x661ff97aad146326[i].x550781f8db1cf5f2(x1844bb3f2776c1ac);
		}
		x1844bb3f2776c1ac.x3a7f601b9a1adbf4();
		image.xcc18177a965e0313 = x1844bb3f2776c1ac.x601e9a2243ca6720();
	}
}
