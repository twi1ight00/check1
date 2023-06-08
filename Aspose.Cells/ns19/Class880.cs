using System.Collections;

namespace ns19;

internal class Class880
{
	private static Hashtable hashtable_0;

	static Class880()
	{
		hashtable_0 = new Hashtable();
		smethod_0(Enum93.const_77, new Class878(new Class875[0], new Class879[14]
		{
			new Class879("dx1", Enum89.const_0, -27273042329602L, 49L, 48L, bool_1: false),
			new Class879("dx2", Enum89.const_0, -27273042329602L, 10L, 48L, bool_1: false),
			new Class879("x1", Enum89.const_1, -27273042329606L, 0L, -27273042329612L, bool_1: false),
			new Class879("x2", Enum89.const_1, -27273042329606L, 0L, -27273042329613L, bool_1: false),
			new Class879("x3", Enum89.const_1, -27273042329606L, -27273042329613L, 0L, bool_1: false),
			new Class879("x4", Enum89.const_1, -27273042329606L, -27273042329612L, 0L, bool_1: false),
			new Class879("y1", Enum89.const_1, -27273042329609L, 0L, -27273042329622L, bool_1: false),
			new Class879("il", Enum89.const_0, -27273042329602L, 1L, 6L, bool_1: false),
			new Class879("ir", Enum89.const_0, -27273042329602L, 5L, 6L, bool_1: false),
			new Class879("ib", Enum89.const_0, -27273042329603L, 2L, 3L, bool_1: false),
			new Class879("hd3", Enum89.const_0, -27273042329603L, 1L, 3L, bool_1: true),
			new Class879("hd4", Enum89.const_0, -27273042329603L, 1L, 4L, bool_1: true),
			new Class879("3cd4", Enum89.const_0, -27273042329601L, 3L, 4L, bool_1: true),
			new Class879("cd4", Enum89.const_0, -27273042329601L, 1L, 4L, bool_1: true)
		}, new Class876[2]
		{
			new Class876(-27273042329606L, -27273042329623L, -27273042329624L),
			new Class876(-27273042329606L, -27273042329611L, -27273042329625L)
		}, null, new Class881[1]
		{
			new Class881(new Enum91[4]
			{
				Enum91.const_1,
				Enum91.const_5,
				Enum91.const_5,
				Enum91.const_0
			}, new long[14]
			{
				-27273042329606L, -27273042329623L, -27273042329616L, -27273042329618L, -27273042329617L, -27273042329623L, -27273042329606L, -27273042329611L, -27273042329614L, -27273042329623L,
				-27273042329615L, -27273042329618L, -27273042329606L, -27273042329623L
			}, 0L, 0L, Enum92.const_1, bool_2: true, bool_3: true)
		}, new Class874(-27273042329619L, -27273042329623L), new Class874(-27273042329620L, -27273042329621L)));
	}

	private static void smethod_0(Enum93 enum93_0, Class878 class878_0)
	{
		hashtable_0.Add(enum93_0, class878_0);
	}

	internal static Class878 smethod_1(Enum93 enum93_0)
	{
		return (Class878)hashtable_0[enum93_0];
	}
}
