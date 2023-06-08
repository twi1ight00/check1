using System.Drawing;
using System.Runtime.CompilerServices;
using ns72;
using ns73;

namespace ns76;

internal class Class4073
{
	private Class3548<Class3696<Font>> class3548_0;

	[CompilerGenerated]
	private static Delegate2774<Font> delegate2774_0;

	[CompilerGenerated]
	private static Delegate2774<Font> delegate2774_1;

	[CompilerGenerated]
	private static Delegate2774<Font> delegate2774_2;

	[CompilerGenerated]
	private static Delegate2774<Font> delegate2774_3;

	[CompilerGenerated]
	private static Delegate2774<Font> delegate2774_4;

	[CompilerGenerated]
	private static Delegate2774<Font> delegate2774_5;

	public Class4073()
	{
		class3548_0 = new Class3548<Class3696<Font>>();
		class3548_0.method_0("caption", new Class3696<Font>(() => SystemFonts.CaptionFont));
		class3548_0.method_0("icon", new Class3696<Font>(() => SystemFonts.IconTitleFont));
		class3548_0.method_0("menu", new Class3696<Font>(() => SystemFonts.MenuFont));
		class3548_0.method_0("message-box", new Class3696<Font>(() => SystemFonts.MessageBoxFont));
		class3548_0.method_0("small-caption", new Class3696<Font>(() => SystemFonts.SmallCaptionFont));
		class3548_0.method_0("status-bar", new Class3696<Font>(() => SystemFonts.StatusFont));
	}

	public bool method_0(string value)
	{
		return class3548_0.ContainsKey(value);
	}

	public Font method_1(string value)
	{
		return class3548_0.method_1(value).Value;
	}

	[CompilerGenerated]
	private static Font smethod_0()
	{
		return SystemFonts.CaptionFont;
	}

	[CompilerGenerated]
	private static Font smethod_1()
	{
		return SystemFonts.IconTitleFont;
	}

	[CompilerGenerated]
	private static Font smethod_2()
	{
		return SystemFonts.MenuFont;
	}

	[CompilerGenerated]
	private static Font smethod_3()
	{
		return SystemFonts.MessageBoxFont;
	}

	[CompilerGenerated]
	private static Font smethod_4()
	{
		return SystemFonts.SmallCaptionFont;
	}

	[CompilerGenerated]
	private static Font smethod_5()
	{
		return SystemFonts.StatusFont;
	}
}
