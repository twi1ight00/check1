using ns217;

namespace ns216;

internal class Class5903 : Class5898
{
	public override void vmethod_0(string value)
	{
		base.Value = value[0];
	}

	public override string vmethod_1()
	{
		return (string)base.Value;
	}

	protected override Class5898 vmethod_2()
	{
		Class5903 @class = new Class5903();
		@class.Value = (char)base.Value;
		return @class;
	}
}
