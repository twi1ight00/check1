using System.Drawing.Drawing2D;

namespace x5794c252ba25e723;

internal abstract class x7fafd7c73d78a86d : x845d6a068e0b03c5
{
	private x54366fa5f75a02f7 x435b26849f0d2436;

	private WrapMode x95f514a4b958699a;

	public x54366fa5f75a02f7 xaccac17571a8d9fa
	{
		get
		{
			if (x435b26849f0d2436 == null)
			{
				x435b26849f0d2436 = new x54366fa5f75a02f7();
			}
			return x435b26849f0d2436;
		}
		set
		{
			x435b26849f0d2436 = value;
		}
	}

	public WrapMode x349ff0df1e641b4e
	{
		get
		{
			return x95f514a4b958699a;
		}
		set
		{
			x95f514a4b958699a = value;
		}
	}

	protected x7fafd7c73d78a86d(x0b257a9fb413b6c3 type)
		: base(type)
	{
	}

	protected x7fafd7c73d78a86d(WrapMode wrapMode, x0b257a9fb413b6c3 brushType)
		: this(brushType)
	{
		x349ff0df1e641b4e = wrapMode;
	}
}
