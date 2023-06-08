using System.Collections.Generic;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Serialization;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace System.Data.Entity.ModelConfiguration.Edm.Db;

internal static class DbDatabaseMetadataExtensions
{
	public const string DefaultSchema = "dbo";

	private const string ProviderInfoAnnotation = "ProviderInfo";

	public static DbDatabaseMetadata Initialize(this DbDatabaseMetadata database)
	{
		database.Version = 2.0;
		database.Name = "CodeFirstDatabase";
		database.Schemas.Add(new DbSchemaMetadata
		{
			Name = "dbo",
			DatabaseIdentifier = "dbo"
		});
		return database;
	}

	public static StoreItemCollection ToStoreItemCollection(this DbDatabaseMetadata database)
	{
		DbProviderInfo providerInfo = database.GetProviderInfo();
		StringBuilder stringBuilder = new StringBuilder();
		using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, new XmlWriterSettings
		{
			Indent = true
		}))
		{
			new SsdlSerializer().Serialize(database, providerInfo.ProviderInvariantName, providerInfo.ProviderManifestToken, xmlWriter);
		}
		string s = stringBuilder.ToString();
		using XmlReader xmlReader = XmlReader.Create(new StringReader(s));
		return new StoreItemCollection(new XmlReader[1] { xmlReader });
	}

	public static DbTableMetadata AddTable(this DbDatabaseMetadata database, string name)
	{
		DbSchemaMetadata dbSchemaMetadata = database.Schemas.Single();
		string text = dbSchemaMetadata.Tables.UniquifyIdentifier(name);
		DbTableMetadata dbTableMetadata = new DbTableMetadata();
		dbTableMetadata.Name = text;
		dbTableMetadata.DatabaseIdentifier = text;
		DbTableMetadata dbTableMetadata2 = dbTableMetadata;
		dbSchemaMetadata.Tables.Add(dbTableMetadata2);
		return dbTableMetadata2;
	}

	public static DbTableMetadata AddTable(this DbDatabaseMetadata database, string name, DbTableMetadata pkSource, bool isIdentity)
	{
		DbTableMetadata dbTableMetadata = database.AddTable(name);
		foreach (DbTableColumnMetadata keyColumn in pkSource.KeyColumns)
		{
			DbTableColumnMetadata dbTableColumnMetadata = keyColumn.Clone();
			if (!isIdentity)
			{
				dbTableColumnMetadata.RemoveStoreGeneratedIdentityPattern();
			}
			dbTableMetadata.Columns.Add(dbTableColumnMetadata);
		}
		return dbTableMetadata;
	}

	public static void RemoveTable(this DbDatabaseMetadata database, DbTableMetadata table)
	{
		database.Schemas.Select((DbSchemaMetadata s) => s.Tables).Each((IList<DbTableMetadata> ts) => ts.Remove(table));
	}

	public static DbTableMetadata FindTableByName(this DbDatabaseMetadata database, DatabaseName tableName)
	{
		return database.Schemas.Single().Tables.SingleOrDefault((DbTableMetadata t) => t.GetTableName()?.Equals(tableName) ?? string.Equals(t.Name, tableName.Name, StringComparison.Ordinal));
	}

	public static DbProviderInfo GetProviderInfo(this DbDatabaseMetadata database)
	{
		return (DbProviderInfo)database.Annotations.GetAnnotation("ProviderInfo");
	}

	public static void SetProviderInfo(this DbDatabaseMetadata database, DbProviderInfo providerInfo)
	{
		database.Annotations.SetAnnotation("ProviderInfo", providerInfo);
	}
}
