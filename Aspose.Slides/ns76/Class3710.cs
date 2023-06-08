using System;
using System.Diagnostics;
using ns73;
using ns75;
using ns84;

namespace ns76;

[DebuggerDisplay("{CSSText}")]
internal class Class3710 : Class3707, Interface59, Interface60, Interface61
{
	private Class3716 class3716_0;

	public override string CSSText
	{
		get
		{
			return $"@font-face {{ {class3716_0.CSSText} }}";
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public Interface58 Style => class3716_0;

	public string Family => class3716_0[base.ParentStyleSheet.Engine.method_1(Enum600.const_113)];

	public string Src => class3716_0[base.ParentStyleSheet.Engine.method_1(Enum600.const_297)];

	public string FontStyle => class3716_0[base.ParentStyleSheet.Engine.method_1(Enum600.const_118)];

	public string Weight => class3716_0[base.ParentStyleSheet.Engine.method_1(Enum600.const_126)];

	public string Stretch => class3716_0[base.ParentStyleSheet.Engine.method_1(Enum600.const_117)];

	public string Variant => class3716_0[base.ParentStyleSheet.Engine.method_1(Enum600.const_119)];

	public Class3710(Class3735 styleSheet, Interface59 parentRule)
		: base(styleSheet, parentRule, 5)
	{
		class3716_0 = new Class3720(this);
	}
}
