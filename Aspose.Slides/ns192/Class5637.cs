using System;
using System.Collections;
using ns171;
using ns183;

namespace ns192;

internal class Class5637
{
	public const int int_0 = 0;

	public const int int_1 = 1;

	public const int int_2 = 2;

	private int int_3;

	private Interface208 interface208_0;

	private int int_4;

	public Class5637(Class5156 table, int tablePart)
	{
		int_3 = tablePart;
		switch (tablePart)
		{
		default:
			throw new ArgumentException("Unrecognised TablePart: " + tablePart);
		case 0:
		{
			ArrayList arrayList = new ArrayList();
			Class5088.Interface163 @interface = table.vmethod_15();
			while (@interface.imethod_0())
			{
				Class5088 @class = @interface.imethod_10();
				if (@class is Class5152)
				{
					arrayList.AddRange(((Class5152)@class).method_55());
				}
			}
			interface208_0 = new Class5495(arrayList);
			break;
		}
		case 1:
			interface208_0 = new Class5495(table.method_60().method_55());
			break;
		case 2:
			interface208_0 = new Class5495(table.method_61().method_55());
			break;
		}
	}

	internal Class5645[] method_0()
	{
		if (!interface208_0.imethod_0())
		{
			return null;
		}
		ArrayList arrayList = (ArrayList)interface208_0.imethod_1();
		Class5645[] array = new Class5645[arrayList.Count];
		int num = 0;
		Interface208 @interface = new Class5495(arrayList);
		while (@interface.imethod_0())
		{
			ArrayList gridUnits = (ArrayList)@interface.imethod_1();
			array[num++] = new Class5645(int_4++, int_3, gridUnits);
		}
		return array;
	}
}
