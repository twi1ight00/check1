using System.Data.Entity.Edm.Db;
using System.Xml;

namespace System.Data.Entity.Edm.Serialization.Xml.Internal.Ssdl;

internal class DbModelEntityContainerSsdlSchemaWriter : XmlSchemaWriter
{
	public const string ContainerSuffix = "Container";

	internal DbModelEntityContainerSsdlSchemaWriter(XmlWriter xmlWriter)
	{
		_xmlWriter = xmlWriter;
	}

	internal void WriteEntityContainerElementHeader(string containerName)
	{
		_xmlWriter.WriteStartElement("EntityContainer");
		_xmlWriter.WriteAttributeString("Name", containerName);
	}

	internal void WriteAssociationSetElementHeader(DbForeignKeyConstraintMetadata constraint)
	{
		_xmlWriter.WriteStartElement("AssociationSet");
		_xmlWriter.WriteAttributeString("Name", constraint.Name);
		_xmlWriter.WriteAttributeString("Association", GetQualifiedTypeName("Self", constraint.Name));
	}

	internal void WriteAssociationSetEndElement(DbTableMetadata end, string roleName)
	{
		_xmlWriter.WriteStartElement("End");
		_xmlWriter.WriteAttributeString("Role", roleName);
		_xmlWriter.WriteAttributeString("EntitySet", end.Name);
		_xmlWriter.WriteEndElement();
	}

	internal void WriteEntitySetElementHeader(DbSchemaMetadata containingSchema, DbTableMetadata entitySet)
	{
		_xmlWriter.WriteStartElement("EntitySet");
		_xmlWriter.WriteAttributeString("Name", entitySet.Name);
		_xmlWriter.WriteAttributeString("EntityType", GetQualifiedTypeName("Self", entitySet.Name));
		if (containingSchema.DatabaseIdentifier != null)
		{
			_xmlWriter.WriteAttributeString("Schema", containingSchema.DatabaseIdentifier);
		}
		if (entitySet.DatabaseIdentifier != null)
		{
			_xmlWriter.WriteAttributeString("Table", entitySet.DatabaseIdentifier);
		}
	}
}
