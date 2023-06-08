using ns224;

namespace ns258;

internal class Class6399 : Class6397
{
	public override void vmethod_0(Class6003 pen)
	{
		pen.EndCap = method_0();
	}

	public override Class6397 Clone()
	{
		Class6399 @class = new Class6399();
		CopyTo(@class);
		return @class;
	}
}
