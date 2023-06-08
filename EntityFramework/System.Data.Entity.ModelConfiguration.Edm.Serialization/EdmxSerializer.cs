using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.Edm.Serialization;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;

namespace System.Data.Entity.ModelConfiguration.Edm.Serialization;

[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Edmx")]
internal sealed class EdmxSerializer
{
	private class EndElement : IDisposable
	{
		private readonly XmlWriter _xmlWriter;

		public EndElement(XmlWriter xmlWriter)
		{
			_xmlWriter = xmlWriter;
		}

		public void Dispose()
		{
			_xmlWriter.WriteEndElement();
		}
	}

	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Edm")]
	public const string EdmXmlNamespace = "http://schemas.microsoft.com/ado/2008/10/edmx";

	private DbDatabaseMapping _databaseMapping;

	private double _version;

	private DbProviderInfo _providerInfo;

	private XmlWriter _xmlWriter;

	public void Serialize(DbDatabaseMapping databaseMapping, double version, DbProviderInfo providerInfo, XmlWriter xmlWriter)
	{
		_xmlWriter = xmlWriter;
		_databaseMapping = databaseMapping;
		_version = version;
		_providerInfo = providerInfo;
		_xmlWriter.WriteStartDocument();
		using (Element("Edmx", "Version", string.Format(CultureInfo.InvariantCulture, "{0:F1}", new object[1] { _version })))
		{
			WriteEdmxRuntime();
			WriteEdmxDesigner();
		}
		_xmlWriter.WriteEndDocument();
		_xmlWriter.Flush();
	}

	private void WriteEdmxRuntime()
	{
		using (Element("Runtime"))
		{
			using (Element("ConceptualModels"))
			{
				_databaseMapping.Model.ValidateAndSerializeCsdl(_xmlWriter);
			}
			using (Element("Mappings"))
			{
				bool flag = new MslSerializer().Serialize(_databaseMapping, _xmlWriter);
			}
			using (Element("StorageModels"))
			{
				bool flag2 = new SsdlSerializer().Serialize(_databaseMapping.Database, _providerInfo.ProviderInvariantName, _providerInfo.ProviderManifestToken, _xmlWriter);
			}
		}
	}

	private void WriteEdmxDesigner()
	{
		using (Element("Designer"))
		{
			WriteEdmxConnection();
			WriteEdmxOptions();
			WriteEdmxDiagrams();
		}
	}

	private void WriteEdmxConnection()
	{
		using (Element("Connection"))
		{
			using (Element("DesignerInfoPropertySet"))
			{
				WriteDesignerPropertyElement("MetadataArtifactProcessing", "EmbedInOutputAssembly");
			}
		}
	}

	private void WriteEdmxOptions()
	{
		using (Element("Options"))
		{
			using (Element("DesignerInfoPropertySet"))
			{
				WriteDesignerPropertyElement("ValidateOnBuild", "False");
				WriteDesignerPropertyElement("CodeGenerationStrategy", "None");
				WriteDesignerPropertyElement("ProcessDependentTemplatesOnSave", "False");
			}
		}
	}

	private void WriteDesignerPropertyElement(string name, string value)
	{
		using (Element("DesignerProperty", "Name", name, "Value", value))
		{
		}
	}

	private void WriteEdmxDiagrams()
	{
		using (Element("Diagrams"))
		{
			using (Element("Diagram", "Name", "Sample"))
			{
			}
		}
	}

	private IDisposable Element(string elementName, params string[] attributes)
	{
		_xmlWriter.WriteStartElement(elementName, "http://schemas.microsoft.com/ado/2008/10/edmx");
		for (int i = 0; i < attributes.Length - 1; i += 2)
		{
			_xmlWriter.WriteAttributeString(attributes[i], attributes[i + 1]);
		}
		return new EndElement(_xmlWriter);
	}
}
