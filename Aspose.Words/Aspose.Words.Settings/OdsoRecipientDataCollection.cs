using System.Collections;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Settings;

[JavaGenericArguments("Iterable<OdsoRecipientData>")]
public class OdsoRecipientDataCollection : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	public int Count => x82b70567a5f68f41.Count;

	public OdsoRecipientData this[int index]
	{
		get
		{
			return (OdsoRecipientData)x82b70567a5f68f41[index];
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x82b70567a5f68f41[index] = value;
		}
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	public int Add(OdsoRecipientData value)
	{
		x0d299f323d241756.x0aaaea7864a53f26(value, "value");
		return x82b70567a5f68f41.Add(value);
	}

	public void Clear()
	{
		x82b70567a5f68f41.Clear();
	}

	public void RemoveAt(int index)
	{
		x82b70567a5f68f41.RemoveAt(index);
	}
}
