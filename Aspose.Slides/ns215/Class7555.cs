using System;
using ns216;
using ns217;
using ns322;

namespace ns215;

internal class Class7555 : Class7457
{
	internal static readonly Type type_0 = typeof(Class5784);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => Class7552.type_0;

	public override void Initialize()
	{
	}

	protected override void vmethod_2(Class7397 instance)
	{
		Class5784 @class = (Class5784)instance.Value;
		if (@class != null)
		{
			if (@class.LayoutModel != null)
			{
				method_12(instance, "layout", method_2(@class.LayoutModel, @class.LayoutModel.GetType()));
			}
			base.vmethod_2(instance);
		}
	}
}
