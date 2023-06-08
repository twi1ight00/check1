namespace ns322;

internal class Class7426 : Class7399
{
	public const string string_21 = "callee";

	private int int_1;

	private Interface401 interface401_0;

	protected Class7359 class7359_0;

	protected Class7400 Callee => this["callee"] as Class7400;

	public override int Length
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public override string _Class => "Arguments";

	public override bool vmethod_2()
	{
		return false;
	}

	public override double vmethod_3()
	{
		return Length;
	}

	public Class7426(Interface401 global, Class7400 callee, Class7397[] arguments)
		: base(global.ObjectClass.method_6())
	{
		interface401_0 = global;
		for (int i = 0; i < arguments.Length; i++)
		{
			vmethod_18(new Class7359(this, i.ToString(), arguments[i])
			{
				Enumerable = false
			});
		}
		int_1 = arguments.Length;
		class7359_0 = new Class7359(this, "callee", callee);
		class7359_0.Enumerable = false;
		vmethod_18(class7359_0);
		vmethod_18(new Class7354(global, this, "length")
		{
			Enumerable = false
		});
	}
}
