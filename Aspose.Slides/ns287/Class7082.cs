using System;
using System.Collections;
using System.Collections.Generic;
using ns305;

namespace ns287;

internal class Class7082 : Class7078
{
	private class Class6775 : IDisposable, IEnumerator, IEnumerator<Class6976>
	{
		private IEnumerator<Class7038> ienumerator_0;

		public Class6976 Current => ienumerator_0.Current;

		object IEnumerator.Current => Current;

		public Class6775(List<Class7038> rows)
		{
			ienumerator_0 = rows.GetEnumerator();
		}

		public void Dispose()
		{
			ienumerator_0.Dispose();
		}

		public bool MoveNext()
		{
			return ienumerator_0.MoveNext();
		}

		public void Reset()
		{
			ienumerator_0.Reset();
		}
	}

	private List<Class7038> list_0;

	public override int Length => list_0.Count;

	public override Class6976 this[int index] => list_0[index];

	public Class7082(Class7040 row)
	{
		list_0 = new List<Class7038>();
		for (Class6981 @class = row.FirstElementChild; @class != null; @class = @class.NextElementSibling)
		{
			if (@class is Class7038 item)
			{
				list_0.Add(item);
			}
		}
	}

	public override IEnumerator<Class6976> GetEnumerator()
	{
		return new Class6775(list_0);
	}

	public override Class6976 vmethod_0(string name)
	{
		foreach (Class7038 item in list_0)
		{
			string text = item.method_20("ID");
			if (text != null && text.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return item;
			}
		}
		foreach (Class7038 item2 in list_0)
		{
			string text2 = item2.method_20("NAME");
			if (text2 != null && text2.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return item2;
			}
		}
		return null;
	}
}
