using System;
using System.Globalization;
using ns215;
using ns217;

namespace ns216;

internal class Class5899 : Class5898
{
	public override void vmethod_0(string value)
	{
		try
		{
			base.Value = float.Parse(value, NumberStyles.Any);
		}
		catch (Exception ex)
		{
			if (!(ex is FormatException))
			{
				throw;
			}
			base.Value = Class5932.smethod_0(value);
		}
	}

	public override string vmethod_1()
	{
		return ((float)base.Value).ToString(CultureInfo.InvariantCulture) + "pt";
	}

	protected override Class5898 vmethod_2()
	{
		Class5899 @class = new Class5899();
		@class.Value = (float)base.Value;
		return @class;
	}
}
