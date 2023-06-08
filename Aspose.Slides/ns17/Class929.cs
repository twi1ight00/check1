using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns33;
using ns53;
using ns55;
using ns56;

namespace ns17;

internal class Class929
{
	public static void smethod_0(IChart chart, Class2106 plotAreaElementData, Class1341 deserializationContext)
	{
		if (plotAreaElementData == null)
		{
			throw new PptxException("plotAreaElementData must not be null.");
		}
		Class1347[] array = null;
		if (deserializationContext.RelationshipsOfCurrentPartEntry != null)
		{
			array = deserializationContext.RelationshipsOfCurrentPartEntry.method_0(Class1327.class1338_0);
		}
		if (array != null && array.Length > 0)
		{
			Class1342 targetPart = array[0].TargetPart;
			if (targetPart != null)
			{
				List<string> namesToCheckResolve = smethod_11(plotAreaElementData);
				MemoryStream ms = new MemoryStream(targetPart.Data);
				if (!((ChartData)chart.ChartData).method_1(ms, namesToCheckResolve))
				{
					smethod_1(chart.ChartData, plotAreaElementData);
				}
				targetPart.Processed = true;
			}
		}
		else
		{
			smethod_1(chart.ChartData, plotAreaElementData);
		}
	}

	private static void smethod_1(IChartData chartData, Class2106 plotAreaElementData)
	{
		ChartDataWorkbook chartDataWorkbook = (ChartDataWorkbook)chartData.ChartDataWorkbook;
		Class2605[] chartList = plotAreaElementData.ChartList;
		foreach (Class2605 @class in chartList)
		{
			Class2021 class2 = (Class2021)@class.Object;
			smethod_2(class2.SerList, chartDataWorkbook);
		}
	}

	private static void smethod_2(Class2038[] serList, ChartDataWorkbook chartDataWorkbook)
	{
		foreach (Class2038 @class in serList)
		{
			smethod_3(@class.Tx, chartDataWorkbook);
			smethod_4(@class.Cat, chartDataWorkbook);
			smethod_5(@class.Val, chartDataWorkbook);
			smethod_6(@class.XVal, chartDataWorkbook);
			smethod_7(@class.YVal, chartDataWorkbook);
			smethod_8(@class.BubbleSize, chartDataWorkbook);
			smethod_9(@class.ErrBarsList, chartDataWorkbook);
		}
	}

	private static void smethod_3(Class2114 serTxElementData, ChartDataWorkbook chartDataWorkbook)
	{
		if (serTxElementData == null)
		{
			return;
		}
		switch (serTxElementData.Text.Name)
		{
		case "v":
			break;
		case "strRef":
		{
			Class2120 @class = (Class2120)serTxElementData.Text.Object;
			if (@class.StrCache == null)
			{
				break;
			}
			List<object[]> list = chartDataWorkbook.method_6(@class.F);
			{
				foreach (object[] item in list)
				{
					if (@class.StrCache.PtList.Length > 0)
					{
						string worksheetName = (string)item[0];
						ChartDataWorksheet chartDataWorksheet = chartDataWorkbook.method_5(worksheetName);
						int row = ((List<int>)item[1])[0];
						int col = ((List<int>)item[2])[0];
						IChartDataCell chartDataCell = chartDataWorksheet.Cells[row, col];
						chartDataCell.Value = @class.StrCache.PtList[0].V;
						break;
					}
				}
				break;
			}
		}
		default:
			throw new ArgumentOutOfRangeException("Unknown element \"" + serTxElementData.Text.Name + "\"");
		}
	}

