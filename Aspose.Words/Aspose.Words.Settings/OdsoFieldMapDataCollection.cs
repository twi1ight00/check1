using System;
using System.Collections;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;
using xda075892eccab2ad;

namespace Aspose.Words.Settings;

[JavaGenericArguments("Iterable<OdsoFieldMapData>")]
public class OdsoFieldMapDataCollection : IEnumerable
{
	internal const int x8ac88818c8bfa88b = 30;

	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	public int Count => x82b70567a5f68f41.Count;

	public OdsoFieldMapData this[int index]
	{
		get
		{
			return (OdsoFieldMapData)x82b70567a5f68f41[index];
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

	public int Add(OdsoFieldMapData value)
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

	internal void xb37a1dde21a93661()
	{
		if (Count == 0)
		{
			return;
		}
		OdsoFieldMapData[] array = new OdsoFieldMapData[30];
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				OdsoFieldMapData odsoFieldMapData = (OdsoFieldMapData)enumerator.Current;
				if (odsoFieldMapData.Type != OdsoFieldMappingType.Null)
				{
					x7108b36f9eb19d89 x7108b36f9eb19d = xca039bdabeb3e5dc.x7fd761f12621f24c(odsoFieldMapData.MappedName);
					if (x7108b36f9eb19d != x7108b36f9eb19d89.xcde3a31c5a88fc93)
					{
						array[(int)x7108b36f9eb19d] = odsoFieldMapData;
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == null)
			{
				array[i] = new OdsoFieldMapData();
			}
		}
		Clear();
		OdsoFieldMapData[] array2 = array;
		foreach (OdsoFieldMapData value in array2)
		{
			Add(value);
		}
	}
}
