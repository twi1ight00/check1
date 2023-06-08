using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns34;

namespace ns33;

internal class Class833 : IDisposable, Interface18
{
	private Class829 class829_0;

	private string string_0 = "";

	private Enum67 enum67_0;

	private int int_0;

	private Enum82 enum82_0;

	private Enum82 enum82_1;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	public int Rotation
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			method_1(bool_3: false);
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

	[SpecialName]
	internal bool method_0()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_1(bool bool_3)
	{
		bool_1 = bool_3;
	}

	internal Class833(Class821 class821_0, object object_0, Enum52 enum52_0)
	{
		class829_0 = new Class829(class821_0, object_0, Enum52.const_13, Enum57.const_15);
		int_0 = 0;
		class829_0.method_1().Formatting = Enum71.const_0;
		enum82_0 = Enum82.const_1;
		enum82_1 = Enum82.const_1;
		bool_1 = true;
	}

	[SpecialName]
	internal Class829 method_2()
	{
		return class829_0;
	}

	[SpecialName]
	public Interface14 imethod_0()
	{
		return class829_0;
	}

	[SpecialName]
	public Enum67 vmethod_0()
	{
		return enum67_0;
	}

	[SpecialName]
	public void imethod_1(Enum67 enum67_1)
	{
		enum67_0 = enum67_1;
	}

	[SpecialName]
	public string vmethod_1()
	{
		if (string_0 != "")
		{
			return string_0;
		}
		return enum67_0 switch
		{
			Enum67.const_3 => "Millions", 
			Enum67.const_2 => "Thousands", 
			Enum67.const_1 => "Hundrends", 
			Enum67.const_0 => "None", 
			Enum67.const_4 => "Billions", 
			Enum67.const_5 => "Trillions", 
			_ => "None", 
		};
	}

	[SpecialName]
	public void imethod_2(string string_1)
	{
		string_0 = string_1;
	}

	[SpecialName]
	public bool vmethod_2()
	{
		return bool_0;
	}

	[SpecialName]
	public void imethod_3(bool bool_3)
	{
		bool_0 = bool_3;
	}

	internal void method_3()
	{
		if (vmethod_0() != 0 && vmethod_2())
		{
			class829_0.method_19();
			Struct61.smethod_0(class829_0.Chart.imethod_0(), class829_0.rectangle_0, vmethod_1(), Rotation, class829_0.Font, class829_0.FontColor, TextHorizontalAlignment, TextVerticalAlignment);
		}
	}

	internal Size method_4(SizeF sizeF_0)
	{
		Size size = new Size(0, 0);
		if (vmethod_0() != 0 && vmethod_2())
		{
			size = Struct61.smethod_3(class829_0.Chart.imethod_0(), vmethod_1(), Rotation, class829_0.Font, sizeF_0, TextHorizontalAlignment, TextVerticalAlignment);
		}
		class829_0.rectangle_1.Size = size;
		return size;
	}

	~Class833()
	{
		Dispose(bool_3: false);
	}

	public void Dispose()
	{
		Dispose(bool_3: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_3)
	{
		if (!bool_2)
		{
			if (bool_3 && class829_0 != null)
			{
				class829_0.Dispose();
			}
			bool_2 = true;
		}
	}
}