	private static void smethod_4(Class2341 cat, ChartDataWorkbook chartDataWorkbook)
	{
		if (cat != null && cat != null)
		{
			Class2095 @class = null;
			Class2098 class2 = null;
			Class2120 class3 = null;
			string f;
			List<object[]> list;
			int num;
			switch (cat.AxisDataSource.Name)
			{
			case "numLit":
				break;
			case "strLit":
				break;
			case "strRef":
				class3 = (Class2120)cat.AxisDataSource.Object;
				f = class3.F;
				goto IL_00bc;
			case "numRef":
				class2 = (Class2098)cat.AxisDataSource.Object;
				f = class2.F;
				goto IL_00bc;
			case "multiLvlStrRef":
				@class = (Class2095)cat.AxisDataSource.Object;
				f = @class.F;
				goto IL_00bc;
			default:
				{
					throw new ArgumentOutOfRangeException("Unknown element \"" + cat.AxisDataSource.Name + "\"");
				}
				IL_00bc:
				list = chartDataWorkbook.method_6(f);
				num = 0;
				foreach (object[] item in list)
				{
					string worksheetName = (string)item[0];
					ChartDataWorksheet chartDataWorksheet = chartDataWorkbook.method_5(worksheetName);
					int count = ((List<int>)item[1]).Count;
					int num2 = 1;
					bool flag = true;
					if (@class != null && @class.MultiLvlStrCache != null)
					{
						num2 = @class.MultiLvlStrCache.LvlList.Length;
						flag = ((List<int>)item[2])[((List<int>)item[2]).Count - 1] - ((List<int>)item[2])[0] == num2 - 1;
					}
					for (int i = 0; i < count; i++)
					{
						int row = ((List<int>)item[1])[i];
						int col = ((List<int>)item[2])[i];
						IChartDataCell chartDataCell = chartDataWorksheet.Cells[row, col];
						if (class3 != null)
						{
							if (class3.StrCache == null || i + 1 > class3.StrCache.PtList.Length)
							{
								continue;
							}
							Class2121[] ptList = class3.StrCache.PtList;
							foreach (Class2121 class4 in ptList)
							{
								if (class4.Idx == i + num)
								{
									chartDataCell.Value = class4.V;
									break;
								}
							}
						}
						else if (class2 != null)
						{
							if (class2.NumCache == null || i + 1 > class2.NumCache.PtList.Length)
							{
								continue;
							}
							Class2099[] ptList2 = class2.NumCache.PtList;
							foreach (Class2099 class5 in ptList2)
							{
								if (class5.Idx == i + num)
								{
									string v = class5.V;
									try
									{
										chartDataCell.Value = double.Parse(v, CultureInfo.InvariantCulture);
									}
									catch (Exception ex)
									{
										Class1165.smethod_28(ex);
										chartDataCell.Value = v;
									}
									break;
								}
							}
						}
						else
						{
							if (@class == null || @class.MultiLvlStrCache == null)
							{
								continue;
							}
							int num3 = count / num2;
							int num4 = (flag ? (num2 - 1 - i % num2) : (num2 - 1 - i / num3));
							int num5 = (flag ? (i / num2) : ((i + num3) % num3));
							Class2121[] ptList3 = @class.MultiLvlStrCache.LvlList[num4].PtList;
							foreach (Class2121 class6 in ptList3)
							{
								if (class6.Idx == num5)
								{
									chartDataCell.Value = class6.V;
									break;
								}
							}
						}
					}
					num++;
				}
				break;
			}
		}
	}

	private static void smethod_5(Class2342 vals, ChartDataWorkbook chartDataWorkbook)
	{
		if (vals == null)
		{
			return;
		}
		string[] array = new string[8] { "#DIV/0!", "#NAME?", "#VALUE!", "#NULL!", "#NUM!", "#REF!", "#N/A", "#GETTING_DATA" };
		if (vals == null)
		{
			return;
		}
		Class2098 @class = null;
		switch (vals.DataSource.Name)
		{
		case "numLit":
			break;
		case "numRef":
		{
			@class = (Class2098)vals.DataSource.Object;
			string f = @class.F;
			if (@class.NumCache == null)
			{
				break;
			}
			List<object[]> list = chartDataWorkbook.method_6(f);
			int num = 0;
			{
				foreach (object[] item in list)
				{
					string worksheetName = (string)item[0];
					ChartDataWorksheet chartDataWorksheet = chartDataWorkbook.method_5(worksheetName);
					int count = ((List<int>)item[1]).Count;
					uint val = @class.NumCache.PtCount.Val;
					for (int i = 0; i < count; i++)
					{
						int row = ((List<int>)item[1])[i];
						int col = ((List<int>)item[2])[i];
						ChartDataCell chartDataCell = chartDataWorksheet.Cells[row, col];
						if (i >= val)
						{
							chartDataCell.IsHidden = true;
							continue;
						}
						Class2099[] ptList = @class.NumCache.PtList;
						foreach (Class2099 class2 in ptList)
						{
							if (class2.Idx == i + num && Array.IndexOf(array, class2.V) < 0)
							{
								chartDataCell.Value = double.Parse(class2.V, CultureInfo.InvariantCulture);
								if (@class.NumCache.FormatCode != null)
								{
								}
								break;
							}
						}
					}
					num++;
				}
				break;
			}
		}
		default:
			throw new ArgumentOutOfRangeException("Unknown element \"" + vals.DataSource.Name + "\"");
		}
	}

