using System.Collections.Generic;
using System.IO;
using ns55;

namespace ns53;

internal class Class1185 : Class1183
{
	private Class1342 class1342_0;

	private Class1342 class1342_1;

	private Class1342 class1342_2;

	private Class1342 class1342_3;

	private List<Class1342> list_2 = new List<Class1342>();

	private Class1342 class1342_4;

	private List<Class1342> list_3 = new List<Class1342>();

	private List<Class1342> list_4 = new List<Class1342>();

	private Class1342 class1342_5;

	private Class1342 class1342_6;

	private Class1342 class1342_7;

	private Class1342 class1342_8;

	private Class1342 class1342_9;

	private Class1342 class1342_10;

	private List<Class1342> list_5 = new List<Class1342>();

	private Class1342 class1342_11;

	public Class1342 CustomProperties => class1342_2;

	public Class1342 CoreProperties => class1342_1;

	public Class1342 ExtendedProperties => class1342_0;

	public Class1342 CalcChain => class1342_3;

	public Class1342[] Chartsheets => list_2.ToArray();

	public Class1342 Connections => class1342_4;

	public Class1342[] Dialogsheets => list_3.ToArray();

	public Class1342[] ExternalReferences => list_4.ToArray();

	public Class1342 Metadata => class1342_5;

	public Class1342 SharedStrings => class1342_6;

	public Class1342 RevisionHeaders => class1342_7;

	public Class1342 UserNames => class1342_8;

	public Class1342 Styles => class1342_9;

	public Class1342 VolatileDependencies => class1342_10;

	public Class1342 Workbook => class1342_11;

	public Class1342[] Sheets => list_5.ToArray();

	public Class1185()
	{
	}

	public Class1185(Stream stream)
		: base(stream)
	{
	}

	public override void vmethod_0(IList<Class1342> parts)
	{
		foreach (Class1342 part in parts)
		{
			vmethod_1(part);
		}
		string target = base.RootRelationships.method_0(Class1250.class1338_0)[0].Target;
		if (!sortedList_0.TryGetValue(target, out class1342_11))
		{
			throw new Exception5($"Error reading pptx presentation: can't find \"{target}\" entry in \"parts\" list.");
		}
	}

	public override void vmethod_1(Class1342 pentry)
	{
		if (pentry.ContentType is Class1225)
		{
			switch (pentry.ContentType.ContentType)
			{
			case "application/vnd.openxmlformats-officedocument.extended-properties+xml":
				class1342_0 = pentry;
				break;
			case "application/vnd.openxmlformats-package.core-properties+xml":
				class1342_1 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.custom-properties+xml":
				class1342_2 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.calcChain+xml":
				class1342_3 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.chartsheet+xml":
				list_2.Add(pentry);
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.connections+xml":
				class1342_4 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.dialogsheet+xml":
				list_3.Add(pentry);
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.externalLink+xml":
				list_4.Add(pentry);
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheetMetadata+xml":
				class1342_5 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.sharedStrings+xml":
				class1342_6 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.revisionHeaders+xml":
				class1342_7 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.userNames+xml":
				class1342_8 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml":
				class1342_9 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.volatileDependencies+xml":
				class1342_10 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml":
				list_5.Add(pentry);
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml":
			case "application/vnd.ms-excel.sheet.macroEnabled.main+xml":
			case "application/vnd.ms-excel.template.macroEnabled.main+xml":
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.template.main+xml":
				class1342_11 = pentry;
				break;
			}
		}
		else if (pentry.ContentType == null)
		{
			pentry.method_5(new Class1337());
		}
	}
}
