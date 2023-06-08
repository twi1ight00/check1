using ns217;
using ns322;
using ns323;

namespace ns215;

internal abstract class Class7457 : Class7456
{
	protected override void vmethod_2(Class7397 instance)
	{
		Class5781 @class = (Class5781)instance.Value;
		if (@class == null)
		{
			return;
		}
		foreach (Class5781 item in @class.Nodes.List)
		{
			if (!string.IsNullOrEmpty(item.Name) && !@class.Attributes.ContainsKey(item.Name))
			{
				method_12(instance, item.Name, method_2(item, item.GetType()));
			}
		}
	}
}
