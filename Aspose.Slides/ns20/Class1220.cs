using System.Collections;
using System.Xml;
using Aspose.Slides.Charts;
using ns19;
using ns21;
using ns34;
using ns53;
using ns55;
using ns56;

namespace ns20;

internal class Class1220 : Class1216
{
	internal void method_5(ChartDataWorksheet worksheet)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType != XmlNodeType.Element || !(base.XmlPartReader.LocalName == "worksheet"))
			{
				continue;
			}
			Class1747 @class = new Class1747(base.XmlPartReader);
			Class1348 relationshipsOfCurrentPartEntry = base.DeserializationContext.RelationshipsOfCurrentPartEntry;
			Class250.smethod_0(worksheet.Cells, @class, base.DeserializationContext);
			if (@class.TableParts != null)
			{
				Class1715[] tablePartList = @class.TableParts.TablePartList;
				foreach (Class1715 class2 in tablePartList)
				{
					Class1218 class3 = new Class1218(relationshipsOfCurrentPartEntry[class2.R_Id].TargetPart, base.DeserializationContext);
					class3.method_5(worksheet);
				}
			}
			Class799 sheetPartXLSXUnsupportedProps = worksheet.SheetPartXLSXUnsupportedProps;
			sheetPartXLSXUnsupportedProps.AutoFilter = @class.AutoFilter;
			sheetPartXLSXUnsupportedProps.CellWatches = @class.CellWatches;
			sheetPartXLSXUnsupportedProps.ColBreaks = @class.ColBreaks;
			sheetPartXLSXUnsupportedProps.ColsList = @class.ColsList;
			sheetPartXLSXUnsupportedProps.ConditionalFormattingList = @class.ConditionalFormattingList;
			sheetPartXLSXUnsupportedProps.Controls = @class.Controls;
			sheetPartXLSXUnsupportedProps.CustomProperties = @class.CustomProperties;
			sheetPartXLSXUnsupportedProps.CustomSheetViews = @class.CustomSheetViews;
			sheetPartXLSXUnsupportedProps.DataConsolidate = @class.DataConsolidate;
			sheetPartXLSXUnsupportedProps.DataValidations = @class.DataValidations;
			sheetPartXLSXUnsupportedProps.Dimension = @class.Dimension;
			sheetPartXLSXUnsupportedProps.Drawing = @class.Drawing;
			sheetPartXLSXUnsupportedProps.HeaderFooter = @class.HeaderFooter;
			sheetPartXLSXUnsupportedProps.Hyperlinks = @class.Hyperlinks;
			sheetPartXLSXUnsupportedProps.IgnoredErrors = @class.IgnoredErrors;
			sheetPartXLSXUnsupportedProps.LegacyDrawing = @class.LegacyDrawing;
			sheetPartXLSXUnsupportedProps.LegacyDrawingHF = @class.LegacyDrawingHF;
			sheetPartXLSXUnsupportedProps.MergeCells = @class.MergeCells;
			sheetPartXLSXUnsupportedProps.OleObjects = @class.OleObjects;
			sheetPartXLSXUnsupportedProps.PageMargins = @class.PageMargins;
			sheetPartXLSXUnsupportedProps.PageSetup = @class.PageSetup;
			sheetPartXLSXUnsupportedProps.PhoneticPr = @class.PhoneticPr;
			sheetPartXLSXUnsupportedProps.Picture = @class.Picture;
			sheetPartXLSXUnsupportedProps.PrintOptions = @class.PrintOptions;
			sheetPartXLSXUnsupportedProps.ProtectedRanges = @class.ProtectedRanges;
			sheetPartXLSXUnsupportedProps.RowBreaks = @class.RowBreaks;
			sheetPartXLSXUnsupportedProps.Scenarios = @class.Scenarios;
			sheetPartXLSXUnsupportedProps.SheetCalcPr = @class.SheetCalcPr;
			sheetPartXLSXUnsupportedProps.SheetFormatPr = @class.SheetFormatPr;
			sheetPartXLSXUnsupportedProps.SheetPr = @class.SheetPr;
			sheetPartXLSXUnsupportedProps.SheetProtection = @class.SheetProtection;
			sheetPartXLSXUnsupportedProps.SheetViews = @class.SheetViews;
			sheetPartXLSXUnsupportedProps.SmartTags = @class.SmartTags;
			sheetPartXLSXUnsupportedProps.SortState = @class.SortState;
			sheetPartXLSXUnsupportedProps.WebPublishItems = @class.WebPublishItems;
			sheetPartXLSXUnsupportedProps.ExtLst = @class.ExtLst;
		}
		method_2();
	}

	internal void method_6(ChartDataWorksheet worksheet)
	{
		method_3();
		Class1747 @class = new Class1747();
		Class799 sheetPartXLSXUnsupportedProps = worksheet.SheetPartXLSXUnsupportedProps;
		if (worksheet.Cells.Count > 0)
		{
			Class1716 class2 = @class.delegate1027_0();
			foreach (Class1097 item in worksheet.class809_0)
			{
				Class1342 class3 = base.SerializationContext.Package.method_4("/xl/tables/table{0}.xml", base.SerializationContext.method_1, new Class1277());
				Class1218 class4 = new Class1218(class3, base.SerializationContext);
				class4.method_6(item);
				Class1347 class5 = base.Part.Relationships.method_4(class3);
				Class1715 class6 = class2.delegate1024_0();
				class6.R_Id = class5.Id;
			}
		}
		SortedList sortedList = new SortedList();
		foreach (SortedList value in worksheet.Cells.sortedList_0.Values)
		{
			foreach (SortedList value2 in value.Values)
			{
				foreach (ChartDataCell value3 in value2.Values)
				{
					if (sortedList[value3.Row + 1] == null)
					{
						sortedList.Add(value3.Row + 1, new SortedList());
					}
					(sortedList[value3.Row + 1] as SortedList).Add(value3.Column, value3);
				}
			}
		}
		foreach (int key in sortedList.Keys)
		{
			Class1671 class7 = @class.SheetData.delegate892_0();
			class7.R = (uint)key;
			if ((sortedList[key] as SortedList).Count > 0 && ((sortedList[key] as SortedList).GetByIndex(0) as ChartDataCell).IsHidden)
			{
				class7.Hidden = true;
			}
			foreach (ChartDataCell value4 in (sortedList[key] as SortedList).Values)
			{
				Class1394 cellElementData = class7.delegate144_0();
				Class251.smethod_1(value4, cellElementData, base.SerializationContext);
			}
		}
		@class.delegate77_0(sheetPartXLSXUnsupportedProps.AutoFilter);
		@class.delegate176_0(sheetPartXLSXUnsupportedProps.CellWatches);
		@class.delegate690_1(sheetPartXLSXUnsupportedProps.ColBreaks);
		if (sheetPartXLSXUnsupportedProps.ColsList != null)
		{
			Class1423[] colsList = sheetPartXLSXUnsupportedProps.ColsList;
			foreach (Class1423 elementData in colsList)
			{
				@class.delegate232_0(elementData);
			}
		}
		if (sheetPartXLSXUnsupportedProps.ConditionalFormattingList != null)
		{
			Class1429[] conditionalFormattingList = sheetPartXLSXUnsupportedProps.ConditionalFormattingList;
			foreach (Class1429 elementData2 in conditionalFormattingList)
			{
				@class.delegate250_0(elementData2);
			}
		}
		@class.delegate266_0(sheetPartXLSXUnsupportedProps.Controls);
		@class.delegate284_0(sheetPartXLSXUnsupportedProps.CustomProperties);
		@class.delegate293_0(sheetPartXLSXUnsupportedProps.CustomSheetViews);
		@class.delegate307_0(sheetPartXLSXUnsupportedProps.DataConsolidate);
		@class.delegate325_0(sheetPartXLSXUnsupportedProps.DataValidations);
		@class.delegate948_0(sheetPartXLSXUnsupportedProps.Dimension);
		@class.delegate370_0(sheetPartXLSXUnsupportedProps.Drawing);
		@class.delegate519_0(sheetPartXLSXUnsupportedProps.HeaderFooter);
		@class.delegate528_0(sheetPartXLSXUnsupportedProps.Hyperlinks);
		@class.delegate543_0(sheetPartXLSXUnsupportedProps.IgnoredErrors);
		@class.delegate564_0(sheetPartXLSXUnsupportedProps.LegacyDrawing);
		@class.delegate564_1(sheetPartXLSXUnsupportedProps.LegacyDrawingHF);
		@class.delegate624_0(sheetPartXLSXUnsupportedProps.MergeCells);
		@class.delegate681_0(sheetPartXLSXUnsupportedProps.OleObjects);
		@class.delegate702_0(sheetPartXLSXUnsupportedProps.PageMargins);
		@class.delegate708_0(sheetPartXLSXUnsupportedProps.PageSetup);
		@class.delegate738_0(sheetPartXLSXUnsupportedProps.PhoneticPr);
		@class.delegate939_0(sheetPartXLSXUnsupportedProps.Picture);
		@class.delegate798_0(sheetPartXLSXUnsupportedProps.PrintOptions);
		@class.delegate804_0(sheetPartXLSXUnsupportedProps.ProtectedRanges);
		@class.delegate690_0(sheetPartXLSXUnsupportedProps.RowBreaks);
		@class.delegate915_0(sheetPartXLSXUnsupportedProps.Scenarios);
		@class.delegate942_0(sheetPartXLSXUnsupportedProps.SheetCalcPr);
		@class.delegate954_0(sheetPartXLSXUnsupportedProps.SheetFormatPr);
		@class.delegate963_0(sheetPartXLSXUnsupportedProps.SheetPr);
		@class.delegate966_0(sheetPartXLSXUnsupportedProps.SheetProtection);
		@class.delegate975_0(sheetPartXLSXUnsupportedProps.SheetViews);
		@class.delegate987_0(sheetPartXLSXUnsupportedProps.SmartTags);
		@class.delegate999_0(sheetPartXLSXUnsupportedProps.SortState);
		@class.delegate1104_0(sheetPartXLSXUnsupportedProps.WebPublishItems);
		@class.delegate387_0(sheetPartXLSXUnsupportedProps.ExtLst);
		@class.vmethod_4(null, base.XmlPartWriter, "worksheet");
		method_4();
	}

	public Class1220(Class1342 part, Class1340 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1220(Class1342 part, Class1345 serializationContext, ChartDataWorksheet worksheet)
		: base(part, serializationContext)
	{
		Class247.Write(part, worksheet.ParentWorkbook.WorkbookPartXLSXUnsupportedProps.UnknownParts, worksheet.SheetPartXLSXUnsupportedProps.RelsToUnknownParts);
	}
}
