using System;
using System.Runtime.CompilerServices;
using ns3;

namespace ns31;

internal class Class812 : IDisposable, Interface30
{
	private Class794 class794_0;

	private int int_0;

	private string string_0;

	private Enum82 enum82_0;

	private Enum82 enum82_1;

	private Class864 class864_0;

	internal bool bool_0 = true;

	private bool bool_1;

	public int Rotation
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			bool_0 = false;
		}
	}

	public string Text
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Enum82 TextHorizontalAlignment
	{
		get
		{
			return enum82_0;
		}
		set
		{
			enum82_0 = value;
		}
	}

	public Enum82 TextVerticalAlignment
	{
		get
		{
			return enum82_1;
		}
		set
		{
			enum82_1 = value;
		}
	}

	internal bool IsVisible
	{
		get
		{
			if (string_0 == null)
			{
				return false;
			}
			if (string_0.Length > 0)
			{
				return true;
			}
			return false;
		}
	}

	internal Class812(Class787 class787_0, object object_0, Enum52 enum52_0)
	{
		class794_0 = new Class794(class787_0, object_0, enum52_0);
		int_0 = 0;
		string_0 = "";
		class794_0.method_1().Formatting = Enum71.const_0;
		enum82_0 = Enum82.const_1;
		enum82_1 = Enum82.const_1;
		class794_0.Border.Formatting = Enum71.const_0;
		class864_0 = new Class864();
	}

	[SpecialName]
	internal Class794 method_0()
	{
		return class794_0;
	}

	[SpecialName]
	public Interface14 imethod_0()
	{
		return class794_0;
	}

	[SpecialName]
	public Interface38 imethod_1()
	{
		return class864_0;
	}

	~Class812()
	{
		Dispose(bool_2: false);
	}

	public void Dispose()
	{
		Dispose(bool_2: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_2)
	{
		if (!bool_1)
		{
			if (bool_2 && class794_0 != null)
			{
				class794_0.Dispose();
			}
			bool_1 = true;
		}
	}
}
