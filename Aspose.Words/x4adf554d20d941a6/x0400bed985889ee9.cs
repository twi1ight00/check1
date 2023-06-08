using System;
using Aspose.Words;

namespace x4adf554d20d941a6;

internal class x0400bed985889ee9
{
	private x852fe8bb5ac31098 x9886858906e51a59;

	internal x852fe8bb5ac31098 x902d63c74e3c13c4 => x9886858906e51a59;

	internal void xee89fee4f0415c13(x852fe8bb5ac31098 xe3e287548b3d01f5)
	{
		x9886858906e51a59 = xe3e287548b3d01f5.x902d63c74e3c13c4;
		int num = x76a019c602cd5091(x9886858906e51a59);
		while (true)
		{
			int num2 = xe21bdcd7a80024cc(x9886858906e51a59, xffd6352b2e5d70e3: true);
			int num3 = xe21bdcd7a80024cc(x9886858906e51a59, xffd6352b2e5d70e3: false);
			if (num2 <= num || num3 <= num)
			{
				break;
			}
			xaa2a75c86806b58e(x9886858906e51a59, num3 - 1);
			int num4 = xe21bdcd7a80024cc(x9886858906e51a59, xffd6352b2e5d70e3: true);
			if (num4 >= num2)
			{
				xaa2a75c86806b58e(x9886858906e51a59, num2);
				break;
			}
		}
		x9886858906e51a59.x05d2302b6c276f0b(Math.Min(xe21bdcd7a80024cc(x9886858906e51a59, xffd6352b2e5d70e3: true), x9886858906e51a59.xb0f146032f47c24e));
		int num5 = x9886858906e51a59.xe38820c59d60221a.xd7fab63fabd0a319 - x9886858906e51a59.xc821290d7ecc08bf;
		if (num5 < x9886858906e51a59.xb0f146032f47c24e)
		{
			x9886858906e51a59.x05d2302b6c276f0b(num5);
		}
		x9886858906e51a59 = null;
	}

	internal static bool x0a491b09c448a296(x852fe8bb5ac31098 xb6842aa1e60562e1)
	{
		if (xb6842aa1e60562e1.xdd62b6960d1f1486)
		{
			return false;
		}
		if (xb6842aa1e60562e1.x345fbad4ac42bc22())
		{
			return false;
		}
		xf6689e0eed33812c x0d6e7e3547c7244f = xb6842aa1e60562e1.x3c1c340351d94fbd.x0d6e7e3547c7244f;
		bool flag = xb6842aa1e60562e1.x35dcdaa8bc9d8066 && x0d6e7e3547c7244f != null && x0d6e7e3547c7244f.x25416a65ee993a54;
		if (flag)
		{
			flag = x0d6e7e3547c7244f.xf48cd6e82340ac70.xe95664527db59e6e == SectionStart.Continuous || xb6842aa1e60562e1.x5458a425704f77fe().x7149c962c02931b3;
		}
		if (!flag)
		{
			return false;
		}
		xb6842aa1e60562e1.x05d2302b6c276f0b(Math.Min(xb6842aa1e60562e1.xe38820c59d60221a.xd7fab63fabd0a319 - xb6842aa1e60562e1.xc821290d7ecc08bf, xe21bdcd7a80024cc(xb6842aa1e60562e1, xffd6352b2e5d70e3: true)));
		if (xb6842aa1e60562e1.x6c98ade5b8f05ba3)
		{
			return false;
		}
		if (!x5d30045af3da9a92.xadfbd9589d068bcf(xb6842aa1e60562e1.x3c1c340351d94fbd))
		{
			return false;
		}
		if (xb6842aa1e60562e1.x5458a425704f77fe() == xb6842aa1e60562e1)
		{
			return false;
		}
		if (!xb6842aa1e60562e1.xe555546649482e02())
		{
			return false;
		}
		return true;
	}

