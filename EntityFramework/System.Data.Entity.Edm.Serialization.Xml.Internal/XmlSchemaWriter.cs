using System.Text;
using System.Xml;

namespace System.Data.Entity.Edm.Serialization.Xml.Internal;

internal abstract class XmlSchemaWriter
{
	protected XmlWriter _xmlWriter;

	protected double _version;

	internal void WriteEndElement()
	{
		_xmlWriter.WriteEndElement();
	}

	protected string GetQualifiedTypeName(string prefix, string typeName)
	{
		StringBuilder stringBuilder = new StringBuilder();
		return stringBuilder.Append(prefix).Append(".").Append(typeName)
			.ToString();
	}

	internal static string GetTypeNameFromPrimitiveTypeKind(EdmPrimitiveTypeKind primitiveTypeKind)
	{
		return primitiveTypeKind.ToString();
	}

	internal static string GetLowerCaseStringFromBoolValue(bool value)
	{
		if (!value)
		{
			return "false";
		}
		return "true";
	}
}
