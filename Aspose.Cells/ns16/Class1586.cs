using System;
using System.Collections;
using System.Globalization;
using System.Xml;
using ns45;

namespace ns16;

internal class Class1586
{
	private Class1141 class1141_0;

	internal Class1586(Class1141 class1141_1)
	{
		class1141_0 = class1141_1;
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		try
		{
			xmlTextWriter_0.WriteStartDocument(standalone: true);
			xmlTextWriter_0.WriteStartElement("pivotCacheRecords");
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_0);
			xmlTextWriter_0.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			ArrayList arrayList_ = class1141_0.class1144_0.arrayList_0;
			int count = arrayList_.Count;
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			for (int i = 0; i < count; i++)
			{
				xmlTextWriter_0.WriteStartElement("r");
				object[] array = (object[])arrayList_[i];
				int num = array.Length;
				for (int j = 0; j < num; j++)
				{
					object obj = array[j];
					if (obj == null)
					{
						xmlTextWriter_0.WriteElementString("m", null);
					}
					if (obj is string)
					{
						xmlTextWriter_0.WriteStartElement("s");
						xmlTextWriter_0.WriteAttributeString("v", (string)obj);
						xmlTextWriter_0.WriteEndElement();
					}
					else if (obj is double)
					{
						string value = Class1618.smethod_79((double)obj);
						xmlTextWriter_0.WriteStartElement("n");
						xmlTextWriter_0.WriteAttributeString("v", value);
						xmlTextWriter_0.WriteEndElement();
					}
					else if (obj is int)
					{
						string value2 = Class1618.smethod_80((int)obj);
						xmlTextWriter_0.WriteStartElement("x");
						xmlTextWriter_0.WriteAttributeString("v", value2);
						xmlTextWriter_0.WriteEndElement();
					}
					else if (obj is short)
					{
						string value3 = Class1618.smethod_83((short)obj);
						xmlTextWriter_0.WriteStartElement("n");
						xmlTextWriter_0.WriteAttributeString("v", value3);
						xmlTextWriter_0.WriteEndElement();
					}
					else if (obj is DateTime dateTime)
					{
						string value4 = dateTime.ToString("yyyy-MM-dd\\THH:mm:ss.fff", CultureInfo.InvariantCulture);
						xmlTextWriter_0.WriteStartElement("d");
						xmlTextWriter_0.WriteAttributeString("v", value4);
						xmlTextWriter_0.WriteEndElement();
					}
					else if (obj is bool)
					{
						string value5 = (((bool)obj) ? "1" : "0");
						xmlTextWriter_0.WriteStartElement("b");
						xmlTextWriter_0.WriteAttributeString("v", value5);
						xmlTextWriter_0.WriteEndElement();
					}
				}
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndDocument();
			xmlTextWriter_0.Flush();
		}
		catch (Exception)
		{
		}
	}
}
