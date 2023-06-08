using ns252;

namespace ns251;

internal abstract class Class6293 : Class6292
{
	private Class6329 class6329_0 = new Class6329(0.0);

	public Class6329 Value
	{
		get
		{
			return class6329_0;
		}
		set
		{
			class6329_0 = value;
		}
	}

	public override Interface275 Clone()
	{
		Class6293 @class = vmethod_0();
		@class.Value = Value;
		return @class;
	}

	protected abstract Class6293 vmethod_0();
}
