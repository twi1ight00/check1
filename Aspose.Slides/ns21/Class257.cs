using System.Collections.Generic;
using System.IO;
using Aspose.Slides.Charts;
using ns19;
using ns20;
using ns34;
using ns53;
using ns55;

namespace ns21;

internal class Class257
{
	public static bool bool_0;

	private Class1340 class1340_0;

	private Class1342 class1342_0;

	public void method_0(ChartDataWorkbook workbook, Stream stream)
	{
		Class1185 @class = new Class1185(stream);
		class1340_0 = new Class1340(workbook);
		class1342_0 = @class.Workbook;
		workbook.WorkbookType = Class256.smethod_0(class1342_0.ContentType.ContentType, Enum22.const_0);
		method_1(@class, workbook.LoadOptions);
		method_2(@class, workbook);
		method_3(@class, workbook);
		method_4(@class, workbook);
		method_5(@class, workbook);
		method_6(@class, workbook);
		smethod_0(@class, workbook, class1340_0);
	}

	private void method_1(Class1185 package, Class803 loadOptions)
	{
		if (package.RootRelationships.method_0(Class1336.class1338_0).Length > 0)
		{
			loadOptions.method_0();
			package.RootRelationships.method_3(Class1336.class1338_0);
		}
	}

	private void method_2(Class1185 package, ChartDataWorkbook workbook)
	{
		if (package.SharedStrings != null)
		{
			Class1222 @class = new Class1222(package.SharedStrings, class1340_0);
			@class.method_5(workbook);
		}
	}

	private void method_3(Class1185 package, ChartDataWorkbook workbook)
	{
		Class1221 @class = new Class1221(package.Styles, class1340_0);
		@class.method_5(workbook);
	}

	private void method_4(Class1185 package, ChartDataWorkbook workbook)
	{
		Class1219 @class = new Class1219(package.Workbook, class1340_0);
		@class.method_5(workbook);
	}

	private void method_5(Class1185 package, ChartDataWorkbook workbook)
	{
		if (package.CalcChain != null)
		{
			Class1217 @class = new Class1217(package.CalcChain, class1340_0);
			@class.method_5(workbook);
		}
	}

	private void method_6(Class1185 package, ChartDataWorkbook workbook)
	{
		if (package.CoreProperties != null)
		{
			Class1213 @class = new Class1213(package.CoreProperties, class1340_0);
			@class.method_5(workbook.WorkbookPartXLSXUnsupportedProps.DocumentProperties);
		}
		if (package.ExtendedProperties != null)
		{
			Class1215 class2 = new Class1215(package.ExtendedProperties, class1340_0);
			class2.method_5(workbook.WorkbookPartXLSXUnsupportedProps.DocumentProperties);
		}
		if (package.CustomProperties != null)
		{
			Class1214 class3 = new Class1214(package.CustomProperties, class1340_0);
			class3.method_5(workbook.WorkbookPartXLSXUnsupportedProps.DocumentProperties);
		}
	}

	internal static void smethod_0(Class1185 package, ChartDataWorkbook workbook, Class1340 deserializationContext)
	{
		Class801 workbookPartXLSXUnsupportedProps = workbook.WorkbookPartXLSXUnsupportedProps;
		Class1342[] parts = package.Parts;
		foreach (Class1342 @class in parts)
		{
			if (!@class.Processed && !(@class.ContentType is Class1296))
			{
				workbookPartXLSXUnsupportedProps.UnknownParts.Add(@class.PartPath, @class.Data, @class.ContentType.ContentType, (@class.ContentType.TypeAttributeOfSourceRelationship != null) ? @class.ContentType.TypeAttributeOfSourceRelationship.Type : "", @class.Relationships);
				@class.Processed = true;
			}
		}
		Class1347[] array = package.Workbook.Relationships.method_2();
		foreach (Class1347 relationship in array)
		{
			smethod_1(workbookPartXLSXUnsupportedProps, workbookPartXLSXUnsupportedProps.RelsToUnknownParts, relationship);
		}
		List<Class1342> list = new List<Class1342>();
		Class1342[] sheets = package.Sheets;
		foreach (Class1342 item in sheets)
		{
			list.Add(item);
		}
		foreach (Class1342 item2 in list)
		{
			IChartDataWorksheet chartDataWorksheet = deserializationContext.SheetPartPathToSheet[item2.PartPath];
			Class799 sheetPartXLSXUnsupportedProps = ((ChartDataWorksheet)chartDataWorksheet).SheetPartXLSXUnsupportedProps;
			Class1347[] array2 = item2.Relationships.method_2();
			foreach (Class1347 relationship2 in array2)
			{
				smethod_1(workbookPartXLSXUnsupportedProps, sheetPartXLSXUnsupportedProps.RelsToUnknownParts, relationship2);
			}
		}
	}

	private static void smethod_1(Class801 workbookUnsupported, List<object[]> relsToUnknownParts, Class1347 relationship)
	{
		Class248 @class = workbookUnsupported.UnknownParts[relationship.Target];
		if (@class != null)
		{
			if (string.IsNullOrEmpty(@class.TypeAttributeOfSourceRelationship))
			{
				@class.TypeAttributeOfSourceRelationship = relationship.Type;
			}
			relsToUnknownParts.Add(new object[4] { relationship.Id, relationship.Type, relationship.Target, relationship.TargetMode });
		}
		else
		{
			relsToUnknownParts.Add(new object[4] { relationship.Id, relationship.Type, relationship.Target, relationship.TargetMode });
		}
	}
}
