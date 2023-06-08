using System;
using ns99;

namespace ns100;

internal class Class4410 : Class4409, Interface113, Interface119, Interface120, Interface121, Interface122
{
	private Class4409 class4409_0;

	private Class4505 class4505_0;

	private Class4503 class4503_0;

	private object object_2 = new object();

	private bool bool_0;

	public override string FontFamily => class4409_0.FontFamily;

	public override string Style => class4409_0.Style;

	public override Enum640 FontStyle => class4409_0.FontStyle;

	public override string FontName => class4409_0.FontName;

	public override Class4519 FontNames => class4409_0.FontNames;

	public override Interface114 Encoding => class4409_0.Encoding;

	public Class4505 UsedGlyphs => class4505_0;

	internal Class4503 UsedGlyphsIndexes => class4503_0;

	public virtual Class4408 OriginalFont => method_3();

	internal Class4410(Class4409 originalFont)
		: base(originalFont.FontDefinition)
	{
		method_4(originalFont);
		class4505_0 = new Class4505();
		class4505_0.class4501_0.Add(this);
		class4505_0.class4500_0.Add(this);
		class4505_0.class4499_0.Add(this);
		class4503_0 = new Class4503();
		class4503_0.method_1();
	}

	public override Class4480 imethod_0(Class4506 id)
	{
		if (UsedGlyphs.Contains(id))
		{
			return base.imethod_0(id);
		}
		return null;
	}

	private Class4408 method_3()
	{
		if (!bool_0)
		{
			lock (object_2)
			{
				if (!bool_0)
				{
					throw new NotImplementedException();
				}
			}
		}
		return class4409_0;
	}

	internal void method_4(Class4409 originalFont)
	{
		class4409_0 = originalFont;
		bool_0 = true;
	}

	void Interface121.imethod_0(object sender)
	{
		try
		{
			class4503_0.method_0();
			class4503_0.Clear();
		}
		finally
		{
			class4503_0.method_1();
		}
	}

	void Interface122.imethod_0(object sender, EventArgs3 e)
	{
		try
		{
			class4503_0.method_0();
			class4503_0.Remove(method_5(e.class4506_0));
		}
		finally
		{
			class4503_0.method_1();
		}
	}

	void Interface120.imethod_0(object sender, EventArgs3 e)
	{
		try
		{
			class4503_0.method_0();
			class4503_0.Add(method_5(e.class4506_0));
		}
		finally
		{
			class4503_0.method_1();
		}
	}

	internal string method_5(Class4506 id)
	{
		Class4508 @class;
		if ((@class = id as Class4508) != null)
		{
			Class4507 class2 = Encoding.imethod_3((char)@class.Value) as Class4507;
			if (!(class2 != null))
			{
				return null;
			}
			return class2.Value;
		}
		Class4507 class3;
		if ((class3 = id as Class4507) != null)
		{
			return class3.Value;
		}
		return Class4507.class4507_0.Value;
	}
}
