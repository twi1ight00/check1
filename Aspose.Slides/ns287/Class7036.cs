using System;
using ns284;
using ns305;
using ns73;

namespace ns287;

internal class Class7036 : Class6983, Interface92
{
	private bool bool_1;

	private Interface76 interface76_0;

	public bool Disabled
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public string Media
	{
		get
		{
			return method_45("media", string.Empty);
		}
		set
		{
			method_21("media", value);
		}
	}

	public string Type
	{
		get
		{
			return method_45("type", string.Empty);
		}
		set
		{
			method_21("type", value);
		}
	}

	public Interface76 CSSStyleSheet
	{
		get
		{
			if (interface76_0 == null)
			{
				method_53();
			}
			return interface76_0;
		}
	}

	protected internal Class7036(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
		bool_1 = false;
	}

	public override void vmethod_5(Interface325 visitor)
	{
	}

	private void method_53()
	{
		string textContent = TextContent;
		if (!string.IsNullOrEmpty(textContent) && (string.IsNullOrEmpty(Media) || Media.Equals("all", StringComparison.OrdinalIgnoreCase) || Media.Equals("screen", StringComparison.OrdinalIgnoreCase)))
		{
			interface76_0 = ((Interface89)base.OwnerDocument).Engine.imethod_3(this);
		}
	}

	public override Class6976 vmethod_1(Class6976 newChild)
	{
		Class6976 result = base.vmethod_1(newChild);
		if (newChild is Class6980)
		{
			method_53();
		}
		return result;
	}
}
