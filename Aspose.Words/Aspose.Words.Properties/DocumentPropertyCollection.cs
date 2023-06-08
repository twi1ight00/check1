using System.Collections;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Properties;

[JavaGenericArguments("Iterable<DocumentProperty>")]
public abstract class DocumentPropertyCollection : IEnumerable
{
	private readonly xd345c73dd1b16b74 x82b70567a5f68f41 = new xd345c73dd1b16b74(isCaseSensitive: false);

	public int Count => x82b70567a5f68f41.Count;

	public virtual DocumentProperty this[string name]
	{
		get
		{
			x0d299f323d241756.x48501aec8e48c869(name, "name");
			return (DocumentProperty)x82b70567a5f68f41[name];
		}
	}

	public DocumentProperty this[int index] => (DocumentProperty)x82b70567a5f68f41.GetByIndex(index);

	internal DocumentPropertyCollection()
	{
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetValueList().GetEnumerator();
	}

	internal DocumentProperty x1cd8943d02c5342f(string xc15bd84e01929885, object xbcea506a33cf9111)
	{
		x0d299f323d241756.x48501aec8e48c869(xc15bd84e01929885, "name");
		x0d299f323d241756.x0aaaea7864a53f26(xbcea506a33cf9111, "value");
		DocumentProperty documentProperty = (DocumentProperty)x82b70567a5f68f41[xc15bd84e01929885];
		if (documentProperty == null)
		{
			return xd6b6ed77479ef68c(xc15bd84e01929885, xbcea506a33cf9111);
		}
		return documentProperty;
	}

	internal DocumentProperty xd6b6ed77479ef68c(string xc15bd84e01929885, object xbcea506a33cf9111)
	{
		x0d299f323d241756.x48501aec8e48c869(xc15bd84e01929885, "name");
		x0d299f323d241756.x0aaaea7864a53f26(xbcea506a33cf9111, "value");
		DocumentProperty documentProperty = new DocumentProperty(xc15bd84e01929885, xbcea506a33cf9111);
		x82b70567a5f68f41.Add(xc15bd84e01929885, documentProperty);
		return documentProperty;
	}

	public bool Contains(string name)
	{
		return x82b70567a5f68f41.Contains(name);
	}

	public int IndexOf(string name)
	{
		return x82b70567a5f68f41.IndexOfKey(name);
	}

	public void Remove(string name)
	{
		x0d299f323d241756.x48501aec8e48c869(name, "name");
		x82b70567a5f68f41.Remove(name);
	}

	public void RemoveAt(int index)
	{
		x82b70567a5f68f41.RemoveAt(index);
	}

	public void Clear()
	{
		x82b70567a5f68f41.Clear();
	}

	internal DocumentPropertyCollection x8b61531c8ea35b85()
	{
		DocumentPropertyCollection documentPropertyCollection = xebcf83b00134300b();
		foreach (DictionaryEntry item in x82b70567a5f68f41)
		{
			DocumentProperty documentProperty = (DocumentProperty)item.Value;
			documentPropertyCollection.x82b70567a5f68f41.Add(item.Key, documentProperty.x8b61531c8ea35b85());
		}
		return documentPropertyCollection;
	}

	internal abstract DocumentPropertyCollection xebcf83b00134300b();
}
