using System.Collections.Generic;

namespace ns24;

internal class Class519
{
	private const long long_0 = -27273042329608L;

	private const long long_1 = -27273042329602L;

	private const long long_2 = -27273042329603L;

	private const long long_3 = -27273042329609L;

	private const long long_4 = -27273042329610L;

	private const long long_5 = -27273042329611L;

	private long long_6;

	private long long_7;

	public Class519(long width, long height)
	{
		long_6 = width;
		long_7 = height;
	}

	public long method_0(List<Class541> geomGuides, long valueToScale, Class342.Enum164[] flags)
	{
		long coord = valueToScale;
		method_4(geomGuides, ref coord, flags);
		return Class342.smethod_2(geomGuides, Enum113.const_1, -27273042329608L, Class342.smethod_2(geomGuides, Enum113.const_0, coord, -27273042329602L, long_6), 0L);
	}

	public long method_1(List<Class541> geomGuides, long valueToScale, Class342.Enum164[] flags)
	{
		long coord = valueToScale;
		method_4(geomGuides, ref coord, flags);
		return Class342.smethod_2(geomGuides, Enum113.const_1, -27273042329609L, Class342.smethod_2(geomGuides, Enum113.const_0, coord, -27273042329603L, long_7), 0L);
	}

	public long method_2(List<Class541> geomGuides, long valueToScale, Class342.Enum164[] flags)
	{
		return Class342.smethod_2(geomGuides, Enum113.const_0, valueToScale, -27273042329602L, long_6);
	}

	public long method_3(List<Class541> geomGuides, long valueToScale, Class342.Enum164[] flags)
	{
		return Class342.smethod_2(geomGuides, Enum113.const_0, valueToScale, -27273042329603L, long_7);
	}

	private void method_4(List<Class541> geomGuides, ref long coord, Class342.Enum164[] flags)
	{
		if (coord >= -27273042329600L)
		{
			return;
		}
		int num = (int)(-27273042329600L - coord - 1L);
		Class342.Enum164 @enum = flags[num] & (Class342.Enum164.flag_1 | Class342.Enum164.flag_2 | Class342.Enum164.flag_3 | Class342.Enum164.flag_4);
		if (@enum == Class342.Enum164.flag_0)
		{
			return;
		}
		Class342.Enum164 enum2 = @enum & (Class342.Enum164.flag_1 | Class342.Enum164.flag_2);
		Class342.Enum164 enum3 = @enum & (Class342.Enum164.flag_3 | Class342.Enum164.flag_4);
		if (enum2 != 0)
		{
			long param = Class342.smethod_2(geomGuides, Enum113.const_3, Class342.smethod_2(geomGuides, Enum113.const_1, -27273042329602L, 0L, -27273042329603L), Class342.smethod_2(geomGuides, Enum113.const_0, -27273042329603L, 1L, -27273042329602L), 1L);
			switch (enum2)
			{
			case Class342.Enum164.flag_1:
				coord = Class342.smethod_2(geomGuides, Enum113.const_0, coord, param, 1L);
				break;
			case Class342.Enum164.flag_2:
			{
				long param4 = Class342.smethod_2(geomGuides, Enum113.const_1, long_6, 0L, coord);
				long param5 = Class342.smethod_2(geomGuides, Enum113.const_0, param4, param, 1L);
				coord = Class342.smethod_2(geomGuides, Enum113.const_1, long_6, 0L, param5);
				break;
			}
			default:
			{
				long num2 = Class342.smethod_2(geomGuides, Enum113.const_0, long_6, 1L, 2L);
				long param2 = Class342.smethod_2(geomGuides, Enum113.const_1, coord, 0L, num2);
				long param3 = Class342.smethod_2(geomGuides, Enum113.const_0, param2, param, 1L);
				coord = Class342.smethod_2(geomGuides, Enum113.const_1, param3, num2, 0L);
				break;
			}
			}
		}
		if (enum3 != 0)
		{
			long param6 = Class342.smethod_2(geomGuides, Enum113.const_3, Class342.smethod_2(geomGuides, Enum113.const_1, -27273042329603L, 0L, -27273042329602L), Class342.smethod_2(geomGuides, Enum113.const_0, -27273042329602L, 1L, -27273042329603L), 1L);
			switch (enum3)
			{
			case Class342.Enum164.flag_3:
				coord = Class342.smethod_2(geomGuides, Enum113.const_0, coord, param6, 1L);
				break;
			case Class342.Enum164.flag_4:
			{
				long param9 = Class342.smethod_2(geomGuides, Enum113.const_1, long_7, 0L, coord);
				long param10 = Class342.smethod_2(geomGuides, Enum113.const_0, param9, param6, 1L);
				coord = Class342.smethod_2(geomGuides, Enum113.const_1, long_7, 0L, param10);
				break;
			}
			default:
			{
				long num3 = Class342.smethod_2(geomGuides, Enum113.const_0, long_7, 1L, 2L);
				long param7 = Class342.smethod_2(geomGuides, Enum113.const_1, coord, 0L, num3);
				long param8 = Class342.smethod_2(geomGuides, Enum113.const_0, param7, param6, 1L);
				coord = Class342.smethod_2(geomGuides, Enum113.const_1, param8, num3, 0L);
				break;
			}
			}
		}
	}
}
