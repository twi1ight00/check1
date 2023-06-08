using System.Collections;

namespace Aspose.Cells.Charts;

/// <summary>
///       Represents a collection of all the <see cref="T:Aspose.Cells.Charts.LegendEntry" /> objects in the specified chart legend.
///       </summary>
public class LegendEntryCollection : CollectionBase
{
	private Chart chart_0;

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Charts.LegendEntry" /> element at the specified index.
	///       </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public LegendEntry this[int index]
	{
		get
		{
			LegendEntry legendEntry = method_0(index);
			if (legendEntry == null)
			{
				legendEntry = new LegendEntry(chart_0.Legend, index);
				base.InnerList.Add(legendEntry);
			}
			return legendEntry;
		}
	}

	internal LegendEntryCollection(Chart chart_1)
	{
		chart_0 = chart_1;
	}

	internal LegendEntry method_0(int int_0)
	{
		foreach (LegendEntry item in base.List)
		{
			if (item.Index == int_0)
			{
				return item;
			}
		}
		return null;
	}

	internal LegendEntry method_1(int int_0)
	{
		return (LegendEntry)base.InnerList[int_0];
	}

	internal void Copy(LegendEntryCollection legendEntryCollection_0)
	{
		base.InnerList.Clear();
		for (int i = 0; i < legendEntryCollection_0.Count; i++)
		{
			LegendEntry legendEntry = new LegendEntry(chart_0.Legend, legendEntryCollection_0[i].Index);
			legendEntry.Copy(legendEntryCollection_0[i]);
			base.InnerList.Add(legendEntry);
		}
	}
}
