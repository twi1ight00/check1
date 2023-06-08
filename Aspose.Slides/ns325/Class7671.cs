using System;
using ns322;
using ns323;

namespace ns325;

internal class Class7671<T> : Class7456
{
	protected internal override Type Type => typeof(T);

	public override void Initialize()
	{
		method_11("CustomProperty", Enum983.flag_0 | Enum983.flag_1);
		method_10("CustomMethod");
	}

	protected override void vmethod_2(Class7397 instance)
	{
		method_12(instance, "CustomField", base.Null);
		base.vmethod_2(instance);
	}

	public Class7397 method_15(Class7397[] arr)
	{
		return method_8(arr);
	}

	public Class7397 method_16(string value)
	{
		return method_4(value);
	}

	public Class7397 method_17(bool value)
	{
		return method_6(value);
	}

	public Class7397 method_18(object value)
	{
		return method_7(value);
	}
}
