using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Web;
using System.Xml;

namespace Aspose.Slides.Import;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("ba8c992c-d69e-4a39-aa4b-dfe73814695a")]
public class HtmlExternalResolver : IHtmlExternalResolver
{
	private const string string_0 = "data:";

	private const string string_1 = "base64";

	private readonly XmlUrlResolver xmlUrlResolver_0 = new XmlUrlResolver();

	public virtual string ResolveUri(string baseUri, string relativeUri)
	{
		try
		{
			if (baseUri != null)
			{
				return new Uri(new Uri(baseUri), relativeUri).ToString();
			}
			return new Uri(relativeUri).ToString();
		}
		catch (Exception)
		{
			return null;
		}
	}

	public virtual Stream GetEntity(string absoluteUri)
	{
		if (absoluteUri.Length > "data:".Length && absoluteUri.Substring(0, "data:".Length).ToLower() == "data:")
		{
			bool flag = false;
			int length = "data:".Length;
			int i;
			for (i = length; i < absoluteUri.Length && absoluteUri[i] != ',' && absoluteUri[i] != ';'; i++)
			{
			}
			while (i < absoluteUri.Length && absoluteUri[i] == ';')
			{
				for (i++; i < absoluteUri.Length && absoluteUri[i] <= ' '; i++)
				{
				}
				length = i;
				for (; i < absoluteUri.Length && absoluteUri[i] != ',' && absoluteUri[i] != ';'; i++)
				{
				}
				int num = i;
				while (length < num && absoluteUri[num - 1] <= ' ')
				{
					num--;
				}
				if (absoluteUri.Substring(length, num - length).ToLower() == "base64")
				{
					flag = true;
				}
			}
			if (i < absoluteUri.Length && absoluteUri[i] == ',')
			{
				i++;
				if (flag)
				{
					return new MemoryStream(Convert.FromBase64String(absoluteUri.Substring(i)));
				}
				return new MemoryStream(HttpUtility.UrlDecodeToBytes(absoluteUri.Substring(i)));
			}
		}
		try
		{
			return xmlUrlResolver_0.GetEntity(new Uri(absoluteUri), "", typeof(Stream)) as Stream;
		}
		catch (NotSupportedException)
		{
			return null;
		}
	}
}
