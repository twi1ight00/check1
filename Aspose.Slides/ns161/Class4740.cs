using System.Collections;
using System.IO;
using ns235;
using ns237;

namespace ns161;

internal class Class4740 : CollectionBase, IEnumerable, IEnumerator
{
	private IEnumerator ienumerator_0;

	public Class6216 this[int index]
	{
		get
		{
			return (Class6216)base.List[index];
		}
		set
		{
			base.List[index] = value;
		}
	}

	object IEnumerator.Current => ienumerator_0.Current;

	internal int Add(Class6216 newPage)
	{
		return base.List.Add(newPage);
	}

	public void method_0(string fileName)
	{
		using Stream stream = File.Create(fileName);
		Class6680 options = new Class6680();
		Class6197 @class = new Class6197(stream, options);
		for (int i = 0; i < base.Count; i++)
		{
			@class.method_0(this[i]);
		}
		@class.method_1();
	}

	void IEnumerator.Reset()
	{
		ienumerator_0.Reset();
	}

	bool IEnumerator.MoveNext()
	{
		return ienumerator_0.MoveNext();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		ienumerator_0 = base.List.GetEnumerator();
		ienumerator_0.Reset();
		return ienumerator_0;
	}
}
