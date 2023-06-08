using System;
using ns305;
using ns322;
using ns323;

namespace ns281;

internal class Class7670 : Class7456, Interface403
{
	private static readonly Type type_0 = typeof(Class7670);

	protected internal override Type Type => type_0;

	public Class7397 imethod_0(Class7397 that, Class7397 index)
	{
		int index2;
		try
		{
			index2 = index.vmethod_4();
		}
		catch
		{
			return that.vmethod_0(index);
		}
		Class7075 @class = (Class7075)that.Value;
		Class6976 class2 = @class[index2];
		if (class2 == null)
		{
			return base.Undefined;
		}
		return method_2(class2, class2.GetType());
	}

	public void imethod_1(Class7397 that, Class7397 index, Class7397 value)
	{
	}

	public override void Initialize()
	{
	}
}
