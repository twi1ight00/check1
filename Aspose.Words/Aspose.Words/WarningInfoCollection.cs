using System.Collections;

namespace Aspose.Words;

[JavaGenericArguments("Iterable<WarningInfo>")]
public class WarningInfoCollection : IWarningCallback, IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	public int Count => x82b70567a5f68f41.Count;

	public WarningInfo this[int index] => (WarningInfo)x82b70567a5f68f41[index];

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	public void Clear()
	{
		x82b70567a5f68f41.Clear();
	}

	public void Warning(WarningInfo info)
	{
		x82b70567a5f68f41.Add(info);
	}
}
