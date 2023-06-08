using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Db;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace System.Data.Entity.Edm.Serialization.Xml.Internal.Ssdl;

internal class DbModelSsdlSchemaWriter : XmlSchemaWriter
{
	internal DbModelSsdlSchemaWriter(XmlWriter xmlWriter, double dbVersion)
	{
		_xmlWriter = xmlWriter;
		_version = dbVersion;
	}

	internal void WriteSchemaElementHeader(string schemaNamespace, string provider, string providerManifestToken)
	{
		string ssdlNamespace = GetSsdlNamespace(_version);
		_xmlWriter.WriteStartElement("Schema", ssdlNamespace);
		_xmlWriter.WriteAttributeString("Namespace", schemaNamespace + "Schema");
		_xmlWriter.WriteAttributeString("Provider", provider);
		_xmlWriter.WriteAttributeString("ProviderManifestToken", providerManifestToken);
		_xmlWriter.WriteAttributeString("Alias", "Self");
	}

	private static string GetSsdlNamespace(double dbVersion)
	{
		if (dbVersion == DataModelVersions.Version1)
		{
			return "http://schemas.microsoft.com/ado/2006/04/edm/ssdl";
		}
		if (dbVersion == DataModelVersions.Version2)
		{
			return "http://schemas.microsoft.com/ado/2009/02/edm/ssdl";
		}
		return "http://schemas.microsoft.com/ado/2009/11/edm/ssdl";
	}

	internal void WriteEntityTypeElementHeader(DbTableMetadata entityType)
	{
		_xmlWriter.WriteStartElement("EntityType");
		_xmlWriter.WriteAttributeString("Name", entityType.Name);
	}

	internal void WriteForeignKeyConstraintElement(DbTableMetadata dbTableMetadata, DbForeignKeyConstraintMetadata tableFKConstraint)
	{
		_xmlWriter.WriteStartElement("Association");
		_xmlWriter.WriteAttributeString("Name", tableFKConstraint.Name);
		KeyValuePair<string, string> keyValuePair = DetermineMultiplicity(dbTableMetadata, tableFKConstraint);
		string[] roleNamePair = DbModelSsdlHelper.GetRoleNamePair(tableFKConstraint.PrincipalTable, dbTableMetadata);
		WriteAssociationEndElementHeader(roleNamePair[0], tableFKConstraint.PrincipalTable, keyValuePair.Key);
		if (tableFKConstraint.DeleteAction != 0)
		{
			WriteOperationActionElement("OnDelete", tableFKConstraint.DeleteAction);
		}
		WriteEndElement();
		WriteAssociationEndElementHeader(roleNamePair[1], dbTableMetadata, keyValuePair.Value);
		WriteEndElement();
		WriteReferentialConstraintElementHeader();
		WriteReferentialConstraintRoleElement("Principal", roleNamePair[0], tableFKConstraint.PrincipalTable.KeyColumns);
		WriteReferentialConstraintRoleElement("Dependent", roleNamePair[1], tableFKConstraint.DependentColumns);
		WriteEndElement();
		WriteEndElement();
	}

	internal void WriteOperationActionElement(string elementName, DbOperationAction operationAction)
	{
		_xmlWriter.WriteStartElement(elementName);
		_xmlWriter.WriteAttributeString("Action", operationAction.ToString());
		_xmlWriter.WriteEndElement();
	}

	internal void WriteAssociationEndElementHeader(string roleName, DbTableMetadata associationEnd, string multiplicity)
	{
		_xmlWriter.WriteStartElement("End");
		_xmlWriter.WriteAttributeString("Role", roleName);
		string name = associationEnd.Name;
		_xmlWriter.WriteAttributeString("Type", GetQualifiedTypeName("Self", name));
		_xmlWriter.WriteAttributeString("Multiplicity", multiplicity);
	}