	private static void smethod_6(Class2341 xvals, ChartDataWorkbook chartDataWorkbook)
	{
		if (xvals != null && xvals != null)
		{
			Class2095 @class = null;
			Class2098 class2 = null;
			Class2120 class3 = null;
			string f;
			List<object[]> list;
			switch (xvals.AxisDataSource.Name)
			{
			case "numLit":
				break;
			case "strLit":
				break;
			case "strRef":
				class3 = (Class2120)xvals.AxisDataSource.Object;
				f = class3.F;
				goto IL_00bc;
			case "numRef":
				class2 = (Class2098)xvals.AxisDataSource.Object;
				f = class2.F;
				goto IL_00bc;
			case "multiLvlStrRef":
				@class = (Class2095)xvals.AxisDataSource.Object;
				f = @class.F;
				goto IL_00bc;
			default:
				{
					throw new ArgumentOutOfRangeException("Unknown element \"" + xvals.AxisDataSource.Name + "\"");
				}
				IL_00bc:
				list = chartDataWorkbook.method_6(f);
				foreach (object[] item in list)
				{
					string worksheetName = (string)item[0];
					ChartDataWorksheet chartDataWorksheet = chartDataWorkbook.method_5(worksheetName);
					int count = ((List<int>)item[1]).Count;
					for (int i = 0; i < count; i++)
					{
						int row = ((List<int>)item[1])[i];
						int col = ((List<int>)item[2])[i];
						IChartDataCell chartDataCell = chartDataWorksheet.Cells[row, col];
						if (class2 != null)
						{
							if (class2.NumCache == null)
							{
								continue;
							}
							Class2099[] ptList = class2.NumCache.PtList;
							foreach (Class2099 class4 in ptList)
							{
								if (class4.Idx == i)
								{
									chartDataCell.Value = double.Parse(class4.V, CultureInfo.InvariantCulture);
									break;
								}
							}
						}
						else if (class3 != null)
						{
							if (class3.StrCache == null)
							{
								continue;
							}
							Class2121[] ptList2 = class3.StrCache.PtList;
							foreach (Class2121 class5 in ptList2)
							{
								if (class5.Idx == i)
								{
									chartDataCell.Value = class5.V;
									break;
								}
							}
						}
						else if (@class != null)
						{
							throw new NotImplementedException();
						}
					}
				}
				break;
			}
		}
	}

	private static void smethod_7(Class2342 yvals, ChartDataWorkbook chartDataWorkbook)
	{
		if (yvals == null || yvals == null)
		{
			return;
		}
		Class2098 @class = null;
		switch (yvals.DataSource.Name)
		{
		case "numLit":
			break;
		case "numRef":
		{
			@class = (Class2098)yvals.DataSource.Object;
			string f = @class.F;
			List<object[]> list = chartDataWorkbook.method_6(f);
			{
				foreach (object[] item in list)
				{
					string worksheetName = (string)item[0];
					ChartDataWorksheet chartDataWorksheet = chartDataWorkbook.method_5(worksheetName);
					int count = ((List<int>)item[1]).Count;
					for (int i = 0; i < count; i++)
					{
						int row = ((List<int>)item[1])[i];
						int col = ((List<int>)item[2])[i];
						IChartDataCell chartDataCell = chartDataWorksheet.Cells[row, col];
						if (@class == null || @class.NumCache.PtList.Length <= 0)
						{
							continue;
						}
						Class2099[] ptList = @class.NumCache.PtList;
						foreach (Class2099 class2 in ptList)
						{
							if (class2.Idx == i)
							{
								chartDataCell.Value = double.Parse(class2.V, CultureInfo.InvariantCulture);
								break;
							}
						}
					}
				}
				break;
			}
		}
		default:
			throw new ArgumentOutOfRangeException("Unknown element \"" + yvals.DataSource.Name + "\"");
		}
	}

	private static void smethod_8(Class2342 bubbleSize, ChartDataWorkbook chartDataWorkbook)
	{
		if (bubbleSize != null && bubbleSize != null)
		{
			switch (bubbleSize.DataSource.Name)
			{
			case "numRef":
			{
				Class2098 numRefElementData = (Class2098)bubbleSize.DataSource.Object;
				smethod_10(numRefElementData, chartDataWorkbook);
				break;
			}
			case "numLit":
				break;
			default:
				throw new ArgumentOutOfRangeException("Unknown element \"" + bubbleSize.DataSource.Name + "\"");
			}
		}
	}

