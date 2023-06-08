using System;
using ns73;

namespace ns76;

internal class Class3711 : Class3707, Interface59, Interface70
{
	private string string_2;

	private Interface76 interface76_0;

	private Class3736 class3736_0;

	public override string CSSText
	{
		get
		{
			return $"@import url({Href});";
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public string Href
	{
		get
		{
			return string_2;
		}
		internal set
		{
			string_2 = value;
		}
	}

	Interface79 Interface70.Media => class3736_0;

	public Class3736 Media => class3736_0;

	public Interface76 StyleSheet
	{
		get
		{
			return interface76_0;
		}
		internal set
		{
			interface76_0 = value;
		}
	}

	public Class3711(Class3735 styleSheet, Interface59 parentRule)
		: base(styleSheet, parentRule, 3)
	{
		class3736_0 = new Class3736();
	}
}