	private KeyValuePair<string, string> DetermineMultiplicity(DbTableMetadata dependentTable, DbForeignKeyConstraintMetadata constraint)
	{
		string key = "0..1";
		string value = "*";
		bool flag = false;
		bool flag2 = false;
		IEnumerable<DbTableColumnMetadata> dependentProperties = constraint.DependentColumns;
		if (dependentTable.KeyColumns.Count() == dependentProperties.Count() && dependentTable.KeyColumns.All((DbTableColumnMetadata k) => dependentProperties.Contains(k)))
		{
			flag = true;
		}
		if (dependentProperties.Any((DbTableColumnMetadata p) => p.IsNullable))
		{
			flag2 = true;
		}
		if (!flag2)
		{
			key = "1";
		}
		if (flag)
		{
			key = "1";
			value = "0..1";
		}
		return new KeyValuePair<string, string>(key, value);
	}

	internal void WriteReferentialConstraintElementHeader()
	{
		_xmlWriter.WriteStartElement("ReferentialConstraint");
	}

	internal void WriteDelaredKeyPropertiesElementHeader()
	{
		_xmlWriter.WriteStartElement("Key");
	}

	internal void WriteDelaredKeyPropertyRefElement(DbTableColumnMetadata property)
	{
		_xmlWriter.WriteStartElement("PropertyRef");
		_xmlWriter.WriteAttributeString("Name", property.Name);
		_xmlWriter.WriteEndElement();
	}

	internal void WritePropertyElementHeader(DbTableColumnMetadata property)
	{
		_xmlWriter.WriteStartElement("Property");
		_xmlWriter.WriteAttributeString("Name", property.Name);
		_xmlWriter.WriteAttributeString("Type", property.TypeName);
		WritePropertyTypeFacets(property);
	}

	private IEnumerable<KeyValuePair<string, string>> GetEnumerableFacetValueFromPrimitiveTypeFacets(DbPrimitiveTypeFacets facets)
	{
		if (facets != null)
		{
			if (facets.IsFixedLength.HasValue)
			{
				yield return new KeyValuePair<string, string>("FixedLength", XmlSchemaWriter.GetLowerCaseStringFromBoolValue(facets.IsFixedLength.Value));
			}
			if (facets.IsMaxLength.HasValue)
			{
				yield return new KeyValuePair<string, string>("MaxLength", "Max");
			}
			if (facets.IsUnicode.HasValue)
			{
				yield return new KeyValuePair<string, string>("Unicode", XmlSchemaWriter.GetLowerCaseStringFromBoolValue(facets.IsUnicode.Value));
			}
			if (facets.MaxLength.HasValue)
			{
				yield return new KeyValuePair<string, string>("MaxLength", facets.MaxLength.Value.ToString(CultureInfo.InvariantCulture));
			}
			if (facets.Precision.HasValue)
			{
				yield return new KeyValuePair<string, string>("Precision", facets.Precision.Value.ToString(CultureInfo.InvariantCulture));
			}
			if (facets.Scale.HasValue)
			{
				yield return new KeyValuePair<string, string>("Scale", facets.Scale.Value.ToString(CultureInfo.InvariantCulture));
			}
		}
	}

	private void WritePropertyTypeFacets(DbTableColumnMetadata property)
	{
		if (property.Facets != null)
		{
			foreach (KeyValuePair<string, string> enumerableFacetValueFromPrimitiveTypeFacet in GetEnumerableFacetValueFromPrimitiveTypeFacets(property.Facets))
			{
				_xmlWriter.WriteAttributeString(enumerableFacetValueFromPrimitiveTypeFacet.Key, enumerableFacetValueFromPrimitiveTypeFacet.Value);
			}
		}
		if (property.StoreGeneratedPattern != 0)
		{
			_xmlWriter.WriteAttributeString("StoreGeneratedPattern", (property.StoreGeneratedPattern == DbStoreGeneratedPattern.Computed) ? "Computed" : "Identity");
		}
		_xmlWriter.WriteAttributeString("Nullable", XmlSchemaWriter.GetLowerCaseStringFromBoolValue(property.IsNullable));
	}

	internal void WriteReferentialConstraintRoleElement(string roleElementName, string roleName, IEnumerable<DbColumnMetadata> properties)
	{
		_xmlWriter.WriteStartElement(roleElementName);
		_xmlWriter.WriteAttributeString("Role", roleName);
		foreach (DbColumnMetadata property in properties)
		{
			_xmlWriter.WriteStartElement("PropertyRef");
			_xmlWriter.WriteAttributeString("Name", property.Name);
			_xmlWriter.WriteEndElement();
		}
		_xmlWriter.WriteEndElement();
	}
}
