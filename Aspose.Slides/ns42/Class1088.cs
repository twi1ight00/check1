using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ns276;
using ns33;

namespace ns42;

internal class Class1088 : XmlUrlResolver
{
	private SortedList<string, byte[]> sortedList_0 = new SortedList<string, byte[]>();

	private static Uri uri_0 = new Uri("http://zip/");

	public Class1088(Class6752 zipFile, bool emulateHttp)
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

	public Class1088(SortedList<string, byte[]> unpacked)
	{
		sortedList_0 = new SortedList<string, byte[]>(unpacked);
	}

	private void Add(string publicIdentifier, byte[] buffer)
	{
		sortedList_0.Add(publicIdentifier, buffer);
	}

	public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
	{
		if (absoluteUri != null && sortedList_0.ContainsKey(absoluteUri.AbsoluteUri))
		{
			try
			{
				return new MemoryStream(sortedList_0[absoluteUri.AbsoluteUri], writable: false);
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
