using System.Collections;

namespace ns322;

internal class Class7362 : Class7361
{
	private IList ilist_0;

	public IList Parameters => ilist_0;

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_19(this);
	}

	public Class7362()
	{
		ilist_0 = new ArrayList();
	}
}
