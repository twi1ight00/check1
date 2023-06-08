using System.Xml;
using Aspose.Slides.Charts;
using ns21;
using ns34;
using ns53;
using ns55;
using ns56;

namespace ns20;

internal class Class1219 : Class1216
{
	internal void method_5(ChartDataWorkbook workbook)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType != XmlNodeType.Element || !(base.XmlPartReader.LocalName == "workbook"))
			{
				continue;
			}
			Class1744 @class = new Class1744(base.XmlPartReader);
			if (@class.DefinedNames != null)
			{
				Class1491[] definedNameList = @class.DefinedNames.DefinedNameList;
				foreach (Class1491 class2 in definedNameList)
				{
					if (class2.Name != "")
					{
						workbook.hashtable_0.Add(class2.Name, class2.Value);
					}
				}
			}
			Class1348 relationshipsOfCurrentPartEntry = base.DeserializationContext.RelationshipsOfCurrentPartEntry;
			Class1690[] sheetList = @class.Sheets.SheetList;
			foreach (Class1690 class3 in sheetList)
			{
				string r_Id = class3.R_Id;
				Class1342 targetPart = relationshipsOfCurrentPartEntry[r_Id].TargetPart;
				Class1220 class4 = new Class1220(targetPart, base.DeserializationContext);
				ChartDataWorksheet chartDataWorksheet = workbook.Worksheets.Add();
				class4.method_5(chartDataWorksheet);
				chartDataWorksheet.SheetId = class3.SheetId;
				chartDataWorksheet.NameInternal = class3.Name;
				base.DeserializationContext.SheetPartPathToSheet.Add(targetPart.PartPath, chartDataWorksheet);
			}
			Class801 workbookPartXLSXUnsupportedProps = workbook.WorkbookPartXLSXUnsupportedProps;
			workbookPartXLSXUnsupportedProps.BookViews = @class.BookViews;
			workbookPartXLSXUnsupportedProps.CalcPr = @class.CalcPr;
			workbookPartXLSXUnsupportedProps.CustomWorkbookViews = @class.CustomWorkbookViews;
			workbookPartXLSXUnsupportedProps.DefinedNames = @class.DefinedNames;
			workbookPartXLSXUnsupportedProps.ExternalReferences = @class.ExternalReferences;
			workbookPartXLSXUnsupportedProps.FileRecoveryPrList = @class.FileRecoveryPrList;
			workbookPartXLSXUnsupportedProps.FileSharing = @class.FileSharing;
			workbookPartXLSXUnsupportedProps.FileVersion = @class.FileVersion;
			workbookPartXLSXUnsupportedProps.FunctionGroups = @class.FunctionGroups;
			workbookPartXLSXUnsupportedProps.OleSize = @class.OleSize;
			workbookPartXLSXUnsupportedProps.PivotCaches = @class.PivotCaches;
			workbookPartXLSXUnsupportedProps.SmartTagPr = @class.SmartTagPr;
			workbookPartXLSXUnsupportedProps.SmartTagTypes = @class.SmartTagTypes;
			workbookPartXLSXUnsupportedProps.WebPublishObjects = @class.WebPublishObjects;
			workbookPartXLSXUnsupportedProps.WebPublishing = @class.WebPublishing;
			workbookPartXLSXUnsupportedProps.WorkbookPr = @class.WorkbookPr;
			workbookPartXLSXUnsupportedProps.WorkbookProtection = @class.WorkbookProtection;
			workbookPartXLSXUnsupportedProps.ExtLst = @class.ExtLst;
		}
		method_2();
	}

	internal void method_6(ChartDataWorkbook workbook)
	{
		method_3();
		Class1744 @class = new Class1744();
		uint num = 1u;
		foreach (ChartDataWorksheet worksheet in workbook.Worksheets)
		{
			Class1342 class2 = base.SerializationContext.Package.method_4("/xl/worksheets/sheet{0}.xml", base.SerializationContext.method_2, new Class1275());
			Class1220 class3 = new Class1220(class2, base.SerializationContext, worksheet);
			class3.method_6(worksheet);
			Class1347 class4 = base.Part.Relationships.method_4(class2);
			Class1690 class5 = @class.Sheets.delegate949_0();
			class5.R_Id = class4.Id;
			class5.SheetId = num++;
			class5.Name = worksheet.Name;
		}
		Class801 workbookPartXLSXUnsupportedProps = workbook.WorkbookPartXLSXUnsupportedProps;
		@class.delegate86_0(workbookPartXLSXUnsupportedProps.BookViews);
		@class.delegate128_0(workbookPartXLSXUnsupportedProps.CalcPr);
		@class.delegate299_0(workbookPartXLSXUnsupportedProps.CustomWorkbookViews);
		@class.delegate355_0(workbookPartXLSXUnsupportedProps.DefinedNames);
		@class.delegate408_0(workbookPartXLSXUnsupportedProps.ExternalReferences);
		if (workbookPartXLSXUnsupportedProps.FileRecoveryPrList != null)
		{
			Class1519[] fileRecoveryPrList = workbookPartXLSXUnsupportedProps.FileRecoveryPrList;
			foreach (Class1519 elementData in fileRecoveryPrList)
			{
				@class.delegate437_0(elementData);
			}
		}
		@class.delegate441_0(workbookPartXLSXUnsupportedProps.FileSharing);
		@class.delegate444_0(workbookPartXLSXUnsupportedProps.FileVersion);
		@class.delegate486_0(workbookPartXLSXUnsupportedProps.FunctionGroups);
		@class.delegate684_0(workbookPartXLSXUnsupportedProps.OleSize);
		@class.delegate765_0(workbookPartXLSXUnsupportedProps.PivotCaches);
		@class.delegate984_0(workbookPartXLSXUnsupportedProps.SmartTagPr);
		@class.delegate993_0(workbookPartXLSXUnsupportedProps.SmartTagTypes);
		@class.delegate1110_0(workbookPartXLSXUnsupportedProps.WebPublishObjects);
		@class.delegate1098_0(workbookPartXLSXUnsupportedProps.WebPublishing);
		@class.delegate1116_0(workbookPartXLSXUnsupportedProps.WorkbookPr);
		@class.delegate1119_0(workbookPartXLSXUnsupportedProps.WorkbookProtection);
		@class.delegate387_0(workbookPartXLSXUnsupportedProps.ExtLst);
		@class.vmethod_4(null, base.XmlPartWriter, "workbook");
		method_4();
	}

	public Class1219(Class1342 part, Class1340 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1219(Class1342 part, Class1345 serializationContext)
		: base(part, serializationContext)
	{
	}
}
