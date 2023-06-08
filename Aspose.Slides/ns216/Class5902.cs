using ns217;

namespace ns216;

internal class Class5902 : Class5898
{
	public override void vmethod_0(string value)
	{
		base.Value = value;
	}

	public override string vmethod_1()
	{
		return (string)base.Value;
	}

	protected override Class5898 vmethod_2()
	{
		Class5902 @class = new Class5902();
		@class.Value = ((string)base.Value).Clone();
		return @class;
	}
}
