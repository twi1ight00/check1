using System;
using Aspose.Slides;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class999
{
	public static ITable smethod_0(IShapeCollection shapes, Class1991 graphicFrameElementData, Class1030 slideDeserializationContext)
	{
		if (graphicFrameElementData == null)
		{
			return null;
		}
		Class2315 table = graphicFrameElementData.Graphic.GraphicData.Table;
		int num = table.TblGrid.GridColList.Length;
		int num2 = table.TrList.Length;
		double[] array = new double[num];
		double[] array2 = new double[num2];
		for (int i = 0; i < num; i++)
		{
			array[i] = table.TblGrid.GridColList[i].W;
		}
		for (int j = 0; j < num2; j++)
		{
			array2[j] = ((table.TrList[j].H == 0.0) ? 1.0 : table.TrList[j].H);
		}
		Table table2 = (Table)shapes.AddTable(0f, 0f, array, array2);
		Class291 pPTXUnsupportedProps = table2.PPTXUnsupportedProps;
		Class959.smethod_0(table2, graphicFrameElementData, slideDeserializationContext);
		Class1939 tblPr = table.TblPr;
		if (tblPr != null)
		{
			Class949.smethod_0(table2.FillFormat, tblPr.FillProperties, slideDeserializationContext.DeserializationContext);
			Class939.smethod_0(table2.EffectFormat, tblPr.EffectProperties, slideDeserializationContext.DeserializationContext);
			table2.RightToLeft = tblPr.Rtl;
			table2.FirstRow = tblPr.FirstRow;
			table2.FirstCol = tblPr.FirstCol;
			table2.LastRow = tblPr.LastRow;
			table2.LastCol = tblPr.LastCol;
			table2.HorizontalBanding = tblPr.BandRow;
			table2.VerticalBanding = tblPr.BandCol;
			if (tblPr.TableStyle != null)
			{
				switch (tblPr.TableStyle.Name)
				{
				case "tableStyleId":
				{
					Guid guid = (Guid)tblPr.TableStyle.Object;
					TableStylePreset tableStylePreset2 = (table2.StylePreset = ((Presentation)table2.Presentation).PPTXUnsupportedProps.TableStyles.method_1(guid));
					if (tableStylePreset2 == TableStylePreset.Custom)
					{
						pPTXUnsupportedProps.TableStyle = ((Presentation)table2.Presentation).PPTXUnsupportedProps.TableStyles.method_0(guid);
					}
					break;
				}
				case "tableStyle":
				{
					Class1942 tableStyleElementData = (Class1942)tblPr.TableStyle.Object;
					table2.StylePreset = TableStylePreset.Custom;
					Class1001.smethod_0(pPTXUnsupportedProps.TableStyle, tableStyleElementData, slideDeserializationContext.DeserializationContext);
					break;
				}
				default:
					throw new Exception("Unknown element \"" + tblPr.TableStyle.Name + "\"");
				}
			}
			else
			{
				table2.StylePreset = TableStylePreset.None;
			}
			pPTXUnsupportedProps.ExtensionListOfTableProperties = tblPr.ExtLst;
		}
		Class1936[] gridColList = table.TblGrid.GridColList;
		for (int k = 0; k < gridColList.Length; k++)
		{
			table2.columnCollection_0.method_0(k).PPTXUnsupportedProps.ExtensionList = gridColList[k].ExtLst;
		}
		Class1940[] trList = table.TrList;
		int l;
		for (l = 0; l < trList.Length; l++)
		{
			table2.rowCollection_0.method_0(l).PPTXUnsupportedProps.ExtensionList = trList[l].ExtLst;
		}
		int count = table2.Rows.Count;
		int count2 = table2.Columns.Count;
		l = count;
		while (l > 0)
		{
			l--;
			Row row = table2.rowCollection_0.method_0(l);
			Class1934[] tcList = trList[l].TcList;
			int k = count2;
			while (k > 0)
			{
				k--;
				Cell cell = row.vmethod_3(k);
				Class902.smethod_0(cell, tcList[k], l, count, k, count2, slideDeserializationContext.DeserializationContext);
				cell.int_1 = tcList[k].GridSpan;
				cell.int_0 = tcList[k].RowSpan;
				cell.cell_0 = null;
				if (!cell.IsSingleCell)
				{
					cell.method_1(mergeText: true);
				}
			}
		}
		return table2;
	}

	public static void smethod_1(Table table, Class1991 graphicFrameElementData, Class1346 serializationContext)
	{
		Class291 pPTXUnsupportedProps = table.PPTXUnsupportedProps;
		Class2345 graphicData = graphicFrameElementData.Graphic.GraphicData;
		Class2315 @class = graphicData.delegate2692_0();
		Class1939 class2 = @class.delegate1684_0();
		class2.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfTableProperties);
		Class949.smethod_1(table.FillFormat, class2.delegate2773_1, serializationContext);
		Class939.smethod_1(table.EffectFormat, class2.delegate2773_0, serializationContext);
		if (table.StylePreset == TableStylePreset.Custom)
		{
			if (((Presentation)table.Presentation).PPTXUnsupportedProps.TableStyles.method_0(table.TableStyle.PPTXUnsupportedProps.Id) != null)
			{
				Guid id = table.TableStyle.PPTXUnsupportedProps.Id;
				class2.TableStyle = new Class2605("tableStyleId", id);
				serializationContext.UsedTableStyles[id] = id;
			}
			else
			{
				Class1942 tableStyleElementData = (Class1942)class2.delegate2773_2("tableStyle").Object;
				Class1001.smethod_2(pPTXUnsupportedProps.TableStyle, tableStyleElementData, serializationContext);
			}
		}
		else if (table.StylePreset != 0)
		{
			Guid guid = ((Presentation)table.Presentation).PPTXUnsupportedProps.TableStyles.method_2(table.StylePreset);
			class2.TableStyle = new Class2605("tableStyleId", guid);
			serializationContext.UsedTableStyles[guid] = guid;
		}
		class2.Rtl = table.RightToLeft;
		class2.FirstRow = table.FirstRow;
		class2.FirstCol = table.FirstCol;
		class2.LastRow = table.LastRow;
		class2.LastCol = table.LastCol;
		class2.BandRow = table.HorizontalBanding;
		class2.BandCol = table.VerticalBanding;
		int count = table.Columns.Count;
		int count2 = table.Rows.Count;
		Class1937 tblGrid = @class.TblGrid;
		for (int i = 0; i < count; i++)
		{
			Class1936 class3 = tblGrid.delegate1675_0();
			Column column = table.columnCollection_0.method_0(i);
			double num = 0.0;
			for (int j = 0; j < count2; j++)
			{
				Cell cell = table.GetCell(i, j);
				if (!cell.IsSlaveCell && cell.ColSpan == 1)
				{
					double num2 = cell.MarginLeft + cell.MarginRight + 2.0;
					if (num < num2)
					{
						num = num2;
					}
					continue;
				}
				if (cell.MergedTo == null)
				{
					double num3 = cell.MarginLeft + 2.0;
					if (num < num3)
					{
						num = num3;
					}
					continue;
				}
				cell = cell.MergedTo;
				if (cell.ColSpan <= i + 1 && cell.FirstColumn == table.Columns[i - cell.ColSpan + 1])
				{
					double num4 = cell.MarginRight + 2.0;
					if (num < num4)
					{
						num = num4;
					}
				}
			}
			class3.W = Math.Max(column.Width, num);
			class3.delegate1535_0(column.PPTXUnsupportedProps.ExtensionList);
		}
		for (int k = 0; k < count2; k++)
		{
			Class1940 class4 = @class.delegate1687_0();
			Row row = table.rowCollection_0.method_0(k);
			class4.H = row.MinimalHeight;
			for (int l = 0; l < count; l++)
			{
				ICell cell2 = row.vmethod_3(l);
				Class902.smethod_1(cell2, class4.delegate1669_0, serializationContext);
			}
			class4.delegate1535_0(row.PPTXUnsupportedProps.ExtensionList);
		}
		Class959.smethod_2(table, graphicFrameElementData, serializationContext);
	}
}
