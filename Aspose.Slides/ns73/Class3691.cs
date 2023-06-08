using System.Collections;
using System.Collections.Generic;
using System.Text;
using ns305;

namespace ns73;

internal class Class3691 : Class3679, IEnumerable, IEnumerable<Class3679>, Interface62
{
	private const char char_0 = ' ';

	private List<Class3679> list_0;

	public override string CSSText
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (Length > 0)
			{
				stringBuilder.Append(this[0].CSSText);
			}
			for (int i = 1; i < Length; i++)
			{
				stringBuilder.Append(' ');
				stringBuilder.Append(list_0[i].CSSText);
			}
			return stringBuilder.ToString();
		}
		set
		{
			throw new Exception73(Enum968.const_14);
		}
	}

	public int Length => list_0.Count;

	public Class3679 this[int index] => list_0[index];

	public Class3691()
		: base(2)
	{
		list_0 = new List<Class3679>();
	}

	public Class3691(IList<Class3679> values)
		: base(2)
	{
		list_0 = new List<Class3679>(values);
	}

	public Class3691(params Class3679[] values)
		: base(2)
	{
		list_0 = new List<Class3679>(values);
	}

	internal void Add(Class3679 value)
	{
		list_0.Add(value);
	}

	public IEnumerator<Class3679> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
