using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x3d94286fe72124a8;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x120d4bb5c80fb10c;

internal class x4550028bd6f6fe67 : xf51865b83a7a0b3b
{
	private ArrayList x9641750eecc6b70d;

	private x03d68de1c2f74051 x0aff47ced75afbfa;

	private readonly x6607281c5523036c x51908188f60cae73 = new x6607281c5523036c();

	internal static x03d68de1c2f74051 xa78bd34efc70ec90(xab391c46ff9a0a38 xe125219852864557)
	{
		x4550028bd6f6fe67 x4550028bd6f6fe68 = new x4550028bd6f6fe67();
		return x4550028bd6f6fe68.x74ed4bb22f1a8f34(xe125219852864557);
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		x0aff47ced75afbfa.x7e8ee2030a44c305(segment.x4d7474e8f1849803, x940dba70fec6696a: true);
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		x67293147609631f8[] array = segment.x56b911bdb6515aed.xd3f5c72f5a1d6688();
		for (int i = 0; i < array.Length; i++)
		{
			x0aff47ced75afbfa.x9e8a4f197cec3cdd(array[i].xaf4e0fbe61814cf5);
			x0aff47ced75afbfa.x9e8a4f197cec3cdd(array[i].x2f997a78d547d657);
			x9641750eecc6b70d.Add(x0aff47ced75afbfa.xe161fd465603c384 - 1);
		}
		x0aff47ced75afbfa.x9e8a4f197cec3cdd(array[^1].x2271dea312f4a835);
	}

	private x03d68de1c2f74051 x74ed4bb22f1a8f34(xab391c46ff9a0a38 xe125219852864557)
	{
		x0aff47ced75afbfa = new x03d68de1c2f74051();
		x9641750eecc6b70d = new ArrayList();
		xab391c46ff9a0a38 xab391c46ff9a0a = x30cf62e162be42a8(xe125219852864557);
		if (!xc3b6d0dce8b6f16b(xab391c46ff9a0a))
		{
			return x0aff47ced75afbfa;
		}
		xab391c46ff9a0a.Accept(this);
		xd74a949353ee64fc();
		if (xe125219852864557.x0e1bf8242ad10272 != null)
		{
			x03d68de1c2f74051 xdafde7d9313c28e = xa78bd34efc70ec90(xe125219852864557.x0e1bf8242ad10272);
			x0aff47ced75afbfa = xb48468b763132e39.x1d844bc824c86667(xdafde7d9313c28e, x0aff47ced75afbfa);
		}
		if (xe125219852864557.x52dde376accdec7d != null)
		{
			x0aff47ced75afbfa.x4fdf47a12306c1b7(xe125219852864557.x52dde376accdec7d);
		}
		x0aff47ced75afbfa.x638f09a63b4c2c2c(x2c8de54beeb6f890: true);
		return x0aff47ced75afbfa;
	}

	private xab391c46ff9a0a38 x30cf62e162be42a8(xab391c46ff9a0a38 xe125219852864557)
	{
		if (xe125219852864557.x9e5d5f9128c69a8f == null)
		{
			return xe125219852864557;
		}
		xab391c46ff9a0a38 xab391c46ff9a0a = x51908188f60cae73.xe94da055c1b9a188(xe125219852864557, x2b818897b65c872e: false, xdb73611e5c07ce94: false);
		xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(x26d9ecb4bdf0456d.x89fffa2751fdecbe);
		xab391c46ff9a0a.x9e5d5f9128c69a8f.xdc1bf80853046136 = 1f;
		bool flag = xe125219852864557.x60465f602599d327 != null || xe125219852864557.x424546082eb650ba;
		float num = ((xe125219852864557.x9e5d5f9128c69a8f.xdc1bf80853046136 == 0f) ? 0.75f : xe125219852864557.x9e5d5f9128c69a8f.xdc1bf80853046136);
		if (flag && xe125219852864557.x9e5d5f9128c69a8f.xdc1bf80853046136 == 0f)
		{
			return xab391c46ff9a0a;
		}
		xab391c46ff9a0a38 xab391c46ff9a0a2 = x0c8c298e5b4ef6f5.x500a49d41cd9cfd5(xab391c46ff9a0a, (0f - num) * 0.5f);
		if (flag)
		{
			return xab391c46ff9a0a2;
		}
		return x64fdca2e0f0f469b(xe125219852864557.x9e5d5f9128c69a8f.xdc1bf80853046136, xab391c46ff9a0a, xab391c46ff9a0a2);
	}

