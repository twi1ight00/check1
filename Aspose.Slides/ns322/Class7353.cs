namespace ns322;

internal class Class7353 : Class7352
{
	private Interface401 interface401_0;

	private Class7400 class7400_0;

	private Class7400 class7400_1;

	internal override Enum984 DescriptorType => Enum984.const_1;

	public Class7400 GetFunction
	{
		get
		{
			return class7400_0;
		}
		set
		{
			class7400_0 = value;
		}
	}

	public Class7400 SetFunction
	{
		get
		{
			return class7400_1;
		}
		set
		{
			class7400_1 = value;
		}
	}

	public override bool isReference => false;

	public override Class7352 Clone()
	{
		Class7353 @class = new Class7353(interface401_0, base.Owner, base.Name);
		@class.Enumerable = base.Enumerable;
		@class.Configurable = base.Configurable;
		@class.Writable = base.Writable;
		@class.GetFunction = GetFunction;
		@class.SetFunction = SetFunction;
		return @class;
	}

	public override Class7397 vmethod_1(Class7398 that)
	{
		interface401_0.Visitor.imethod_37(GetFunction, that, Class7397.class7397_0);
		return interface401_0.Visitor.Returned;
	}

	public override void vmethod_2(Class7398 that, Class7397 value)
	{
		if (SetFunction == null)
		{
			throw new Exception88(interface401_0.TypeErrorClass.method_5());
		}
		interface401_0.Visitor.imethod_37(SetFunction, that, new Class7397[1] { value });
	}

	public Class7353(Interface401 global, Class7398 owner, string name)
		: base(owner, name)
	{
		interface401_0 = global;
		base.Enumerable = false;
	}
}
