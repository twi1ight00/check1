using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns3;

internal class Class865 : IDisposable, Interface39
{
	internal RectangleF rectangleF_0 = new RectangleF(0f, 0f, 0f, 0f);

	internal Enum81 enum81_0;

	internal SizeF sizeF_0;

	private Font font_0;

	private string string_0 = "";

	private Color color_0;

	private bool bool_0;

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

	public Font Font => font_0;

	public Color FontColor => color_0;

	internal Class865(string string_1, Font font_1, Color color_1, Enum81 enum81_1)
	{
		string_0 = string_1;
		font_0 = font_1;
		color_0 = color_1;
		enum81_0 = enum81_1;
		if (enum81_1 == Enum81.const_2 && (string_1 == null || string_1 == ""))
		{
			vmethod_1(Enum81.const_1);
		}
	}

	[SpecialName]
	public Enum81 vmethod_0()
	{
		return enum81_0;
	}

	[SpecialName]
	public void vmethod_1(Enum81 enum81_1)
	{
		enum81_0 = enum81_1;
	}

	~Class865()
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
			if (bool_1 && font_0 != null)
			{
				font_0.Dispose();
			}
			bool_0 = true;
		}
	}
}
