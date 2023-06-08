using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using ns2;

namespace Aspose.Slides.Charts;

public class ChartCellCollection : IEnumerable, IEnumerable<IChartDataCell>, IChartCellCollection
{
	internal Chart chart_0;

	internal List<ChartDataCell> list_0 = new List<ChartDataCell>();

	[Obsolete("Use GetConcatenatedValuesFromCells() method instead. Will be removed after 01.09.2013.")]
	public string GetConcateNameFromCells => GetConcatenatedValuesFromCells();

	public IChartDataCell this[int index] => list_0[index];

	IEnumerable IChartCellCollection.AsIEnumerable => this;

	public int Count => list_0.Count;

	internal ChartCellCollection(IChart parent)
	{
		chart_0 = (Chart)parent;
	}

	internal static string smethod_0(string name)
	{
		string text = name.ToUpper();
		for (int i = 0; i < text.Length; i++)
		{
			char c = name[i];
			if (char.IsDigit(c))
			{
				text = text.Insert(i, "$");
				break;
			}
		}
		return text.Insert(0, "$");
	}

	public string GetCellsAddress()
	{
		if (list_0.Count == 0)
		{
			return "";
		}
		if (list_0.Count == 1)
		{
			ChartDataCell chartDataCell = list_0[0];
			return chartDataCell.ChartDataWorksheet.Name + "!" + smethod_0(chartDataCell.Name);
		}
		ChartDataCell chartDataCell2 = list_0[0];
		ChartDataCell chartDataCell3 = list_0[0];
		ChartDataCell chartDataCell4 = list_0[0];
		ChartDataCell chartDataCell5 = list_0[0];
		for (int i = 0; i < list_0.Count; i++)
		{
			ChartDataCell chartDataCell6 = list_0[i];
			if (chartDataCell6.Column < chartDataCell2.Column)
			{
				chartDataCell2 = chartDataCell6;
			}
			if (chartDataCell6.Column > chartDataCell3.Column)
			{
				chartDataCell3 = chartDataCell6;
			}
			if (chartDataCell6.Row < chartDataCell4.Row)
			{
				chartDataCell4 = chartDataCell6;
			}
			if (chartDataCell6.Row > chartDataCell5.Row)
			{
				chartDataCell5 = chartDataCell6;
			}
		}
		if (chartDataCell2.Column == chartDataCell3.Column && chartDataCell5.Row - chartDataCell4.Row + 1 == list_0.Count)
		{
			return chartDataCell4.ChartDataWorksheet.Name + "!" + smethod_0(chartDataCell4.Name) + ":" + smethod_0(chartDataCell5.Name);
		}
		if (chartDataCell4.Row == chartDataCell3.Row && chartDataCell3.Column - chartDataCell2.Column + 1 == list_0.Count)
		{
			return chartDataCell2.ChartDataWorksheet.Name + "!" + smethod_0(chartDataCell2.Name) + ":" + smethod_0(chartDataCell3.Name);
		}
		string text = "";
		if (method_0())
		{
			if (list_0.Count != 0)
			{
				if (list_0.Count == 1)
				{
					ChartDataCell chartDataCell7 = list_0[0];
					text = chartDataCell7.ChartDataWorksheet.Name + "!" + smethod_0(chartDataCell7.Name);
				}
				else
				{
					ChartDataCell chartDataCell8 = list_0[0];
					ChartDataCell chartDataCell9 = list_0[list_0.Count - 1];
					text = chartDataCell8.ChartDataWorksheet.Name + "!" + smethod_0(chartDataCell8.Name) + ":" + smethod_0(chartDataCell9.Name);
				}
			}
		}
		else
		{
			for (int j = 0; j < list_0.Count; j++)
			{
				ChartDataCell chartDataCell10 = list_0[j];
				text = text + chartDataCell10.ChartDataWorksheet.Name + "!" + smethod_0(chartDataCell10.Name);
				if (list_0.Count > 1 && j < list_0.Count - 1)
				{
					text += CultureInfo.CurrentCulture.TextInfo.ListSeparator;
				}
			}
		}
		return text;
	}

