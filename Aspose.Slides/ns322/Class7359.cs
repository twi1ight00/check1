namespace ns322;

internal class Class7359 : Class7352
{
	private Class7397 class7397_0;

	internal override Enum984 DescriptorType => Enum984.const_0;

	public override bool isReference => false;

	public override Class7352 Clone()
	{
		Class7359 @class = new Class7359(base.Owner, base.Name, class7397_0);
		@class.Enumerable = base.Enumerable;
		@class.Configurable = base.Configurable;
		@class.Writable = base.Writable;
		return @class;
	}

	public override Class7397 vmethod_1(Class7398 that)
	{
		if (class7397_0 != null)
		{
			return class7397_0;
		}
		return Class7437.class7437_0;
	}

	public override void vmethod_2(Class7398 that, Class7397 value)
	{
		if (!base.Writable)
		{
			throw new Exception89("This property is not writable");
		}
		class7397_0 = value;
	}

	public Class7359(Class7398 owner, string name)
		: base(owner, name)
	{
		base.Enumerable = true;
		base.Writable = true;
		base.Configurable = true;
	}

	public Class7359(Class7398 owner, string name, Class7397 value)
		: this(owner, name)
	{
		vmethod_2(null, value);
	}
}
