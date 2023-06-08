using ns22;
using ns24;
using ns4;

namespace Aspose.Slides;

public class BaseShapeLock : IBaseShapeLock
{
	private ushort ushort_0;

	private ushort ushort_1 = ushort.MaxValue;

	private Class295 class295_0 = new Class295();

	private Class268 class268_0 = new Class268();

	internal Class295 PPTXUnsupportedProps => class295_0;

	internal Class268 PPTUnsupportedProps => class268_0;

	public bool NoLocks => ushort_0 == 0;

	internal BaseShapeLock()
	{
	}

	internal BaseShapeLock(ushort sign)
	{
		ushort_1 = sign;
	}

	internal static ushort smethod_0(params Enum114[] fields)
	{
		ushort num = 0;
		foreach (Enum114 @enum in fields)
		{
			num = (ushort)(num | (ushort)(1 << (int)@enum));
		}
		return num;
	}

	internal bool method_0(Enum114 field)
	{
		return (ushort_0 & (1 << (int)field)) != 0;
	}

	internal void method_1(Enum114 field, bool value)
	{
		ushort num = (ushort)(1 << (int)field);
		if (value)
		{
			ushort_0 |= num;
		}
		else
		{
			ushort_0 &= (ushort)(~num);
		}
	}

	internal static bool smethod_1(ushort values, Enum114 field)
	{
		return (values & (1 << (int)field)) != 0;
	}
}
