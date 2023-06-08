using System.Collections;

namespace ns322;

internal class Class7391 : Class7360
{
	private Class7360 class7360_0;

	private IList ilist_0;

	private Class7360 class7360_1;

	public Class7360 Expression
	{
		get
		{
			return class7360_0;
		}
		set
		{
			class7360_0 = value;
		}
	}

	public IList CaseClauses => ilist_0;

	public Class7360 DefaultStatement
	{
		get
		{
			return class7360_1;
		}
		set
		{
			class7360_1 = value;
		}
	}

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_13(this);
	}

	public Class7391()
	{
		ilist_0 = new ArrayList();
	}
}
