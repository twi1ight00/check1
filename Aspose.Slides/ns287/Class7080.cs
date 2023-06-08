using System;
using System.Collections;
using System.Collections.Generic;
using ns305;

namespace ns287;

internal class Class7080 : Class7078
{
	private class Class6774 : IDisposable, IEnumerator, IEnumerator<Class6976>
	{
		private IEnumerator<Class7041> ienumerator_0;

		public Class6976 Current => ienumerator_0.Current;

		object IEnumerator.Current => Current;

		public Class6774(List<Class7041> sections)
		{
			ienumerator_0 = sections.GetEnumerator();
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

	private List<Class7041> list_0;

	public override int Length => list_0.Count;

	public override Class6976 this[int index] => list_0[index];

	public Class7080(Class6993 table, string sectionName)
	{
		list_0 = new List<Class7041>();
		for (Class6981 @class = table.FirstElementChild; @class != null; @class = @class.NextElementSibling)
		{
			if (@class.TagName == sectionName)
			{
				list_0.Add((Class7041)@class);
			}
		}
	}

	public override IEnumerator<Class6976> GetEnumerator()
	{
		return new Class6774(list_0);
	}

	public override Class6976 vmethod_0(string name)
	{
		foreach (Class7041 item in list_0)
		{
			string text = item.method_20("ID");
			if (text != null && text.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return item;
			}
		}
		foreach (Class7041 item2 in list_0)
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