	private static void xaa2a75c86806b58e(x852fe8bb5ac31098 xb6842aa1e60562e1, int x4d5aabc7a55b12ba)
	{
		xbba4ca0462c7486f.x5c915d7a114773a2(xb6842aa1e60562e1);
		xb6842aa1e60562e1.x05d2302b6c276f0b(x4d5aabc7a55b12ba);
		xb6842aa1e60562e1.x5458a425704f77fe().xb0f146032f47c24e = 1073741823;
		x3f7228e953be72ed x3f7228e953be72ed2 = new x3f7228e953be72ed();
		x852fe8bb5ac31098 x852fe8bb5ac31099 = xb6842aa1e60562e1;
		while (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.x902d63c74e3c13c4 == xb6842aa1e60562e1)
		{
			x3f7228e953be72ed2.xc3819e13f60dd8e6(x852fe8bb5ac31099, x852fe8bb5ac31099.xb0f146032f47c24e);
			x852fe8bb5ac31099 = x852fe8bb5ac31099.xe202d610ff4b6eca;
		}
	}

	private static int xe21bdcd7a80024cc(x852fe8bb5ac31098 xe3e287548b3d01f5, bool xffd6352b2e5d70e3)
	{
		int num = 0;
		x852fe8bb5ac31098 xe202d610ff4b6eca = xe3e287548b3d01f5.x902d63c74e3c13c4;
		while (xe202d610ff4b6eca != null && xe202d610ff4b6eca.x902d63c74e3c13c4 == xe3e287548b3d01f5.x902d63c74e3c13c4)
		{
			num = Math.Max(num, x8da06d2b7dd8e7d9.xa8e1cf14e7fe26fe(xe202d610ff4b6eca, xffd6352b2e5d70e3));
			xe202d610ff4b6eca = xe202d610ff4b6eca.xe202d610ff4b6eca;
		}
		return num;
	}

	private static int x76a019c602cd5091(x852fe8bb5ac31098 xe3e287548b3d01f5)
	{
		if (x7639fcb6e869dccc(xe3e287548b3d01f5))
		{
			return x4bc35b79f5cf49ba(xe3e287548b3d01f5.x69d28a4aeef83a6f.x8b8a0a04b3aeaf3a) + xe3e287548b3d01f5.x69d28a4aeef83a6f.x43604484a3deae4f.xb0f146032f47c24e + xe3e287548b3d01f5.x69d28a4aeef83a6f.xcb6bfda2755bdd2d.xb0f146032f47c24e;
		}
		if (xe3e287548b3d01f5.x7149c962c02931b3)
		{
			return x4bc35b79f5cf49ba(xe3e287548b3d01f5.xd90ac7fcbe961761.x8b8a0a04b3aeaf3a) + xe3e287548b3d01f5.xd90ac7fcbe961761.x43604484a3deae4f.xb0f146032f47c24e + xe3e287548b3d01f5.xd90ac7fcbe961761.xcb6bfda2755bdd2d.xb0f146032f47c24e;
		}
		return x4bc35b79f5cf49ba(xe3e287548b3d01f5.x8b8a0a04b3aeaf3a);
	}

	internal static bool x7639fcb6e869dccc(x852fe8bb5ac31098 xe3e287548b3d01f5)
	{
		if (xe3e287548b3d01f5.x69d28a4aeef83a6f == null || xe3e287548b3d01f5.x69d28a4aeef83a6f.x7149c962c02931b3)
		{
			return false;
		}
		if (xe3e287548b3d01f5.x7149c962c02931b3)
		{
			return true;
		}
		x398b3bd0acd94b61 x398b3bd0acd94b62 = x16dabaa37d19a5ec.x22e642b5dff41b56(xe3e287548b3d01f5.x69d28a4aeef83a6f.x8b8a0a04b3aeaf3a).xce4443deee105995(x954503abc583f675.x4c38e800e85b21ad);
		return x398b3bd0acd94b62 != xe3e287548b3d01f5;
	}

	private static int x4bc35b79f5cf49ba(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		return xd7e5673853e47af4.x954503abc583f675 switch
		{
			x954503abc583f675.x48cc0c3eaf9f5f05 => x8da06d2b7dd8e7d9.x99c80529a1c59616((x53cb1139c5c64ee6)xd7e5673853e47af4, xffd6352b2e5d70e3: false), 
			x954503abc583f675.xa19781cfbe8b4961 => ((x694f001896973fe3)xd7e5673853e47af4).x647980b7bc85885a, 
			_ => throw new InvalidOperationException("Unexpected part type."), 
		};
	}
}
