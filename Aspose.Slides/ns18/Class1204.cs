using System.Xml;
using ns16;
using ns26;
using ns53;
using ns56;

namespace ns18;

internal class Class1204 : Class1188
{
	internal void method_5(Class290 smartArtUnsupported)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "layoutDef")
			{
				Class2195 layoutDefElementData = new Class2195(base.XmlPartReader);
				smartArtUnsupported.LayoutDefElementData = layoutDefElementData;
			}
		}
		method_2();
	}

	internal void method_6(Class290 smartArtUnsupported)
	{
		method_3();
		Class2195 layoutDefElementData = smartArtUnsupported.LayoutDefElementData;
		layoutDefElementData.vmethod_4(null, base.XmlPartWriter, "layoutDef");
		method_4();
	}

	public Class1204(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1204(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
