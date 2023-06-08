using System;
using System.Runtime.CompilerServices;
using ns3;

namespace ns31;

internal class Class801 : IDisposable, Interface20
{
	private Class788 class788_0;

	private Class806 class806_0;

	private bool bool_0;

	public Interface25 Border => class806_0;

	public Interface8 Area => class788_0;

	internal Class801(Class787 class787_0)
	{
		class806_0 = new Class806(class787_0);
		class788_0 = new Class788(class787_0);
		class788_0.ForegroundColor = class787_0.method_14(bool_11: false).GetColor(55);
		class806_0.Color = class787_0.method_14(bool_11: false).GetColor(40);
	}

	[SpecialName]
	internal Class806 method_0()
	{
		return class806_0;
	}

	[SpecialName]
	internal Class788 method_1()
	{
		return class788_0;
	}

	~Class801()
	{
		Dispose(bool_1: false);
	}

	public void Dispose()
	{
		Dispose(bool_1: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_1)
	{
		if (!bool_0)
		{
			if (bool_1 && class788_0 != null)
			{
				class788_0.Dispose();
			}
			bool_0 = true;
		}
	}
}
