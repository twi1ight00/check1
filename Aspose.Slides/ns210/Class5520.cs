using ns211;

namespace ns210;

internal abstract class Class5520 : Class5510, Interface212
{
	protected Class5520(string id, int sequence, int flags, int format, Class5508 coverage)
		: base(id, sequence, flags, format, coverage)
	{
	}

	public override int vmethod_0()
	{
		return Class5563.int_1;
	}

	public override string vmethod_2()
	{
		return Class5566.smethod_3(vmethod_1());
	}

	public override bool vmethod_3(Class5510 subtable)
	{
		return subtable is Class5520;
	}

	public override bool vmethod_4()
	{
		return false;
	}

	public virtual bool imethod_0(Class5581 ps)
	{
		return false;
	}

	public static bool smethod_2(Class5581 ps, Class5520[] sta, int sequenceIndex)
	{
		int num = ps.method_9();
		bool flag = false;
		while (ps.method_12())
		{
			bool flag2 = false;
			if (!flag && ps.method_47())
			{
				int num2 = 0;
				int num3 = sta.Length;
				while (!flag2 && num2 < num3)
				{
					if (sequenceIndex < 0)
					{
						flag2 = ps.method_63(sta[num2]);
					}
					else if (ps.method_9() == num + sequenceIndex && (flag2 = ps.method_63(sta[num2])))
					{
						flag = true;
					}
					num2++;
				}
			}
			if (!flag2 || !ps.method_19())
			{
				ps.vmethod_0();
			}
			ps.method_14();
		}
		return ps.method_66();
	}

	public static bool smethod_3(Class5591 gs, string script, string language, string feature, int fontSize, Class5520[] sta, int[] widths, int[][] adjustments, Interface216 sct)
	{
		return smethod_2(new Class5581(gs, script, language, feature, fontSize, widths, adjustments, sct), sta, -1);
	}
}
