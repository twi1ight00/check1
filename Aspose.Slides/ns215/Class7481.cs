using System;
using ns216;
using ns217;
using ns323;

namespace ns215;

internal class Class7481 : Class7458
{
	internal static readonly Type type_0 = typeof(Class5803);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => Class7552.type_0;

	public override void Initialize()
	{
		method_11("inverted", Enum983.flag_0 | Enum983.flag_1);
		method_11("join", Enum983.flag_0 | Enum983.flag_1);
		method_11("presence", Enum983.flag_0 | Enum983.flag_1);
		method_11("radius", Enum983.flag_0 | Enum983.flag_1);
		method_11("stroke", Enum983.flag_0 | Enum983.flag_1);
		method_11("thickness", Enum983.flag_0 | Enum983.flag_1);
		method_11("use", Enum983.flag_0 | Enum983.flag_1);
		method_11("usehref", Enum983.flag_0 | Enum983.flag_1);
	}
}
