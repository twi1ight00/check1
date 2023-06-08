using System;
using System.Collections.Generic;

namespace ns67;

internal sealed class Class3328 : Class3326
{
	private string string_0 = string.Empty;

	private Enum465 enum465_0;

	private readonly List<Class3344> list_0 = new List<Class3344>();

	public string Name
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

	public Enum465 Type
	{
		get
		{
			return enum465_0;
		}
		set
		{
			enum465_0 = value;
		}
	}

	public Class3344[] Effects => list_0.ToArray();

	public void Add(Class3344 effect)
	{
		if (effect == null)
		{
			throw new ArgumentNullException("effect");
		}
		list_0.Add(effect.vmethod_0());
	}

	public Class3328()
	{
	}

	public override Class3326 vmethod_0()
	{
		return new Class3328(this);
	}

	private Class3328(Class3328 src)
	{
		string_0 = src.string_0;
		enum465_0 = src.enum465_0;
		foreach (Class3344 item in src.list_0)
		{
			list_0.Add(item.vmethod_0());
		}
	}
}
