using System;
using System.Diagnostics;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

[Serializable]
public class TabStop
{
	private int mPositionTwips;

	private TabAlignment mAlignment;

	private TabLeader mLeader;

	private int mToleranceTwips;

	private bool mUndocumented40;

	public double Position => x4574ea26106f0edb.x0e1fdb362561ddb2(mPositionTwips);

	public TabAlignment Alignment
	{
		get
		{
			return mAlignment;
		}
		set
		{
			mAlignment = value;
		}
	}

	public TabLeader Leader
	{
		get
		{
			return mLeader;
		}
		set
		{
			mLeader = value;
		}
	}

	public bool IsClear => mAlignment == TabAlignment.Clear;

	internal int PositionTwips
	{
		get
		{
			return mPositionTwips;
		}
		set
		{
			mPositionTwips = value;
		}
	}

	internal int ToleranceTwips
	{
		get
		{
			return mToleranceTwips;
		}
		set
		{
			mToleranceTwips = value;
		}
	}

	internal bool Undocumented40
	{
		get
		{
			return mUndocumented40;
		}
		set
		{
			mUndocumented40 = value;
		}
	}

	internal TabStop()
	{
	}

	public TabStop(double position)
		: this(position, TabAlignment.Left, TabLeader.None)
	{
	}

	public TabStop(double position, TabAlignment alignment, TabLeader leader)
		: this(x4574ea26106f0edb.x88bf16f2386d633e(position), alignment, leader)
	{
	}

	internal TabStop(int positionTwips, TabAlignment alignment, TabLeader leader)
	{
		mPositionTwips = positionTwips;
		mAlignment = alignment;
		mLeader = leader;
	}

	internal TabStop Clone()
	{
		return (TabStop)MemberwiseClone();
	}

	internal bool Equals(TabStop rhs)
	{
		if (mPositionTwips == rhs.mPositionTwips && mAlignment == rhs.mAlignment && mLeader == rhs.mLeader && mToleranceTwips == rhs.mToleranceTwips)
		{
			return mUndocumented40 == rhs.mUndocumented40;
		}
		return false;
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void edPreSet(params object[] unused)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void edPostSet(params object[] unused)
	{
	}
}
