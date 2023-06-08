using System.Collections;

namespace Aspose.Words.Markup;

[JavaGenericArguments("Iterable<CustomPart>")]
public class CustomPartCollection : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	public int Count => x82b70567a5f68f41.Count;

	public CustomPart this[int index]
	{
		get
		{
			return (CustomPart)x82b70567a5f68f41[index];
		}
		set
		{
			x82b70567a5f68f41[index] = value;
		}
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	public void Add(CustomPart part)
	{
		x82b70567a5f68f41.Add(part);
	}

	public void RemoveAt(int index)
	{
		x82b70567a5f68f41.RemoveAt(index);
	}

	public void Clear()
	{
		x82b70567a5f68f41.Clear();
	}

	public CustomPartCollection Clone()
	{
		CustomPartCollection customPartCollection = new CustomPartCollection();
		foreach (CustomPart item in x82b70567a5f68f41)
		{
			customPartCollection.Add(item.Clone());
		}
		return customPartCollection;
	}
}
