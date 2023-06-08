using System.Xml;
using Aspose.Slides.Charts;
using ns21;
using ns53;
using ns56;

namespace ns20;

internal class Class1217 : Class1216
{
	internal void method_5(ChartDataWorkbook workbook)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "calcChain")
			{
				new Class1387(base.XmlPartReader);
			}
		}
		method_2();
	}

	internal void method_6(ChartDataWorkbook workbook)
	{
		method_3();
		method_4();
	}

	public Class1217(Class1342 part, Class1340 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1217(Class1342 part, Class1345 serializationContext)
		: base(part, serializationContext)
	{
	}
}
