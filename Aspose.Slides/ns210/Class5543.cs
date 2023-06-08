using ns211;

namespace ns210;

internal abstract class Class5543 : Class5510, Interface214
{
	internal Class5543(string id, int sequence, int flags, int format, Class5508 coverage)
		: base(id, sequence, flags, format, coverage)
	{
	}

	public override int vmethod_0()
	{
		return Class5563.int_0;
	}

	public override string vmethod_2()
	{
		return Class5565.smethod_3(vmethod_1());
	}

	public override bool vmethod_3(Class5510 subtable)
	{
		return subtable is Class5543;
	}

	public override bool vmethod_4()
	{
		return false;
	}

	public virtual bool imethod_0(Class5582 ss)
	{
		return false;
	}

	public static Class5591 smethod_2(Class5582 ss, Class5543[] sta, int sequenceIndex)
	{
		int num = ss.method_9();
		bool flag = false;
		while (ss.method_12())
		{
			bool flag2 = false;
			if (!flag && ss.method_47())
			{
				int num2 = 0;
				int num3 = sta.Length;
				while (!flag2 && num2 < num3)
				{
					if (sequenceIndex < 0)
					{
						flag2 = ss.method_63(sta[num2]);
					}
					else if (ss.method_9() == num + sequenceIndex && (flag2 = ss.method_63(sta[num2])))
					{
						flag = true;
					}
					num2++;
				}
			}
			if (!flag2 || !ss.method_19())
			{
				ss.vmethod_0();
			}
			ss.method_14();
		}
		return ss.method_62();
	}

	public static Class5591 smethod_3(Class5591 gs, string script, string language, string feature, Class5543[] sta, Interface216 sct)
	{
		return smethod_2(new Class5582(gs, script, language, feature, sct), sta, -1);
	}
}
