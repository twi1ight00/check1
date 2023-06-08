namespace ns322;

internal class Class7358 : Class7352
{
	private Class7352 class7352_0;

	private Class7398 class7398_1;

	internal override Enum984 DescriptorType => Enum984.const_0;

	public Class7398 targetObject => class7398_1;

	public override bool isReference => true;

	public override bool isDeleted
	{
		get
		{
			return class7352_0.isDeleted;
		}
		set
		{
		}
	}

	public override Class7352 Clone()
	{
		Class7358 @class = new Class7358(base.Owner, base.Name, this, targetObject);
		@class.bool_2 = base.Writable;
		@class.bool_1 = base.Configurable;
		@class.bool_0 = base.Enumerable;
		return @class;
	}

	public override Class7397 vmethod_1(Class7398 that)
	{
		return class7352_0.vmethod_1(that);
	}

	public override void vmethod_2(Class7398 that, Class7397 value)
	{
		class7352_0.vmethod_2(that, value);
	}

	public Class7358(Class7398 owner, string name, Class7352 source, Class7398 that)
		: base(owner, name)
	{
		if (source.isReference)
		{
			Class7358 @class = source as Class7358;
			class7352_0 = @class.class7352_0;
			class7398_1 = @class.class7398_1;
		}
		else
		{
			class7352_0 = source;
		}
		bool_0 = true;
		bool_2 = true;
		bool_1 = true;
		class7398_1 = that;
	}
}
