using System;
using Aspose.Slides.Charts;
using ns19;
using ns20;
using ns276;
using ns34;
using ns53;
using ns55;

namespace ns21;

internal class Class255
{
	private Class1345 class1345_0;

	private bool bool_0;

	public void method_0(ChartDataWorkbook workbook, Class6752 zipFile, Enum22 outputType)
	{
		if (bool_0)
		{
			throw new Exception("XlsxSerializator instance can call WriteWorkbookToZipFile() method only once.");
		}
		bool_0 = true;
		Class1185 @class = new Class1185();
		class1345_0 = new Class1345(@class, workbook);
		workbook.class808_0.Clear();
		Class1270 contentType = method_1(outputType);
		Class1342 class2 = @class.method_4("/xl/workbook.xml", null, contentType);
		method_4(workbook, class2);
		Class1219 class3 = new Class1219(class2, class1345_0);
		class3.method_6(workbook);
		@class.RootRelationships.method_4(class2);
		method_5(@class, workbook);
		method_6(@class, workbook);
		method_7(@class, workbook);
		method_3(@class, workbook);
		method_2(@class, workbook);
		@class.method_9(zipFile);
	}

	private Class1270 method_1(Enum22 outputType)
	{
		return outputType switch
		{
			Enum22.const_0 => new Class1274(), 
			Enum22.const_1 => new Class1273(), 
			Enum22.const_2 => new Class1272(), 
			Enum22.const_3 => new Class1271(), 
			_ => throw new ArgumentOutOfRangeException("outputType"), 
		};
	}

	private void method_2(Class1185 package, ChartDataWorkbook workbook)
	{
		Class1342 @class = package.method_4("/xl/sharedStrings.xml", null, new Class1283());
		Class1222 class2 = new Class1222(@class, class1345_0);
		class2.method_6(workbook);
		package.Workbook.Relationships.method_4(@class);
	}

	private void method_3(Class1185 package, ChartDataWorkbook workbook)
	{
		Class1342 @class = package.method_4("/xl/styles.xml", null, new Class1278());
		Class1221 class2 = new Class1221(@class, class1345_0);
		class2.method_6(workbook);
		package.Workbook.Relationships.method_4(@class);
	}

	private void method_4(ChartDataWorkbook workbook, Class1342 workbookEntry)
	{
		Class801 workbookPartXLSXUnsupportedProps = workbook.WorkbookPartXLSXUnsupportedProps;
		Class247.Write(workbookEntry, workbookPartXLSXUnsupportedProps.UnknownParts, workbookPartXLSXUnsupportedProps.RelsToUnknownParts);
		foreach (Class248 unknownPart in workbookPartXLSXUnsupportedProps.UnknownParts)
		{
			Class247.smethod_0(class1345_0.Package, unknownPart);
		}
	}

	private void method_5(Class1185 package, ChartDataWorkbook workbook)
	{
		Class1342 @class = package.method_4("/docProps/core.xml", null, new Class1263());
		Class1213 class2 = new Class1213(@class, class1345_0);
		class2.method_6(workbook.WorkbookPartXLSXUnsupportedProps.DocumentProperties);
		package.RootRelationships.method_4(@class);
	}

	private void method_6(Class1185 package, ChartDataWorkbook workbook)
	{
		Class1342 @class = package.method_4("/docProps/app.xml", null, new Class1265());
		Class1215 class2 = new Class1215(@class, class1345_0);
		class2.method_6(workbook.WorkbookPartXLSXUnsupportedProps.DocumentProperties);
		package.RootRelationships.method_4(@class);
	}

	private void method_7(Class1185 package, ChartDataWorkbook workbook)
	{
		if (workbook.WorkbookPartXLSXUnsupportedProps.DocumentProperties.Count > 0)
		{
			Class1342 @class = package.method_4("/docProps/custom.xml", null, new Class1264());
			package.RootRelationships.method_4(@class);
			Class1214 class2 = new Class1214(@class, class1345_0);
			class2.method_6(workbook.WorkbookPartXLSXUnsupportedProps.DocumentProperties);
		}
	}
}
