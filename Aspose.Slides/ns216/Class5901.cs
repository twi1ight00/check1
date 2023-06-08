using System.Globalization;
using ns217;

namespace ns216;

internal class Class5901 : Class5898
{
	public override void vmethod_0(string value)
	{
		base.Value = int.Parse(value) == 1;
	}

	public override string vmethod_1()
	{
		return (((bool)base.Value) ? 1 : 0).ToString(CultureInfo.InvariantCulture);
	}

	protected override Class5898 vmethod_2()
	{
		Class5901 @class = new Class5901();
		@class.Value = (bool)base.Value;
		return @class;
	}
}
