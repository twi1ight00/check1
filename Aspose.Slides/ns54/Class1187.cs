using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using ns33;
using ns46;
using ns53;
using ns55;

namespace ns54;

internal abstract class Class1187
{
	private Class1339 class1339_0;

	private Class1344 class1344_0;

	private bool bool_0;

	private Class1342 class1342_0;

	private XmlReader xmlReader_0;

	private XmlTextWriter xmlTextWriter_0;

	private MemoryStream memoryStream_0;

	private Class1348 class1348_0;

	protected Class1339 DeserializationContext => class1339_0;

	protected Class1344 SerializationContext => class1344_0;

	protected XmlReader XmlPartReader => xmlReader_0;

	protected XmlWriter XmlPartWriter => xmlTextWriter_0;

	protected Class1342 Part => class1342_0;

	protected Class1187(Class1342 part, Class1339 deserializationContext)
	{
		class1342_0 = part;
		class1339_0 = deserializationContext;
	}

	protected Class1187(Class1342 part, Class1344 serializationContext)
	{
		class1342_0 = part;
		class1344_0 = serializationContext;
	}

	protected void method_0()
	{
		if (bool_0)
		{
			throw new Exception5("Parsing must be started once time per instance of PartParser. One instance of PartParser corresponds to one part.");
		}
		bool_0 = true;
		class1348_0 = class1339_0.RelationshipsOfCurrentPartEntry;
		class1339_0.RelationshipsOfCurrentPartEntry = Part.Relationships;
		XmlSchemaCollection schemaCollection = ((Class1224)Part.ContentType).SchemaCollection;
		TextReader reader = method_1();
		xmlReader_0 = Class1181.smethod_0(reader, schemaCollection, ((Class1224)Part.ContentType).ImplicitNamespaces);
	}

	private TextReader method_1()
	{
		XmlSchemaCollection schemaCollection = ((Class1224)Part.ContentType).SchemaCollection;
		bool flag = false;
		bool insertSpacePreserve = schemaCollection == null && flag;
		Stream stream = Part.method_0();
		if (Part.ContentType.ContentType == "application/vnd.openxmlformats-officedocument.vmlDrawing")
		{
			stream = Class1118.smethod_0(stream);
		}
		long position = stream.Position;
		Class1124 builder = Class1118.smethod_2(stream, insertSpacePreserve);
		stream.Seek(position, SeekOrigin.Begin);
		return new Class1122(stream, builder);
	}

	protected void method_2()
	{
		class1339_0.RelationshipsOfCurrentPartEntry = class1348_0;
		class1342_0.Processed = true;
	}

	protected void method_3()
	{
		if (bool_0)
		{
			throw new Exception5("Parsing must be started once time per instance of PartParser. One instance of PartParser corresponds to one part.");
		}
		bool_0 = true;
		class1348_0 = class1344_0.RelationshipsOfCurrentPartEntry;
		class1344_0.RelationshipsOfCurrentPartEntry = Part.Relationships;
		memoryStream_0 = new MemoryStream();
		xmlTextWriter_0 = new XmlTextWriter(memoryStream_0, Encoding.UTF8);
		xmlTextWriter_0.Indentation = 4;
		xmlTextWriter_0.Formatting = (Part.ParentPackage.Indentation ? Formatting.Indented : Formatting.None);
		xmlTextWriter_0.WriteStartDocument(standalone: true);
	}

	protected void method_4()
	{
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
		xmlTextWriter_0.Close();
		Part.Data = memoryStream_0.ToArray();
		class1344_0.RelationshipsOfCurrentPartEntry = class1348_0;
	}
}
