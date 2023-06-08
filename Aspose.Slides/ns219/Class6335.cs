using ns224;
using ns235;
using ns253;

namespace ns219;

internal class Class6335 : Class6334
{
	private Class6451 class6451_0;

	public Class6451 TextShape
	{
		get
		{
			return class6451_0;
		}
		set
		{
			class6451_0 = value;
		}
	}

	protected override Class6212 vmethod_2()
	{
		Class6213 @class = new Class6213();
		@class.RenderTransform = new Class6002();
		return @class;
	}
}