	private bool method_0()
	{
		int num = -1;
		int num2 = -1;
		string text = null;
		int num3 = 0;
		while (true)
		{
			if (num3 < list_0.Count)
			{
				ChartDataCell chartDataCell = list_0[num3];
				if ((num != -1 || text != null) && (num2 != -1 || text != null) && (chartDataCell.Column - num != 1 || !(text == chartDataCell.ChartDataWorksheet.Name)) && (chartDataCell.Row - num2 != 1 || !(text == chartDataCell.ChartDataWorksheet.Name)))
				{
					break;
				}
				num = chartDataCell.Column;
				num2 = chartDataCell.Row;
				text = chartDataCell.ChartDataWorksheet.Name;
				num3++;
				continue;
			}
			return true;
		}
		return false;
	}

	internal string method_1()
	{
		if (list_0.Count == 0)
		{
			return "";
		}
		if (list_0.Count == 1)
		{
			ChartDataCell chartDataCell = list_0[0];
			return chartDataCell.ChartDataWorksheet.Name + "!" + smethod_0(chartDataCell.Name);
		}
		string name = list_0[0].ChartDataWorksheet.Name;
		int num = 1;
		ChartDataCell chartDataCell2;
		ChartDataCell chartDataCell3;
		ChartDataCell chartDataCell4;
		ChartDataCell chartDataCell5;
		while (true)
		{
			if (num < list_0.Count)
			{
				if (!(name != list_0[num].ChartDataWorksheet.Name))
				{
					num++;
					continue;
				}
				throw new ArgumentException("Cells must be on the same worksheet");
			}
			chartDataCell2 = list_0[0];
			chartDataCell3 = list_0[0];
			chartDataCell4 = list_0[0];
			chartDataCell5 = list_0[0];
			for (int i = 0; i < list_0.Count; i++)
			{
				ChartDataCell chartDataCell6 = list_0[i];
				if (chartDataCell6.Column < chartDataCell2.Column)
				{
					chartDataCell2 = chartDataCell6;
				}
				if (chartDataCell6.Column > chartDataCell3.Column)
				{
					chartDataCell3 = chartDataCell6;
				}
				if (chartDataCell6.Row < chartDataCell4.Row)
				{
					chartDataCell4 = chartDataCell6;
				}
				if (chartDataCell6.Row > chartDataCell5.Row)
				{
					chartDataCell5 = chartDataCell6;
				}
			}
			break;
		}
		string text = name + "!";
		char[] anyOf = new char[10] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
		int length = chartDataCell2.Name.IndexOfAny(anyOf);
		string text2 = chartDataCell2.Name.Substring(0, length);
		text = text + "$" + text2;
		length = chartDataCell4.Name.IndexOfAny(anyOf);
		string text3 = chartDataCell4.Name.Substring(length);
		text = text + "$" + text3;
		length = chartDataCell3.Name.IndexOfAny(anyOf);
		text2 = chartDataCell3.Name.Substring(0, length);
		text = text + ":$" + text2;
		length = chartDataCell5.Name.IndexOfAny(anyOf);
		text3 = chartDataCell5.Name.Substring(length);
		return text + "$" + text3;
	}

	public string GetConcatenatedValuesFromCells()
	{
		string text = "";
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ChartDataCell chartDataCell = (ChartDataCell)enumerator.Current;
				text = text + chartDataCell.StringValue + ' ';
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		if (text != "")
		{
			text = text.Remove(text.Length - 1);
		}
		return text;
	}

	public void Add(object value)
	{
		ChartDataCell chartDataCell = ((ChartDataWorkbook)chart_0.ChartData.ChartDataWorkbook).method_3();
		chartDataCell.Value = value;
		Add(chartDataCell);
	}

	public void Add(IChartDataCell cell)
	{
		if (cell == null)
		{
			throw new ArgumentNullException();
		}
		for (int i = 0; i < list_0.Count; i++)
		{
			if (list_0[i].Name == ((ChartDataCell)cell).Name)
			{
				list_0[i] = (ChartDataCell)cell;
			}
		}
		list_0.Add((ChartDataCell)cell);
	}

	internal void method_2(ChartDataCell cell)
	{
		list_0.Add(cell);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	IEnumerator<IChartDataCell> IEnumerable<IChartDataCell>.GetEnumerator()
	{
		return new Class12(list_0);
	}

	public IEnumerator GetEnumerator()
	{
		return new Class12(list_0);
	}
}
