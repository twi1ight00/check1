using System.Collections.Generic;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Internal;
using System.Xml;

namespace System.Data.Entity.Edm.Serialization.Xml.Internal.Ssdl;

internal class DbModelSsdlSerializationVisitor : DbDatabaseVisitor
{
	private class DbModelEntityContainerSerializationVisitor : DbModelSsdlSerializationVisitor
	{
		private readonly DbModelEntityContainerSsdlSchemaWriter _containerSchemaWriter;

		private DbSchemaMetadata currentSchema;

		internal DbModelEntityContainerSerializationVisitor(XmlWriter xmlWriter, double dbVersion)
			: base(xmlWriter, dbVersion)
		{
			_containerSchemaWriter = new DbModelEntityContainerSsdlSchemaWriter(xmlWriter);
		}

		internal void Visit(DbDatabaseMetadata dbDatabase)
		{
			_containerSchemaWriter.WriteEntityContainerElementHeader(dbDatabase.Name);
			foreach (DbSchemaMetadata schema in dbDatabase.Schemas)
			{
				VisitDbSchemaMetadata(currentSchema = schema);
				currentSchema = null;
			}
			_containerSchemaWriter.WriteEndElement();
		}

		protected override void VisitDbTableMetadata(DbTableMetadata item)
		{
			_containerSchemaWriter.WriteEntitySetElementHeader(currentSchema, item);
			VisitForeignKeyConstraints(item, item.ForeignKeyConstraints);
			_schemaWriter.WriteEndElement();
		}

		protected override void VisitForeignKeyConstraints(Dictionary<DbTableMetadata, IEnumerable<DbForeignKeyConstraintMetadata>> foreignKeyConstraints)
		{
			foreach (KeyValuePair<DbTableMetadata, IEnumerable<DbForeignKeyConstraintMetadata>> foreignKeyConstraint in foreignKeyConstraints)
			{
				foreach (DbForeignKeyConstraintMetadata item in foreignKeyConstraint.Value)
				{
					_containerSchemaWriter.WriteAssociationSetElementHeader(item);
					string[] roleNamePair = DbModelSsdlHelper.GetRoleNamePair(item.PrincipalTable, foreignKeyConstraint.Key);
					_containerSchemaWriter.WriteAssociationSetEndElement(item.PrincipalTable, roleNamePair[0]);
					_containerSchemaWriter.WriteAssociationSetEndElement(foreignKeyConstraint.Key, roleNamePair[1]);
					_containerSchemaWriter.WriteEndElement();
				}
			}
		}
	}

	private readonly double _dbVersion;

	private readonly DbModelSsdlSchemaWriter _schemaWriter;

	private readonly XmlWriter _xmlWriter;

	private readonly Dictionary<DbTableMetadata, IEnumerable<DbForeignKeyConstraintMetadata>> _foreignKeyConstraintList = new Dictionary<DbTableMetadata, IEnumerable<DbForeignKeyConstraintMetadata>>();

	internal DbModelSsdlSerializationVisitor(XmlWriter xmlWriter, double dbVersion)
	{
		_dbVersion = dbVersion;
		_xmlWriter = xmlWriter;
		_schemaWriter = new DbModelSsdlSchemaWriter(xmlWriter, dbVersion);
	}

	internal void Visit(DbDatabaseMetadata dbDatabase, string provider, string providerManifestToken)
	{
		string name = dbDatabase.Name;
		_schemaWriter.WriteSchemaElementHeader(name, provider, providerManifestToken);
		foreach (DbSchemaMetadata schema in dbDatabase.Schemas)
		{
			VisitDbSchemaMetadata(schema);
		}
		DbModelEntityContainerSerializationVisitor dbModelEntityContainerSerializationVisitor = new DbModelEntityContainerSerializationVisitor(_xmlWriter, _dbVersion);
		dbModelEntityContainerSerializationVisitor.Visit(dbDatabase);
		_schemaWriter.WriteEndElement();
	}

	protected override void VisitDbSchemaMetadata(DbSchemaMetadata item)
	{
		base.VisitDbSchemaMetadata(item);
		VisitForeignKeyConstraints(_foreignKeyConstraintList);
		_foreignKeyConstraintList.Clear();
	}

	protected virtual void VisitForeignKeyConstraints(Dictionary<DbTableMetadata, IEnumerable<DbForeignKeyConstraintMetadata>> foreignKeyConstraints)
	{
		foreach (KeyValuePair<DbTableMetadata, IEnumerable<DbForeignKeyConstraintMetadata>> foreignKeyConstraint in foreignKeyConstraints)
		{
			foreach (DbForeignKeyConstraintMetadata item in foreignKeyConstraint.Value)
			{
				_schemaWriter.WriteForeignKeyConstraintElement(foreignKeyConstraint.Key, item);
			}
		}
	}

	protected override void VisitDbTableMetadata(DbTableMetadata item)
	{
		_schemaWriter.WriteEntityTypeElementHeader(item);
		base.VisitDbTableMetadata(item);
		_schemaWriter.WriteEndElement();
	}

	protected override void VisitKeyColumns(DbTableMetadata item, IEnumerable<DbTableColumnMetadata> keyColumns)
	{
		_schemaWriter.WriteDelaredKeyPropertiesElementHeader();
		foreach (DbTableColumnMetadata keyColumn in keyColumns)
		{
			_schemaWriter.WriteDelaredKeyPropertyRefElement(keyColumn);
		}
		_schemaWriter.WriteEndElement();
	}

	protected override void VisitDbTableColumnMetadata(DbTableColumnMetadata item)
	{
		_schemaWriter.WritePropertyElementHeader(item);
		base.VisitDbTableColumnMetadata(item);
		_schemaWriter.WriteEndElement();
	}

	protected override void VisitForeignKeyConstraints(DbTableMetadata item, IEnumerable<DbForeignKeyConstraintMetadata> foreignKeyConstraints)
	{
		_foreignKeyConstraintList.Add(item, foreignKeyConstraints);
	}
}
