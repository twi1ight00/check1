namespace ns196;

internal abstract class Class5329 : Class5328
{
	public Class5329(Class5254 position)
		: base(position)
	{
	}

	public abstract bool vmethod_5();

	protected Interface173 method_3()
	{
		Class5254 @class = method_0();
		while (@class is Class5255 && @class.vmethod_0() != null)
		{
			@class = @class.vmethod_0();
		}
		return @class.method_0();
	}
}
