using System.Xml;
using Aspose.Slides.Charts;
using ns21;
using ns53;
using ns56;

namespace ns20;

internal class Class1222 : Class1216
{
	internal void method_5(ChartDataWorkbook workbook)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "sst")
			{
				Class1707 @class = new Class1707(base.XmlPartReader);
				Class1676[] siList = @class.SiList;
				foreach (Class1676 rstElementData in siList)
				{
					workbook.class808_0.Add(rstElementData);
				}
				workbook.class808_0.ExtLst = @class.ExtLst;
			}
		}
		method_2();
	}

	internal void method_6(ChartDataWorkbook workbook)
	{
		method_3();
		Class1707 @class = new Class1707();
		@class.UniqueCount = workbook.class808_0.uint_1;
		@class.Count = workbook.class808_0.uint_0;
		for (int i = 0; i < workbook.class808_0.Count; i++)
		{
			@class.delegate908_0(workbook.class808_0.method_0(i));
		}
		@class.delegate387_0(workbook.class808_0.ExtLst);
		@class.vmethod_4(null, base.XmlPartWriter, "sst");
		method_4();
	}

	public Class1222(Class1342 part, Class1340 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1222(Class1342 part, Class1345 serializationContext)
		: base(part, serializationContext)
	{
	}
}
