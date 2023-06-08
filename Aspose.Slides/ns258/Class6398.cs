using ns224;

namespace ns258;

internal class Class6398 : Class6397
{
	public override void vmethod_0(Class6003 pen)
	{
		pen.StartCap = method_0();
	}

	public override Class6397 Clone()
	{
		Class6398 @class = new Class6398();
		CopyTo(@class);
		return @class;
	}
}
