using System.Drawing.Drawing2D;

namespace ns224;

internal abstract class Class5991 : Class5990
{
	private Class6002 class6002_0;

	private WrapMode wrapMode_0;

	public Class6002 Transform
	{
		get
		{
			if (class6002_0 == null)
			{
				class6002_0 = new Class6002();
			}
			return class6002_0;
		}
		set
		{
			class6002_0 = value;
		}
	}

	public WrapMode WrapMode
	{
		get
		{
			return wrapMode_0;
		}
		set
		{
			wrapMode_0 = value;
		}
	}

	protected Class5991(Enum746 type)
		: base(type)
	{
	}

	protected Class5991(WrapMode wrapMode, Enum746 brushType)
		: this(brushType)
	{
		WrapMode = wrapMode;
	}
}
