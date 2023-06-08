using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;

namespace System.Data.Entity.Migrations.Edm;

internal class ModelCompressor
{
	[SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
	public virtual byte[] Compress(XDocument model)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using (GZipStream stream = new GZipStream(memoryStream, CompressionMode.Compress))
		{
			model.Save(stream);
		}
		return memoryStream.ToArray();
	}

	[SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
	public virtual XDocument Decompress(byte[] bytes)
	{
		using MemoryStream stream = new MemoryStream(bytes);
		using GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress);
		return XDocument.Load(stream2);
	}
}
