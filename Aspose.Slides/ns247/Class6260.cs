using System;
using System.IO;
using ns218;

namespace ns247;

internal class Class6260
{
	private readonly string string_0;

	private string string_1;

	private Stream stream_0;

	private readonly Class6263 class6263_0;

	public string Name => string_0;

	public string Extension => Path.GetExtension(string_0).TrimStart('.');

	public string ContentType
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public Stream Stream
	{
		get
		{
			return stream_0;
		}
		set
		{
			stream_0 = value;
		}
	}

	public Class6263 Rels => class6263_0;

	public Class6260(string partName, string contentType)
	{
		Class5964.smethod_24(partName, "partName");
		string_0 = partName;
		string_1 = contentType;
		stream_0 = new MemoryStream();
		class6263_0 = new Class6263(partName);
	}

	public void method_0(string fileName)
	{
		Stream dstStream = File.Create(fileName);
		try
		{
			stream_0.Position = 0L;
			Class5964.smethod_9(stream_0, dstStream);
			stream_0.Position = 0L;
		}
		finally
		{
			stream_0.Close();
		}
	}

	public string method_1(string relId)
	{
		if (!Class5964.smethod_20(relId))
		{
			return string.Empty;
		}
		Class6262 @class = class6263_0.method_0(relId);
		if (@class == null)
		{
			return string.Empty;
		}
		if (@class.IsExternal)
		{
			string text = @class.Target;
			if (text.StartsWith("file:///"))
			{
				text = text.Replace("file:///", string.Empty);
				text = Class5973.smethod_18(text);
			}
			return text;
		}
		if (Class5973.smethod_15(@class.Target))
		{
			return @class.Target;
		}
		return method_2(@class);
	}

	public string method_2(Class6262 rel)
	{
		if (rel.IsExternal)
		{
			throw new InvalidOperationException("An internal target is expected here.");
		}
		return Class6254.smethod_2(string_0, rel.Target);
	}

	public MemoryStream method_3()
	{
		return Class5964.smethod_10(stream_0);
	}
}
