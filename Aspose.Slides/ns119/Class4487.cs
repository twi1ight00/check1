using System.IO;

namespace ns119;

internal abstract class Class4487
{
	private long long_0;

	public long Offset
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	public Class4487()
	{
	}

	public abstract Stream vmethod_0();

	public virtual bool vmethod_1()
	{
		return true;
	}

	public abstract object Clone();
}