	private static void smethod_9(Class2073[] errBars, ChartDataWorkbook chartDataWorkbook)
	{
		if (errBars == null)
		{
			return;
		}
		foreach (Class2073 @class in errBars)
		{
			if (@class.Minus != null)
			{
				switch (@class.Minus.DataSource.Name)
				{
				case "numRef":
					break;
				case "numLit":
					return;
				default:
					throw new ArgumentOutOfRangeException("Unknown element \"" + @class.Minus.DataSource.Name + "\"");
				}
				Class2098 numRefElementData = (Class2098)@class.Minus.DataSource.Object;
				smethod_10(numRefElementData, chartDataWorkbook);
			}
			if (@class.Plus != null)
			{
				switch (@class.Plus.DataSource.Name)
				{
				case "numRef":
				{
					Class2098 numRefElementData2 = (Class2098)@class.Plus.DataSource.Object;
					smethod_10(numRefElementData2, chartDataWorkbook);
					break;
				}
				case "numLit":
					return;
				default:
					throw new ArgumentOutOfRangeException("Unknown element \"" + @class.Plus.DataSource.Name + "\"");
				}
			}
		}
	}

	private static void smethod_10(Class2098 numRefElementData, ChartDataWorkbook chartDataWorkbook)
	{
		string f = numRefElementData.F;
		List<object[]> list = chartDataWorkbook.method_6(f);
		foreach (object[] item in list)
		{
			string worksheetName = (string)item[0];
			ChartDataWorksheet chartDataWorksheet = chartDataWorkbook.method_5(worksheetName);
			int count = ((List<int>)item[1]).Count;
			for (int i = 0; i < count; i++)
			{
				int row = ((List<int>)item[1])[i];
				int col = ((List<int>)item[2])[i];
				IChartDataCell chartDataCell = chartDataWorksheet.Cells[row, col];
				if (numRefElementData.NumCache.PtList.Length <= 0)
				{
					continue;
				}
				Class2099[] ptList = numRefElementData.NumCache.PtList;
				foreach (Class2099 @class in ptList)
				{
					if (@class.Idx == i)
					{
						chartDataCell.Value = double.Parse(@class.V, CultureInfo.InvariantCulture);
						break;
					}
				}
			}
		}
	}

	private static List<string> smethod_11(Class2106 plotAreaElementData)
	{
		List<string> list = new List<string>();
		Class2605[] chartList = plotAreaElementData.ChartList;
		foreach (Class2605 @class in chartList)
		{
			Class2021 class2 = (Class2021)@class.Object;
			smethod_12(class2.SerList, list);
		}
		list.Sort();
		for (int j = 0; j < list.Count - 1; j++)
		{
			if (list[j] == list[j + 1])
			{
				list.RemoveAt(j);
				j--;
			}
		}
		return list;
	}

	private static void smethod_12(Class2038[] serListElementData, List<string> usedFStrings)
	{
		foreach (Class2038 @class in serListElementData)
		{
			Class2120 strRefElementData = null;
			if (@class.Tx != null && @class.Tx.Text != null)
			{
				object @object = @class.Tx.Text.Object;
				strRefElementData = ((@object is Class2120) ? ((Class2120)@object) : null);
			}
			usedFStrings.AddRange(smethod_13(strRefElementData, @class.Cat, @class.Val, @class.YVal));
		}
	}

	private static List<string> smethod_13(Class2120 strRefElementData, Class2341 catElementData, Class2342 valElementData, Class2342 yValElementData)
	{
		List<string> list = new List<string>();
		if (strRefElementData != null)
		{
			list.Add(strRefElementData.F);
		}
		if (catElementData != null && catElementData.vmethod_5() == DataSourceType.Worksheet)
		{
			list.Add(catElementData.vmethod_6());
		}
		if (valElementData != null && valElementData.vmethod_5() == DataSourceType.Worksheet)
		{
			list.Add(valElementData.vmethod_6());
		}
		if (yValElementData != null && yValElementData.vmethod_5() == DataSourceType.Worksheet)
		{
			list.Add(yValElementData.vmethod_6());
		}
		return list;
	}

	public static void smethod_14(IChart chart, Class2106 plotAreaElementData, Class1346 serializationContext)
	{
	}
}
