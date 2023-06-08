using System.Collections;

namespace ns322;

internal class Class7373 : Class7361
{
	private Class7361 class7361_0;

	private IList ilist_0;

	private IList ilist_1;

	public Class7361 Expression
	{
		get
		{
			return class7361_0;
		}
		set
		{
			class7361_0 = value;
		}
	}

	public IList Arguments
	{
		get
		{
			return ilist_0;
		}
		set
		{
			ilist_0 = value;
		}
	}

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_29(this);
	}

	public Class7373(Class7361 expression)
	{
		class7361_0 = expression;
		ilist_0 = new ArrayList();
		ilist_1 = new ArrayList();
	}
}
