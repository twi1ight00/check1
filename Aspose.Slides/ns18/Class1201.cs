using System.Xml;
using ns16;
using ns26;
using ns53;
using ns56;

namespace ns18;

internal class Class1201 : Class1188
{
	internal void method_5(Class290 smartArtUnsupported)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "colorsDef")
			{
				Class2139 colorsDefElementData = new Class2139(base.XmlPartReader);
				smartArtUnsupported.ColorsDefElementData = colorsDefElementData;
			}
		}
		method_2();
	}

	internal void method_6(Class290 smartArtUnsupported)
	{
		method_3();
		Class2139 colorsDefElementData = smartArtUnsupported.ColorsDefElementData;
		colorsDefElementData.vmethod_4(null, base.XmlPartWriter, "colorsDef");
		method_4();
	}

	public Class1201(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1201(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
