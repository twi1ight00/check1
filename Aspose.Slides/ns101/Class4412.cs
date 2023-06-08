using System;
using ns147;
using ns99;

namespace ns101;

internal class Class4412 : Class4411, Interface113, Interface119, Interface120, Interface121, Interface122
{
	private Class4411 class4411_0;

	private Class4505 class4505_0;

	private Class4504 class4504_0;

	private object object_3 = new object();

	private bool bool_1;

	public override string FontFamily => class4411_0.FontFamily;

	public override string Style => class4411_0.Style;

	public override Enum640 FontStyle => class4411_0.FontStyle;

	public override string FontName => class4411_0.FontName;

	public override Class4519 FontNames => class4411_0.FontNames;

	public override Interface114 Encoding => class4411_0.Encoding;

	public Class4505 UsedGlyphs => class4505_0;

	internal Class4504 UsedGlyphsIndexes => class4504_0;

	public virtual Class4408 OriginalFont => method_8();

	internal Class4412(Class4411 originalFont)
		: base(originalFont.FontDefinition, Class4681.smethod_1(originalFont.TTFTables))
	{
		method_9(originalFont);
		class4505_0 = new Class4505();
		class4505_0.class4501_0.Add(this);
		class4505_0.class4500_0.Add(this);
		class4505_0.class4499_0.Add(this);
		class4504_0 = new Class4504();
		class4504_0.method_1();
		((Class4661)TTFTables.GlyfTable).method_10(this);
		((Class4667)TTFTables.LocaTable).method_2(this);
	}

	public override Class4480 imethod_0(Class4506 id)
	{
		if (UsedGlyphs.Contains(id))
		{
			return base.imethod_0(id);
		}
		return null;
	}

	private Class4408 method_8()
	{
		if (!bool_1)
		{
			lock (object_3)
			{
				if (!bool_1)
				{
					throw new NotImplementedException();
				}
			}
		}
		return class4411_0;
	}

	internal void method_9(Class4411 originalFont)
	{
		class4411_0 = originalFont;
		bool_1 = true;
	}

	void Interface121.imethod_0(object sender)
	{
		try
		{
			class4504_0.method_0();
			class4504_0.Clear();
		}
		finally
		{
			class4504_0.method_1();
		}
	}

	void Interface122.imethod_0(object sender, EventArgs3 e)
	{
		try
		{
			class4504_0.method_0();
			class4504_0.Remove(method_7(e.class4506_0));
		}
		finally
		{
			class4504_0.method_1();
		}
	}

	void Interface120.imethod_0(object sender, EventArgs3 e)
	{
		try
		{
			class4504_0.method_0();
			class4504_0.Add(method_7(e.class4506_0));
		}
		finally
		{
			class4504_0.method_1();
		}
	}
}
