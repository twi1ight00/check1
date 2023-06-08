using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace System.Data.Entity.Migrations.Extensions;

internal static class DbContextExtensions
{
	[SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
	public static XDocument GetModel(this DbContext context)
	{
		return GetModel(delegate(XmlWriter w)
		{
			EdmxWriter.WriteEdmx(context, w);
		});
	}

	public static XDocument GetModel(this DbModel model)
	{
		return GetModel(delegate(XmlWriter w)
		{
			EdmxWriter.WriteEdmx(model, w);
		});
	}

	private static XDocument GetModel(Action<XmlWriter> writeXml)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using (XmlWriter obj = XmlWriter.Create(memoryStream, new XmlWriterSettings
		{
			Indent = true
		}))
		{
			writeXml(obj);
		}
		memoryStream.Position = 0L;
		return XDocument.Load(memoryStream);
	}
}
