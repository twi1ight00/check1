using System.Xml;
using ns16;
using ns26;
using ns53;
using ns56;

namespace ns18;

internal class Class1202 : Class1188
{
	internal void method_5(Class290 smartArtUnsupported)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "dataModel")
			{
				Class2143 dataModelElementData = new Class2143(base.XmlPartReader);
				smartArtUnsupported.DataModelElementData = dataModelElementData;
				smartArtUnsupported.DataModel_RelsOfDataPart = base.DeserializationContext.RelationshipsOfCurrentPartEntry;
			}
		}
		method_2();
	}

	internal void method_6(Class290 smartArtUnsupported, Class1347 relToDrawingPart)
	{
		method_3();
		Class2143 dataModelElementData = smartArtUnsupported.DataModelElementData;
		dataModelElementData.delegate1535_0(null);
		if (relToDrawingPart != null)
		{
			Class2472.smethod_1(dataModelElementData.delegate1534_0(), relToDrawingPart.Id);
		}
		dataModelElementData.vmethod_4(null, base.XmlPartWriter, "dataModel");
		method_4();
	}

	public Class1202(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1202(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
