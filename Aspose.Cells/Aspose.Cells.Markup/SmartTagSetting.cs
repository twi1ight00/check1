using System.Collections;
using System.Runtime.CompilerServices;

namespace Aspose.Cells.Markup;

/// <summary>
///       Represents all <see cref="T:Aspose.Cells.Markup.SmartTagCollection" /> object in the worksheet.
///       </summary>
public class SmartTagSetting : CollectionBase
{
	private Worksheet worksheet_0;

	/// <summary>
	///       Gets a <see cref="T:Aspose.Cells.Markup.SmartTagCollection" /> object by the index.
	///       </summary>
	/// <param name="index">The index of the <see cref="T:Aspose.Cells.Markup.SmartTagCollection" /> object in the list.</param>
	/// <returns>
	/// </returns>
	public SmartTagCollection this[int index] => (SmartTagCollection)base.InnerList[index];

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Markup.SmartTagCollection" /> object of the cell.
	///       </summary>
	/// <param name="row">The row index of the cell.</param>
	/// <param name="column">The column index of the cell</param>
	/// <returns>Returns the <see cref="T:Aspose.Cells.Markup.SmartTagCollection" /> object of the cell.
	///       Returns null if there is no any smart tags on the cell.
	///       </returns>
	public SmartTagCollection this[int row, int column]
	{
		get
		{
			int num = 0;
			SmartTagCollection smartTagCollection;
			while (true)
			{
				if (num < base.Count)
				{
					smartTagCollection = (SmartTagCollection)base.InnerList[num];
					if (smartTagCollection.Row == row && smartTagCollection.Column == column)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return smartTagCollection;
		}
	}

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Markup.SmartTagCollection" /> object of the cell.
	///       </summary>
	/// <param name="cellName">The name of the cell.</param>
	/// <returns>Returns the <see cref="T:Aspose.Cells.Markup.SmartTagCollection" /> object of the cell.
	///       Returns null if there is no any smart tags on the cell.
	///       </returns>
	public SmartTagCollection this[string cellName]
	{
		get
		{
			CellsHelper.CellNameToIndex(cellName, out var row, out var column);
			return this[row, column];
		}
	}

	[SpecialName]
	internal Worksheet method_0()
	{
		return worksheet_0;
	}

	internal SmartTagSetting(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	/// <summary>
	///       Adds a <see cref="T:Aspose.Cells.Markup.SmartTagCollection" /> object to a cell.
	///       </summary>
	/// <param name="row">The row of the cell.</param>
	/// <param name="column">The column of the cell.</param>
	/// <returns>Returns index of a <see cref="T:Aspose.Cells.Markup.SmartTagCollection" /> object in the worksheet.</returns>
	public int Add(int row, int column)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				SmartTagCollection smartTagCollection = (SmartTagCollection)base.InnerList[num];
				if (smartTagCollection.Row == row && smartTagCollection.Column == column)
				{
					break;
				}
				num++;
				continue;
			}
			SmartTagCollection value = new SmartTagCollection(this, row, column);
			base.InnerList.Add(value);
			return base.Count - 1;
		}
		return num;
	}

	/// <summary>
	///       Add a cell smart tags.
	///       </summary>
	/// <param name="cellName">The name of the cell.</param>
	/// <returns>
	/// </returns>
	public int Add(string cellName)
	{
		CellsHelper.CellNameToIndex(cellName, out var row, out var column);
		return Add(row, column);
	}

	internal void Copy(SmartTagSetting smartTagSetting_0)
	{
		base.InnerList.Clear();
		for (int i = 0; i < smartTagSetting_0.InnerList.Count; i++)
		{
			SmartTagCollection smartTagCollection = (SmartTagCollection)smartTagSetting_0.InnerList[i];
			SmartTagCollection value = new SmartTagCollection(this, smartTagCollection.Row, smartTagCollection.Column);
			base.InnerList.Add(value);
		}
	}
}