	private xab391c46ff9a0a38 x64fdca2e0f0f469b(float x29f8afd8e33e8ded, xab391c46ff9a0a38 xd8a07b8e7d4461cb, xab391c46ff9a0a38 x8389ebc8fbfdffec)
	{
		xab391c46ff9a0a38 xe125219852864557 = x0c8c298e5b4ef6f5.x500a49d41cd9cfd5(xd8a07b8e7d4461cb, x29f8afd8e33e8ded * 0.5f);
		xe125219852864557 = x453b6489e3fdbd4d.xf3814c2c2fb527cb(xe125219852864557);
		for (int i = 0; i < xe125219852864557.xd44988f225497f3a; i++)
		{
			if (i == xe125219852864557.xd44988f225497f3a - 1)
			{
				x1cab6af0a41b70e2 x1cab6af0a41b70e = (x1cab6af0a41b70e2)((xbaec545ec01f92ca)xe125219852864557).get_xe6d4b1b411ed94b5(i);
				x1cab6af0a41b70e2 x1cab6af0a41b70e2 = (x1cab6af0a41b70e2)((xbaec545ec01f92ca)x8389ebc8fbfdffec).get_xe6d4b1b411ed94b5(0);
				for (int j = 0; j < x1cab6af0a41b70e.xd44988f225497f3a; j++)
				{
					x1cab6af0a41b70e2.xef23aa45e7612fdd(j, ((xbaec545ec01f92ca)x1cab6af0a41b70e).get_xe6d4b1b411ed94b5(j));
				}
			}
			else
			{
				x8389ebc8fbfdffec.xd6b6ed77479ef68c(((xbaec545ec01f92ca)xe125219852864557).get_xe6d4b1b411ed94b5(i));
			}
		}
		return x8389ebc8fbfdffec;
	}

	private void xd74a949353ee64fc()
	{
		x8f86f499407bd12c();
		xe6d749e755879170();
	}

	private void x8f86f499407bd12c()
	{
		ArrayList arrayList = x620d064982c5a5c7();
		for (int i = 0; i < arrayList.Count; i++)
		{
			x0aff47ced75afbfa.x81b9866957faac98((int)arrayList[i] - i);
		}
	}

	private ArrayList x620d064982c5a5c7()
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < x9641750eecc6b70d.Count; i++)
		{
			int num = (int)x9641750eecc6b70d[i];
			if (x7edd21199e95dbf7(x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(num - 1).x755f16bdf92ce7c4, x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(num).x755f16bdf92ce7c4, x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(num + 1).x755f16bdf92ce7c4, x0aff47ced75afbfa.x7a0b193d493a9b59))
			{
				arrayList.Add(num);
			}
		}
		return arrayList;
	}

	private static bool x7edd21199e95dbf7(PointF xcb09bd0cee4909a3, PointF xb87b7305ef2b2389, PointF xa2da454aa40879d2, bool x2c8de54beeb6f890)
	{
		x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f = new x48cc0c3eaf9f5f05(xcb09bd0cee4909a3, xa2da454aa40879d2);
		bool flag = !x48cc0c3eaf9f5f.xaaf7cfb8dd3fd335(xb87b7305ef2b2389);
		bool flag2 = xcb09bd0cee4909a3.X - xa2da454aa40879d2.X > 0f;
		if (x2c8de54beeb6f890)
		{
			return flag ^ flag2;
		}
		if (!flag2 || !flag)
		{
			if (!flag2)
			{
				return !flag;
			}
			return false;
		}
		return true;
	}

	private void xe6d749e755879170()
	{
		if (x0aff47ced75afbfa.xe161fd465603c384 < 2)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		int xe161fd465603c = x0aff47ced75afbfa.xe161fd465603c384;
		for (int i = 1; i < xe161fd465603c - 1; i++)
		{
			if (x37d2d88f96f87b47.xd0fdca5aa42d16bc(x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(i - 1).x755f16bdf92ce7c4, x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(i).x755f16bdf92ce7c4))
			{
				arrayList.Add(i);
			}
		}
		for (int j = 0; j < arrayList.Count; j++)
		{
			x0aff47ced75afbfa.x81b9866957faac98((int)arrayList[j] - j);
		}
		if (x0aff47ced75afbfa.xe161fd465603c384 > 2 && x37d2d88f96f87b47.xd0fdca5aa42d16bc(x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(0).x755f16bdf92ce7c4, x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(x0aff47ced75afbfa.xe161fd465603c384 - 1).x755f16bdf92ce7c4))
		{
			x0aff47ced75afbfa.x81b9866957faac98(x0aff47ced75afbfa.xe161fd465603c384 - 1);
		}
	}

	private static bool xc3b6d0dce8b6f16b(xab391c46ff9a0a38 xe125219852864557)
	{
		if (xe125219852864557.x9e5d5f9128c69a8f != null && x073e839190656746(xe125219852864557.x9e5d5f9128c69a8f.x60465f602599d327))
		{
			return true;
		}
		return x073e839190656746(xe125219852864557.x60465f602599d327);
	}

	private static bool x073e839190656746(x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		if (xd8f1949f8950238a == null)
		{
			return false;
		}
		if (xd8f1949f8950238a is xc020fa2f5133cba8 xc020fa2f5133cba)
		{
			return xc020fa2f5133cba.x9b41425268471380.xda71bf6f7c07c3bc != 0;
		}
		return true;
	}
}
