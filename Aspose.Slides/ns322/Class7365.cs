using System.Collections;

namespace ns322;

internal class Class7365 : Class7361
{
	private IList ilist_0;

	public IList Statements => ilist_0;

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_20(this);
	}

	public Class7365()
	{
		ilist_0 = new ArrayList();
	}
}
