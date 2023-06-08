using System;
using System.Collections.Generic;
using System.Globalization;
using Aspose.Slides.Charts;
using ns56;

namespace ns17;

internal class Class906
{
	public static void smethod_0(IChartCategoryCollection categories, Class2341 catElementData, ChartDataWorkbook chartDataWorkbook)
	{
		if (catElementData != null)
		{
			if (catElementData.vmethod_5() == DataSourceType.Worksheet)
			{
				smethod_1(categories, catElementData, chartDataWorkbook);
			}
			else
			{
				smethod_4(categories, catElementData);
			}
		}
	}

	private static void smethod_1(IChartCategoryCollection categories, Class2341 catElementData, ChartDataWorkbook chartDataWorkbook)
	{
		categories.UseCells = true;
		string formala = catElementData.vmethod_6();
		Class2605 axisDataSource = catElementData.AxisDataSource;
		switch (axisDataSource.Name)
		{
		case "numLit":
		case "strLit":
			throw new Exception();
		case "numRef":
		case "strRef":
			smethod_3(categories, formala, chartDataWorkbook);
			goto IL_00a2;
		case "multiLvlStrRef":
		{
			Class2095 @class = (Class2095)axisDataSource.Object;
			if (@class.MultiLvlStrCache != null)
			{
				smethod_2(categories, formala, chartDataWorkbook, @class.MultiLvlStrCache.LvlList.Length);
			}
			goto IL_00a2;
		}
		default:
			{
				throw new Exception("Unknown element \"" + axisDataSource.Name + "\"");
			}
			IL_00a2:
			if (axisDataSource.Name == "numRef")
			{
				Class2098 class2 = (Class2098)axisDataSource.Object;
				((ChartCategoryCollection)categories).PPTXUnsupportedProps.NumberFormat = class2.NumCache.FormatCode;
			}
			break;
		}
	}

	public static void smethod_2(IChartCategoryCollection categories, string formala, ChartDataWorkbook chartDataWorkbook, int lvlsCount)
	{
		categories.Clear();
		List<object[]> list = chartDataWorkbook.method_6(formala);
		foreach (object[] item in list)
		{
			string name = (string)item[0];
			ChartDataWorksheet chartDataWorksheet = chartDataWorkbook.Worksheets[name];
			int count = ((List<int>)item[1]).Count;
			int num = count / lvlsCount;
			bool flag = ((List<int>)item[2])[((List<int>)item[2]).Count - 1] - ((List<int>)item[2])[0] == lvlsCount - 1;
			for (int i = 0; i < count; i++)
			{
				if ((flag ? (lvlsCount - 1 - i % lvlsCount) : (lvlsCount - 1 - i / num)) == 0)
				{
					int row = ((List<int>)item[1])[i];
					int col = ((List<int>)item[2])[i];
					IChartDataCell chartDataCell = chartDataWorksheet.Cells[row, col];
					if (!chartDataCell.IsHidden)
					{
						categories.Add(chartDataCell);
					}
				}
			}
			for (int j = 0; j < count; j++)
			{
				int num2 = (flag ? (lvlsCount - 1 - j % lvlsCount) : (lvlsCount - 1 - j / num));
				if (num2 != 0)
				{
					int row2 = ((List<int>)item[1])[j];
					int col2 = ((List<int>)item[2])[j];
					IChartDataCell chartDataCell2 = chartDataWorksheet.Cells[row2, col2];
					if (!chartDataCell2.IsHidden)
					{
						int index = (flag ? (j / lvlsCount) : ((j + num) % num));
						categories[index].GroupingLevels.SetGroupingItem(num2, chartDataCell2);
					}
				}
			}
		}
	}

	public static void smethod_3(IChartCategoryCollection categories, string formala, IChartDataWorkbook chartDataWorkbook)
	{
		categories.Clear();
		IChartCellCollection cellCollection = chartDataWorkbook.GetCellCollection(formala, skipHiddenCells: true);
		foreach (IChartDataCell item in cellCollection)
		{
			categories.Add(item);
		}
	}

	private static void smethod_4(IChartCategoryCollection categories, Class2341 catElementData)
	{
		categories.UseCells = false;
		Class2605 axisDataSource = catElementData.AxisDataSource;
		switch (axisDataSource.Name)
		{
		case "strLit":
		{
			Class2119 class3 = (Class2119)axisDataSource.Object;
			Class2121[] ptList2 = class3.PtList;
			foreach (Class2121 class4 in ptList2)
			{
				categories.Add(class4.V);
			}
			break;
		}
		case "numLit":
		{
			Class2096 @class = (Class2096)axisDataSource.Object;
			Class2099[] ptList = @class.PtList;
			foreach (Class2099 class2 in ptList)
			{
				categories.Add(class2.V);
			}
			break;
		}
		case "multiLvlStrRef":
		case "numRef":
		case "strRef":
			throw new Exception();
		default:
			throw new Exception("Unknown element \"" + axisDataSource.Name + "\"");
		}
	}

