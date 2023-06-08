using System.Collections;

namespace ns322;

internal class Class7372 : Class7361
{
	private IList ilist_0;

	private IList ilist_1;

	public IList Arguments => ilist_0;

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_23(this);
	}

	public Class7372()
	{
		ilist_0 = new ArrayList();
		ilist_1 = new ArrayList();
	}

	public Class7372(IList arguments)
		: this()
	{
		(ilist_0 as ArrayList).AddRange(arguments);
	}
}
