using ns217;
using ns322;

namespace ns215;

internal abstract class Class7458 : Class7457
{
	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class5781 @class = (Class5781)instance.Value;
		if (function.StartsWith("get_"))
		{
			Class5898 class2 = @class.Attributes[function.Substring(4)];
			if (class2 != null)
			{
				return method_3(class2.vmethod_1());
			}
		}
		else if (function.StartsWith("set_"))
		{
			@class.Attributes[function.Substring(4)]?.vmethod_0(parameters[0].ToString());
		}
		return base.Undefined;
	}
}
