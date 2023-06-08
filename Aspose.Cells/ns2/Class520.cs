using System.Globalization;
using System.Runtime.CompilerServices;

namespace ns2;

internal class Class520
{
	private int int_0 = 2000;

	private Interface4 interface4_0;

	private CultureInfo cultureInfo_0;

	private bool bool_0 = true;

	public CultureInfo CultureInfo
	{
		get
		{
			if (cultureInfo_0 == null)
			{
				cultureInfo_0 = CultureInfo.CurrentCulture;
			}
			return cultureInfo_0;
		}
		set
		{
			cultureInfo_0 = value;
		}
	}

	[SpecialName]
	public int method_0()
	{
		return int_0;
	}

	[SpecialName]
	public Interface4 method_1()
	{
		return interface4_0;
	}

	[SpecialName]
	public void method_2(Interface4 interface4_1)
	{
		interface4_0 = interface4_1;
	}

	[SpecialName]
	public bool method_3()
	{
		return bool_0;
	}
}
