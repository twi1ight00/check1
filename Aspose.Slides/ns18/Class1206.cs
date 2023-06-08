using System.Xml;
using ns16;
using ns4;
using ns53;
using ns56;

namespace ns18;

internal class Class1206 : Class1188
{
	internal void method_5(Class146 tableStyles)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "tblStyleLst")
			{
				Class2316 tableStyleListElementData = new Class2316(base.XmlPartReader);
				Class1000.smethod_0(tableStyles, tableStyleListElementData, base.DeserializationContext);
			}
		}
		method_2();
	}

	internal void method_6(Class146 tableStyles)
	{
		method_3();
		Class2316 @class = new Class2316();
		Class1000.smethod_1(tableStyles, @class, base.SerializationContext);
		@class.vmethod_4(null, base.XmlPartWriter, "tblStyleLst");
		method_4();
	}

	public Class1206(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1206(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
