using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.Edm;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace System.Data.Entity.Migrations.Extensions;

internal static class XDocumentExtensions
{
	public static StoreItemCollection GetStoreItemCollection(this XDocument model, out DbProviderInfo providerInfo)
	{
		XElement xElement = model.Descendants(EdmXNames.Ssdl.Schema).Single();
		providerInfo = new DbProviderInfo(xElement.ProviderAttribute(), xElement.ProviderManifestTokenAttribute());
		return new StoreItemCollection(new XmlReader[1] { xElement.CreateReader() });
	}
}
