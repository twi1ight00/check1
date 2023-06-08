using System;
using System.Collections;

namespace Aspose.Words;

[JavaGenericArguments("Iterable<DigitalSignature>")]
public class DigitalSignatureCollection : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	private readonly Hashtable x652713cc0be7d0d4 = new Hashtable();

	public bool IsValid
	{
		get
		{
			foreach (DigitalSignature item in x82b70567a5f68f41)
			{
				if (!item.IsValid)
				{
					return false;
				}
			}
			return true;
		}
	}

	public int Count => x82b70567a5f68f41.Count;

	public DigitalSignature this[int index] => (DigitalSignature)x82b70567a5f68f41[index];

	internal void xd6b6ed77479ef68c(DigitalSignature x8ebde9a98df80374)
	{
		x82b70567a5f68f41.Add(x8ebde9a98df80374);
		if (x8ebde9a98df80374.x5c9e4e2dc9b12067)
		{
			x652713cc0be7d0d4.Add(x8ebde9a98df80374.x7c739bac7cd13266, x8ebde9a98df80374);
		}
	}

	internal DigitalSignature xc2f05c6730cd9522(string xa3e05cfe4f84ce8d)
	{
		return (DigitalSignature)x652713cc0be7d0d4[new Guid(xa3e05cfe4f84ce8d)];
	}

	[JavaGenericArguments("Iterator<DigitalSignature>")]
	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}
}
