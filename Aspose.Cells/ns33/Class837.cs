using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns34;

namespace ns33;

internal class Class837 : IDisposable, Interface22
{
	private object object_0;

	private bool bool_0;

	private Class821 class821_0;

	private Font font_0;

	private bool bool_1 = true;

	private Color color_0;

	private int int_0;

	private string string_0;

	private Enum56 enum56_0;

	private Class844 class844_0;

	private Class850 class850_0;

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
				if (object_0 is Class838)
				{
					font_0 = ((Class838)object_0).method_0().Font;
				}
				else if (object_0 is Class828)
				{
					font_0 = ((Class828)object_0).Font;
				}
				else
				{
					font_0 = Struct63.smethod_24(class821_0.Font);
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
		get
		{
			if (bool_1)
			{
				if (object_0 is Class838)
				{
					return ((Class838)object_0).method_0().FontColor;
				}
				if (object_0 is Class828)
				{
					return ((Class828)object_0).FontColor;
				}
				return class821_0.FontColor;
			}
			return color_0;
		}
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

	internal Class837(Class821 class821_1, object object_1, int int_1)
	{
		class821_0 = class821_1;
		object_0 = object_1;
		int_0 = int_1;
		bool_0 = false;
		bool_1 = true;
	}

	[SpecialName]
	public int vmethod_0()
	{
		return int_0;
	}

	[SpecialName]
	internal Class844 method_0()
	{
		return class844_0;
	}

	[SpecialName]
	internal void method_1(Class844 class844_1)
	{
		class844_0 = class844_1;
	}

	[SpecialName]
	internal Class850 method_2()
	{
		return class850_0;
	}

	[SpecialName]
	internal void method_3(Class850 class850_1)
	{
		class850_0 = class850_1;
	}

	~Class837()
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
