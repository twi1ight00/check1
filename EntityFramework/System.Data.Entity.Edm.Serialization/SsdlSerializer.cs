using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Serialization.Xml.Internal.Ssdl;
using System.Xml;

namespace System.Data.Entity.Edm.Serialization;

internal class SsdlSerializer
{
	/// <summary>
	///     Serialize the <see cref="T:System.Data.Entity.Edm.Db.DbDatabaseMetadata" /> to the <see cref="T:System.Xml.XmlWriter" />
	/// </summary>
	/// <param name="dbDatabase"> The DbDatabaseMetadata to serialize </param>
	/// <param name="provider"> Provider information on the Schema element </param>
	/// <param name="providerManifestToken"> ProviderManifestToken information on the Schema element </param>
	/// <param name="xmlWriter"> The XmlWriter to serialize to </param>
	/// <returns> </returns>
	public bool Serialize(DbDatabaseMetadata dbDatabase, string provider, string providerManifestToken, XmlWriter xmlWriter)
	{
		DbModelSsdlSerializationVisitor dbModelSsdlSerializationVisitor = new DbModelSsdlSerializationVisitor(xmlWriter, dbDatabase.Version);
		dbModelSsdlSerializationVisitor.Visit(dbDatabase, provider, providerManifestToken);
		return true;
	}
}
