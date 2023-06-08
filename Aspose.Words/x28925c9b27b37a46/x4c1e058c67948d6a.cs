using System;
using System.Diagnostics;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x28925c9b27b37a46;

internal abstract class x4c1e058c67948d6a : x09ce2c02826e31a6
{
	public object xf7866f89640a29a3(int xba08ce632055a1d9)
	{
		return base.get_xe6d4b1b411ed94b5(xba08ce632055a1d9);
	}

	internal object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		object obj = xf7866f89640a29a3(xba08ce632055a1d9);
		if (obj == null)
		{
			return xdafa1f94b023b665(xba08ce632055a1d9);
		}
		return obj;
	}

	public object xdafa1f94b023b665(int xba08ce632055a1d9)
	{
		x4c1e058c67948d6a defaults = GetDefaults();
		int num = defaults.xf8af57cefd692401(xba08ce632055a1d9);
		if (num < 0)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mkgomlnofmepgmlpdlcaoljamlabkkhbgkobpffcakmcojddmjkdejbefkiejjpeojgfhenfkjegcilgkichajjhnhaifdhiihoiohfjohmjjcdkhgkkbhblacilchpliggmcgnmcgenaglnfgcojfjoiaapgehpgfopdffaoemacedbidkbiebceeiccdpcipfd", 1591469658)));
		}
		return defaults.x6d3720b962bd3112(num);
	}

	public void xae20093bed1e48a8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		base.set_xe6d4b1b411ed94b5(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	public void xc6dffc0c16c55f7a(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null)
		{
			xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
		}
	}

	protected void xae20093bed1e48a8(int xba08ce632055a1d9, object xbcea506a33cf9111, bool x3a6e018e511bd2c6)
	{
		if (x3a6e018e511bd2c6)
		{
			xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
		}
		else
		{
			x52b190e626f65140(xba08ce632055a1d9);
		}
	}

	internal virtual void x43c6155e35f47d2b(int xba08ce632055a1d9)
	{
		base.set_xe6d4b1b411ed94b5(xba08ce632055a1d9, (object)null);
	}

	internal void x0111f20a41a5f3c0(int xba08ce632055a1d9, x4c1e058c67948d6a x9e4d7279252bee4a)
	{
		object obj = xf7866f89640a29a3(xba08ce632055a1d9);
		if (obj != null)
		{
			x52b190e626f65140(xba08ce632055a1d9);
			x9e4d7279252bee4a.xae20093bed1e48a8(xba08ce632055a1d9, obj);
		}
	}

	internal void x456b2c186131b981(int xba08ce632055a1d9, x4c1e058c67948d6a x9e4d7279252bee4a)
	{
		object obj = xf7866f89640a29a3(xba08ce632055a1d9);
		if (obj != null)
		{
			x9e4d7279252bee4a.xae20093bed1e48a8(xba08ce632055a1d9, obj);
		}
		else
		{
			x9e4d7279252bee4a.x52b190e626f65140(xba08ce632055a1d9);
		}
	}

	public virtual void ClearAttrs()
	{
		xa9d636b00ff486b7();
	}

	protected abstract x4c1e058c67948d6a GetDefaults();

	internal virtual x4c1e058c67948d6a x8b61531c8ea35b85()
	{
		x4c1e058c67948d6a x4c1e058c67948d6a2 = (x4c1e058c67948d6a)x676cdebdb54fa6f0();
		for (int i = 0; i < base.xd44988f225497f3a; i++)
		{
			int xba08ce632055a1d = xf15263674eb297bb(i);
			object obj = x6d3720b962bd3112(i);
			object xbcea506a33cf;
			if (obj is x11e014059489ae95)
			{
				x11e014059489ae95 x11e014059489ae96 = (x11e014059489ae95)obj;
				if (x11e014059489ae96.xc8ea2954a6825f32)
				{
					continue;
				}
				xbcea506a33cf = x11e014059489ae96.xcc4933610939ad04();
			}
			else
			{
				xbcea506a33cf = obj;
			}
			((x09ce2c02826e31a6)x4c1e058c67948d6a2).set_xe6d4b1b411ed94b5(xba08ce632055a1d, xbcea506a33cf);
		}
		return x4c1e058c67948d6a2;
	}

	internal void xab3af626b1405ee8(x4c1e058c67948d6a x7a65590f8086d4cf)
	{
		xab3af626b1405ee8(x7a65590f8086d4cf, null);
	}

	internal void xab3af626b1405ee8(x4c1e058c67948d6a x7a65590f8086d4cf, bool x9ee6c2f047893ddc)
	{
		if (x9ee6c2f047893ddc)
		{
			x4c1e058c67948d6a defaults = GetDefaults();
			defaults.xab3af626b1405ee8(x7a65590f8086d4cf);
		}
		xab3af626b1405ee8(x7a65590f8086d4cf);
	}

	internal void xab3af626b1405ee8(x4c1e058c67948d6a x7a65590f8086d4cf, xceb510a6fe203e32 x7ac07d7dd429ba6e)
	{
		if (x7a65590f8086d4cf == null)
		{
			throw new ArgumentNullException("dstAttrs");
		}
		for (int i = 0; i < base.xd44988f225497f3a; i++)
		{
			int xba08ce632055a1d = xf15263674eb297bb(i);
			object obj = x6d3720b962bd3112(i);
			object xbcea506a33cf;
			if (obj is x11e014059489ae95)
			{
				x11e014059489ae95 x11e014059489ae96 = (x11e014059489ae95)obj;
				if (x11e014059489ae96.xc8ea2954a6825f32)
				{
					continue;
				}
				if (x11e014059489ae96 is x29fbbb70011562a9)
				{
					x29fbbb70011562a9 xc2cb9a5cf10fb63f = (x29fbbb70011562a9)((x09ce2c02826e31a6)x7a65590f8086d4cf).get_xe6d4b1b411ed94b5(xba08ce632055a1d);
					xbcea506a33cf = ((x29fbbb70011562a9)x11e014059489ae96).x8810335244b90b9d(xc2cb9a5cf10fb63f);
				}
				else
				{
					xbcea506a33cf = x11e014059489ae96.xcc4933610939ad04();
				}
			}
			else if (obj is x9b28b1f7f0cc963f)
			{
				x9b28b1f7f0cc963f x9b28b1f7f0cc963f2 = (x9b28b1f7f0cc963f)obj;
				xbcea506a33cf = x9b28b1f7f0cc963f2.xd0c62c194ffc67e6(x7a65590f8086d4cf, xba08ce632055a1d);
			}
			else
			{
				xbcea506a33cf = obj;
			}
			if (x7ac07d7dd429ba6e != null)
			{
				x7ac07d7dd429ba6e.x0acd3c2012ea2ee8(x7a65590f8086d4cf, xba08ce632055a1d, xbcea506a33cf);
			}
			else
			{
				((x09ce2c02826e31a6)x7a65590f8086d4cf).set_xe6d4b1b411ed94b5(xba08ce632055a1d, xbcea506a33cf);
			}
		}
	}

	internal void x968eca275aff04e3(x4c1e058c67948d6a x94351a74a6703192)
	{
		x968eca275aff04e3(x94351a74a6703192, -1);
	}

	internal void x968eca275aff04e3(x4c1e058c67948d6a x94351a74a6703192, int x096fa9d55d1361b6)
	{
		if (x94351a74a6703192 == null)
		{
			throw new ArgumentNullException("baseAttrs");
		}
		for (int i = 0; i < x94351a74a6703192.xd44988f225497f3a; i++)
		{
			int num = x94351a74a6703192.xf15263674eb297bb(i);
			if (num == x096fa9d55d1361b6)
			{
				continue;
			}
			int num2 = xf8af57cefd692401(num);
			if (num2 >= 0)
			{
				object obj = x94351a74a6703192.x6d3720b962bd3112(i);
				object obj2 = x6d3720b962bd3112(num2);
				if (obj.Equals(obj2))
				{
					x7121e9e177952651(num2);
				}
				else
				{
					x1eea676c325a2e50(obj2, obj);
				}
				continue;
			}
			object obj3 = xdafa1f94b023b665(num);
			if (obj3 is x11e014059489ae95)
			{
				obj3 = ((x11e014059489ae95)obj3).xcc4933610939ad04();
				object xf8a6672b07b695d = x94351a74a6703192.x6d3720b962bd3112(i);
				x1eea676c325a2e50(obj3, xf8a6672b07b695d);
			}
			base.set_xe6d4b1b411ed94b5(num, obj3);
		}
	}

	internal bool Equals(x4c1e058c67948d6a coll, int[] keysToIgnore)
	{
		return Equals(this, coll, keysToIgnore);
	}

	internal bool xa7ee97ddde231678(int[] xf872ef10023993ae)
	{
		for (int i = 0; i < base.xd44988f225497f3a; i++)
		{
			int xbcea506a33cf = xf15263674eb297bb(i);
			if (xcd4bd3abd72ff2da.x792b6f092cbf4bb1(xf872ef10023993ae, 0, xf872ef10023993ae.Length, xbcea506a33cf) < 0)
			{
				object obj = x6d3720b962bd3112(i);
				if (!(obj is x11e014059489ae95) || !((x11e014059489ae95)obj).xc8ea2954a6825f32)
				{
					return true;
				}
			}
		}
		return false;
	}

	internal static bool Equals(x4c1e058c67948d6a coll1, x4c1e058c67948d6a coll2, int[] keysToIgnore)
	{
		int x30cc7819189f11b = 0;
		int x30cc7819189f11b2 = 0;
		int xba08ce632055a1d = 0;
		int xba08ce632055a1d2 = 0;
		bool flag3;
		bool flag4;
		do
		{
			bool flag = x3135f5823c0fe903(coll1, ref x30cc7819189f11b, ref xba08ce632055a1d, keysToIgnore);
			bool flag2 = x3135f5823c0fe903(coll2, ref x30cc7819189f11b2, ref xba08ce632055a1d2, keysToIgnore);
			flag3 = flag && flag2;
			flag4 = ((!flag3) ? (!flag && !flag2) : (xba08ce632055a1d == xba08ce632055a1d2 && coll1.x6d3720b962bd3112(x30cc7819189f11b++).Equals(coll2.x6d3720b962bd3112(x30cc7819189f11b2++))));
		}
		while (flag4 && flag3);
		return flag4;
	}

	private static bool x3135f5823c0fe903(x4c1e058c67948d6a x01c8fcfe91402774, ref int x30cc7819189f11b6, ref int xba08ce632055a1d9, int[] xf872ef10023993ae)
	{
		int num = x01c8fcfe91402774.xd44988f225497f3a;
		int x961016a387451f = ((xf872ef10023993ae != null) ? xf872ef10023993ae.Length : 0);
		while (x30cc7819189f11b6 < num)
		{
			xba08ce632055a1d9 = x01c8fcfe91402774.xf15263674eb297bb(x30cc7819189f11b6);
			if (xf872ef10023993ae == null || xcd4bd3abd72ff2da.x792b6f092cbf4bb1(xf872ef10023993ae, 0, x961016a387451f, xba08ce632055a1d9) < 0)
			{
				return true;
			}
			x30cc7819189f11b6++;
		}
		return false;
	}

	private static void x1eea676c325a2e50(object x17851e025f61f449, object xf8a6672b07b695d7)
	{
		if (x17851e025f61f449 is x29fbbb70011562a9)
		{
			((x29fbbb70011562a9)x17851e025f61f449).x968eca275aff04e3((x29fbbb70011562a9)xf8a6672b07b695d7);
		}
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void x466dd296f7338c95(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void xcbdf0bfb4ca95676(params object[] xcd31b50c43a96e21)
	{
	}
}
