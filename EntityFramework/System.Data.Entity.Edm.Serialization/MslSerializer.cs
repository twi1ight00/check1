using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.Edm.Serialization.Xml.Internal.Msl;
using System.Xml;

namespace System.Data.Entity.Edm.Serialization;

internal class MslSerializer
{
	/// <summary>
	///     Serialize the <see cref="T:System.Data.Entity.Infrastructure.DbModel" /> to the XmlWriter
	/// </summary>
	/// <param name="databaseMapping"> The DbModel to serialize </param>
	/// <param name="xmlWriter"> The XmlWriter to serialize to </param>
	public bool Serialize(DbDatabaseMapping databaseMapping, XmlWriter xmlWriter)
	{
		DbModelMslSchemaWriter dbModelMslSchemaWriter = new DbModelMslSchemaWriter(xmlWriter, databaseMapping.Model.Version);
		dbModelMslSchemaWriter.WriteSchema(databaseMapping);
		return true;
	}
}
