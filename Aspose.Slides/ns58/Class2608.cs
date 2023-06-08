using System;
using System.Collections;
using System.IO;
using System.Xml;
using ns276;
using ns33;

namespace ns58;

internal class Class2608 : XmlUrlResolver
{
	private Hashtable hashtable_0 = new Hashtable();

	private static Uri uri_0 = new Uri("http://zip/");

	public Class2608(Class6752 zipFile, bool emulateHttp)
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

	public Class2608(IDictionary unpacked)
	{
		hashtable_0 = new Hashtable(unpacked);
	}

	private void Add(string publicIdentifier, byte[] buffer)
	{
		hashtable_0.Add(publicIdentifier, buffer);
	}

	public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
	{
		if (absoluteUri != null && hashtable_0.ContainsKey(absoluteUri.AbsoluteUri))
		{
			try
			{
				return new MemoryStream((byte[])hashtable_0[absoluteUri.AbsoluteUri], writable: false);
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
			}
		}
		return null;
	}
}
