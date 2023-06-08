using System;

namespace ns304;

internal class Class7059 : Interface363
{
	private bool bool_0;

	private bool bool_1;

	private Interface362 interface362_0;

	private Enum963 enum963_0;

	private Interface362 interface362_1;

	private ulong ulong_0;

	private string string_0;

	private Class7060 class7060_0;

	public bool Bubbles => bool_0;

	public bool Cancelable => bool_1;

	public Interface362 CurrentTarget
	{
		get
		{
			return interface362_0;
		}
		internal set
		{
			interface362_0 = value;
		}
	}

	public Enum963 Phase
	{
		get
		{
			return enum963_0;
		}
		internal set
		{
			enum963_0 = value;
		}
	}

	public Interface362 Target
	{
		get
		{
			return interface362_1;
		}
		internal set
		{
			interface362_1 = value;
		}
	}

	public ulong TimeStamp => ulong_0;

	public string Type => string_0;

	internal Class7060 Executor
	{
		get
		{
			return class7060_0;
		}
		set
		{
			class7060_0 = value;
		}
	}

	public void imethod_0(string eventTypeArg, bool canBubbleArg, bool cancelableArg)
	{
		string_0 = eventTypeArg;
		bool_0 = canBubbleArg;
		bool_1 = cancelableArg;
		ulong_0 = Convert.ToUInt64(DateTime.Now.Ticks);
	}

	public void imethod_1()
	{
		class7060_0.method_1();
	}

	public void imethod_2()
	{
		class7060_0.method_0();
	}
}
