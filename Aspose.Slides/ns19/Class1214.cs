using System;
using System.Xml;
using Aspose.Slides;
using ns33;
using ns53;
using ns54;
using ns56;

namespace ns19;

internal class Class1214 : Class1187
{
	internal void method_5(IDocumentProperties documentProperties)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType != XmlNodeType.Element || !(base.XmlPartReader.NamespaceURI == "http://schemas.openxmlformats.org/officeDocument/2006/custom-properties") || !(base.XmlPartReader.LocalName == "Properties"))
			{
				continue;
			}
			Class2142 @class = new Class2142(base.XmlPartReader);
			Class2344[] propertyList = @class.PropertyList;
			for (int i = 0; i < propertyList.Length; i++)
			{
				try
				{
					documentProperties[propertyList[i].Name] = propertyList[i].PropertyValue.Object;
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
				}
			}
		}
		method_2();
	}

	internal void method_6(IDocumentProperties documentProperties)
	{
		method_3();
		Class2142 @class = new Class2142();
		for (int i = 0; i < documentProperties.Count; i++)
		{
			Class2344 class2 = @class.delegate2771_0();
			class2.Fmtid = "{D5CDD505-2E9C-101B-9397-08002B2CF9AE}";
			class2.Pid = i + 2;
			class2.Name = documentProperties.GetPropertyName(i);
			object value = documentProperties[class2.Name];
			class2.method_3(value);
		}
		@class.vmethod_4(null, base.XmlPartWriter, "Properties");
		method_4();
	}

	public Class1214(Class1342 part, Class1339 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1214(Class1342 part, Class1344 serializationContext)
		: base(part, serializationContext)
	{
	}
}
