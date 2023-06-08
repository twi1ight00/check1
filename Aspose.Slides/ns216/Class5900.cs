using System.Globalization;
using ns217;

namespace ns216;

internal class Class5900 : Class5898
{
	public override void vmethod_0(string value)
	{
		base.Value = int.Parse(value);
	}

	public override string vmethod_1()
	{
		return ((int)base.Value).ToString(CultureInfo.InvariantCulture);
	}

	protected override Class5898 vmethod_2()
	{
		Class5900 @class = new Class5900();
		@class.Value = (int)base.Value;
		return @class;
	}
}
