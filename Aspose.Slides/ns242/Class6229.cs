using ns243;

namespace ns242;

internal class Class6229 : Class6227
{
	protected int int_1;

	public Class6229(float width, Struct220 margin, int columnCount, Class6239 documentCreator)
		: base(width, margin, documentCreator)
	{
		int_1 = columnCount;
	}

	public virtual Class6232 vmethod_17()
	{
		Class6232 @class = class6239_0.NodesFactory.vmethod_3(int_1, this);
		vmethod_5(@class);
		return @class;
	}

	public override Class6227 vmethod_14()
	{
		Class6229 @class = new Class6229(float_0, Margin, int_1, class6239_0);
		@class.Location = Location;
		return @class;
	}
}
