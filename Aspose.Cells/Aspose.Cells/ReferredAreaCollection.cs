using System.Collections;

namespace Aspose.Cells;

/// <summary>
///       Represents all referred cells and areas.
///       </summary>
public class ReferredAreaCollection : CollectionBase
{
	private bool bool_0 = true;

	/// <summary>
	/// </summary>
	/// <param name="index">
	/// </param>
	/// <returns>
	/// </returns>
	public ReferredArea this[int index] => (ReferredArea)base.InnerList[index];

	internal ReferredAreaCollection(bool bool_1)
	{
		bool_0 = bool_1;
	}

	internal ReferredAreaCollection()
	{
		bool_0 = true;
	}

	internal void method_0(ReferredArea referredArea_0)
	{
		base.InnerList.Add(referredArea_0);
	}

	internal void Add(ReferredArea referredArea_0)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				if (this[num] == null || !this[num].method_0(referredArea_0))
				{
					num++;
					continue;
				}
				break;
			}
			base.InnerList.Add(referredArea_0);
			break;
		}
	}
}
