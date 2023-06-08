using System;
using ns216;
using ns217;
using ns323;

namespace ns215;

internal class Class7496 : Class7458
{
	internal static readonly Type type_0 = typeof(Class5820);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => Class7552.type_0;

	public override void Initialize()
	{
		method_11("baselineShift", Enum983.flag_0 | Enum983.flag_1);
		method_11("lineThrough", Enum983.flag_0 | Enum983.flag_1);
		method_11("lineThroughPeriod", Enum983.flag_0 | Enum983.flag_1);
		method_11("overline", Enum983.flag_0 | Enum983.flag_1);
		method_11("overlinePeriod", Enum983.flag_0 | Enum983.flag_1);
		method_11("posture", Enum983.flag_0 | Enum983.flag_1);
		method_11("size", Enum983.flag_0 | Enum983.flag_1);
		method_11("typeface", Enum983.flag_0 | Enum983.flag_1);
		method_11("underline", Enum983.flag_0 | Enum983.flag_1);
		method_11("underlinePeriod", Enum983.flag_0 | Enum983.flag_1);
		method_11("use", Enum983.flag_0 | Enum983.flag_1);
		method_11("usehref", Enum983.flag_0 | Enum983.flag_1);
		method_11("weight", Enum983.flag_0 | Enum983.flag_1);
	}
}
