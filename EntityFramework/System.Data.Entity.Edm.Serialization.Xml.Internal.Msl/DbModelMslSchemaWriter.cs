using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Linq;
using System.Xml;

namespace System.Data.Entity.Edm.Serialization.Xml.Internal.Msl;

internal class DbModelMslSchemaWriter : XmlSchemaWriter
{
	private string _entityTypeNamespace;

	private string _dbSchemaName;

	internal DbModelMslSchemaWriter(XmlWriter xmlWriter, double version)
	{
		_xmlWriter = xmlWriter;
		_version = version;
	}

	internal void WriteSchema(DbDatabaseMapping databaseMapping)
	{
		WriteSchemaElementHeader();
		WriteDbModelElement(databaseMapping);
		WriteEndElement();
	}

	private void WriteSchemaElementHeader()
	{
		string mslNamespace = GetMslNamespace(_version);
		_xmlWriter.WriteStartElement("Mapping", mslNamespace);
		_xmlWriter.WriteAttributeString("Space", "C-S");
	}

	private void WriteDbModelElement(DbDatabaseMapping databaseMapping)
	{
		_entityTypeNamespace = databaseMapping.Model.Namespaces.First().Name;
		_dbSchemaName = databaseMapping.Database.Name;
		WriteEntityContainerMappingElement(databaseMapping.EntityContainerMappings.FirstOrDefault());
	}

	private void WriteEntityContainerMappingElement(DbEntityContainerMapping containerMapping)
	{
		_xmlWriter.WriteStartElement("EntityContainerMapping");
		_xmlWriter.WriteAttributeString("StorageEntityContainer", _dbSchemaName);
		_xmlWriter.WriteAttributeString("CdmEntityContainer", containerMapping.EntityContainer.Name);
		foreach (DbEntitySetMapping entitySetMapping in containerMapping.EntitySetMappings)
		{
			WriteEntitySetMappingElement(entitySetMapping);
		}
		foreach (DbAssociationSetMapping associationSetMapping in containerMapping.AssociationSetMappings)
		{
			WriteAssociationSetMappingElement(associationSetMapping);
		}
		_xmlWriter.WriteEndElement();
	}

	private void WriteEntitySetMappingElement(DbEntitySetMapping set)
	{
		_xmlWriter.WriteStartElement("EntitySetMapping");
		_xmlWriter.WriteAttributeString("Name", set.EntitySet.Name);
		foreach (DbEntityTypeMapping entityTypeMapping in set.EntityTypeMappings)
		{
			WriteEntityTypeMappingElement(entityTypeMapping);
		}
		_xmlWriter.WriteEndElement();
	}

	private void WriteAssociationSetMappingElement(DbAssociationSetMapping set)
	{
		_xmlWriter.WriteStartElement("AssociationSetMapping");
		_xmlWriter.WriteAttributeString("Name", set.AssociationSet.Name);
		_xmlWriter.WriteAttributeString("TypeName", _entityTypeNamespace + "." + set.AssociationSet.ElementType.Name);
		_xmlWriter.WriteAttributeString("StoreEntitySet", set.Table.Name);
		WriteAssociationEndMappingElement(set.SourceEndMapping);
		WriteAssociationEndMappingElement(set.TargetEndMapping);
		foreach (DbColumnCondition columnCondition in set.ColumnConditions)
		{
			WriteConditionElement(columnCondition);
		}
		_xmlWriter.WriteEndElement();
	}

	private void WriteAssociationEndMappingElement(DbAssociationEndMapping endMapping)
	{
		_xmlWriter.WriteStartElement("EndProperty");
		_xmlWriter.WriteAttributeString("Name", endMapping.AssociationEnd.Name);
		foreach (DbEdmPropertyMapping propertyMapping in endMapping.PropertyMappings)
		{
			WriteScalarPropertyElement(propertyMapping.PropertyPath.First(), propertyMapping.Column);
		}
		_xmlWriter.WriteEndElement();
	}

