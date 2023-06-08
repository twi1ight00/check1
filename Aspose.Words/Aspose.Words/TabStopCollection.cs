using System;
using System.ComponentModel;
using System.Diagnostics;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

[Serializable]
public class TabStopCollection : x11e014059489ae95, x29fbbb70011562a9
{
	private x09ce2c02826e31a6 mItems = new x09ce2c02826e31a6();

	private bool mHasTolerances;

	public int Count => mItems.xd44988f225497f3a;

	internal bool HasTolerances
	{
		get
		{
			if (mHasTolerances)
			{
				return true;
			}
			for (int i = 0; i < Count; i++)
			{
				if (this[i].ToleranceTwips != 0)
				{
					return true;
				}
			}
			return false;
		}
		set
		{
			mHasTolerances = value;
		}
	}

	public TabStop this[int index] => (TabStop)mItems.x6d3720b962bd3112(index);

	public TabStop this[double position] => GetByPositionTwips(x4574ea26106f0edb.x88bf16f2386d633e(position));

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool xc8ea2954a6825f32 => false;

	internal TabStopCollection()
	{
	}

	internal bool Equals(TabStopCollection rhs)
	{
		if (object.ReferenceEquals(null, rhs))
		{
			return false;
		}
		if (object.ReferenceEquals(this, rhs))
		{
			return true;
		}
		if (mHasTolerances != rhs.mHasTolerances)
		{
			return false;
		}
		if (Count != rhs.Count)
		{
			return false;
		}
		for (int i = 0; i < Count; i++)
		{
			if (!this[i].Equals(rhs[i]))
			{
				return false;
			}
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(TabStopCollection))
		{
			return false;
		}
		return Equals((TabStopCollection)obj);
	}

	public override int GetHashCode()
	{
		return (mItems.GetHashCode() * 397) ^ mHasTolerances.GetHashCode();
	}

	internal TabStop GetByPositionTwips(int positionTwips)
	{
		return (TabStop)mItems.get_xe6d4b1b411ed94b5(positionTwips);
	}

	public void Clear()
	{
		mItems.xa9d636b00ff486b7();
	}

	public double GetPositionByIndex(int index)
	{
		return x4574ea26106f0edb.x0e1fdb362561ddb2(GetPositionTwipsByIndex(index));
	}

	internal int GetPositionTwipsByIndex(int index)
	{
		return mItems.xf15263674eb297bb(index);
	}

	public int GetIndexByPosition(double position)
	{
		return GetIndexByPositionTwips(x4574ea26106f0edb.x88bf16f2386d633e(position));
	}

	internal int GetIndexByPositionTwips(int positionTwips)
	{
		return mItems.xf8af57cefd692401(positionTwips);
	}

	public void Add(TabStop tabStop)
	{
		if (tabStop == null)
		{
			throw new ArgumentNullException("tabStop");
		}
		mItems.set_xe6d4b1b411ed94b5(tabStop.PositionTwips, (object)tabStop);
	}

	public void Add(double position, TabAlignment alignment, TabLeader leader)
	{
		Add(new TabStop(position, alignment, leader));
	}

	public void RemoveByPosition(double position)
	{
		RemoveByPositionTwips(x4574ea26106f0edb.x88bf16f2386d633e(position));
	}

	internal void RemoveByPositionTwips(int positionTwips)
	{
		mItems.x52b190e626f65140(positionTwips);
	}

	public void RemoveByIndex(int index)
	{
		mItems.x7121e9e177952651(index);
	}

	public TabStop After(double position)
	{
		int num = x4574ea26106f0edb.x88bf16f2386d633e(position);
		for (int i = 0; i < Count; i++)
		{
			if (GetPositionTwipsByIndex(i) > num)
			{
				TabStop tabStop = this[i];
				if (tabStop.Alignment != TabAlignment.Bar)
				{
					return tabStop;
				}
			}
		}
		return null;
	}

	public TabStop Before(double position)
	{
		int num = x4574ea26106f0edb.x88bf16f2386d633e(position);
		for (int num2 = Count - 1; num2 >= 0; num2--)
		{
			if (GetPositionTwipsByIndex(num2) < num)
			{
				TabStop tabStop = this[num2];
				if (tabStop.Alignment != TabAlignment.Bar)
				{
					return tabStop;
				}
			}
		}
		return null;
	}

	internal void RemoveClearTabStops()
	{
		for (int num = Count - 1; num >= 0; num--)
		{
			if (this[num].IsClear)
			{
				RemoveByIndex(num);
			}
		}
	}

	internal float[] GetBarTabPositions()
	{
		int num = 0;
		for (int i = 0; i < Count; i++)
		{
			if (this[i].Alignment == TabAlignment.Bar)
			{
				num++;
			}
		}
		float[] array = new float[num];
		int num2 = 0;
		for (int j = 0; j < Count; j++)
		{
			if (this[j].Alignment == TabAlignment.Bar)
			{
				array[num2] = (float)this[j].Position;
				num2++;
			}
		}
		return array;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	x11e014059489ae95 x11e014059489ae95.DeepCloneComplexAttr()
	{
		TabStopCollection tabStopCollection = (TabStopCollection)MemberwiseClone();
		tabStopCollection.mItems = new x09ce2c02826e31a6();
		for (int i = 0; i < Count; i++)
		{
			tabStopCollection.mItems.xd6b6ed77479ef68c(GetPositionTwipsByIndex(i), this[i].Clone());
		}
		return tabStopCollection;
	}

	x29fbbb70011562a9 x29fbbb70011562a9.Expand(x29fbbb70011562a9 parentAttr)
	{
		TabStopCollection tabStopCollection = ((parentAttr == null) ? new TabStopCollection() : ((TabStopCollection)parentAttr.xcc4933610939ad04()));
		for (int i = 0; i < Count; i++)
		{
			TabStop tabStop = this[i];
			tabStopCollection.Add(tabStop.Clone());
		}
		return tabStopCollection;
	}

	void x29fbbb70011562a9.Collapse(x29fbbb70011562a9 parentAttr)
	{
		TabStopCollection tabStopCollection = (TabStopCollection)parentAttr;
		for (int i = 0; i < tabStopCollection.Count; i++)
		{
			TabStop tabStop = tabStopCollection[i];
			int indexByPosition = GetIndexByPosition(tabStop.Position);
			if (indexByPosition >= 0)
			{
				TabStop tabStop2 = this[indexByPosition];
				if (tabStop2.Equals(tabStop))
				{
					RemoveByIndex(indexByPosition);
				}
			}
			else
			{
				Add(tabStop.Position, TabAlignment.Clear, TabLeader.None);
			}
		}
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
