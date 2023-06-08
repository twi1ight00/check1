using System;
using ns216;
using ns217;
using ns323;

namespace ns215;

internal class Class7469 : Class7458
{
	internal static readonly Type type_0 = typeof(Class5791);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => Class7552.type_0;

	public override void Initialize()
	{
		method_11("after", Enum983.flag_0 | Enum983.flag_1);
		method_11("afterTarget", Enum983.flag_0 | Enum983.flag_1);
		method_11("before", Enum983.flag_0 | Enum983.flag_1);
		method_11("beforeTarget", Enum983.flag_0 | Enum983.flag_1);
		method_11("bookendLeader", Enum983.flag_0 | Enum983.flag_1);
		method_11("bookendTrailer", Enum983.flag_0 | Enum983.flag_1);
		method_11("overflowLeader", Enum983.flag_0 | Enum983.flag_1);
		method_11("overflowTarget", Enum983.flag_0 | Enum983.flag_1);
		method_11("overflowTrailer", Enum983.flag_0 | Enum983.flag_1);
		method_11("startNew", Enum983.flag_0 | Enum983.flag_1);
		method_11("use", Enum983.flag_0 | Enum983.flag_1);
		method_11("usehref", Enum983.flag_0 | Enum983.flag_1);
	}
}