	private void WriteEntityTypeMappingElement(DbEntityTypeMapping entityTypeMapping)
	{
		_xmlWriter.WriteStartElement("EntityTypeMapping");
		_xmlWriter.WriteAttributeString("TypeName", GetEntityTypeName(_entityTypeNamespace + "." + entityTypeMapping.EntityType.Name, entityTypeMapping.IsHierarchyMapping));
		foreach (DbEntityTypeMappingFragment typeMappingFragment in entityTypeMapping.TypeMappingFragments)
		{
			WriteMappingFragmentElement(typeMappingFragment);
		}
		_xmlWriter.WriteEndElement();
	}

	private void WriteMappingFragmentElement(DbEntityTypeMappingFragment mappingFragment)
	{
		_xmlWriter.WriteStartElement("MappingFragment");
		_xmlWriter.WriteAttributeString("StoreEntitySet", mappingFragment.Table.Name);
		WritePropertyMappings(mappingFragment.PropertyMappings);
		foreach (DbColumnCondition columnCondition in mappingFragment.ColumnConditions)
		{
			WriteConditionElement(columnCondition);
		}
		_xmlWriter.WriteEndElement();
	}

	private static string GetEntityTypeName(string fullyQualifiedEntityTypeName, bool isHierarchyMapping)
	{
		if (isHierarchyMapping)
		{
			return "IsTypeOf(" + fullyQualifiedEntityTypeName + ")";
		}
		return fullyQualifiedEntityTypeName;
	}

	private void WriteConditionElement(DbColumnCondition condition)
	{
		_xmlWriter.WriteStartElement("Condition");
		if (condition.IsNull.HasValue)
		{
			_xmlWriter.WriteAttributeString("IsNull", XmlSchemaWriter.GetLowerCaseStringFromBoolValue(condition.IsNull.Value));
		}
		else if (condition.Value is bool)
		{
			_xmlWriter.WriteAttributeString("Value", ((bool)condition.Value) ? "1" : "0");
		}
		else
		{
			_xmlWriter.WriteAttributeString("Value", condition.Value.ToString());
		}
		_xmlWriter.WriteAttributeString("ColumnName", condition.Column.Name);
		_xmlWriter.WriteEndElement();
	}

	private void WritePropertyMappings(IEnumerable<DbEdmPropertyMapping> propertyMappings, int level = 0)
	{
		IEnumerable<IGrouping<EdmProperty, DbEdmPropertyMapping>> enumerable = from pm in propertyMappings
			where pm.PropertyPath.Count() > level
			group pm by pm.PropertyPath.ElementAt(level);
		foreach (IGrouping<EdmProperty, DbEdmPropertyMapping> item in enumerable)
		{
			EdmProperty key = item.Key;
			if (item.Count() == 1 && item.Single().PropertyPath.Count == level + 1)
			{
				WriteScalarPropertyElement(key, item.Single().Column);
				continue;
			}
			_xmlWriter.WriteStartElement("ComplexProperty");
			_xmlWriter.WriteAttributeString("Name", key.Name);
			_xmlWriter.WriteAttributeString("TypeName", _entityTypeNamespace + "." + key.PropertyType.ComplexType.Name);
			WritePropertyMappings(item, level + 1);
			_xmlWriter.WriteEndElement();
		}
	}

	private void WriteScalarPropertyElement(EdmProperty property, DbTableColumnMetadata column)
	{
		_xmlWriter.WriteStartElement("ScalarProperty");
		_xmlWriter.WriteAttributeString("Name", property.Name);
		_xmlWriter.WriteAttributeString("ColumnName", column.Name);
		_xmlWriter.WriteEndElement();
	}

	private static string GetMslNamespace(double version)
	{
		if (version == DataModelVersions.Version1)
		{
			return "urn:schemas-microsoft-com:windows:storage:mapping:CS";
		}
		if (version == DataModelVersions.Version2)
		{
			return "http://schemas.microsoft.com/ado/2008/09/mapping/cs";
		}
		return "http://schemas.microsoft.com/ado/2009/11/mapping/cs";
	}
}