	public static void smethod_5(IChartCategoryCollection categories, Class2341.Delegate2765 addCat)
	{
		if (addCat != null && categories.Count != 0)
		{
			Class2341 catElementData = addCat();
			if (categories.UseCells)
			{
				smethod_6(categories, catElementData);
			}
			else
			{
				smethod_7(categories, catElementData);
			}
		}
	}

	private static void smethod_6(IChartCategoryCollection categories, Class2341 catElementData)
	{
		string cellsAddress = ((ChartCategoryCollection)categories).GetCellsAddress();
		if (categories.GroupingLevelCount == 1)
		{
			bool flag = true;
			string[] array = new string[categories.Count];
			for (int i = 0; i < categories.Count; i++)
			{
				array[i] = ((categories[i].Value != null) ? Convert.ToString(categories[i].Value, CultureInfo.InvariantCulture) : null);
				flag &= categories[i].Value == null || double.TryParse(array[i], NumberStyles.Any, CultureInfo.InvariantCulture, out var _);
			}
			if (flag)
			{
				Class2098 @class = (Class2098)catElementData.delegate2773_0("numRef").Object;
				@class.F = cellsAddress;
				Class2096 class2 = @class.delegate2006_0();
				class2.FormatCode = ((ChartCategoryCollection)categories).PPTXUnsupportedProps.NumberFormat;
				class2.delegate2136_0().Val = (uint)categories.Count;
				for (int j = 0; j < categories.Count; j++)
				{
					if (array[j] != null)
					{
						Class2099 class3 = class2.delegate2015_0();
						class3.Idx = (uint)j;
						class3.V = array[j];
					}
				}
				return;
			}
			Class2120 class4 = (Class2120)catElementData.delegate2773_0("strRef").Object;
			class4.F = cellsAddress;
			Class2119 class5 = class4.delegate2085_0();
			class5.delegate2136_0().Val = (uint)categories.Count;
			for (int k = 0; k < categories.Count; k++)
			{
				if (array[k] != null)
				{
					Class2121 class6 = class5.delegate2091_0();
					class6.Idx = (uint)k;
					class6.V = array[k];
				}
			}
			return;
		}
		Class2095 class7 = (Class2095)catElementData.delegate2773_0("multiLvlStrRef").Object;
		class7.F = cellsAddress;
		Class2094 class8 = class7.delegate2000_0();
		class8.delegate2136_0().Val = (uint)categories.Count;
		for (int l = 0; l < categories.GroupingLevelCount; l++)
		{
			Class2089 class9 = class8.delegate1985_0();
			for (int m = 0; m < categories.Count; m++)
			{
				IChartDataCell chartDataCell = categories[m].GroupingLevels[l];
				if (chartDataCell != null && chartDataCell.Value != null)
				{
					Class2121 class10 = class9.delegate2091_0();
					class10.Idx = (uint)m;
					class10.V = Convert.ToString(chartDataCell.Value, CultureInfo.InvariantCulture);
				}
			}
		}
	}

	private static void smethod_7(IChartCategoryCollection categories, Class2341 catElementData)
	{
		bool flag = true;
		string[] array = new string[categories.Count];
		for (int i = 0; i < categories.Count; i++)
		{
			array[i] = ((categories[i].Value != null) ? Convert.ToString(categories[i].Value, CultureInfo.InvariantCulture) : null);
			flag &= double.TryParse(array[i], NumberStyles.Any, CultureInfo.InvariantCulture, out var _);
		}
		if (flag)
		{
			Class2096 @class = (Class2096)catElementData.delegate2773_0("numLit").Object;
			@class.FormatCode = "General";
			@class.delegate2136_0().Val = (uint)categories.Count;
			for (int j = 0; j < categories.Count; j++)
			{
				Class2099 class2 = @class.delegate2015_0();
				class2.Idx = (uint)j;
				class2.V = array[j];
			}
			return;
		}
		Class2119 class3 = (Class2119)catElementData.delegate2773_0("strLit").Object;
		class3.delegate2136_0().Val = (uint)categories.Count;
		for (int k = 0; k < categories.Count; k++)
		{
			if (array[k] != null)
			{
				Class2121 class4 = class3.delegate2091_0();
				class4.Idx = (uint)k;
				class4.V = array[k];
			}
		}
	}
}
