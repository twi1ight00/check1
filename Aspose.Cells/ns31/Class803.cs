using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns32;

namespace ns31;

internal class Class803 : IDisposable, Interface22
{
	private object object_0;

	private bool bool_0;

	private Class787 class787_0;

	private Font font_0;

	private bool bool_1 = true;

	private Color color_0;

	private int int_0;

	private string string_0;

	private Enum56 enum56_0;

	private Class810 class810_0;

	private Class815 class815_0;

	private bool bool_2;

	public bool IsDeleted
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Font Font
	{
		get
		{
			if (font_0 == null)
			{
				if (object_0 is Class804)
				{
					font_0 = ((Class804)object_0).method_0().Font;
				}
				else if (object_0 is Class793)
				{
					font_0 = ((Class793)object_0).Font;
				}
				else
				{
					font_0 = Struct40.smethod_24(class787_0.Font);
				}
			}
			return font_0;
		}
		set
		{
			font_0 = value;
		}
	}

	public Color FontColor
	{
		set
		{
			bool_1 = false;
			color_0 = value;
		}
	}

	internal string Name
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

	internal Enum56 Type
	{
		get
		{
			return enum56_0;
		}
		set
		{
			enum56_0 = value;
		}
	}

	internal Class803(Class787 class787_1, object object_1, int int_1)
	{
		class787_0 = class787_1;
		object_0 = object_1;
		int_0 = int_1;
		bool_0 = false;
	}

	[SpecialName]
	public int vmethod_0()
	{
		return int_0;
	}

	[SpecialName]
	internal Class810 method_0()
	{
		return class810_0;
	}

	[SpecialName]
	internal void method_1(Class810 class810_1)
	{
		class810_0 = class810_1;
	}

	[SpecialName]
	internal Class815 method_2()
	{
		return class815_0;
	}

	[SpecialName]
	internal void method_3(Class815 class815_1)
	{
		class815_0 = class815_1;
	}

	~Class803()
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
			if (bool_3 && font_0 != null)
			{
				font_0.Dispose();
			}
			bool_2 = true;
		}
	}
}
