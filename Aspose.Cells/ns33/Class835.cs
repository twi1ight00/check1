using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;

namespace ns33;

internal class Class835 : IDisposable, Interface20
{
	private Class822 class822_0;

	private Class840 class840_0;

	private bool bool_0;

	public Interface25 Border => class840_0;

	public Interface8 Area => class822_0;

	internal Class835(Class821 class821_0)
	{
		class840_0 = new Class840(class821_0, Enum57.const_5);
		class822_0 = new Class822(class821_0, this, Enum52.const_3);
		class822_0.Formatting = Enum71.const_1;
		class822_0.ForegroundColor = Color.Empty;
		class840_0.Formatting = Enum71.const_1;
		class840_0.Color = Color.Empty;
	}

	[SpecialName]
	internal Class840 method_0()
	{
		return class840_0;
	}

	[SpecialName]
	internal Class822 method_1()
	{
		return class822_0;
	}

	~Class835()
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
			if (bool_1 && class822_0 != null)
			{
				class822_0.Dispose();
			}
			bool_0 = true;
		}
	}
}
