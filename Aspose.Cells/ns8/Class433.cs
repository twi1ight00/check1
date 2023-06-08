using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns8;

internal class Class433 : IStreamProvider
{
	private Hashtable hashtable_0;

	public Stream GetStream(ref string origPath, string parsedPath)
	{
		return method_2(origPath);
	}

	public void Close(string origPath, Stream stream)
	{
	}

	[SpecialName]
	public void method_0(Hashtable hashtable_1)
	{
		hashtable_0 = hashtable_1;
	}

	[SpecialName]
	public Hashtable method_1()
	{
		return hashtable_0;
	}

	private Stream method_2(string string_0)
	{
		IDictionaryEnumerator enumerator = hashtable_0.GetEnumerator();
		do
		{
			if (!enumerator.MoveNext())
			{
				return null;
			}
		}
		while (!((string)enumerator.Key).EndsWith(string_0));
		if (enumerator.Value is Stream)
		{
			return (Stream)enumerator.Value;
		}
		return ((Class438)enumerator.Value).stream_0;
	}
}
