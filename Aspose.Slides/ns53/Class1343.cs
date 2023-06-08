using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ns276;
using ns33;

namespace ns53;

internal class Class1343 : XmlUrlResolver
{
	private Dictionary<string, byte[]> dictionary_0 = new Dictionary<string, byte[]>();

	private static Uri uri_0 = new Uri("http://zip/");

	public Class1343(Class6752 zipFile, bool emulateHttp)
	{
		IEnumerator enumerator = zipFile.method_75();
		while (enumerator.MoveNext())
		{
			Class6751 @class = (Class6751)enumerator.Current;
			if (@class.IsDirectory)
			{
				continue;
			}
			byte[] array = new byte[@class.UncompressedSize];
			using (Stream stream = @class.method_19())
			{
				int num;
				for (int i = 0; i < array.Length; i += num)
				{
					num = stream.Read(array, i, array.Length - i);
					if (num == 0)
					{
						break;
					}
				}
			}
			if (emulateHttp && @class.FileName.StartsWith("http"))
			{
				Add("http://" + @class.FileName.Substring(5), array);
			}
			else
			{
				Add("http://zip/" + @class.FileName, array);
			}
			@class.FileName.IndexOf('/');
		}
	}

	public Class1343(SortedDictionary<string, byte[]> unpacked)
	{
		dictionary_0 = new Dictionary<string, byte[]>(unpacked);
	}

	private void Add(string publicIdentifier, byte[] buffer)
	{
		dictionary_0.Add(publicIdentifier, buffer);
	}

	public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
	{
		if (absoluteUri != null && dictionary_0.ContainsKey(absoluteUri.AbsoluteUri))
		{
			try
			{
				return new MemoryStream(dictionary_0[absoluteUri.AbsoluteUri], writable: false);
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
			}
			return null;
		}
		return null;
	}
}
