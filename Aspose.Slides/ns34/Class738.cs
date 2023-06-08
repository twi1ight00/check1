using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides.Charts;
using ns42;
using ns43;

namespace ns34;

internal sealed class Class738 : ICollection, IEnumerable
{
	private const string string_0 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	internal SortedList sortedList_0;

	internal ChartDataWorksheet chartDataWorksheet_0;

	public ChartDataCell this[int row, int col] => this[smethod_0(row, col)];

	public ChartDataCell this[string cellName]
	{
		get
		{
			int num = cellName.IndexOfAny(new char[10] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
			string key = cellName.Substring(0, num);
			string text = cellName.Substring(num);
			uint num2 = (uint)Math.Floor((double)(Convert.ToInt32(text) / 1000));
			SortedList sortedList = (SortedList)sortedList_0[key];
			if (sortedList != null)
			{
				SortedList sortedList2 = (SortedList)sortedList[num2];
				if (sortedList2 != null)
				{
					ChartDataCell chartDataCell = (ChartDataCell)sortedList2[text];
					if (chartDataCell != null)
					{
						return chartDataCell;
					}
				}
			}
			return new ChartDataCell(chartDataWorksheet_0, cellName);
		}
	}

	public int Count => sortedList_0.Count;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal Class738(ChartDataWorksheet parent)
	{
		sortedList_0 = new SortedList();
		chartDataWorksheet_0 = parent;
	}

	internal void Clear()
	{
		sortedList_0.Clear();
	}

	internal void method_0(Class810 sheetData, List<Class812> colSet)
	{
		Class810[] array = sheetData.method_56("row", Class827.string_12);
		Class810[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Class815 @class = (Class815)array2[i];
			Class810[] array3 = @class.method_56("c", Class827.string_12);
			Class810[] array4 = array3;
			for (int j = 0; j < array4.Length; j++)
			{
				Class811 elemCell = (Class811)array4[j];
				ChartDataCell chartDataCell = new ChartDataCell(chartDataWorksheet_0, elemCell);
				Add(chartDataCell);
				chartDataCell.IsHidden = @class.IsHidden;
				foreach (Class812 item in colSet)
				{
					if (chartDataCell.Column + 1 >= item.Min && chartDataCell.Column + 1 <= item.Max && item.Hidden)
					{
						chartDataCell.IsHidden = true;
					}
				}
			}
		}
	}

	internal static string smethod_0(int row, int col)
	{
		double num = Math.Floor((double)col / (double)"ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length);
		string text = ((!(num > 0.0)) ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[col].ToString() : ("ABCDEFGHIJKLMNOPQRSTUVWXYZ"[(int)num - 1].ToString() + "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[(int)((double)col - num * (double)"ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length)]));
		return text + (row + 1);
	}

	internal void Add(ChartDataCell cell)
	{
		int num = cell.Name.IndexOfAny(new char[10] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
		string key = cell.Name.Substring(0, num);
		string text = cell.Name.Substring(num);
		uint num2 = (uint)Math.Floor((double)(Convert.ToInt32(text) / 1000));
		SortedList sortedList = (SortedList)sortedList_0[key];
		if (sortedList == null)
		{
			SortedList sortedList2 = new SortedList();
			SortedList sortedList3 = new SortedList();
			sortedList3.Add(text, cell);
			sortedList2.Add(num2, sortedList3);
			sortedList_0.Add(key, sortedList2);
			return;
		}
		SortedList sortedList4 = (SortedList)sortedList[num2];
		if (sortedList4 == null)
		{
			SortedList sortedList5 = new SortedList();
			sortedList5.Add(text, cell);
			sortedList.Add(num2, sortedList5);
		}
		else
		{
			sortedList4.Add(text, cell);
		}
	}

	public IEnumerator GetEnumerator()
	{
		return sortedList_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		sortedList_0.CopyTo(array, index);
	}
}
